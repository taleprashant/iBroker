using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBroker.Forms.Leads
{
    public partial class FollowUpReminder : Form
    {
        private DataTable followUpReminderTable;
        public FollowUpReminder(DataTable followUpReminderTable)
        {
            this.followUpReminderTable = followUpReminderTable;
            InitializeComponent();
        }

        private void FollowUpReminder_Load(object sender, EventArgs e)
        {
            //lblTodayDate.Text = "abc";
            lblTodayDate.Text = DateTime.Now.ToString("dd'/'MM'/'yyyy");
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.followUpReminderTable;
            dgvFollowUpReminder.DataSource = bSource;

            dgvFollowUpReminder.Columns["Id"].Visible = false;
            dgvFollowUpReminder.Columns["LeadId"].Visible = false;
            dgvFollowUpReminder.Columns["LastName"].Visible = false;
            dgvFollowUpReminder.Columns["Date"].DisplayIndex = 0;
            dgvFollowUpReminder.Columns["FirstName"].DisplayIndex = 1;
            dgvFollowUpReminder.Columns["PhoneNo1"].DisplayIndex = 2;
            dgvFollowUpReminder.Columns["TransactionType"].DisplayIndex = 3;
            dgvFollowUpReminder.Columns["PropertyType"].DisplayIndex = 3;
        }
    }
}
