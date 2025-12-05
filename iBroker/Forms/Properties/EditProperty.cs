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

namespace iBroker.Forms.Properties
{
    public partial class EditProperty : Form
    {
        private int propertyId = 0;
        private Property objProperty = null;
        private Customer objCustomer = null;
        //private DataTable followUpTable;
        private PropertyDAL propertyDALObj;
        private LocationDAL locationDAL;
        private SourceDAL sourceDAL;
        private SocietyDAL societyDAL;
        private BrokerDAL brokerDAL;
        private ComboBox cmbBroker;
        private DataTable brokersData;

        public EditProperty()
        {
            InitializeComponent();
        }

        public EditProperty(int propertyId)
        {
            this.propertyId = propertyId;
            using (PropertyDAL objDAL = new PropertyDAL())
            {
                this.objProperty = objDAL.GetProperty(propertyId);
            }

            using (OwnerDAL objDAL = new OwnerDAL())
            {
                objCustomer = objDAL.GetCustomer(objProperty.OwnerId);
            }

            //using (LeadFollowUpDAL objDAL = new LeadFollowUpDAL())
            //{
            //    this.followUpTable = objDAL.GetLeadFollowUps(leadId);
            //}

            InitializeComponent();

            //BindingSource bSource = new BindingSource();
            //bSource.DataSource = this.followUpTable;
            //dgvfollowUps.DataSource = bSource;
            //dgvfollowUps.Columns["Id"].Visible = false;
            //dgvfollowUps.Columns["LeadId"].Visible = false;
            //dgvfollowUps.Columns["Date"].DisplayIndex = 1;
            //dgvfollowUps.Columns["FollowUpBy"].DisplayIndex = 2;
            //dgvfollowUps.Columns["ShownBy"].DisplayIndex = 3;
            //dgvfollowUps.Columns["ReminderDate"].DisplayIndex = 4;
            //dgvfollowUps.Columns["Comment"].DisplayIndex = 5;
        }

        private void EditProperty_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> floors = new Dictionary<int, string>();
            floors.Add(-1, "Stilt Floor");
            floors.Add(0, "Ground Floor");
            floors.Add(1, "1");
            floors.Add(2, "2");
            floors.Add(3, "3");
            floors.Add(4, "4");
            floors.Add(5, "5");
            floors.Add(6, "6");
            floors.Add(7, "7");
            floors.Add(8, "8");
            floors.Add(9, "9");
            floors.Add(10, "10");
            floors.Add(11, "11");
            floors.Add(12, "12");
            floors.Add(13, "13");
            floors.Add(14, "14");
            floors.Add(15, "15");
            floors.Add(16, "16");
            floors.Add(17, "17");
            floors.Add(18, "18");
            floors.Add(19, "19");
            floors.Add(20, "20");

            cmbTotalFloor.DataSource = new BindingSource(floors, null);
            cmbTotalFloor.DisplayMember = "Value";
            cmbTotalFloor.ValueMember = "Key";

            cmbPropertyFloor.DataSource = new BindingSource(floors, null);
            cmbPropertyFloor.DisplayMember = "Value";
            cmbPropertyFloor.ValueMember = "Key";

            sourceDAL = new SourceDAL();
            cbSource.DataSource = sourceDAL.GetSources();
            cbSource.DisplayMember = "Source";
            cbSource.ValueMember = "Source";

            locationDAL = new LocationDAL();
            cmbLocation.DataSource = locationDAL.GetLocations();
            cmbLocation.DisplayMember = "Location";
            cmbLocation.ValueMember = "Location";

            societyDAL = new SocietyDAL();
            cmbSociety.DataSource = societyDAL.GetSocieties();
            cmbSociety.DisplayMember = "SocietyName";
            cmbSociety.ValueMember = "SocietyName";

