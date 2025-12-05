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

namespace iBroker.Forms.Admin
{
    public partial class Masters : Form
    {
        private LocationDAL locationDAL;
        private SocietyDAL societyDAL;
        private SourceDAL sourceDAL;
        public PropertyTypeDAL propertyTypeDAL;
        DataTable locations;
        DataTable societies;
        DataTable sources;
        DataTable propertyTypes;
        BindingSource bSource;
        private BrokerDAL brokerDAL;
        private BuilderDAL builderDAL;
        private DataTable builders;
        private DataTable brokers;

        public Masters()
        {
            bSource = new BindingSource();
            InitializeComponent();
        }

        private void cmbMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMaster.SelectedItem.ToString() == "Locations")
            {
                locationDAL = new LocationDAL();
                locations = locationDAL.GetLocations();
                
                bSource.DataSource = locations;
                dgvMasters.DataSource = bSource;
            }
            else if(cmbMaster.SelectedItem.ToString() == "Societies")
            {
                societyDAL = new SocietyDAL();
                societies = societyDAL.GetSocieties();
                bSource.DataSource = societies;
                dgvMasters.DataSource = bSource;
            }
            else if (cmbMaster.SelectedItem.ToString() == "Sources")
            {
                sourceDAL = new SourceDAL();
                sources = sourceDAL.GetSources();
                bSource.DataSource = sources;
                dgvMasters.DataSource = bSource;
            }
            else if (cmbMaster.SelectedItem.ToString() == "PropertyType")
            {
                propertyTypeDAL = new PropertyTypeDAL();
                sources = propertyTypeDAL.GetPropertyTypes();
                bSource.DataSource = sources;
                dgvMasters.DataSource = bSource;
            }
            else if (cmbMaster.SelectedItem.ToString() == "Brokers")
            {
                brokerDAL = new BrokerDAL();
                brokers = brokerDAL.GetBrokers();
                bSource.DataSource = brokers;
                dgvMasters.DataSource = bSource;

                dgvMasters.Columns["Name"].DisplayIndex = 0;
                dgvMasters.Columns["PhoneNo1"].DisplayIndex = 1;
                dgvMasters.Columns["Location"].DisplayIndex = 2;
                dgvMasters.Columns["PhoneNo2"].DisplayIndex = 3;
                dgvMasters.Columns["City"].DisplayIndex = 4;
                dgvMasters.Columns["State"].DisplayIndex = 5;
                dgvMasters.Columns["Id"].DisplayIndex = 6;
            }else if(cmbMaster.SelectedItem.ToString() == "Builders")
            {
                builderDAL = new BuilderDAL();
                builders = builderDAL.GetBuilders();
                bSource.DataSource = builders;
                dgvMasters.DataSource = bSource;

                dgvMasters.Columns["Name"].DisplayIndex = 0;
                dgvMasters.Columns["PhoneNo"].DisplayIndex = 1;
                dgvMasters.Columns["Email"].DisplayIndex = 2;
                dgvMasters.Columns["HeadOfficeAddress"].DisplayIndex = 3;
            }

            if (dgvMasters.Columns["Id"] != null)
            {
                dgvMasters.Columns["Id"].Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (cmbMaster.SelectedItem.ToString() == "Locations")
                {
                    locationDAL = new LocationDAL();
                    locationDAL.UpdateLocations((DataTable)bSource.DataSource);
                }
                else if (cmbMaster.SelectedItem.ToString() == "Societies")
                {
                    societyDAL = new SocietyDAL();
                    societyDAL.UpdateSocieties((DataTable)bSource.DataSource);
                }
                else if (cmbMaster.SelectedItem.ToString() == "Sources")
                {
                    sourceDAL = new SourceDAL();
                    sourceDAL.UpdateSources((DataTable)bSource.DataSource);
                }
                else if (cmbMaster.SelectedItem.ToString() == "PropertyType")
                {
                    propertyTypeDAL = new PropertyTypeDAL();
                    propertyTypeDAL.UpdatePropTypes((DataTable)bSource.DataSource);
                }
                else if (cmbMaster.SelectedItem.ToString() == "Brokers")
                {
                    brokerDAL = new BrokerDAL();
                    brokerDAL.UpdateBrokers((DataTable)bSource.DataSource);
                }
                else if (cmbMaster.SelectedItem.ToString() == "Builders")
                {
                    builderDAL = new BuilderDAL();
                    builderDAL.UpdateBuilder((DataTable)bSource.DataSource);
                }

                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Master updated successfully.", "Master", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Error in updating master.", "Master", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Masters_Load(object sender, EventArgs e)
        {
            cmbMaster.SelectedIndex = 0;
        }

        private void dgvMasters_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSerial(dgvMasters);
        }

        private void LoadSerial(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[row.Index].HeaderCell.Value = string.Format("{0}  ", row.Index + 1).ToString();
                row.Height = 25;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            bool dataFoundInRow = false;
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvMasters.DataSource];
            try
            {
                foreach (DataGridViewRow row in dgvMasters.Rows)
                {
                    if(row.Index == (dgvMasters.Rows.Count-1))
                    {
                        continue;
                    }

                    dataFoundInRow = false;
                    foreach (DataGridViewCell item in row.Cells)
                    {
                        if (item.Value != null && item.Value.ToString().ToLower().Contains(searchValue.ToLower()))
                        {
                            dataFoundInRow = true;
                            dgvMasters.Rows[row.Index].Visible = true;
                        }
                        //if (row.Cells[1].Value != null)
                        //{
                        //    currencyManager1.SuspendBinding();
                        //    dgvMasters.Rows[row.Index].Visible = false;
                        //    currencyManager1.ResumeBinding();

                        //}
                    }

                    if(!dataFoundInRow)
                    {
                        currencyManager1.SuspendBinding();
                        dgvMasters.Rows[row.Index].Visible = false;
                        currencyManager1.ResumeBinding();
                    }

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
