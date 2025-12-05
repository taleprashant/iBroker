using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBroker.Forms.Admin
{
    public partial class DatabaseBackup : Form
    {
        public DatabaseBackup()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdBackupFileLocation.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBackupFileLocation.Text = fbdBackupFileLocation.SelectedPath + "\\iBroker_Database_Backup.txt";
                Environment.SpecialFolder root = fbdBackupFileLocation.RootFolder;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerateBackup_Click(object sender, EventArgs e)
        {
            //"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump" -u root -pAdmin123 ibrokerdb > %DATE%_fulldatabasebackup.txt
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            //startInfo.WorkingDirectory = @"E:\PSP\Clients\JJProperties\SourceCode\iBroker\iBroker.DBBackupUtility\bin\Debug";
            //startInfo.FileName = "C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin\\mysqldump";
            //startInfo.UseShellExecute = false;
            //startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = false;
            //startInfo.Verb = "runas";
            //startInfo.Arguments = "/c start -u root -pAdmin123 ibrokerdb > fulldatabasebackup.txt";
            //process.StartInfo = startInfo;
            ////process.admi
            //var cmd = process.Start();
            ////cmd.WaitForExit();

            //System.Diagnostics.Process.Start(@"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe", 
                //"C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin\\mysqldump - u root - pAdmin123 ibrokerdb > fulldatabasebackup.txt").WaitForExit();
        }
    }
}