            propertyDALObj = new PropertyDAL();
            lblPropertyId.Text = (propertyDALObj.GetLatestPropId() + 1).ToString();
            cmbOnlinePublished.SelectedIndex = 1;
            cbActive.Checked = true;
            cbSource.SelectedIndex = 0;
            dateAvailableFrom.CustomFormat = "dd/MM/yyyy";
            dateAvailableFrom.Value = DateTime.Now;
            registrationDate.CustomFormat = "dd/MM/yyyy";
            registrationDate.Value = DateTime.Now;
            cmbPropSubType.Items.Add("Apartment");
            cmbPropSubType.Items.Add("Row House");
            cmbPropSubType.Items.Add("Bunglow");
            cmbPropSubType.Items.Add("Pent House");
            cmbPropSubType.Items.Add("PG");
            cmbPropSubType.Items.Add("Shop");
            cmbPropSubType.Items.Add("Showroom");
            cmbPropSubType.Items.Add("Office Space");
            cmbPropSubType.Items.Add("Godown/Warehouse");

            cmbPropSubType.SelectedIndex = 0;
            cmbTransaction.SelectedIndex = 0;
            cmbPropType.SelectedIndex = 0;
            cmbCarpetAreaUnit.SelectedIndex = 0;
            cmbBuiltUpAreaUnit.SelectedIndex = 0;
            cmbSuperBuiltUpAreaUnit.SelectedIndex = 0;
            string[] direction = { "", "East", "West", "North", "Sourth" };
            cmbMainDoorDirection.DataSource = direction;
            cmbMainDoorDirection.SelectedIndex = 0;

