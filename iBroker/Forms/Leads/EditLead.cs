using System;
using System.Windows.Forms;
using iBroker.Entities;
using iBroker.DAL;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Linq;

namespace iBroker.Forms.Leads
{
    public partial class EditLead : Form
    {
        private int leadId=0;
        private Lead objLead = null;
        private Customer objCustomer = null;
        private DataTable followUpTable;
        private LeadDAL leadDALObj;
        private LocationDAL locationDAL;
        private PropertyTypeDAL propertyTypeDAL;
        private SourceDAL sourceDAL;
        ComboBox editGridCellComboBox = new ComboBox();
        private BrokerDAL brokerDAL;
        private ComboBox cmbBroker;
        private DataTable brokersData;

        public EditLead()
        {
            InitializeComponent();
        }

        public EditLead(int leadId)
        {
            this.leadId = leadId;
            using (LeadDAL objDAL = new LeadDAL())
            {
                this.objLead = objDAL.GetLead(leadId);
            }

            using (CustomerDAL objDAL = new CustomerDAL())
            {
                objCustomer = objDAL.GetCustomer(objLead.ClientId);
            }

            using (LeadFollowUpDAL objDAL = new LeadFollowUpDAL())
            {
                this.followUpTable =  objDAL.GetLeadFollowUps(leadId);
            }

            InitializeComponent();

            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.followUpTable;
            dgvfollowUps.DataSource = bSource;
            dgvfollowUps.Columns["Id"].Visible = false;
            dgvfollowUps.Columns["LeadId"].Visible = false;
            dgvfollowUps.Columns["Date"].DisplayIndex = 1;
            dgvfollowUps.Columns["FollowUpBy"].DisplayIndex = 2;
            dgvfollowUps.Columns["ShownBy"].DisplayIndex = 3;
            dgvfollowUps.Columns["ReminderDate"].DisplayIndex = 4;
            dgvfollowUps.Columns["Comment"].DisplayIndex = 5;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtPhone1.Text.Length > 10 || txtPhone1.Text.Length < 10)
            {
                MessageBox.Show("Invalid phone no1, Please enter 10 digit phone no", "Lead", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPhone2.Text.Length > 0 && (txtPhone2.Text.Length > 10 || txtPhone2.Text.Length < 10))
            {
                MessageBox.Show("Invalid phone no2, Please enter 10 digit phone no", "Lead", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            var firstName = txtName.Text;
            //var lastName = txtLastName.Text;
            var phone1 = txtPhone1.Text;
            var phone2 = txtPhone2.Text;
            var email = txtEmail.Text;

            var customer = new Customer();
            customer.FirstName = firstName;
            //customer.LastName = lastName;
            customer.PhoneNo1 = phone1;
            customer.PhoneNo2 = phone2;
            customer.Email = email;
            customer.AddressOther = txtAddress.Text;
            if (cbSource.SelectedValue != null && cbSource.SelectedValue.ToString() == "Broker")
            {
                customer.IsBroker = true;
                customer.FirstName = cmbBroker.SelectedValue != null ? cmbBroker.SelectedValue.ToString() : cmbBroker.Text;
            }
            else
            {
                customer.IsBroker = false;
                customer.FirstName = txtName.Text;
            }
            //customer.Society = txtSociety.Text;
            //customer.Landmark = txtLandmark.Text;
            //customer.City = txtCity.Text;
            //customer.State = txtState.Text;
            //customer.Country = txtCountry.Text;
            //customer.Pincode = txtPincode.Text;
            int customerId = 0;

            //var requirement = tabs[1].Controls;
            //var transactionType = requirement["cmbTransaction"];
            var transactionType = cmbTransaction.SelectedItem.ToString();

            //var propertyType = requirement["cmbPropType"];
            var propertyType = cmbPropType.SelectedValue.ToString();

            //var propSubType = requirement["cmbPropSubType"];
            var propSubType = cmbPropSubType.SelectedValue.ToString();

            //var residencyProp = requirement["residentialPanel"].Controls;
            //var minBudget = residencyProp["txtMinBudget"];
            var minBudget = txtMinBudget.Text;
            if(minBudget.ToLower().Contains("lacs") || minBudget.ToLower().Contains("lakhs") || minBudget.ToLower().Contains("lakh") || minBudget.ToLower().Contains("lac"))
            {
                minBudget = Regex.Match(minBudget, @"\d+").Value;
                minBudget = minBudget + "00000";
            }else if (minBudget.ToLower().Contains("thousand") || minBudget.ToLower().Contains("k"))
            {
                minBudget = Regex.Match(minBudget, @"\d+").Value;
                minBudget = minBudget + "000";
            }

            //var maxBudget = residencyProp["txtMaxBudget"];
            var maxBudget = txtMaxBudget.Text;
            if (maxBudget.ToLower().Contains("lacs") || maxBudget.ToLower().Contains("lakhs") || maxBudget.ToLower().Contains("lakh") || maxBudget.ToLower().Contains("lac"))
            {
                maxBudget = Regex.Match(maxBudget, @"\d+").Value;
                maxBudget = maxBudget + "00000";
            }
            else if (maxBudget.ToLower().Contains("thousand") || maxBudget.ToLower().Contains("k"))
            {
                maxBudget = Regex.Match(maxBudget, @"\d+").Value;
                maxBudget = maxBudget + "000";
            }
            //var cb1BHK = residencyProp["cb1BHK"];
            //var cb2BHK = residencyProp["cb2BHK"];
            //var cb25BHK = residencyProp["cb25BHK"];
            //var cb3BHK = residencyProp["cb3BHK"];

            //var cb1BHK = cb1BHK;
            //var cb2BHK = residencyProp["cb2BHK"];
            //var cb25BHK = residencyProp["cb25BHK"];
            //var cb3BHK = residencyProp["cb3BHK"];

            var lead = new Lead();
            lead.TransactionType = transactionType;
            lead.PropertyType = propertyType;
            lead.PropertySubType = propSubType;

            try
            {
                lead.MinArea = string.IsNullOrEmpty(txtMinArea.Text) ? 0 : Convert.ToInt32(txtMinArea.Text);
                lead.MaxArea = string.IsNullOrEmpty(txtMaxArea.Text) ? 0 : Convert.ToInt32(txtMaxArea.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Only numbers allowed in Minimun and Maximum Area.", "Lead", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Arrow;
                return;
            }

            //----------------------------------------
            string bedrooms = string.Empty;
            if (((CheckBox)cb1HK).Checked)
            {
                bedrooms = "0";
            }
            if (((CheckBox)cb1BHK).Checked)
            {
                bedrooms = bedrooms + (string.IsNullOrEmpty(bedrooms) ? "1" : ",1");
            }
            if (((CheckBox)cb15BHK).Checked)
            {
                bedrooms = bedrooms + (string.IsNullOrEmpty(bedrooms) ? "1.5" : ",1.5");
            }
            if (((CheckBox)cb2BHK).Checked)
            {
                bedrooms = bedrooms + (string.IsNullOrEmpty(bedrooms) ? "2" : ",2");
            }
            if (((CheckBox)cb25BHK).Checked)
            {
                bedrooms = bedrooms + (string.IsNullOrEmpty(bedrooms) ? "2.5" : ",2.5");
            }
            if (((CheckBox)cb3BHK).Checked)
            {
                bedrooms = bedrooms + (string.IsNullOrEmpty(bedrooms) ? "3" : ",3");
            }
            if (((CheckBox)cb4BHK).Checked)
            {
                bedrooms = bedrooms + (string.IsNullOrEmpty(bedrooms) ? "4" : ",4");
            }
            lead.Bedrooms = bedrooms;

            try
            {
                lead.MinBudget = string.IsNullOrEmpty(minBudget) ? 0 : Convert.ToInt64(minBudget);
                lead.MaxBudget = string.IsNullOrEmpty(maxBudget) ? 0 : Convert.ToInt64(maxBudget);
            }catch(Exception ex)
            {
                MessageBox.Show("Error in converting amount, please check.", "Lead", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Arrow;
                return;
            }

            lead.Location = txtLocation.Text;
            lead.IsActive = cbActive.Checked;
            lead.Source = cbSource.SelectedValue != null ? cbSource.SelectedValue.ToString() : "";
            lead.SocietyPreference = txtSocietyPreference.Text;
            List<string> furPreference = new List<string>();
            furPreference.Add(cbFullyFurnished.Checked ? "FullyFurnished" : "");
            furPreference.Add(cbSemiFurnished.Checked ? "SemiFurnished" : "");
            furPreference.Add(cbNonFurnished.Checked ? "NonFurnished" : "");
            string furRef = String.Join(",", furPreference);

            lead.FurnitureStatus = furRef;
            lead.Remark = txtRemark.Text;
            lead.CreatedDate = registrationDate.Value.ToString("dd'/'MM'/'yyyy");

            List<string> listRequiredRentFor = new List<string>();
            listRequiredRentFor.Add(cbFamily.Checked ? "Family" : "");
            listRequiredRentFor.Add(cbBachelor.Checked ? "Bachelor" : "");
            listRequiredRentFor.Add(cbStudent.Checked ? "Student" : "");
            string requiredRentFor = String.Join(",", listRequiredRentFor);
            lead.RequiredRentFor = requiredRentFor;

            if (!customer.ValidateCustomerInfo(customer))
            {
                MessageBox.Show("Please enter client details.", "Lead", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Arrow;
                return;
            }

            if (this.leadId == 0)
            {
                using (CustomerDAL objDAL = new CustomerDAL())
                {
                    if (!customer.IsBroker)
                    {
                        if (!objDAL.CustomeExists(customer))
                        {
                            customerId = objDAL.Insert(customer);
                        }
                        else
                        {
                            MessageBox.Show("Lead already exists with this phone no", "Lead", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cursor.Current = Cursors.Arrow;
                            return;
                        }
                    }
                    else
                    {
                        customerId = objDAL.Insert(customer);
                    }
                }

                lead.ClientId = customerId;
                using (LeadDAL objDAL = new LeadDAL())
                {
                    this.leadId = objDAL.Insert(lead);
                }

                if (followUpTable.Rows.Count > 0)
                {
                    foreach (DataRow row in followUpTable.Rows)
                    {
                        row["LeadId"] = leadId;
                    }

                    using (LeadFollowUpDAL objDAL = new LeadFollowUpDAL())
                    {
                        objDAL.SaveAll(followUpTable);
                    }
                }

                MessageBox.Show("Lead saved successfully.", "Lead", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Arrow;
            }
            else
            {
                lead.Id = objLead.Id;
                customer.Id = objCustomer.Id;
                using (CustomerDAL objDAL = new CustomerDAL())
                {
                    customerId = objDAL.Update(customer);
                }

                lead.ClientId = customerId;
                using (LeadDAL objDAL = new LeadDAL())
                {
                    this.leadId = objDAL.Update(lead);
                }

                using (LeadFollowUpDAL objDAL = new LeadFollowUpDAL())
                {
                    objDAL.SaveAll(followUpTable);
                }

                MessageBox.Show("Lead saved successfully.", "Lead", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Arrow;
            }
        }

        private void EditLead_Load(object sender, EventArgs e)
        {
            //string[] locations = {"Tingre Nagar",
            //                            "Dhanori",
            //                            "Vishrantwadi",
            //                            "Viman Nagar",
            //                            "Wadgaonsheri",
            //                            "Chandan Nagar",
            //                            "Kalyani Nagar",
            //                            "Kharadi",
            //                            "Wagholi",
            //                            "Charholi",
            //                            "Lohegaon",
            //                            "Nagpur Chawl",
            //                            "Shashtri Nagar",
            //                            "Yerwada",
            //                            "Hadapsar",
            //                            "Koregaon Park",
            //                            "Mundhwa",
            //                            "Bund Garden"};

            //string[] sources = {"Direct Client",
            //        "Broker",
            //        "Magicbricks",
            //        "Housing.com",
            //        "JustDial",
            //        "Facebook",
            //        "WhatsApp",
            //        "Reference"};
            //cbSource.Items.AddRange(sources);

            //clbLocations.Items.AddRange(locations);
            sourceDAL = new SourceDAL();
            cbSource.DataSource = sourceDAL.GetSources();
            cbSource.DisplayMember = "Source";
            cbSource.ValueMember = "Source";

            locationDAL = new LocationDAL();
            DataTable locationData =  locationDAL.GetLocations();
            List<string> locationList = locationData.AsEnumerable().Select(x => x.Field<string>("Location")).ToList();
            locationList.RemoveAll(string.IsNullOrWhiteSpace);
            clbLocations.Items.AddRange(locationList.ToArray());

            leadDALObj = new LeadDAL();
            registrationDate.CustomFormat = "dd'/'MM'/'yyyy";
            lblLeadFormNo.Text =  (leadDALObj.GetNextLeadId() + 1).ToString();
            //tabControl1.TabPages["tabFollowUp"].Hide();
            registrationDate.Value = DateTime.Now;
            cbActive.Checked = true;
            cbSource.SelectedIndex = 0;

            propertyTypeDAL = new PropertyTypeDAL();
            cmbPropType.DataSource = propertyTypeDAL.GetDistinctPropertyTypes();
            cmbPropType.DisplayMember = "PropertyType";
            cmbPropType.ValueMember = "PropertyType";

            cmbTransaction.SelectedIndex = 0;
            cmbPropType.SelectedIndex = 0;

            cmbPropSubType.DataSource = propertyTypeDAL.GetDistinctPropertySubTypes(cmbPropType.SelectedValue.ToString());
            cmbPropSubType.DisplayMember = "propertysubtype";
            cmbPropSubType.ValueMember = "propertysubtype";

            cmbPropSubType.SelectedIndex = 0;
            //cmbPropSubType.Items.Add("Apartment");
            //cmbPropSubType.Items.Add("Row House");
            //cmbPropSubType.Items.Add("Bunglow");
            //cmbPropSubType.Items.Add("Pent House");
            //cmbPropSubType.Items.Add("PG");
            //cmbPropSubType.Items.Add("Shop");
            //cmbPropSubType.Items.Add("Showroom");
            //cmbPropSubType.Items.Add("Office Space");
            //cmbPropSubType.Items.Add("N.A. Plot");
            //cmbPropSubType.Items.Add("R-Zone Plot");
            //cmbPropSubType.Items.Add("Agriculture Plot");
            //cmbPropSubType.Items.Add("Industrial Plot");
           

            followUpDate.CustomFormat = "dd'/'MM'/'yyyy";
            reminderDate.CustomFormat = "dd'/'MM'/'yyyy";
            cmbFollowupStatus.SelectedIndex = 0;

            if (objLead != null)
            {
                LoadDataInControls();
            }
            else
            {
                followUpTable = new DataTable();
                followUpTable.Columns.Add("Id");
                followUpTable.Columns.Add("LeadId");
                followUpTable.Columns.Add("Date");
                followUpTable.Columns.Add("Comment");
                followUpTable.Columns.Add("FollowUpBy");
                followUpTable.Columns.Add("ReminderDate");
                followUpTable.Columns.Add("ShownBy");
                followUpTable.Columns.Add("Status");


                BindingSource bSource = new BindingSource();
                //leadDAL = new LeadDAL();
                bSource.DataSource = followUpTable;
                dgvfollowUps.DataSource = bSource;
                dgvfollowUps.Columns["Id"].Visible = false;
                dgvfollowUps.Columns["LeadId"].Visible = false;
                dgvfollowUps.Columns["Id"].Visible = false;
                dgvfollowUps.Columns["LeadId"].Visible = false;
                dgvfollowUps.Columns["Date"].DisplayIndex = 1;
                dgvfollowUps.Columns["FollowUpBy"].DisplayIndex = 2;
                dgvfollowUps.Columns["ShownBy"].DisplayIndex = 3;
                dgvfollowUps.Columns["ReminderDate"].DisplayIndex = 4;
                dgvfollowUps.Columns["Comment"].DisplayIndex = 5;
                //dgvfollowUps.Columns["Status"].DisplayIndex = 6;
                //DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
                //dgvCmb.Items.Add("Open");
                //dgvCmb.Items.Add("Close");
                //dgvCmb.HeaderText = "Status";
                //dgvCmb.Name = "status";
                //dgvfollowUps.Columns.Add(dgvCmb);
                //
            }
        }

        private void LoadDataInControls()
        {
            lblLeadFormNo.Text = objLead.Id.ToString();
            registrationDate.Value = Convert.ToDateTime(!string.IsNullOrEmpty(objLead.CreatedDate) ? objLead.CreatedDate : DateTime.Now.ToString());
            cbActive.Checked = objLead.IsActive;
            cmbTransaction.SelectedItem = objLead.TransactionType;
            cmbPropType.SelectedValue = objLead.PropertyType;
            cmbPropSubType.SelectedValue = objLead.PropertySubType;
            txtMinBudget.Text = objLead.MinBudget.ToString();
            txtMaxBudget.Text = objLead.MaxBudget.ToString();
            txtLocation.Text = objLead.Location;
            //List<tableClass> list = MyCheckedList();
            for (int count = 0; count < clbLocations.Items.Count; count++)
            {
                if (txtLocation.Text.Contains(clbLocations.Items[count].ToString()))
                {
                    clbLocations.SetItemChecked(count, true);
                }
            }
            txtRemark.Text = objLead.Remark;
            cbSource.SelectedValue = objLead.Source;
            txtSocietyPreference.Text = objLead.SocietyPreference;
            txtMinArea.Text = objLead.MinArea == 0 ? "": objLead.MinArea.ToString();
            txtMaxArea.Text = objLead.MaxArea == 0 ? "" : objLead.MaxArea.ToString();
            if (objLead.Bedrooms != null)
            {
                cb1HK.Checked = objLead.Bedrooms.Contains("0") ? true : false;
                cb15BHK.Checked = objLead.Bedrooms.Contains("1.5") ? true : false;
                cb1BHK.Checked = ((objLead.Bedrooms.Contains("1") && !objLead.Bedrooms.Contains("1.")) || objLead.Bedrooms.Contains("1,")) ? true : false;
                //cb1BHK.Checked = objLead.Bedrooms.Contains("1") ? true : false;
                cb25BHK.Checked = objLead.Bedrooms.Contains("2.5") ? true : false;
                cb2BHK.Checked = ((objLead.Bedrooms.Contains("2") && !objLead.Bedrooms.Contains("2.")) || objLead.Bedrooms.Contains("2,")) ? true : false;
                cb3BHK.Checked = objLead.Bedrooms.Contains("3") ? true : false;
                cb4BHK.Checked = objLead.Bedrooms.Contains("4") ? true : false;
            }
            if (objLead.FurnitureStatus != null)
            {
                cbFullyFurnished.Checked = objLead.FurnitureStatus.Contains("FullyFurnished") ? true : false;
                cbSemiFurnished.Checked = objLead.FurnitureStatus.Contains("SemiFurnished") ? true : false;
                cbNonFurnished.Checked = objLead.FurnitureStatus.Contains("NonFurnished") ? true : false;
            }
            if (objLead.RequiredRentFor != null)
            {
                cbFamily.Checked = objLead.RequiredRentFor.Contains("Family") ? true : false;
                cbBachelor.Checked = objLead.RequiredRentFor.Contains("Bachelor") ? true : false;
                cbStudent.Checked = objLead.RequiredRentFor.Contains("Student") ? true : false;
            }
            if (objCustomer != null)
            {
                if (objLead.Source == "Broker")
                {
                    cmbBroker.SelectedValue = objCustomer.FirstName;
                }
                else
                {
                    txtName.Text = objCustomer.FirstName;
                }
                //txtLastName.Text = objCustomer.LastName;
                txtPhone1.Text = objCustomer.PhoneNo1;
                txtPhone2.Text = objCustomer.PhoneNo2;
                txtEmail.Text = objCustomer.Email;
                txtAddress.Text = objCustomer.FlatNo;
                txtAddress.Text = objCustomer.AddressOther;
                //txtSociety.Text = objCustomer.Society;
                //txtLandmark.Text = objCustomer.Landmark;
                //txtCity.Text = objCustomer.City;
                //txtState.Text = objCustomer.State;
                //txtCountry.Text = objCustomer.Country;
            }

            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.followUpTable;
            dgvfollowUps.DataSource = bSource;
            dgvfollowUps.Columns["Id"].Visible = false;
            dgvfollowUps.Columns["LeadId"].Visible = false;
            dgvfollowUps.Columns["Date"].DisplayIndex = 1;
            dgvfollowUps.Columns["FollowUpBy"].DisplayIndex = 2;
            dgvfollowUps.Columns["ShownBy"].DisplayIndex = 3;
            dgvfollowUps.Columns["ReminderDate"].DisplayIndex = 4;
            dgvfollowUps.Columns["Comment"].DisplayIndex = 5;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPropType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var followUpDateValue = followUpDate.Value;
            var followUpBy = txtFollowUpBy.Text;
            var nextReminderDate = reminderDate.Value;
            var comment = txtFollowUpComment.Text;
            var shownBy = txtShownBy.Text;
            bool rowExists = false;
            foreach (DataRow row in followUpTable.Rows)
            {
                if(row["Date"].ToString() == followUpDateValue.ToString("dd'/'MM'/'yyyy") && row["followUpBy"].ToString() == followUpBy && row["ReminderDate"].ToString() == nextReminderDate.ToString("dd'/'MM'/'yyyy")
                    && row["Comment"].ToString() == comment)
                {
                    rowExists = true;
                    MessageBox.Show("Same follow up can not be added again.", "Lead", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }

            if (!rowExists)
            {
                DataRow row = followUpTable.NewRow();
                row["Id"] = 0;
                row["LeadId"] = this.leadId;
                row["Date"] = followUpDateValue.ToString("dd'/'MM'/'yyyy");
                row["Comment"] = comment;
                row["FollowUpBy"] = followUpBy;
                row["ShownBy"] = shownBy;
                row["ReminderDate"] = nextReminderDate.ToString("dd'/'MM'/'yyyy");
                //followUpTable.Rows.In((0, this.leadId, followUpDateValue.ToString("dd/MM/yyyy"), comment, followUpBy, nextReminderDate.ToString("dd/MM/yyyy")), 0);
                followUpTable.Rows.InsertAt(row, 0);
            }
        }

        private void cmbPropType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //if (!cmbPropSubType.Items.Contains("Apartment"))
            //{
            //    cmbPropSubType.Items.Add("Apartment");
            //}
            //if (!cmbPropSubType.Items.Contains("Row House"))
            //{
            //    cmbPropSubType.Items.Add("Row House");
            //}
            //if (!cmbPropSubType.Items.Contains("Bunglow"))
            //{
            //    cmbPropSubType.Items.Add("Bunglow");
            //}
            //if (!cmbPropSubType.Items.Contains("Pent House"))
            //{
            //    cmbPropSubType.Items.Add("Pent House");
            //}
            //if (!cmbPropSubType.Items.Contains("PG"))
            //{
            //    cmbPropSubType.Items.Add("PG");
            //}
            //if (!cmbPropSubType.Items.Contains("Shop"))
            //{
            //    cmbPropSubType.Items.Add("Shop");
            //}
            //if (!cmbPropSubType.Items.Contains("Showroom"))
            //{
            //    cmbPropSubType.Items.Add("Showroom");
            //}
            //if (!cmbPropSubType.Items.Contains("Office Space"))
            //{
            //    cmbPropSubType.Items.Add("Office Space");
            //}
            //if (!cmbPropSubType.Items.Contains("Godown/Warehouse"))
            //{
            //    cmbPropSubType.Items.Add("Godown/Warehouse");
            //}

            //if (!cmbPropSubType.Items.Contains("N.A. Plot"))
            //{
            //    cmbPropSubType.Items.Add("N.A. Plot");
            //}
            //if (!cmbPropSubType.Items.Contains("R-Zone Plot"))
            //{
            //    cmbPropSubType.Items.Add("R-Zone Plot");
            //}
            //if (!cmbPropSubType.Items.Contains("Agriculture Plot"))
            //{
            //    cmbPropSubType.Items.Add("Agriculture Plot");
            //}
            //if (!cmbPropSubType.Items.Contains("Industrial Plot"))
            //{
            //    cmbPropSubType.Items.Add("Industrial Plot");
            //}

            if (cmbPropType.SelectedValue.ToString() == "Residential")
            {
                if (cmbTransaction.SelectedItem != null && cmbTransaction.SelectedItem.ToString() == "Rent")
                {
                    lblRequiredRentFor.Visible = true;
                    cbFamily.Visible = true;
                    cbBachelor.Visible = true;
                    cbStudent.Visible = true;
                }else if (cmbTransaction.SelectedItem != null && cmbTransaction.SelectedItem.ToString() == "Rent")
                {
                    lblRequiredRentFor.Visible = false;
                    cbFamily.Visible = false;
                    cbBachelor.Visible = false;
                    cbStudent.Visible = false;
                }

                lblNoOfBedrooms.Visible = true;
                cb1HK.Visible = true;
                cb1BHK.Visible = true;
                cb15BHK.Visible = true;
                cb2BHK.Visible = true;
                cb25BHK.Visible = true;
                cb3BHK.Visible = true;
                cb4BHK.Visible = true;

                cmbPropSubType.DataSource = propertyTypeDAL.GetDistinctPropertySubTypes(cmbPropType.SelectedValue.ToString());
                cmbPropSubType.DisplayMember = "propertysubtype";
                cmbPropSubType.ValueMember = "propertysubtype";
                //cmbPropSubType.Items.Remove("Shop");
                //cmbPropSubType.Items.Remove("Showroom");
                //cmbPropSubType.Items.Remove("Office Space");
                //cmbPropSubType.Items.Remove("Godown/Warehouse");
                //cmbPropSubType.Items.Remove("N.A. Plot");
                //cmbPropSubType.Items.Remove("R-Zone Plot");
                //cmbPropSubType.Items.Remove("Agriculture Plot");
                //cmbPropSubType.Items.Remove("Industrial Plot");
            }
            else if (cmbPropType.SelectedValue.ToString() == "Commercial")
            {
                lblRequiredRentFor.Visible = false;
                cbFamily.Visible = false;
                cbBachelor.Visible = false;
                cbStudent.Visible = false;
                lblNoOfBedrooms.Visible = false;
                cb1HK.Visible = false;
                cb1BHK.Visible = false;
                cb15BHK.Visible = false;
                cb2BHK.Visible = false;
                cb25BHK.Visible = false;
                cb3BHK.Visible = false;
                cb4BHK.Visible = false;
                cmbPropSubType.DataSource = propertyTypeDAL.GetDistinctPropertySubTypes(cmbPropType.SelectedValue.ToString());
                cmbPropSubType.DisplayMember = "propertysubtype";
                cmbPropSubType.ValueMember = "propertysubtype";
                //cmbPropSubType.Items.Remove("Apartment");
                //cmbPropSubType.Items.Remove("Row House");
                //cmbPropSubType.Items.Remove("Bunglow");
                //cmbPropSubType.Items.Remove("Pent House");
                //cmbPropSubType.Items.Remove("PG");
                //cmbPropSubType.Items.Remove("N.A. Plot");
                //cmbPropSubType.Items.Remove("R-Zone Plot");
                //cmbPropSubType.Items.Remove("Agriculture Plot");
                //cmbPropSubType.Items.Remove("Industrial Plot");
            }
            else if (cmbPropType.SelectedValue.ToString() == "Plots")
            {
                lblRequiredRentFor.Visible = false;
                cbFamily.Visible = false;
                cbBachelor.Visible = false;
                cbStudent.Visible = false;
                lblNoOfBedrooms.Visible = false;
                cb1HK.Visible = false;
                cb1BHK.Visible = false;
                cb15BHK.Visible = false;
                cb2BHK.Visible = false;
                cb25BHK.Visible = false;
                cb3BHK.Visible = false;
                cb4BHK.Visible = false;
                cmbPropSubType.DataSource = propertyTypeDAL.GetDistinctPropertySubTypes(cmbPropType.SelectedValue.ToString());
                cmbPropSubType.DisplayMember = "propertysubtype";
                cmbPropSubType.ValueMember = "propertysubtype";
                //cmbPropSubType.Items.Remove("Apartment");
                //cmbPropSubType.Items.Remove("Row House");
                //cmbPropSubType.Items.Remove("Bunglow");
                //cmbPropSubType.Items.Remove("Pent House");
                //cmbPropSubType.Items.Remove("PG");
                //cmbPropSubType.Items.Remove("Shop");
                //cmbPropSubType.Items.Remove("Showroom");
                //cmbPropSubType.Items.Remove("Office Space");
                //cmbPropSubType.Items.Remove("Godown/Warehouse");
            }

            if (cmbPropSubType.Items.Count > 0)
            {
                cmbPropSubType.SelectedIndex = 0;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var followUpDateValue = followUpDate.Value;
            var followUpBy = txtFollowUpBy.Text;
            var nextReminderDate = reminderDate.Value;
            var comment = txtFollowUpComment.Text;
            var shownBy = txtShownBy.Text;
            var status = cmbFollowupStatus.SelectedItem.ToString();
            var index = txtRowIndex.Text != "" ? Convert.ToInt32(txtRowIndex.Text) : 0;

            bool rowExists = false;
            foreach (DataRow row in followUpTable.Rows)
            {
                if (row["Date"].ToString() == followUpDateValue.ToString("dd'/'MM'/'yyyy") && row["followUpBy"].ToString() == followUpBy && row["ReminderDate"].ToString() == nextReminderDate.ToString("dd'/'MM'/'yyyy")
                    && row["Comment"].ToString() == comment && row["Status"].ToString() == status)
                {
                    rowExists = true;
                    MessageBox.Show("Same follow up can not be added again.", "Lead", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }

            if (!rowExists)
            {
                if (index == 0)
                {
                    DataRow row = followUpTable.NewRow();
                    row["Id"] = 0;
                    row["LeadId"] = this.leadId;
                    row["Date"] = followUpDateValue.ToString("dd'/'MM'/'yyyy");
                    row["Comment"] = comment;
                    row["FollowUpBy"] = followUpBy;
                    row["ShownBy"] = shownBy;
                    row["ReminderDate"] = nextReminderDate.ToString("dd'/'MM'/'yyyy");
                    row["Status"] = status;
                    //followUpTable.Rows.In((0, this.leadId, followUpDateValue.ToString("dd/MM/yyyy"), comment, followUpBy, nextReminderDate.ToString("dd/MM/yyyy")), 0);
                    followUpTable.Rows.InsertAt(row, 0);
                }
                else
                {
                    DataRow row = followUpTable.Rows.Cast<DataRow>()
                                    .Where(r => r["Id"].ToString().Equals(index.ToString()))
                                    .First();

                    row["Date"] = followUpDateValue.ToString("dd'/'MM'/'yyyy");
                    row["Comment"] = comment;
                    row["FollowUpBy"] = followUpBy;
                    row["ShownBy"] = shownBy;
                    row["ReminderDate"] = nextReminderDate.ToString("dd'/'MM'/'yyyy");
                    row["Status"] = status;
                }
            }
        }

        private void clbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox locations = (ListBox)sender;
            string txtLoc = string.Empty;
            foreach (string loc in clbLocations.CheckedItems)
            {
                if (txtLoc == "")
                    txtLoc = loc;
                else
                    txtLoc = txtLoc + ", " + loc;
            }
            txtLocation.Text = txtLoc;
        }

        private void cmbBroker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBroker.SelectedValue.ToString() != "")
            {
                if (brokerDAL == null)
                {
                    brokerDAL = new BrokerDAL();
                }

                Broker broker = brokerDAL.GetBroker(cmbBroker.SelectedValue.ToString());
                if (broker != null)
                {
                    txtPhone1.Text = broker.PhoneNo1;
                    txtPhone2.Text = broker.PhoneNo2;
                    txtEmail.Text = broker.Email;
                }
            }
            else
            {
                txtPhone1.Text = "";
                txtPhone2.Text = "";
                txtEmail.Text = "";
            }
        }

        private void cbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSource.SelectedValue != null && cbSource.SelectedValue.ToString() == "Broker")
            {
                if (brokerDAL == null)
                {
                    brokerDAL = new BrokerDAL();
                }

                if (cmbBroker == null)
                {
                    cmbBroker = new ComboBox();
                    brokersData = brokerDAL.GetBrokers();
                    cmbBroker.DataSource = brokersData;
                    cmbBroker.DisplayMember = "Name";
                    cmbBroker.ValueMember = "Name";
                    DataRow row = brokersData.NewRow();
                    row["Name"] = "";
                    brokersData.Rows.InsertAt(row, 0);

                    cmbBroker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    cmbBroker.Location = new System.Drawing.Point(62, 25);
                    cmbBroker.Size = new System.Drawing.Size(196, 21);
                    cmbBroker.Name = "cmbBroker";
                    Controls.Add(cmbBroker);
                    cmbBroker.SelectedIndexChanged += cmbBroker_SelectedIndexChanged;
                    cmbBroker.Parent = grpbPersonal;
                }
                else
                {
                    cmbBroker.SelectedIndex = 0;
                    cmbBroker.Visible = true;
                    //txtPhone1.Text = "";
                    //txtPhone2.Text = "";
                    //txtEmail.Text = "";
                }

                groupBox1.Text = "Broker Details";
                this.txtName.Visible = false;
            }
            else
            {
                //txtPhone1.Text = "";
                //txtPhone2.Text = "";
                //txtEmail.Text = "";
                groupBox1.Text = "Owner Details";
                if (cmbBroker != null)
                {
                    cmbBroker.Visible = false;
                }
                this.txtName.Visible = true; ;
            }
        }

        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void grpbPersonal_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.LightGray, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 10);
            gfx.DrawLine(p, 0, 5, 0, 5);
            gfx.DrawLine(p, 80, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        private void gbSelectedLocation_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.LightGray, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 10);
            gfx.DrawLine(p, 0, 5, 0, 5);
            gfx.DrawLine(p, 80, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.LightGray, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 10);
            gfx.DrawLine(p, 0, 5, 0, 5);
            gfx.DrawLine(p, 80, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        private void cmbTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransaction.SelectedItem.ToString() == "Rent")
            {
                lblRequiredRentFor.Visible = true;
                cbFamily.Visible = true;
                cbBachelor.Visible = true;
                cbStudent.Visible = true;
            }
            else if (cmbTransaction.SelectedItem.ToString() == "Buy")
            {
                lblRequiredRentFor.Visible = false;
                cbFamily.Visible = false;
                cbBachelor.Visible = false;
                cbStudent.Visible = false;
            }
        }

        private void txtPhone1_Leave(object sender, EventArgs e)
        {
            bool isBroker = false;
            if(cbSource.SelectedValue != null)
            {
                if(cbSource.SelectedValue.ToString() == "Broker")
                {
                    isBroker = true;
                }
                else
                {
                    isBroker = false;
                }
            }

            if (!isBroker)
            {
                string phoneno = txtPhone1.Text;
                if (!string.IsNullOrEmpty(phoneno))
                {
                    using (CustomerDAL objDAL = new CustomerDAL())
                    {
                        objCustomer = objDAL.GetCustomer(0, phoneno);
                    }

                    if (objCustomer != null)
                    {
                        objLead = leadDALObj.GetLead(0, objCustomer.Id);
                        this.leadId = objLead != null ? objLead.Id : 0;
                    }

                    if (objLead != null)
                    {
                        using (LeadFollowUpDAL objDAL = new LeadFollowUpDAL())
                        {
                            this.followUpTable = objDAL.GetLeadFollowUps(objLead.Id);
                        }
                    }

                    if (objCustomer != null && objLead != null)
                    {
                        DialogResult dr = MessageBox.Show("Lead already present with this phone no, do you want to open?", "Lead", MessageBoxButtons.YesNo);
                        if (dr.ToString() == "Yes")
                        {
                            LoadDataInControls();
                        }
                    }
                }
            }
        }

        private void dgvfollowUps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvfollowUps.BeginEdit(false);
            //editGridCellComboBox.DropDownHeight = 170;
            //editGridCellComboBox.DroppedDown = true;
            if (e.ColumnIndex > -1)
            {
                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();

                // Check the column  cell, in which it click.  
                if (dgvfollowUps.Columns[e.ColumnIndex].Name.Contains("Status"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    dgvfollowUps[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    string[] status = { "Open", "Close"};
                    l_objGridDropbox.Items.Add("Open");
                    l_objGridDropbox.Items.Add("Close");
                    //GetDescriptionTable(); // Bind combobox with datasource.  
                    //l_objGridDropbox.ValueMember = "Description";
                    //l_objGridDropbox.DisplayMember = "Description";

                }
            }
        }

        private void dgvfollowUps_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                editGridCellComboBox = (ComboBox)e.Control;
                if ((editGridCellComboBox != null))
                {
                    editGridCellComboBox.SelectedIndexChanged += editGridCellComboBox_SelectedIndexChanged;
                }
            }
            catch (Exception)
            {
            }            
        }

        private void editGridCellComboBox_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (editGridCellComboBox.SelectedItem != null)
            {
                editGridCellComboBox.SelectedIndexChanged -= editGridCellComboBox_SelectedIndexChanged;
                if (dgvfollowUps.Columns[dgvfollowUps.CurrentCell.ColumnIndex].Name.Equals("Status"))
                {
                    try
                    {
                        string newStatus = dgvfollowUps.Rows[dgvfollowUps.CurrentRow.Index].Cells[dgvfollowUps.CurrentCell.ColumnIndex].EditedFormattedValue.ToString();
                        followUpTable.Rows[dgvfollowUps.CurrentRow.Index][dgvfollowUps.CurrentCell.ColumnIndex] = newStatus;
                        //string Description = ((DataRowView)editGridCellComboBox.SelectedItem).Row["Status"].ToString();
                        //string Type = ((DataRowView)editGridCellComboBox.SelectedItem).Row["Type"].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Follow Up",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    
                }

                editGridCellComboBox.SelectedIndexChanged += editGridCellComboBox_SelectedIndexChanged;
            }
        }

        private void dgvfollowUps_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvfollowUps.SelectedRows.Count > 0 && dgvfollowUps.Rows.Count != (dgvfollowUps.SelectedRows[0].Index + 1))
            {
                txtRowIndex.Text = dgvfollowUps.SelectedRows[0].Cells["Id"].Value.ToString();
                //dgvfollowUps.SelectedRows[0].Cells[["LeadId"]
                followUpDate.Value = Convert.ToDateTime(dgvfollowUps.SelectedRows[0].Cells["Date"].Value.ToString()); // = followUpDateValue.ToString("dd'/'MM'/'yyyy");
                txtFollowUpComment.Text = dgvfollowUps.SelectedRows[0].Cells["Comment"].Value.ToString();
                txtFollowUpBy.Text = dgvfollowUps.SelectedRows[0].Cells["FollowUpBy"].Value.ToString();
                txtShownBy.Text = dgvfollowUps.SelectedRows[0].Cells["ShownBy"].Value.ToString();
                reminderDate.Value = Convert.ToDateTime(dgvfollowUps.SelectedRows[0].Cells["ReminderDate"].Value.ToString());
                cmbFollowupStatus.SelectedItem = dgvfollowUps.SelectedRows[0].Cells["Status"].Value.ToString();
            }
            else
            {
                followUpDate.CustomFormat = "dd'/'MM'/'yyyy";
                reminderDate.CustomFormat = "dd'/'MM'/'yyyy";
                txtFollowUpBy.Text = "";
                txtShownBy.Text = "";
                reminderDate.Value = DateTime.Now;
                followUpDate.Value = DateTime.Now;
                txtFollowUpComment.Text = "";
                txtRowIndex.Text = "0";
                cmbFollowupStatus.SelectedIndex = 0;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            followUpDate.CustomFormat = "dd'/'MM'/'yyyy";
            reminderDate.CustomFormat = "dd'/'MM'/'yyyy";
            txtFollowUpBy.Text = "";
            txtShownBy.Text = "";
            reminderDate.Value = DateTime.Now;
            followUpDate.Value = DateTime.Now;
            txtFollowUpComment.Text = "";
            txtRowIndex.Text = "0";
            cmbFollowupStatus.SelectedIndex = 0;
            dgvfollowUps.ClearSelection();
        }
    }
}
