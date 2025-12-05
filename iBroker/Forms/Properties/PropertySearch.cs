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

namespace iBroker.Forms.Properties
{
    public partial class PropertySearch : Form
    {
        private BindingSource bSource;
        public PropertyDAL propertyDAL { get; set; }
        private DataTable properties;
        public Entities.PropertySearch propertySearch;
        private SourceDAL sourceDAL;
        private LocationDAL locationDAL;
        private PropertyTypeDAL propertyTypeDAL;
        private SocietyDAL societyDAL;
        List<CheckedListBoxItem> locationList;
        List<CheckedListBoxItem> societyList;

        public PropertySearch()
        {
            InitializeComponent();
        }

        private void PropertySearch_Load(object sender, EventArgs e)
        {
            registrationDateFrom.CustomFormat = " ";
            //registrationDateFrom.Value = DateTime.Bl
            registrationDateTo.CustomFormat = " ";
            //string[] sources = {"",
            //    "Direct Client",
            //        "Broker",
            //        "Magicbricks",
            //        "Housing.com",
            //        "JustDial",
            //        "Facebook",
            //        "WhatsApp",
            //        "Reference", "ALL"};
            //cmbSource.Items.AddRange(sources);
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
            //locationList = locationData.AsEnumerable().Select(x => 
            //x.Field<string>("Location") != null ? new CheckedListBoxItem { Text = x.Field<string>("Location") } : continue).ToList();
            locationList = (from loc in locationData.AsEnumerable()
                           where !string.IsNullOrEmpty(loc["Location"].ToString())
                           select new CheckedListBoxItem { Text = loc["Location"].ToString() }).ToList();

            //locationList.RemoveAll(string.IsNullOrWhiteSpace);
            lbLocations.Items.AddRange(locationList.ToArray());

            societyDAL = new SocietyDAL();
            DataTable socities = societyDAL.GetSocieties();
            //societyList = socities.AsEnumerable().Select(x => new CheckedListBoxItem {  Text = x.Field<string>("SocietyName") }).ToList();
            societyList = (from soc in socities.AsEnumerable()
                            where !string.IsNullOrEmpty(soc["SocietyName"].ToString())
                            select new CheckedListBoxItem { Text = soc["SocietyName"].ToString() }).ToList();

            //societyList.RemoveAll(string.IsNullOrWhiteSpace);
            lbSocieties.Items.AddRange(societyList.ToArray());

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
            bSource = new BindingSource();
            propertyDAL = new PropertyDAL();
            properties = propertyDAL.GetProperties();
            bSource.DataSource = properties;
            int propCount = properties != null ? properties.Rows.Count : 0;
            lblLeadCount.Text = propCount.ToString();
            lblSearchCount.Text = propCount.ToString();
            dgvProperties.DataSource = bSource;
            AdjustColumnOrder();
        }
        private void AdjustColumnOrder()
        {
            dgvProperties.AutoGenerateColumns = false;
            dgvProperties.Columns["Id"].HeaderText = "Sr.No.";
            dgvProperties.Columns["Id"].Width = 50;
            dgvProperties.Columns["CreatedDate"].HeaderText = "RegistrationDate";
            dgvProperties.Columns["CreatedDate"].DefaultCellStyle.Format = "dd'/'MM'/'yyy";
            dgvProperties.Columns["Id"].DisplayIndex = 0;
            dgvProperties.Columns["CreatedDate"].DisplayIndex = 1;
            dgvProperties.Columns["TransactionType"].DisplayIndex = 2;
            dgvProperties.Columns["PropertyType"].DisplayIndex = 3;
            dgvProperties.Columns["Society"].DisplayIndex = 4;
            dgvProperties.Columns["Owner Name"].DisplayIndex = 5;
            dgvProperties.Columns["Owner PhoneNo"].DisplayIndex = 6;
            dgvProperties.Columns["BedroomCount"].DisplayIndex = 7;
            dgvProperties.Columns["Location"].DisplayIndex = 8;
            dgvProperties.Columns["PropertyFloor"].DisplayIndex = 9;
            dgvProperties.Columns["FurnitureStatus"].DisplayIndex = 10;
            dgvProperties.Columns["PropertyAge"].DisplayIndex = 11;
            dgvProperties.Columns["WillingRentFor"].DisplayIndex = 12;
            dgvProperties.Columns["RentPerMonth"].DisplayIndex = 13;
            dgvProperties.Columns["SellingPrice"].DisplayIndex = 14;
            dgvProperties.Columns["Landmark"].DisplayIndex = 21;
            dgvProperties.Columns["Pincode"].DisplayIndex = 22;
            dgvProperties.Columns["OwnerId"].DisplayIndex = 20;
            dgvProperties.Columns["OwnerId"].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var clientName = txtClientName.Text;
            var phoneNo = txtPhoneNo.Text;
            var email = txtEmail.Text;
            var transaction = cmbTransaction.SelectedItem != null ? cmbTransaction.SelectedItem.ToString() : "";
            var propType = cmbPropType.SelectedValue != null ? cmbPropType.SelectedValue.ToString() : "";
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
            foreach (CheckedListBoxItem loc in lbLocations.CheckedItems)
            {
                locations.Add(loc.Text);
            }

            List<string> furPreference = new List<string>();
            furPreference.Add(cbFullyFurnished.Checked ? "FullyFurnished" : "");
            furPreference.Add(cbSemiFurnished.Checked ? "SemiFurnished" : "");
            furPreference.Add(cbNonFurnished.Checked ? "NonFurnished" : "");

            List<string> societies = new List<string>();
            foreach (CheckedListBoxItem soc in lbSocieties.CheckedItems)
            {
                societies.Add(soc.Text);
            }

            List<string> rentFor = new List<string>();
            rentFor.Add(cbFamily.Checked ? "Family" : "");
            rentFor.Add(cbBachelor.Checked ? "Bachelor" : "");
            rentFor.Add(cbStudent.Checked ? "Student" : "");

            propertySearch = new Entities.PropertySearch
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
                RegistrationDateTo = Convert.ToInt16(registrationDateTo.Tag) == 2 ? registrationDateTo.Value.ToString("dd'/'MM'/'yyyy") : null,
                Source = cmbSource.SelectedValue != null ? cmbSource.SelectedValue.ToString() : null,
                PropertyAge = !string.IsNullOrEmpty(txtPropertyAge.Text.Trim()) ? Convert.ToInt32(txtPropertyAge.Text) : 0,
                PropertyFloor = !string.IsNullOrEmpty(txtPropertyFloor.Text.Trim()) ? Convert.ToInt32(txtPropertyFloor.Text) : -1,
                CommercialUse = cbCommercialUse.Checked ? true : false,
                Societies = societies,
                AvailableForRent = rentFor,
                KeyWithUs = cbKeyWithUs.Checked
            };