            if(objProperty != null)
            {
                lblPropertyId.Text = objProperty.Id.ToString();
                registrationDate.Value = Convert.ToDateTime(!string.IsNullOrEmpty(objProperty.CreatedDate) ? objProperty.CreatedDate : DateTime.Now.ToString());

                txtFlatNo.Text = objProperty.FlatNo;
                cmbSociety.SelectedValue = objProperty.Society;
                txtLandmark.Text = objProperty.Landmark;
                cmbLocation.SelectedValue = objProperty.Location;
                txtCity.Text = objProperty.City;
                txtPincode.Text = objProperty.Pincode;
                //txtState.Text = objProperty.State;
                //txtCountry.Text = objProperty.Country;
                txtOtherAddress.Text = objProperty.OtherAddress;
                
                cbActive.Checked = objProperty.IsActive;
                cmbTransaction.SelectedItem = objProperty.TransactionType;
                cmbPropType.SelectedItem = objProperty.PropertyType;
                cmbPropSubType.SelectedItem = objProperty.PropertySubType;
                txtBathrooms.Text = objProperty.BathroomCount.ToString();
                txtBalconies.Text = objProperty.BalconyCount.ToString();
                txtCoveredParking.Text = objProperty.CoveredParkingCount.ToString();
                txtOpenParking.Text = objProperty.OpenParkingCount.ToString();
                cmbTotalFloor.SelectedValue = objProperty.TotalFloor;
                cmbPropertyFloor.SelectedValue = objProperty.PropertyFloor;
                txtCarpetArea.Text = objProperty.CarpetArea.ToString();
                cmbCarpetAreaUnit.SelectedItem = objProperty.CarpetAreaUnit;
                txtBuiltUpArea.Text = objProperty.BuiltUpArea.ToString();
                cmbBuiltUpAreaUnit.SelectedItem = objProperty.BuiltUpAreaUnit;
                txtSuperBuiltUpArea.Text = objProperty.SuperBuiltUpArea.ToString();
                cmbSuperBuiltUpAreaUnit.SelectedItem = objProperty.SuperBuiltUpAreaUnit;
                txtPropertyAge.Text = objProperty.PropertyAgeYear.ToString();
                dateAvailableFrom.Value = Convert.ToDateTime(objProperty.AvailableRentFrom);
                txtKeyPlacedAt.Text = objProperty.KeyPlacedAt;
                cbKeyWithUs.Checked = objProperty.KeyPlacedAt != null ? (objProperty.KeyPlacedAt.ToLower() == "with us") : false;
                cmbOnlinePublished.SelectedItem = objProperty.OnlinePublished ? "Yes" : "No";

                rbUnderConstruction.Checked = (objProperty.ConstructionStatus != null && objProperty.ConstructionStatus.Contains("UnderConstruction"));
                rbReadyToMove.Checked = (objProperty.ConstructionStatus != null && objProperty.ConstructionStatus.Contains("ReadyToMove"));
                if (objProperty.ConstructionStatus != null && objProperty.ConstructionStatus.Contains("UnderConstruction"))
                {
                    txtPropertyAge.Text = objProperty.PossessionInYears.ToString();
                }

                txtPropertyAgeRent.Text = objProperty.TransactionType == "Rent" ? objProperty.PropertyAgeYear.ToString() : "";
                txtPropertyAge.Text = objProperty.PropertyAgeYear.ToString();
                txtRentSellingPrice.Text = objProperty.TransactionType == "Sell" ? objProperty.SellingPrice.ToString() : objProperty.RentPerMonth.ToString();
                txtDeposit.Text = objProperty.Deposit.ToString();
                cmbLocation.SelectedValue = objProperty.Location;
                
                txtRemark.Text = objProperty.Remark;
                cbSource.SelectedValue = objProperty.Source;
                cbCommercialUse.Checked = objProperty.CommercialUse;
                cmbBalconyFacing.SelectedItem = objProperty.BalconyFacing;
                cmbMainDoorDirection.SelectedItem = objProperty.MainDoorDirection;
                cbBrokerageAgreed.Checked = objProperty.BrokerageAgreed;
                txtBrokerageDetail.Text = objProperty.BrokerageDetail;

                if (objProperty.Bedrooms != null)
                {
                    rb1HK.Checked = objProperty.Bedrooms.Contains("0") ? true : false;
                    rb15BHK.Checked = objProperty.Bedrooms.Contains("1.5") ? true : false;
                    rb1BHK.Checked = ((objProperty.Bedrooms.Contains("1") && !objProperty.Bedrooms.Contains("1.")) || objProperty.Bedrooms.Contains("1,")) ? true : false;
                    //rb1BHK.Checked = objProperty.Bedrooms.Contains("1") ? true : false;
                    rb25BHK.Checked = objProperty.Bedrooms.Contains("2.5") ? true : false;
                    rb2BHK.Checked = ((objProperty.Bedrooms.Contains("2") && !objProperty.Bedrooms.Contains("2.")) || objProperty.Bedrooms.Contains("2,")) ? true : false;
                    rb3BHK.Checked = objProperty.Bedrooms.Contains("3") ? true : false;
                    rb4BHK.Checked = objProperty.Bedrooms.Contains("4") ? true : false;
                }
                if (objProperty.FurnitureStatus != null)
                {
                    rbFullyFurnished.Checked = objProperty.FurnitureStatus.Contains("FullyFurnished") ? true : false;
                    rbSemiFurnished.Checked = objProperty.FurnitureStatus.Contains("SemiFurnished") ? true : false;
                    rbNonFurnished.Checked = objProperty.FurnitureStatus.Contains("NonFurnished") ? true : false;
                }
                if (objProperty.WillingRentFor != null)
                {
                    cbFamily.Checked = objProperty.WillingRentFor.Contains("Family") ? true : false;
                    cbBachelor.Checked = objProperty.WillingRentFor.Contains("Bachelor") ? true : false;
                    cbStudent.Checked = objProperty.WillingRentFor.Contains("Student") ? true : false;
                }
                if (objCustomer != null)
                {
                    if(objProperty.Source == "Broker")
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
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPropType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbPropSubType.Items.Contains("Apartment"))
            {
                cmbPropSubType.Items.Add("Apartment");
            }
            if (!cmbPropSubType.Items.Contains("Row House"))
            {
                cmbPropSubType.Items.Add("Row House");
            }
            if (!cmbPropSubType.Items.Contains("Bunglow"))
            {
                cmbPropSubType.Items.Add("Bunglow");
            }
            if (!cmbPropSubType.Items.Contains("Pent House"))
            {
                cmbPropSubType.Items.Add("Pent House");
            }
            if (!cmbPropSubType.Items.Contains("PG"))
            {
                cmbPropSubType.Items.Add("PG");
            }
            if (!cmbPropSubType.Items.Contains("Shop"))
            {
                cmbPropSubType.Items.Add("Shop");
            }
            if (!cmbPropSubType.Items.Contains("Showroom"))
            {
                cmbPropSubType.Items.Add("Showroom");
            }
            if (!cmbPropSubType.Items.Contains("Office Space"))
            {
                cmbPropSubType.Items.Add("Office Space");
            }
            if (!cmbPropSubType.Items.Contains("Godown/Warehouse"))
            {
                cmbPropSubType.Items.Add("Godown/Warehouse");
            }

            if (cmbPropType.SelectedItem.ToString() == "Residential")
            {
                lblNoOfBedroom.Visible = true;
                rb1HK.Visible = true;
                rb1BHK.Visible = true;
                rb15BHK.Visible = true;
                rb2BHK.Visible = true;
                rb25BHK.Visible = true;
                rb3BHK.Visible = true;
                rb4BHK.Visible = true;
                if (cmbTransaction.SelectedItem.ToString() == "Sell")
                {
                    lblWillingToRent.Visible = false;
                    cbFamily.Visible = false;
                    cbBachelor.Visible = false;
                    cbStudent.Visible = false;
                }
                else
                {
                    lblWillingToRent.Visible = true;
                    cbFamily.Visible = true;
                    cbBachelor.Visible = true;
                    cbStudent.Visible = true;
                }
                    
                cmbPropSubType.Items.Remove("Shop");
                cmbPropSubType.Items.Remove("Showroom");
                cmbPropSubType.Items.Remove("Office Space");
                cmbPropSubType.Items.Remove("Godown/Warehouse");
                cbCommercialUse.Visible = true;
            }
            else if (cmbPropType.SelectedItem.ToString() == "Commercial")
            {
                lblNoOfBedroom.Visible = false;
                rb1HK.Visible = false;
                rb1BHK.Visible = false;
                rb15BHK.Visible = false;
                rb2BHK.Visible = false;
                rb25BHK.Visible = false;
                rb3BHK.Visible = false;
                rb4BHK.Visible = false;
                lblWillingToRent.Visible = false;
                cbFamily.Visible = false;
                cbBachelor.Visible = false;
                cbStudent.Visible = false;
                cmbPropSubType.Items.Remove("Apartment");
                cmbPropSubType.Items.Remove("Row House");
                cmbPropSubType.Items.Remove("Bunglow");
                cmbPropSubType.Items.Remove("Pent House");
                cmbPropSubType.Items.Remove("PG");
                cbCommercialUse.Visible = false;
            }

            cmbPropSubType.SelectedIndex = 0;
        }

