using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using iBroker.DAL;
using iBroker.Entities;
using Tulpep.NotificationWindow;
using System.Configuration;
using iBroker.Properties;

namespace iBroker.Forms
{
    public partial class Home : Form
    {
        private int childFormNumber = 0;
        public bool userAuthenticated = false;
        public int loggedInUserRoleId = 0;
        private UserDAL userDAL;

        public Home()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Leads.EditLead();
            childForm.MdiParent = this;
            childForm.Text = "Lead";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            Form childForm = new Leads.LeadGrid();
            childForm.MdiParent = this;
            childForm.Text = "Leads";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            menuStrip.Enabled = false;
            toolStrip.Enabled = false;
            administrationToolStripMenuItem.Visible = false;

            grpbLogin.Top = (this.Height - grpbLogin.Height) / 2;
            grpbLogin.Left = (this.Width - grpbLogin.Width)/ 2;

            cbRememberMe.Checked = true;
            toolStripLblUserName.Text = "";
            if (!string.IsNullOrEmpty(Settings.Default.PhoneNo))
            {
                txtPhoneNo.Text = Settings.Default.PhoneNo;
            }

        }

        private void todayFollowUp_Click(object sender, EventArgs e)
        {
            string todayDate = DateTime.Now.ToString("dd'/'MM'/'yyyy");
            DataTable todayFollowUp;
            using (LeadFollowUpDAL objDAL = new LeadFollowUpDAL())
            {
                todayFollowUp = objDAL.GetLeadFollowUps(todayDate);
            }

            Form childForm = new Leads.FollowUpReminder(todayFollowUp);
            childForm.MdiParent = this;
            childForm.Text = "Leads";
            childForm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form childForm = new Properties.EditProperty();
            childForm.MdiParent = this;
            childForm.Text = "Property";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form childForm = new Properties.PropertySearch();
            childForm.MdiParent = this;
            childForm.Text = "Property Search";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.userAuthenticated = false;
            string phoneNo = txtPhoneNo.Text;
            string password = txtPassword.Text;
            if(string.IsNullOrEmpty(phoneNo.Trim()) || string.IsNullOrEmpty(password.Trim()))
            {
                MessageBox.Show("Please enter PhoneNo and Password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            User loggedInUser = null;
            userDAL = new UserDAL();
            User user = new User();
            user.PhoneNo1 = phoneNo;
            if(userDAL.UserExists(user))
            {
                loggedInUser = userDAL.ValidateUser(phoneNo, password);
                if (loggedInUser == null)
                {
                    this.userAuthenticated = false;
                    MessageBox.Show("Invalid password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.userAuthenticated = true;
                    toolStripLblUserName.Text = "Current User - " + loggedInUser.FirstName + " " + loggedInUser.LastName;
                    toolStripLblUserName.Text = toolStripLblUserName.Text + " | Phone No - " + (string.IsNullOrEmpty(loggedInUser.PhoneNo1) ? loggedInUser.PhoneNo2 : loggedInUser.PhoneNo1);
                }
            }
            else
            {
                this.userAuthenticated = false;
                MessageBox.Show("Invalid phone no", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this.userAuthenticated)
            {
                if (cbRememberMe.Checked)
                {
                    Settings.Default["PhoneNo"] = txtPhoneNo.Text;
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default["PhoneNo"] = string.Empty;
                    Settings.Default.Save();
                }

                txtPassword.Text = "";
                txtPhoneNo.Text = "";
                grpbLogin.Visible = false;
                menuStrip.Enabled = true;
                toolStrip.Enabled = true;
                this.loggedInUserRoleId = loggedInUser.RoleId;
                if (this.loggedInUserRoleId == (int)Enum.Parse(typeof(Roles), Roles.Administrator.ToString()))
                {
                    administrationToolStripMenuItem.Visible = true;
                }
                else
                {
                    administrationToolStripMenuItem.Visible = false;
                }

                string todayDate = DateTime.Now.ToString("dd'/'MM'/'yyyy");
                DataTable todayFollowUp;
                using (LeadFollowUpDAL objDAL = new LeadFollowUpDAL())
                {
                    todayFollowUp = objDAL.GetLeadFollowUps(todayDate);
                }

                if (todayFollowUp != null && todayFollowUp.Rows.Count > 0)
                {
                    PopupNotifier notifier = new PopupNotifier();
                    notifier.TitleText = "Today's Follow up - " + DateTime.Now.ToString("dd/MMM/yyyy");
                    notifier.Image = SystemIcons.Asterisk.ToBitmap();
                    string content = "";
                    foreach (DataRow row in todayFollowUp.Rows)
                    {
                        content = content + row["FirstName"] + " | " + row["TransactionType"] + " | " + row["PhoneNo1"] + Environment.NewLine;
                    }

                    notifier.ContentText = content;
                    notifier.TitleFont = new Font("", 10);
                    notifier.TitleColor = Color.Black;
                    notifier.ContentColor = Color.Red;
                    notifier.ContentFont = new Font("", 10);
                    notifier.Popup();
                }

                Form childForm = new Leads.LeadGrid();
                childForm.MdiParent = this;
                childForm.Text = "Leads";
                childForm.Show();
                childForm.WindowState = FormWindowState.Maximized;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            if (!string.IsNullOrEmpty(Settings.Default.PhoneNo))
            {
                txtPhoneNo.Text = Settings.Default.PhoneNo;
            }
            grpbLogin.Visible = true;
            toolStripLblUserName.Text = "";
            menuStrip.Enabled = false;
            toolStrip.Enabled = false;
        }

        private void mastersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Admin.Masters();
            childForm.MdiParent = this;
            childForm.Text = "Masters";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void userManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Admin.UserManagment();
            childForm.MdiParent = this;
            childForm.Text = "User Managment";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form childForm = new Lease.EditLease();
            childForm.MdiParent = this;
            childForm.Text = "Lease and Agreements";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form childForm = new Lease.LeaseSearch();
            childForm.MdiParent = this;
            childForm.Text = "Lease Search";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void endingInAMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Lease.LeaseEnding();
            childForm.MdiParent = this;
            childForm.Text = "Lease Ending";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Admin.DatabaseBackup();
            childForm.MdiParent = this;
            childForm.Text = "Database Backup";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form childForm = new BuilderProject.EditProject();
            childForm.MdiParent = this;
            childForm.Text = "Builder Project";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form childForm = new BuilderProject.ProjectSearch();
            childForm.MdiParent = this;
            childForm.Text = "Builder Project";
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }
    }
}
