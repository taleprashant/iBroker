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

namespace iBroker.Forms.Lease
{
    public partial class LeaseEnding : Form
    {
        private LeaseDAL leaseDAL;

        public LeaseEnding()
        {
            InitializeComponent();
        }

        private void LeaseEnding_Load(object sender, EventArgs e)
        {
            lblFrom.Text = "From " + DateTime.Now.ToString("dd'/'MM'/'yyyy") + " To " + DateTime.Now.AddMonths(1).ToString("dd'/'MM'/'yyyy");
            Entities.LeaseSearch leaseSearch = new Entities.LeaseSearch();
            leaseSearch.Active = true;
            leaseSearch.LeaseEndDateFrom = DateTime.Now.ToString("dd'/'MM'/'yyyy");
            leaseSearch.LeaseEndDateTo = DateTime.Now.AddMonths(1).ToString("dd'/'MM'/'yyyy");

            BindingSource bSource = new BindingSource();
            leaseDAL = new LeaseDAL();
            DataTable lease = leaseDAL.GetLease(leaseSearch);
            bSource.DataSource = lease;
            int leaseCount = lease != null ? lease.Rows.Count : 0;
            dgvLease.DataSource = bSource;
            adjustColumnOrder();
        }

        private void adjustColumnOrder()
        {
            dgvLease.AutoGenerateColumns = false;
            dgvLease.Columns["id"].HeaderText = "Sr.No.";
            dgvLease.Columns["CreatedDate"].HeaderText = "RegistrationDate";
            dgvLease.Columns["CreatedDate"].DefaultCellStyle.Format = "dd'/'MM'/'yyy";

            dgvLease.Columns["id"].DisplayIndex = 0;
            dgvLease.Columns["CreatedDate"].DisplayIndex = 1;
            dgvLease.Columns["TokenNo"].DisplayIndex = 2;
            dgvLease.Columns["GRNNo"].DisplayIndex = 3;
            dgvLease.Columns["OwnerName"].DisplayIndex = 4;
            dgvLease.Columns["OwnerPhoneNo"].DisplayIndex = 5;
            dgvLease.Columns["TenantName"].DisplayIndex = 6;
            dgvLease.Columns["TenantPhoneNo"].DisplayIndex = 7;
            dgvLease.Columns["PropertyUnitNo"].DisplayIndex = 8;
            dgvLease.Columns["PropertySociety"].DisplayIndex = 9;
            dgvLease.Columns["StartDate"].DisplayIndex = 10;
            dgvLease.Columns["EndDate"].DisplayIndex = 11;
            dgvLease.Columns["Duration"].DisplayIndex = 12;
            dgvLease.Columns["Rent"].DisplayIndex = 13;
            dgvLease.Columns["OwnerEmail"].DisplayIndex = 14;
            dgvLease.Columns["OwnerPAN"].DisplayIndex = 15;
            dgvLease.Columns["OwnerAadharNo"].DisplayIndex = 16;
            dgvLease.Columns["TenantEmail"].DisplayIndex = 17;
            dgvLease.Columns["TenantPAN"].DisplayIndex = 18;
            dgvLease.Columns["TenantAadharNo"].DisplayIndex = 19;
        }
    }
}
