using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iBroker.DAL;
using iBroker.Entities;

namespace iBroker.Forms.Admin
{
    public partial class UserManagment : Form
    {
        private UserDAL userDAL;
        DataTable users;
        public UserManagment()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserManagment_Load(object sender, EventArgs e)
        {
            userDAL = new UserDAL();
            DataTable roles = userDAL.Roles();
            cmbRole.DataSource = roles;
            cmbRole.DisplayMember = "role";
            cmbRole.ValueMember = "id";
            cmbRole.SelectedValue = 2;
            users = userDAL.GetAllUsers();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = users;
            dgvUsers.DataSource = bSource;
            //if (users.Rows.Count == 0) {
            //    dgvUsers.Columns.Add("Id", "Sr.No.");
            //    dgvUsers.Columns.Add("firstname", "First Name");
            //    dgvUsers.Columns.Add("lastname", "Last Name");
            //    dgvUsers.Columns.Add("phoneNo1", "PhoneNo1");
            //    dgvUsers.Columns.Add("phoneNo2", "PhoneNo2");
            //    dgvUsers.Columns.Add("email", "Email");
            //    dgvUsers.Columns.Add("role", "Role");
            //    dgvUsers.Columns.Add("password", "Password");
            //}
            //else
            //{
            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns["Id"].HeaderText = "Sr.No.";
                dgvUsers.Columns["Id"].Visible = false;
                dgvUsers.Columns["firstname"].HeaderText = "First Name";
                dgvUsers.Columns["lastname"].HeaderText = "Last Name";
                dgvUsers.Columns["phoneNo1"].HeaderText = "PhoneNo1";
                dgvUsers.Columns["phoneNo2"].HeaderText = "PhoneNo2";
                dgvUsers.Columns["phoneNo2"].DisplayIndex = 4;
                dgvUsers.Columns["email"].HeaderText = "Email";
                dgvUsers.Columns["role"].HeaderText = "Role";
                dgvUsers.Columns["password"].HeaderText = "Password";
            }
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFirstName.Text.Trim()) && string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                MessageBox.Show("First and Last name can not be blank.", "User Managment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPhoneNo1.Text.Length > 10 || txtPhoneNo1.Text.Length < 10)
            {
                MessageBox.Show("Invalid phone no1, Please enter 10 digit phone no", "User Managment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPhoneNo2.Text.Length > 0 && (txtPhoneNo2.Text.Length > 10 || txtPhoneNo2.Text.Length < 10))
            {
                MessageBox.Show("Invalid phone no2, Please enter 10 digit phone no", "User Managment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            User user = new User();
            try
            {
                user.FirstName = txtFirstName.Text;
                user.LastName = txtLastName.Text;
                user.PhoneNo1 = txtPhoneNo1.Text;
                user.PhoneNo2 = txtPhoneNo2.Text;
                user.Email = txtEmail.Text;
                user.RoleId = Convert.ToInt32(cmbRole.SelectedValue);
                user.Password = txtPassword.Text;
                user.Id = txtUserId.Text == "" ? 0 : Convert.ToInt32(txtUserId.Text);

                if (user.Id == 0)
                {
                    userDAL.Insert(user);
                }
                else
                {
                    userDAL.Update(user);
                }

                users = userDAL.GetAllUsers();
                BindingSource bSource = new BindingSource();
                bSource.DataSource = users;
                dgvUsers.DataSource = bSource;

                MessageBox.Show("User updated successfully.", "User Managment", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtPhoneNo1.Text = "";
                txtPhoneNo2.Text = "";
                txtEmail.Text = "";
                cmbRole.SelectedValue = 2;
                txtPassword.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Error in updating User.", "User Managment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = cmbRole.SelectedValue.ToString();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            string userRole = string.Empty;
            if (dgvUsers.SelectedRows.Count > 0)
            {
                txtUserId.Text = dgvUsers.SelectedRows[0].Cells["id"].Value.ToString();
                txtFirstName.Text = dgvUsers.SelectedRows[0].Cells["firstname"].Value.ToString();
                txtLastName.Text = dgvUsers.SelectedRows[0].Cells["lastname"].Value.ToString();
                txtPhoneNo1.Text = dgvUsers.SelectedRows[0].Cells["phoneno1"].Value.ToString();
                txtPhoneNo2.Text = dgvUsers.SelectedRows[0].Cells["phoneno2"].Value.ToString();
                txtEmail.Text = dgvUsers.SelectedRows[0].Cells["email"].Value.ToString();
                txtPassword.Text = dgvUsers.SelectedRows[0].Cells["password"].Value.ToString();
                //cmbRole.select = users.Rows[rowIndex]["role"].ToString();
                if(dgvUsers.SelectedRows[0].Cells["role"].Value == null || dgvUsers.SelectedRows[0].Cells["role"].Value is DBNull)
                {
                    userRole = "BusinessUser";
                }
                else
                {
                    userRole = dgvUsers.SelectedRows[0].Cells["role"].Value.ToString();
                }
                cmbRole.SelectedValue = (int)Enum.Parse(typeof(Roles), userRole);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhoneNo1.Text = "";
            txtPhoneNo2.Text = "";
            txtEmail.Text = "";
            cmbRole.SelectedValue = 2;
            txtPassword.Text = "";
            txtUserId.Text = "";
        }

        private void dgvUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSerial(dgvUsers);
        }

        private void LoadSerial(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[row.Index].HeaderCell.Value = string.Format("{0}  ", row.Index + 1).ToString();
                row.Height = 25;
            }
        }

        private void txtPhoneNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhoneNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