        private void cmbTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTransaction.SelectedItem.ToString() == "Sell")
            {
                sellPanel.Visible = true;
                rentPanel.Visible = false;
                lblPrice.Text = "Selling Price";
                lblPerMonth.Visible = false;
                lblDeposit.Visible = false;
                txtDeposit.Visible = false;
                lblWillingToRent.Visible = false;
                cbFamily.Visible = false;
                cbBachelor.Visible = false;
                cbStudent.Visible = false;
            }
            else
            {
                sellPanel.Visible = false;
                rentPanel.Visible = true;
                lblPrice.Text = "Expected Rent";
                lblPerMonth.Visible = true;
                lblDeposit.Visible = true;
                txtDeposit.Visible = true;
                if (cmbPropType.SelectedItem != null && cmbPropType.SelectedItem.ToString() == "Residential")
                {
                    lblWillingToRent.Visible = true;
                    cbFamily.Visible = true;
                    cbBachelor.Visible = true;
                    cbStudent.Visible = true;
                }else if(cmbPropType.SelectedItem != null && cmbPropType.SelectedItem.ToString() == "Commercial")
                {
                    lblWillingToRent.Visible = false;
                    cbFamily.Visible = false;
                    cbBachelor.Visible = false;
                    cbStudent.Visible = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPhone1.Text.Length > 10 || txtPhone1.Text.Length < 10)
            {
                MessageBox.Show("Invalid phone no1, Please enter 10 digit phone no", "Property", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPhone2.Text.Length > 0 && (txtPhone2.Text.Length > 10 || txtPhone2.Text.Length < 10))
            {
                MessageBox.Show("Invalid phone no2, Please enter 10 digit phone no", "Property", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Customer customer = new Customer
            {
                 FirstName = txtName.Text,
                 PhoneNo1 = txtPhone1.Text,
                 PhoneNo2 = txtPhone2.Text,
                 Email = txtEmail.Text
            };

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

            Property property = new Property
            {
                FlatNo = txtFlatNo.Text,
                //Society = cmbSociety.SelectedValue !=null ? cmbSociety.SelectedValue.ToString() : "",
                Landmark = txtLandmark.Text,
                //Location = cmbLocation.SelectedValue != null ? cmbLocation.SelectedValue.ToString() : null,
                City = txtCity.Text,
                Pincode = txtPincode.Text,
                //State = txtState.Text,
                //Country = txtCountry.Text,
                OtherAddress = txtOtherAddress.Text,

                CreatedDate = registrationDate.Value.ToString("dd'/'MM'/'yyyy"),
                TransactionType = cmbTransaction.SelectedItem != null ? cmbTransaction.SelectedItem.ToString() : null,
                PropertyType = cmbPropType.SelectedItem != null ? cmbPropType.SelectedItem.ToString() : null,
                PropertySubType = cmbPropSubType.SelectedItem != null ? cmbPropSubType.SelectedItem.ToString() : null,
                BathroomCount = string.IsNullOrEmpty(txtBathrooms.Text.Trim()) ? 0 : Convert.ToInt32(txtBathrooms.Text),
                BalconyCount = string.IsNullOrEmpty(txtBalconies.Text.Trim()) ? 0 : Convert.ToInt32(txtBalconies.Text),
                CoveredParkingCount = string.IsNullOrEmpty(txtCoveredParking.Text.Trim()) ? 0 : Convert.ToInt32(txtCoveredParking.Text),
                OpenParkingCount = string.IsNullOrEmpty(txtOpenParking.Text.Trim()) ? 0 : Convert.ToInt32(txtOpenParking.Text),
                
                CarpetArea = string.IsNullOrEmpty(txtCarpetArea.Text.Trim()) ? 0 : Convert.ToInt32(txtCarpetArea.Text),
                CarpetAreaUnit = cmbCarpetAreaUnit.SelectedItem != null ? cmbCarpetAreaUnit.SelectedItem.ToString() : null,
                BuiltUpArea = string.IsNullOrEmpty(txtBuiltUpArea.Text.Trim()) ? 0 : Convert.ToInt32(txtBuiltUpArea.Text),
                BuiltUpAreaUnit = cmbBuiltUpAreaUnit.SelectedItem != null ? cmbBuiltUpAreaUnit.SelectedItem.ToString() : null,
                SuperBuiltUpArea = string.IsNullOrEmpty(txtSuperBuiltUpArea.Text.Trim()) ? 0 : Convert.ToInt32(txtSuperBuiltUpArea.Text),
                SuperBuiltUpAreaUnit = cmbSuperBuiltUpAreaUnit.SelectedItem != null ? cmbSuperBuiltUpAreaUnit.SelectedItem.ToString() : null,
                //AvailableRentFrom = txt
                PropertyAgeYear = string.IsNullOrEmpty(txtPropertyAge.Text.Trim()) ? 0 : Convert.ToInt32(txtPropertyAge.Text),
                //KeyPlacedAt = txtKeyPlacedAt.Text,
                Source = cbSource.SelectedValue != null ? cbSource.SelectedValue.ToString() : null,
                Remark = txtRemark.Text,
                OnlinePublished = cmbOnlinePublished.SelectedItem.ToString() == "No" ? false : true,
                AvailableRentFrom = dateAvailableFrom.Value.ToString("dd'/'MM'/'yyyy"),
                CommercialUse = cbCommercialUse.Checked,
                BalconyFacing = cmbBalconyFacing.SelectedItem != null ? cmbBalconyFacing.SelectedItem.ToString() : "",
                MainDoorDirection = cmbMainDoorDirection.SelectedItem.ToString(),
                BrokerageAgreed = cbBrokerageAgreed.Checked,
                BrokerageDetail = txtBrokerageDetail.Text,
                

                RentPerMonth = cmbTransaction.SelectedItem.ToString() == "Rent" ? (string.IsNullOrEmpty(txtRentSellingPrice.Text.Trim()) ? 0 : Convert.ToInt32(txtRentSellingPrice.Text)) : 0,
                Deposit = string.IsNullOrEmpty(txtDeposit.Text.Trim()) ? 0 : Convert.ToInt32(txtDeposit.Text),
                SellingPrice = cmbTransaction.SelectedItem.ToString() == "Sell" ? (string.IsNullOrEmpty(txtRentSellingPrice.Text.Trim()) ? 0 : Convert.ToInt32(txtRentSellingPrice.Text)) : 0,
                IsActive = cbActive.Checked ? true : false
            };

            try
            {
                property.TotalFloor = cmbTotalFloor.SelectedValue == null ? 0 : Convert.ToInt32(cmbTotalFloor.SelectedValue.ToString());
                property.PropertyFloor = cmbPropertyFloor.SelectedValue == null ? 0 : Convert.ToInt32(cmbPropertyFloor.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Total/Property Floor value.", "Property", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(cmbSociety.SelectedValue != null || cmbSociety.SelectedText != null)
            {
                string society = string.IsNullOrEmpty(cmbSociety.Text) ? (cmbSociety.SelectedValue == null ? "" : cmbSociety.SelectedValue.ToString()) : cmbSociety.Text;
                //string society = cmbSociety.SelectedValue != null ? cmbSociety.SelectedValue.ToString() : cmbSociety.Text;
                property.Society = society;
            }

            if (cmbLocation.SelectedValue != null || cmbLocation.SelectedText != null)
            {
                string location = string.IsNullOrEmpty(cmbLocation.Text) ? (cmbSociety.SelectedValue == null ? "" : cmbLocation.SelectedValue.ToString()) : cmbLocation.Text;
                property.Location = location;
            }


            if (property.TransactionType == "Rent")
            {
                property.PropertyAgeYear = string.IsNullOrEmpty(txtPropertyAgeRent.Text.Trim()) ? 0 : Convert.ToInt32(txtPropertyAgeRent.Text);
            }

            string noOfbedrooms = null;
            if (rb1HK.Checked)
            {
                noOfbedrooms = "0";
            }
            if (rb1BHK.Checked)
            {
                noOfbedrooms = "1";
            }
            if (rb15BHK.Checked)
            {
                noOfbedrooms = "1.5";
            }
            if (rb2BHK.Checked)
            {
                noOfbedrooms = "2";
            }
            if (rb25BHK.Checked)
            {
                noOfbedrooms = "2.5";
            }
            if (rb3BHK.Checked)
            {
                noOfbedrooms = "3";
            }
            if (rb4BHK.Checked)
            {
                noOfbedrooms = "4";
            }
            property.Bedrooms = noOfbedrooms;

            string furnitureStatus = string.Empty;
            if (rbFullyFurnished.Checked)
            {
                furnitureStatus = "FullyFurnished";
            }
            if (rbSemiFurnished.Checked)
            {
                furnitureStatus = "SemiFurnished";
            }
            if (rbNonFurnished.Checked)
            {
                furnitureStatus = "NonFurnished";
            }
            property.FurnitureStatus = furnitureStatus;

            List<string> willingRentTo = new List<string>();
            if (cbFamily.Checked)
            {
                willingRentTo.Add("Family");
            }
            if (cbBachelor.Checked)
            {
                willingRentTo.Add("Bachelor");
            }
            if (cbStudent.Checked)
            {
                willingRentTo.Add("Student");
            }
            property.WillingRentFor = string.Join(",", willingRentTo);

            property.ConstructionStatus = rbReadyToMove.Checked ? "ReadyToMove" : null;
            property.ConstructionStatus = rbUnderConstruction.Checked ? "UnderConstruction" : property.ConstructionStatus;
            property.KeyPlacedAt = cbKeyWithUs.Checked ? "With Us" : txtKeyPlacedAt.Text;

            if (!customer.ValidateCustomerInfo(customer))
            {
                MessageBox.Show("Please enter owner details.", "Property", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Below code updates location and society in master if not present.
            //if (!string.IsNullOrEmpty(property.Location))
            //{
            //    locationDAL.UpdateLocationMaster(property.Location);
            //}

            //if (!string.IsNullOrEmpty(property.Society))
            //{
            //    societyDAL.UpdateSocietyMaster(property.Society);
            //}

            int customerId = 0;
            if (this.propertyId == 0)
            {
                using (OwnerDAL objDAL = new OwnerDAL())
                {
                    customerId = objDAL.Insert(customer);
                }

                property.OwnerId = customerId;
                using (PropertyDAL objDAL = new PropertyDAL())
                {
                    this.propertyId = objDAL.Insert(property);
                }

                MessageBox.Show("Property saved successfully.", "Property", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                property.Id = objProperty.Id;
                customer.Id = objCustomer.Id;
                using (OwnerDAL objDAL = new OwnerDAL())
                {
                    customerId = objDAL.Update(customer);
                }

                property.OwnerId = customerId;
                using (PropertyDAL objDAL = new PropertyDAL())
                {
                    this.propertyId = objDAL.Update(property);
                }

                MessageBox.Show("Property saved successfully.", "Property", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtBathrooms_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtBalconies_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCoveredParking_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtOpenParking_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCarpetArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtBuiltUpArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSuperBuiltUpArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPropertyAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRentSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void rbReadyToMove_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReadyToMove.Checked)
            {
                lblPropertyAge.Text = "Property Age";
                lblPropertyAge.Visible = true;
                txtPropertyAge.Visible = true;
                lblYears.Visible = true;
            }
            else
            {
                if (rbUnderConstruction.Checked)
                {
                    lblPropertyAge.Text = "Possession By";
                    lblPropertyAge.Visible = true;
                    txtPropertyAge.Visible = true;
                    lblYears.Visible = true;
                }
                else
                {
                    lblPropertyAge.Visible = false;
                    txtPropertyAge.Visible = false;
                    lblYears.Visible = false;
                }
            }
        }

        private void rbUnderConstruction_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnderConstruction.Checked)
            {
                lblPropertyAge.Text = "Possession By";
                lblPropertyAge.Visible = true;
                txtPropertyAge.Visible = true;
                lblYears.Visible = true;
            }
            else
            {
                if (rbReadyToMove.Checked)
                {
                    lblPropertyAge.Text = "Property Age";
                    //lblPropertyAge.Location.X = 446;
                    lblPropertyAge.Visible = true;
                    txtPropertyAge.Visible = true;
                    lblYears.Visible = true;
                }
                else
                {
                    lblPropertyAge.Visible = false;
                    txtPropertyAge.Visible = false;
                    lblYears.Visible = false;
                }
            }
        }

        private void cmbBroker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBroker.SelectedValue !=null && cmbBroker.SelectedValue.ToString() != "")
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
            if (cbSource.SelectedValue.ToString() == "Broker")
            {
                if(brokerDAL == null)
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
                    cmbBroker.Location = new System.Drawing.Point(75, 29);
                    cmbBroker.Size = new System.Drawing.Size(165, 21);
                    cmbBroker.Name = "cmbBroker";
                    Controls.Add(cmbBroker);
                    cmbBroker.SelectedIndexChanged += cmbBroker_SelectedIndexChanged;
                    cmbBroker.Parent = groupBox1;
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
    }
}
