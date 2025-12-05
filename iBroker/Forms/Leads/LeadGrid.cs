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
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace iBroker.Forms.Leads
{
    public partial class LeadGrid : Form
    {
        private MySqlConnection connection;
        private DataTable leadTable;
        private LeadDAL leadDAL;
        private LeadSearch leadSearch;
        private LocationDAL locationDAL;
        private SourceDAL sourceDAL;
        private PropertyTypeDAL propertyTypeDAL;

        public LeadGrid()
        {
            InitializeComponent();
        }

        private void LeadGrid_Load(object sender, EventArgs e)
        {
            registrationDateFrom.CustomFormat = " ";
            registrationDateTo.CustomFormat = " ";
            reminderDateFrom.CustomFormat = " ";
            reminderDateTo.CustomFormat = " ";

            //sourceDAL = new SourceDAL();
            //DataTable sources = sourceDAL.GetSources();
            //DataRow row = sources.NewRow();
            //row["id"] = 0;
            //row["Source"] = "";
            //sources.Rows.InsertAt(row, 0);

            //cmbSource.DataSource = sources;
            //cmbSource.DisplayMember = "Source";
            //cmbSource.ValueMember = "Source";

            locationDAL = new LocationDAL();
            DataTable locationData = locationDAL.GetLocations();
            List<string> locationList = locationData.AsEnumerable().Select(x => x.Field<string>("Location")).ToList();
            locationList.RemoveAll(string.IsNullOrWhiteSpace);
            lbLocations.Items.AddRange(locationList.ToArray());

            propertyTypeDAL = new PropertyTypeDAL();
            DataTable propTypeTable = propertyTypeDAL.GetDistinctPropertyTypes();
            cmbPropType.DataSource = propTypeTable;
            cmbPropType.DisplayMember = "PropertyType";
            cmbPropType.ValueMember = "PropertyType";
            DataRow propTypeRow = propTypeTable.NewRow();
            propTypeRow["PropertyType"] = " ";
            propTypeTable.Rows.InsertAt(propTypeRow, 0);
            cmbPropType.SelectedIndex = 0;

            cbActive.Checked = true;
            BindingSource bSource = new BindingSource();
            leadDAL = new LeadDAL();
            DataTable leads = leadDAL.GetLeads();
            bSource.DataSource = leads;
            int leadCount = leads != null ? leads.Rows.Count : 0;
            lblLeadCount.Text = leadCount.ToString();
            lblSearchCount.Text = leadCount.ToString();
            dataGridView1.DataSource = bSource;
            AdjustColumnOrder();
        }

        private void AdjustColumnOrder()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["Id"].HeaderText = "Sr.No.";
            dataGridView1.Columns["Id"].Width = 50;
            dataGridView1.Columns["CreatedDate"].HeaderText = "RegistrationDate";
            dataGridView1.Columns["CreatedDate"].DefaultCellStyle.Format = "dd'/'MM'/'yyy";
            dataGridView1.Columns["ClientId"].Visible = false;
            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["CreatedDate"].DisplayIndex = 1;
            dataGridView1.Columns["TransactionType"].DisplayIndex = 2;
            dataGridView1.Columns["PropertyType"].DisplayIndex = 3;
            dataGridView1.Columns["Client FirstName"].DisplayIndex = 4;
            dataGridView1.Columns["Client LastName"].Visible = false;
            dataGridView1.Columns["Client PhoneNo"].DisplayIndex = 5;
            dataGridView1.Columns["Bedrooms"].DisplayIndex = 6;
            dataGridView1.Columns["Location"].DisplayIndex = 7;
            dataGridView1.Columns["MinBudget"].DisplayIndex = 8;
            dataGridView1.Columns["MaxBudget"].DisplayIndex = 9;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var leadId = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;
                Form childForm = new Leads.EditLead(Convert.ToInt32(leadId));
                childForm.MdiParent = this.MdiParent;
                childForm.Text = "Lead";
                childForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var clientName = txtClientName.Text;
            var phoneNo = txtPhoneNo.Text;
            var email = txtEmail.Text;
            var transaction = cmbTransaction.SelectedItem != null ? cmbTransaction.SelectedItem.ToString() : "";
            var propType = cmbPropType.SelectedValue !=null ? cmbPropType.SelectedValue.ToString() : "";
            var bedrooms = string.Empty;

            List<string> listBedrooms = new List<string>();
            listBedrooms.Add(cb1HK.Checked ? "0" : "");
            listBedrooms.Add(cb15BHK.Checked ? "1.5" : "");
            listBedrooms.Add(cb25BHK.Checked ? "2.5" : "");
            listBedrooms.Add(cb1BHK.Checked ? "1" : "");
            listBedrooms.Add(cb2BHK.Checked ? "2" : "");
            listBedrooms.Add(cb3BHK.Checked ? "3" : "");
            listBedrooms.Add(cb4BHK.Checked ? "4" : "");

            List<string> locations = new List<string>();
            foreach (string loc in lbLocations.SelectedItems)
            {
                locations.Add(loc);
            }

            List<string> furPreference = new List<string>();
            furPreference.Add(cbFullyFurnished.Checked ? "FullyFurnished" : "");
            furPreference.Add(cbSemiFurnished.Checked ? "SemiFurnished" : "");
            furPreference.Add(cbNonFurnished.Checked ? "NonFurnished" : "");

            leadSearch = new LeadSearch
            {
                TransactionType = transaction,
                Bedrooms = listBedrooms,
                ClientPhoneNo = phoneNo,
                ClientName = clientName,
                ClientEmail = email,
                PropertyType = propType,
                Active = cbActive.Checked,
                BudgetMin = txtBudgetMin.Text == "" ? 0 : Convert.ToInt32(txtBudgetMin.Text),
                BudgetMax = txtBudgetMax.Text == "" ? 0 : Convert.ToInt32(txtBudgetMax.Text),
                Locations = locations,
                FurnitureStatus = furPreference,
                RegistrationDateFrom = Convert.ToInt16(registrationDateFrom.Tag) == 2 ? registrationDateFrom.Value.ToString("dd'/'MM'/'yyyy") : null,
                RegistrationDateTo = Convert.ToInt16(registrationDateTo.Tag) == 2 ?  registrationDateTo.Value.ToString("dd'/'MM'/'yyyy") : null,
                ReminderDateFrom = Convert.ToInt16(reminderDateFrom.Tag) == 2 ?  reminderDateFrom.Value.ToString("dd'/'MM'/'yyyy") : null,
                ReminderDateTo = Convert.ToInt16(reminderDateTo.Tag) == 2 ?  reminderDateTo.Value.ToString("dd'/'MM'/'yyyy") : null,
                Source = cmbSource.SelectedValue != null ? cmbSource.SelectedValue.ToString() : null
            };

            BindingSource bSource = new BindingSource();
            bSource.DataSource = leadDAL.GetLeads(leadSearch);
            dataGridView1.DataSource = bSource;
            lblSearchCount.Text = (dataGridView1.Rows.Count-1).ToString();
            AdjustColumnOrder();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            sourceDAL = new SourceDAL();
            DataTable sources = sourceDAL.GetSources();
            DataRow row = sources.NewRow();
            row["id"] = 0;
            row["Source"] = "";
            sources.Rows.InsertAt(row, 0);
            cmbSource.DataSource = sources;
            cmbSource.DisplayMember = "Source";
            cmbSource.ValueMember = "Source";

            locationDAL = new LocationDAL();
            DataTable locationData = locationDAL.GetLocations();
            List<string> locationList = locationData.AsEnumerable().Select(x => x.Field<string>("Location")).ToList();
            locationList.RemoveAll(string.IsNullOrWhiteSpace);
            lbLocations.Items.AddRange(locationList.ToArray());

            BindingSource bSource = new BindingSource();
            DataTable leads;
            if (leadSearch != null)
            {
                leads = leadDAL.GetLeads(leadSearch);
                bSource.DataSource = leads;
            }
            else
            {
                leads = leadDAL.GetLeads();
                bSource.DataSource = leads;
            }
            
            dataGridView1.DataSource = bSource;
            int leadCount = leads != null ? leads.Rows.Count : 0;
            lblLeadCount.Text = leadCount.ToString();
            AdjustColumnOrder();
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

        private void reminderDateFrom_ValueChanged(object sender, EventArgs e)
        {
            reminderDateFrom.CustomFormat = "dd'/'MM'/'yyyy";
            reminderDateFrom.Tag = 2;
        }

        private void reminderDateTo_ValueChanged(object sender, EventArgs e)
        {
            reminderDateTo.CustomFormat = "dd'/'MM'/'yyyy";
            reminderDateTo.Tag = 2;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            registrationDateFrom.CustomFormat = " ";
            registrationDateFrom.Tag = 1;
            registrationDateTo.CustomFormat = " ";
            registrationDateTo.Tag = 1;
            reminderDateFrom.CustomFormat = " ";
            reminderDateFrom.Tag = 1;
            reminderDateTo.CustomFormat = " ";
            reminderDateTo.Tag = 1;
            txtClientName.Text = "";
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            cbActive.Checked = true;
            cmbTransaction.SelectedIndex = 0;
            cmbPropType.SelectedIndex = 0;
            txtBudgetMin.Text = "";
            txtBudgetMax.Text = "";
            cb1HK.Checked = false;
            cb1BHK.Checked = false;
            cb15BHK.Checked = false;
            cb2BHK.Checked = false;
            cb25BHK.Checked = false;
            cb3BHK.Checked = false;
            cb4BHK.Checked = false;
            cbFullyFurnished.Checked = false;
            cbSemiFurnished.Checked = false;
            cbNonFurnished.Checked = false;
            lbLocations.ClearSelected();
            cmbSource.SelectedIndex = 0;

            BindingSource bSource = new BindingSource();
            leadDAL = new LeadDAL();
            DataTable leads = leadDAL.GetLeads();
            bSource.DataSource = leads;
            int leadCount = leads != null ? leads.Rows.Count : 0;
            lblLeadCount.Text = leadCount.ToString();
            lblSearchCount.Text = leadCount.ToString();
            dataGridView1.DataSource = bSource;
            AdjustColumnOrder();
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                //Write Headers
                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                        }
                        catch
                        {
                            ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmbSource_Click(object sender, EventArgs e)
        {
            if (cmbSource.Items.Count == 0)
            {
                sourceDAL = new SourceDAL();
                DataTable sources = sourceDAL.GetSources();
                DataRow row = sources.NewRow();
                row["id"] = 0;
                row["Source"] = "";
                sources.Rows.InsertAt(row, 0);

                cmbSource.DataSource = sources;
                cmbSource.DisplayMember = "Source";
                cmbSource.ValueMember = "Source";
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void lblSearchCount_Click(object sender, EventArgs e)
        {

        }
    }
}