            BindingSource bSource = new BindingSource();
            bSource.DataSource = propertyDAL.GetProperties(propertySearch);
            dgvProperties.DataSource = bSource;
            lblSearchCount.Text = (dgvProperties.Rows.Count-1).ToString();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtLocationSearch.Text = "";
            txtSocietySearch.Text = "";
            registrationDateFrom.CustomFormat = " ";
            registrationDateFrom.Tag = 1;
            registrationDateTo.CustomFormat = " ";
            registrationDateTo.Tag = 1;
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

            foreach (int i in lbLocations.CheckedIndices)
            {
                lbLocations.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (int i in lbSocieties.CheckedIndices)
            {
                lbSocieties.SetItemCheckState(i, CheckState.Unchecked);
            }

            cmbSource.SelectedIndex = 0;
            cbCommercialUse.Checked = false;
            cbFamily.Checked = false;
            cbBachelor.Checked = false;
            cbStudent.Checked = false;
            txtPropertyFloor.Text = "";
            lbSocieties.ClearSelected();
            txtPropertyAge.Text = "";
            cbKeyWithUs.Checked = false;

            BindingSource bSource = new BindingSource();
            propertyDAL = new PropertyDAL();
            DataTable properties = propertyDAL.GetProperties();
            bSource.DataSource = properties;
            int propertiesCount = properties != null ? properties.Rows.Count : 0;
            lblLeadCount.Text = propertiesCount.ToString();
            lblSearchCount.Text = propertiesCount.ToString();
            dgvProperties.DataSource = bSource;
            AdjustColumnOrder();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var propertyId = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;
                if (propertyId != null && !(propertyId is DBNull))
                {
                    Form childForm = new Properties.EditProperty(Convert.ToInt32(propertyId));
                    childForm.MdiParent = this.MdiParent;
                    childForm.Text = "Lead";
                    childForm.Show();
                }
            }
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
            locationList = (from loc in locationData.AsEnumerable()
                            where !string.IsNullOrEmpty(loc["Location"].ToString())
                            select new CheckedListBoxItem { Text = loc["Location"].ToString() }).ToList();
            //locationList.RemoveAll(string.IsNullOrWhiteSpace);
            lbLocations.Items.AddRange(locationList.ToArray());

