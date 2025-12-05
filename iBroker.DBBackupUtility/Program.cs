using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace iBroker.DBBackupUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            //Client ID - 12229347852-4dife8a09mai5ta3mabuprllj20hj0tc.apps.googleusercontent.com
            //Client Secret - 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

            //{"installed":{"client_id":"12229347852-4dife8a09mai5ta3mabuprllj20hj0tc.apps.googleusercontent.com","project_id":"ibrokerdbbackupuploader","auth_uri":"https://accounts.google.com/o/oauth2/auth","token_uri":"https://oauth2.googleapis.com/token","auth_provider_x509_cert_url":"https://www.googleapis.com/oauth2/v1/certs","client_secret":"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","redirect_uris":["urn:ietf:wg:oauth:2.0:oob","http://localhost"]}}


            //Scopes for use with the Google Drive API
            string[] scopes = new string[] { DriveService.Scope.Drive,
                                 DriveService.Scope.DriveFile};
            var clientId = "12229347852-4dife8a09mai5ta3mabuprllj20hj0tc.apps.googleusercontent.com";      // From https://console.developers.google.com
            var clientSecret = "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";          // From https://console.developers.google.com
                                               // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                                                                            {
                                                                                ClientId = clientId,
                                                                                ClientSecret = clientSecret
                                                                            },
                                                                        scopes,
                                                                        Environment.UserName,
                                                                        CancellationToken.None,
                                                                        new FileDataStore("MyAppsToken")).Result;

            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "iBroker",
            });
            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);

            File dir = createDirectory(service, "iBrokerDBBackup", "iBroker DB Backup", "root");
            if (dir != null)
            {
                File file = UploadFile(service, args[0], dir.Id);
            }
        }

        // tries to figure out the mime type of the file.
        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        /// 

        /// Uploads a file
        /// Documentation: https://developers.google.com/drive/v2/reference/files/insert
        /// 

        /// a Valid authenticated DriveService
        /// path to the file to upload
        /// Collection of parent folders which contain this file. 
        ///                       Setting this field will put the file in all of the provided folders. root folder.
        /// If upload succeeded returns the File resource of the uploaded file 
        ///          If the upload fails returns null
        public static File UploadFile(DriveService _service, string _uploadFile, string _parent)
        {

            if (System.IO.File.Exists(_uploadFile))
            {
                File body = new File();
                body.Title = System.IO.Path.GetFileName(_uploadFile);
                body.Description = "iBroker Database backup file";
                body.MimeType = GetMimeType(_uploadFile);
                body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };

                // File's content.
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.InsertMediaUpload request = _service.Files.Insert(body, stream, GetMimeType(_uploadFile));
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("File does not exist: " + _uploadFile);
                return null;
            }

        }

        //// 

        /// Create a new Directory.
        /// Documentation: https://developers.google.com/drive/v2/reference/files/insert
        /// 

        /// a Valid authenticated DriveService
        /// The title of the file. Used to identify file or folder name.
        /// A short description of the file.
        /// Collection of parent folders which contain this file. 
        ///                       Setting this field will put the file in all of the provided folders. root folder.
        /// 
        public static File createDirectory(DriveService _service, string _title, string _description, string _parent)
        {
            FilesResource.ListRequest listRequest = _service.Files.List();
            //listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";
            listRequest.Q = "mimeType='application/vnd.google-apps.folder'";
            listRequest.Spaces = "drive";
            listRequest.Fields = "nextPageToken, items(id, title)";
            listRequest.PageToken = null;

            // List files.
            IList<Google.Apis.Drive.v2.Data.File> files = listRequest.Execute().Items;

            foreach (File item in files)
            {
                if(item.Title == _title)
                {
                    return item;
                }
            }

            File NewDirectory = null;

            // Create metaData for a new Directory
            File body = new File();
            body.Title = _title;
            body.Description = _description;
            body.MimeType = "application/vnd.google-apps.folder";
            body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };
            try
            {
                FilesResource.InsertRequest request = _service.Files.Insert(body);
                NewDirectory = request.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return NewDirectory;
        }
    }
}
