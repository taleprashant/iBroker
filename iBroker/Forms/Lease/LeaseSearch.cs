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
    public partial class LeaseSearch : Form
    {
        private LeaseDAL leaseDAL;
        private LocationDAL locationDAL;
        private SocietyDAL societyDAL;
        List<string> locationList;
        List<string> societyList;

        public LeaseSearch()
        {
            InitializeComponent();
        }

        private void LeaseSearch_Load(object sender, EventArgs e)
        {
            cbActive.Checked = true;
            registrationDateFrom.CustomFormat = " ";
            registrationDateTo.CustomFormat = " ";
            leaseEndDateFrom.CustomFormat = " ";
            leaseEndDateTo.CustomFormat = " ";

            registrationDateFrom.Tag = 0;
            registrationDateTo.Tag = 0;
            leaseEndDateFrom.Tag = 0;
            leaseEndDateTo.Tag = 0;

            locationDAL = new LocationDAL();
            DataTable locationData = locationDAL.GetLocations();
            locationList = locationData.AsEnumerable().Select(x => x.Field<string>("Location")).ToList();
            locationList.RemoveAll(string.IsNullOrWhiteSpace);
            lbLocations.Items.AddRange(locationList.ToArray());

            societyDAL = new SocietyDAL();
            DataTable socities = societyDAL.GetSocieties();
            societyList = socities.AsEnumerable().Select(x => x.Field<string>("SocietyName")).ToList();
            societyList.RemoveAll(string.IsNullOrWhiteSpace);
            lbSocieties.Items.AddRange(societyList.ToArray());

            BindingSource bSource = new BindingSource();
            leaseDAL = new LeaseDAL();
            DataTable lease = leaseDAL.GetLease();
            bSource.DataSource = lease;
            int leaseCount = lease != null ? lease.Rows.Count : 0;
            lblLeadCount.Text = leaseCount.ToString();
            lblSearchCount.Text = leaseCount.ToString();
            dgvLease.DataSource = bSource;
            adjustColumnOrder();
        }

        private void dgvLease_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var leaseId = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;
                Form childForm = new Lease.EditLease(Convert.ToInt32(leaseId));
                childForm.MdiParent = this.MdiParent;
                childForm.Text = "Lease";
                childForm.Show();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindingSource bSource = new BindingSource();
            leaseDAL = new LeaseDAL();
            DataTable lease = leaseDAL.GetLease();
            bSource.DataSource = lease;
            int leaseCount = lease != null ? lease.Rows.Count : 0;
            lblLeadCount.Text = leaseCount.ToString();
            lblSearchCount.Text = leaseCount.ToString();
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

        private void txtLocationSearch_TextChanged(object sender, EventArgs e)
        {
            var itemList = locationList;
            if (itemList.Count > 0)
            {
                //clear the items from the list
                lbLocations.Items.Clear();

                //filter the items and add them to the list
                if (!string.IsNullOrEmpty(txtLocationSearch.Text))
                {
                    lbLocations.Items.AddRange(
                        itemList.Where(i => i.ToLower().Contains(txtLocationSearch.Text.ToLower())).ToArray());
                }
                else
                {
                    lbLocations.Items.AddRange(itemList.ToArray());
                }
            }
        }

        private void txtSocietySearch_TextChanged(object sender, EventArgs e)
        {
            var itemList = societyList;
            if (itemList.Count > 0)
            {
                //clear the items from the list
                lbSocieties.Items.Clear();

                //filter the items and add them to the list
                if (!string.IsNullOrEmpty(txtSocietySearch.Text))
                {
                    lbSocieties.Items.AddRange(
                        itemList.Where(i => i.ToLower().Contains(txtSocietySearch.Text.ToLower())).ToArray());
                }
                else
                {
                    lbSocieties.Items.AddRange(itemList.ToArray());
                }
            }
        }

        private void btnSearchLease_Click(object sender, EventArgs e)
        {
            Entities.LeaseSearch leaseSearch = new Entities.LeaseSearch();
            leaseSearch.Active = cbActive.Checked;
            leaseSearch.OwnerName = txtOwnerName.Text;
            leaseSearch.OwnerPhoneNo = txtOwnerPhoneNo.Text;
            leaseSearch.TenantName = txtTenantName.Text;
            leaseSearch.TenantPhoneNo = txtTenantPhoneNo.Text;
            leaseSearch.TokenNo = txtTokenNo.Text;
            leaseSearch.GRNNo = txtGRNNo.Text;

            List<string> locations = new List<string>();
            foreach (string loc in lbLocations.SelectedItems)
            {
                locations.Add(loc);
            }
            leaseSearch.Locations = locations;

            List<string> societies = new List<string>();
            foreach (string soc in lbSocieties.SelectedItems)
            {
                societies.Add(soc);
            }
            leaseSearch.Societies = societies;

            leaseSearch.RegistrationDateFrom = Convert.ToInt16(registrationDateFrom.Tag) == 2 ? registrationDateFrom.Value.ToString("dd'/'MM'/'yyyy") : null;
            leaseSearch.RegistrationDateTo = Convert.ToInt16(registrationDateTo.Tag) == 2 ? registrationDateTo.Value.ToString("dd'/'MM'/'yyyy") : null;
            leaseSearch.LeaseEndDateFrom = Convert.ToInt16(leaseEndDateFrom.Tag) == 2 ? leaseEndDateFrom.Value.ToString("dd'/'MM'/'yyyy") : null;
            leaseSearch.LeaseEndDateTo = Convert.ToInt16(leaseEndDateTo.Tag) == 2 ? leaseEndDateTo.Value.ToString("dd'/'MM'/'yyyy") : null;

            BindingSource bSource = new BindingSource();
            bSource.DataSource = leaseDAL.GetLease(leaseSearch);
            dgvLease.DataSource = bSource;
            lblSearchCount.Text = (dgvLease.Rows.Count - 1).ToString();
            adjustColumnOrder();
        }

        private void registrationDateFrom_ValueChanged(object sender, EventArgs e)
        {
            registrationDateFrom.CustomFormat = "dd'/'MM'/'yyyy";
            registrationDateFrom.Tag = 2;
        }

        private void registrationDateTo_ValueChanged(object sender, EventArgs e)
        {
            registrationDateTo.CustomFormat = "dd'/'MM'/'yyyy";
            registrationDateTo.Tag = 2;
        }

        private void leaseEndDateFrom_ValueChanged(object sender, EventArgs e)
        {
            leaseEndDateFrom.CustomFormat = "dd'/'MM'/'yyyy";
            leaseEndDateFrom.Tag = 2;
        }

        private void leaseEndDateTo_ValueChanged(object sender, EventArgs e)
        {
            leaseEndDateTo.CustomFormat = "dd'/'MM'/'yyyy";
            leaseEndDateTo.Tag = 2;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtLocationSearch.Text = "";
            txtSocietySearch.Text = "";
            registrationDateFrom.CustomFormat = " ";
            registrationDateFrom.Tag = 1;
            registrationDateTo.CustomFormat = " ";
            registrationDateTo.Tag = 1;
            leaseEndDateFrom.CustomFormat = " ";
            leaseEndDateFrom.Tag = 1;
            leaseEndDateTo.CustomFormat = " ";
            leaseEndDateTo.Tag = 1;
            txtOwnerName.Text = "";
            txtOwnerPhoneNo.Text = "";
            txtTenantName.Text = "";
            txtTenantPhoneNo.Text = "";
            txtTokenNo.Text = "";
            txtGRNNo.Text = "";
            cbActive.Checked = true;
            lbLocations.ClearSelected();
            lbSocieties.ClearSelected();

            BindingSource bSource = new BindingSource();
            leaseDAL = new LeaseDAL();
            DataTable lease = leaseDAL.GetLease();
            bSource.DataSource = lease;
            int leaseCount = lease != null ? lease.Rows.Count : 0;
            lblLeadCount.Text = leaseCount.ToString();
            lblSearchCount.Text = leaseCount.ToString();
            dgvLease.DataSource = bSource;
            adjustColumnOrder();
        }
    }
}