            societyDAL = new SocietyDAL();
            DataTable socities = societyDAL.GetSocieties();
            //societyList = socities.AsEnumerable().Select(x => x.Field<CheckedListBoxItem>("SocietyName")).ToList();
            societyList = (from soc in socities.AsEnumerable()
                           where !string.IsNullOrEmpty(soc["SocietyName"].ToString())
                           select new CheckedListBoxItem { Text = soc["SocietyName"].ToString() }).ToList();
            //societyList.RemoveAll(string.IsNullOrWhiteSpace);
            lbSocieties.Items.AddRange(societyList.ToArray());

            properties = propertyDAL.GetProperties();
            bSource.DataSource = properties;
            int propCount = properties != null ? properties.Rows.Count : 0;
            lblLeadCount.Text = propCount.ToString();
            dgvProperties.DataSource = bSource;
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
                for (j = 0; j < dgvProperties.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dgvProperties.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dgvProperties.Rows.Count; i++)
                {
                    for (j = 0; j < dgvProperties.Columns.Count; j++)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dgvProperties[j, i].Value == null ? "" : dgvProperties[j, i].Value;
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

        private void txtSocietySearch_TextChanged(object sender, EventArgs e)
        {
            //var itemList = societyList;
            //if (itemList.Count > 0)
            //{
            //    //clear the items from the list
            //    lbSocieties.Items.Clear();

            //    //filter the items and add them to the list
            //    if (!string.IsNullOrEmpty(txtSocietySearch.Text))
            //    {
            //        lbSocieties.Items.AddRange(
            //            itemList.Where(i => i.Text.ToLower().Contains(txtSocietySearch.Text.ToLower())).ToArray());
            //    }
            //    else
            //    {
            //        lbSocieties.Items.AddRange(itemList.ToArray());
            //    }
            //}

            lbSocieties.Items.Clear();
            if (string.IsNullOrEmpty(txtSocietySearch.Text) == false)
            {
                foreach (var item in societyList)
                {
                    if (item.Contains(txtSocietySearch.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        lbSocieties.Items.Add(item, item.CheckState);
                    }
                }
            }
            else
            {
                foreach (var item in societyList)
                {
                    lbSocieties.Items.Add(item, item.CheckState);
                }
            }
        }

        private void txtLocationSearch_TextChanged(object sender, EventArgs e)
        {
            //var itemList = locationList;
            //if (itemList.Count > 0)
            //{
            //    //clear the items from the list
            //    lbLocations.Items.Clear();

            //    //filter the items and add them to the list
            //    if (!string.IsNullOrEmpty(txtLocationSearch.Text))
            //    {
            //        lbLocations.Items.AddRange(
            //            itemList.Where(i => i.ToLower().Contains(txtLocationSearch.Text.ToLower())).ToArray());
            //    }
            //    else
            //    {
            //        lbLocations.Items.AddRange(itemList.ToArray());
            //    }
            //}
            lbLocations.Items.Clear();
            if (string.IsNullOrEmpty(txtLocationSearch.Text) == false)
            {
                foreach (var item in locationList)
                {
                    if (item.Contains(txtLocationSearch.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        lbLocations.Items.Add(item, item.CheckState);
                    }
                }
            }
            else
            {
                foreach (var item in locationList)
                {
                    lbLocations.Items.Add(item, item.CheckState);
                }
            }
        }

        private void lbSocieties_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBoxItem item = lbSocieties.Items[e.Index] as CheckedListBoxItem;
            item.CheckState = e.NewValue;
        }

        private void lbLocations_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBoxItem item = lbLocations.Items[e.Index] as CheckedListBoxItem;
            item.CheckState = e.NewValue;
        }
    }

    // CheckedListBoxItem.cs
    public class CheckedListBoxItem
    {
        /// <summary>
        /// The item's text - what will be displayed in the CheckedListBox.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The item's check state.
        /// </summary>
        public CheckState CheckState { get; set; } = CheckState.Unchecked;

        /// <summary>
        /// Whether the item is checked or not.
        /// </summary>
        public bool Checked
        {
            get
            {
                return (CheckState == CheckState.Checked || CheckState == CheckState.Indeterminate);
            }
            set
            {
                if (value)
                {
                    CheckState = CheckState.Checked;
                }
                else
                {
                    CheckState = CheckState.Unchecked;
                }
            }
        }

        public bool Contains(string str, StringComparison comparison)
        {
            return Text.IndexOf(str, comparison) >= 0;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
