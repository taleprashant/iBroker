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

namespace iBroker.Forms.Lease
{
    public partial class EditLease : Form
    {
        private int leaseId;
        private LocationDAL locationDAL;
        private SocietyDAL societyDAL;
        private PropertyTypeDAL propertyTypeDAL;
        private LeaseDAL leaseDAL;
        private Entities.Lease objLease;
        private int tenantCount = 1;
        private int maxTenantCount=3;
        private GroupBox grpbTenant2Details;
        private GroupBox grpbTenant3Details;
        private TextBox txtTenant3Phone;
        private TextBox txtTenant3Name;
        private TextBox txtTenant3Email;
        private TextBox txtTenant3Address;
        private TextBox txtTenant3Pan;
        private TextBox txtTenant3AadharNo;
        private Button btnRemoveTenant3;
        private TextBox txtTenant2Phone;
        private TextBox txtTenant2Name;
        private TextBox txtTenant2Email;
        private TextBox txtTenant2Address;
        private TextBox txtTenant2Pan;
        private TextBox txtTenant2AadharNo;
        private Button btnRemoveTenant2;

        public EditLease()
        {
            InitializeComponent();
        }

        public EditLease(int leaseId)
        {
            this.leaseId = leaseId;
            using (LeaseDAL objDAL = new LeaseDAL())
            {
                this.objLease = objDAL.GetLease(leaseId);
            }

            InitializeComponent();
        }

        private void EditLease_Load(object sender, EventArgs e)
        {
            this.ScrollControlIntoView(label24);
            startDate.CustomFormat = "dd/MM/yyyy";
            startDate.Value = DateTime.Now;
            endDate.CustomFormat = "dd/MM/yyyy";
            //endDate.Value = DateTime.Now;
            registrationDate.CustomFormat = "dd/MM/yyyy";
            registrationDate.Value = DateTime.Now;
            leaseDAL = new LeaseDAL();
            lblLeaseId.Text = (leaseDAL.GetLatestLeaseId() +1).ToString();
            cbActive.Checked = true;

            lblEscalation2.Visible = false;
            txtEscalation2.Visible = false;
            btnEscalation2.Visible = false;
            lblEscalation3.Visible = false;
            txtEscalation3.Visible = false;
            btnEscalation3.Visible = false;

            locationDAL = new LocationDAL();
            cmbLocation.DataSource = locationDAL.GetLocations();
            cmbLocation.DisplayMember = "Location";
            cmbLocation.ValueMember = "Location";

            societyDAL = new SocietyDAL();
            cmbSociety.DataSource = societyDAL.GetSocieties();
            cmbSociety.DisplayMember = "SocietyName";
            cmbSociety.ValueMember = "SocietyName";

            propertyTypeDAL = new PropertyTypeDAL();
            cmbPropType.DataSource = propertyTypeDAL.GetDistinctPropertyTypes();
            cmbPropType.DisplayMember = "PropertyType";
            cmbPropType.ValueMember = "PropertyType";

            cmbPropSubType.DataSource = propertyTypeDAL.GetDistinctPropertySubTypes(cmbPropType.SelectedValue.ToString());
            cmbPropSubType.DisplayMember = "propertysubtype";
            cmbPropSubType.ValueMember = "propertysubtype";

            if(this.objLease != null)
            {
                LoadDataInControl();
            }
        }

        private void LoadDataInControl()
        {
            registrationDate.Value = Convert.ToDateTime(objLease.CreatedDate);
            txtOwnerName.Text = objLease.OwnerName;
            txtOwnerPhone.Text = objLease.OwnerPhoneNo;
            txtOwnerEmail.Text = objLease.OwnerEmail;
            txtOwnerPan.Text = objLease.OwnerPAN;
            txtOwnerAadharNo.Text = objLease.OwnerAadharNo;
            txtOwnerAddress.Text = objLease.OwnerAddress;

            txtTenantName.Text= objLease.TenantName;
            txtTenantPhone.Text= objLease.TenantPhoneNo;
            txtTenantEmail.Text= objLease.TenantEmail;
            txtTenantPan.Text = objLease.TenantPAN;
            txtTenantAadharNo.Text = objLease.TenantAadharNo;
            txtTenantAddress.Text = objLease.TenantAddress;

            txtFlatNo.Text = objLease.PropertyUnitNo;
            txtLandmark.Text = objLease.PropertyLandmark;
            txtSurveyNo.Text = objLease.PropertySurveyNo;
            txtCity.Text = objLease.PropertyCity;
            txtPincode.Text = objLease.PropertyPincode;
            txtOtherAddress.Text = objLease.PropertyAddressOther;
            cmbPropType.SelectedValue  = objLease.PropertyType;
            cmbPropSubType.SelectedValue = objLease.PropertySubType;

            txtTokenNo.Text = objLease.TokenNo;
            txtGRNNo.Text = objLease.GRNNo;
            txtDuration.Text = objLease.DurationInMonths.ToString();
            txtLockinPeriod.Text = objLease.LockinPeriodInMonths.ToString();
            txtNoticePeriod.Text = objLease.NoticePeriodInMonths.ToString();
            startDate.Value = Convert.ToDateTime(objLease.StartDate);
            endDate.Value = Convert.ToDateTime(objLease.EndDate);
            txtEscalation1.Text = objLease.Escalation1;
            txtEscalation2.Text = objLease.Escalation2;
            if(!string.IsNullOrEmpty((objLease.Escalation2)))
            {
                lblEscalation2.Visible = true;
                txtEscalation2.Visible = true;
                btnEscalation2.Visible = true;
            }

            txtEscalation3.Text = objLease.Escalation3;
            if (!string.IsNullOrEmpty((objLease.Escalation3)))
            {
                lblEscalation3.Visible = true;
                txtEscalation3.Visible = true;
                btnEscalation3.Visible = true;
            }

            txtLockinPeriod.Text = objLease.LockinPeriodInMonths.ToString();
            txtRemark.Text = objLease.Remark;
            txtBrokerageDetail.Text = objLease.BrokerageDetail;
            cmbSource.SelectedItem = objLease.Source;
            cbActive.Checked = objLease.IsActive;

            txtRentSellingPrice.Text= objLease.Rent.ToString();
            txtDeposit.Text = objLease.Deposit.ToString();
            cmbSociety.SelectedValue = objLease.PropertySociety;
            cmbLocation.SelectedValue = objLease.PropertyLocation;
            if (objLease.PropertyBedrooms != null)
            {
                rb1HK.Checked = objLease.PropertyBedrooms.Contains("0") ? true : false;
                rb15BHK.Checked = objLease.PropertyBedrooms.Contains("1.5") ? true : false;
                rb1BHK.Checked = ((objLease.PropertyBedrooms.Contains("1") && !objLease.PropertyBedrooms.Contains("1.")) || objLease.PropertyBedrooms.Contains("1,")) ? true : false;
                //rb1BHK.Checked = objLease.PropertyBedrooms.Contains("1") ? true : false;
                rb25BHK.Checked = objLease.PropertyBedrooms.Contains("2.5") ? true : false;
                rb2BHK.Checked = ((objLease.PropertyBedrooms.Contains("2") && !objLease.PropertyBedrooms.Contains("2.")) || objLease.PropertyBedrooms.Contains("2,")) ? true : false;
                rb3BHK.Checked = objLease.PropertyBedrooms.Contains("3") ? true : false;
                rb4BHK.Checked = objLease.PropertyBedrooms.Contains("4") ? true : false;
            }
        }

        private void btnEscalationPlus_Click(object sender, EventArgs e)
        {
            if(!lblEscalation2.Visible)
            {
                lblEscalation2.Visible = true;
                txtEscalation2.Visible = true;
                btnEscalation2.Visible = true;
                return;
            }else if(!lblEscalation3.Visible)
            {
                lblEscalation3.Visible = true;
                txtEscalation3.Visible = true;
                btnEscalation3.Visible = true;
            }
        }

        private void btnEscalation2_Click(object sender, EventArgs e)
        {
            lblEscalation2.Visible = false;
            txtEscalation2.Visible = false;
            btnEscalation2.Visible = false;
        }

        private void btnEscalation3_Click(object sender, EventArgs e)
        {
            lblEscalation3.Visible = false;
            txtEscalation3.Visible = false;
            btnEscalation3.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Entities.Lease lease = new Entities.Lease();
            lease.CreatedDate = registrationDate.Value.ToString("dd'/'MM'/'yyyy");
            lease.OwnerName = txtOwnerName.Text;
            lease.OwnerPhoneNo = txtOwnerPhone.Text;
            lease.OwnerEmail = txtOwnerEmail.Text;
            lease.OwnerPAN = txtOwnerPan.Text;
            lease.OwnerAadharNo = txtOwnerAadharNo.Text;
            lease.OwnerAddress = txtOwnerAddress.Text;

            lease.TenantName = txtTenantName.Text;
            lease.TenantPhoneNo = txtTenantPhone.Text;
            lease.TenantEmail = txtTenantEmail.Text;
            lease.TenantPAN = txtTenantPan.Text;
            lease.TenantAadharNo = txtTenantAadharNo.Text;
            lease.TenantAddress = txtTenantAddress.Text;

            lease.PropertyUnitNo = txtFlatNo.Text;
            lease.PropertyLandmark = txtLandmark.Text;
            lease.PropertySurveyNo = txtSurveyNo.Text;
            lease.PropertyCity = txtCity.Text;
            lease.PropertyPincode = txtPincode.Text;
            lease.PropertyAddressOther = txtOtherAddress.Text;
            lease.PropertyType = cmbPropType.SelectedValue != null ? cmbPropType.SelectedValue.ToString() : null;
            lease.PropertySubType = cmbPropSubType.SelectedValue != null ? cmbPropSubType.SelectedValue.ToString() : null;

            lease.TokenNo = txtTokenNo.Text;
            lease.GRNNo = txtGRNNo.Text;
            lease.DurationInMonths = !string.IsNullOrWhiteSpace(txtDuration.Text) ? Convert.ToInt32(txtDuration.Text) : 0;
            lease.NoticePeriodInMonths = !string.IsNullOrWhiteSpace(txtNoticePeriod.Text) ? Convert.ToInt32(txtNoticePeriod.Text) : 0;
            lease.StartDate = startDate.Value.ToString("dd'/'MM'/'yyyy");
            lease.EndDate = endDate.Value.ToString("dd'/'MM'/'yyyy");
            lease.Escalation1 = txtEscalation1.Text;

            if (txtEscalation2.Visible)
            {
                lease.Escalation2 = txtEscalation2.Text;
            }
            else
            {
                lease.Escalation2 = "";
            }

            if (txtEscalation3.Visible)
            {
                lease.Escalation3 = txtEscalation3.Text;
            }
            else
            {
                lease.Escalation3 = "";
            }

            lease.LockinPeriodInMonths = !string.IsNullOrWhiteSpace(txtLockinPeriod.Text) ? Convert.ToInt32(txtLockinPeriod.Text) : 0;
            lease.Remark = txtRemark.Text;
            lease.BrokerageDetail = txtBrokerageDetail.Text;
            lease.Source = cmbSource.SelectedItem != null ? cmbSource.SelectedItem.ToString() : null;
            lease.IsActive = cbActive.Checked ? true : false;

            try
            {
                lease.Rent = !string.IsNullOrWhiteSpace(txtRentSellingPrice.Text) ? Convert.ToInt32(txtRentSellingPrice.Text): 0;
                lease.Deposit = !string.IsNullOrWhiteSpace(txtDeposit.Text) ? Convert.ToInt32(txtDeposit.Text) : 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Rent or Deposit amount.", "Lease", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cmbSociety.SelectedValue != null || cmbSociety.SelectedText != null)
            {
                string society = string.IsNullOrEmpty(cmbSociety.Text) ? (cmbSociety.SelectedValue == null ? "" : cmbSociety.SelectedValue.ToString()) : cmbSociety.Text;
                lease.PropertySociety = society;
            }

            if (cmbLocation.SelectedValue != null || cmbLocation.SelectedText != null)
            {
                string location = string.IsNullOrEmpty(cmbLocation.Text) ? (cmbSociety.SelectedValue == null ? "" : cmbLocation.SelectedValue.ToString()) : cmbLocation.Text;
                lease.PropertyLocation = location;
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
            lease.PropertyBedrooms = noOfbedrooms;

            if (this.leaseId == 0)
            {
                using (LeaseDAL objDAL = new LeaseDAL())
                {
                    leaseId = objDAL.Insert(lease);
                }

                MessageBox.Show("Lease saved successfully.", "Lease", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lease.Id = objLease.Id;
                using (LeaseDAL objDAL = new LeaseDAL())
                {
                    this.leaseId = objDAL.Update(lease);
                }

                MessageBox.Show("Lease saved successfully.", "Lease", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtOwnerPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTenantPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbPropType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPropType.SelectedValue.ToString() == "Residential")
            {
                cmbPropSubType.DataSource = propertyTypeDAL.GetDistinctPropertySubTypes(cmbPropType.SelectedValue.ToString());
                cmbPropSubType.DisplayMember = "propertysubtype";
                cmbPropSubType.ValueMember = "propertysubtype";
                lblNoOfBedroom.Visible = true;
                rb1HK.Visible = true;
                rb1BHK.Visible = true;
                rb15BHK.Visible = true;
                rb2BHK.Visible = true;
                rb25BHK.Visible = true;
                rb3BHK.Visible = true;
                rb4BHK.Visible = true;
            }
            else if (cmbPropType.SelectedValue.ToString() == "Commercial")
            {
                cmbPropSubType.DataSource = propertyTypeDAL.GetDistinctPropertySubTypes(cmbPropType.SelectedValue.ToString());
                cmbPropSubType.DisplayMember = "propertysubtype";
                cmbPropSubType.ValueMember = "propertysubtype";

                lblNoOfBedroom.Visible = false;
                rb1HK.Visible = false;
                rb1BHK.Visible = false;
                rb15BHK.Visible = false;
                rb2BHK.Visible = false;
                rb25BHK.Visible = false;
                rb3BHK.Visible = false;
                rb4BHK.Visible = false;
            }
            else if (cmbPropType.SelectedValue.ToString() == "Plots")
            {
                cmbPropSubType.DataSource = propertyTypeDAL.GetDistinctPropertySubTypes(cmbPropType.SelectedValue.ToString());
                cmbPropSubType.DisplayMember = "propertysubtype";
                cmbPropSubType.ValueMember = "propertysubtype";

                lblNoOfBedroom.Visible = false;
                rb1HK.Visible = false;
                rb1BHK.Visible = false;
                rb15BHK.Visible = false;
                rb2BHK.Visible = false;
                rb25BHK.Visible = false;
                rb3BHK.Visible = false;
                rb4BHK.Visible = false;
            }

            if (cmbPropSubType.Items.Count > 0)
            {
                cmbPropSubType.SelectedIndex = 0;
            }
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtLockinPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtDuration.Text))
            {
                endDate.Value = startDate.Value.AddMonths(Convert.ToInt32(txtDuration.Text));
            }
        }

        private void txtDuration_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDuration.Text))
            {
                endDate.Value = startDate.Value.AddMonths(Convert.ToInt32(txtDuration.Text));
            }
        }

        private void btnAddTenant_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddTenant_Click_1(object sender, EventArgs e)
        {
            if (tenantCount + 1 > maxTenantCount)
            {
                return;
            }

            tenantCount = tenantCount + 1;

            this.Size = new Size(this.Size.Width, this.Size.Height + 100);
            cbActive.Location = new Point(cbActive.Location.X, cbActive.Location.Y + 100);
            btnSave.Location = new Point(btnSave.Location.X, btnSave.Location.Y + 100);
            btnCancel.Location = new Point(btnCancel.Location.X, btnCancel.Location.Y + 100);
            panel2.Size = new Size(panel2.Size.Width, panel2.Size.Height + 100);
            groupBox4.Location = new Point(groupBox4.Location.X, groupBox4.Location.Y + 100);
            groupBox3.Location = new Point(groupBox3.Location.X, groupBox3.Location.Y + 100);
            groupBox2.Location = new Point(groupBox2.Location.X, groupBox2.Location.Y + 100);

            createTenantControls(tenantCount);
        }

        private void btnRemoveTenant2_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Remove(grpbTenant2Details);

            this.Size = new Size(this.Size.Width, this.Size.Height - 100);
            cbActive.Location = new Point(cbActive.Location.X, cbActive.Location.Y - 100);
            btnSave.Location = new Point(btnSave.Location.X, btnSave.Location.Y - 100);
            btnCancel.Location = new Point(btnCancel.Location.X, btnCancel.Location.Y - 100);
            panel2.Size = new Size(panel2.Size.Width, panel2.Size.Height - 100);
            groupBox4.Location = new Point(groupBox4.Location.X, groupBox4.Location.Y - 100);
            groupBox3.Location = new Point(groupBox3.Location.X, groupBox3.Location.Y - 100);
            groupBox2.Location = new Point(groupBox2.Location.X, groupBox2.Location.Y - 100);
        }

        private void btnRemoveTenant3_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Remove(grpbTenant3Details);

            this.Size = new Size(this.Size.Width, this.Size.Height - 100);
            cbActive.Location = new Point(cbActive.Location.X, cbActive.Location.Y - 100);
            btnSave.Location = new Point(btnSave.Location.X, btnSave.Location.Y - 100);
            btnCancel.Location = new Point(btnCancel.Location.X, btnCancel.Location.Y - 100);
            panel2.Size = new Size(panel2.Size.Width, panel2.Size.Height - 100);
            groupBox4.Location = new Point(groupBox4.Location.X, groupBox4.Location.Y - 100);
            groupBox3.Location = new Point(groupBox3.Location.X, groupBox3.Location.Y - 100);
            groupBox2.Location = new Point(groupBox2.Location.X, groupBox2.Location.Y - 100);
        }

        private void createTenantControls(int tenantNo)
        {
            if (tenantNo == 2)
            {
                grpbTenant2Details = new System.Windows.Forms.GroupBox();
                this.txtTenant2Phone = new System.Windows.Forms.TextBox();
                this.txtTenant2Name = new System.Windows.Forms.TextBox();
                this.txtTenant2Email = new System.Windows.Forms.TextBox();
                this.txtTenant2Address = new System.Windows.Forms.TextBox();
                this.txtTenant2Pan = new System.Windows.Forms.TextBox();
                this.txtTenant2AadharNo = new System.Windows.Forms.TextBox();
                this.btnRemoveTenant2 = new System.Windows.Forms.Button();

                // 
                // txtTenantPhone
                // 
                this.txtTenant2Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant2Phone.Location = new System.Drawing.Point(340, 18);
                this.txtTenant2Phone.MaxLength = 10;
                this.txtTenant2Phone.Name = "txtTenant2Phone";
                this.txtTenant2Phone.Size = new System.Drawing.Size(145, 21);
                this.txtTenant2Phone.TabIndex = 8;
                this.txtTenant2Phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenantPhone_KeyPress);
                // 
                // txtTenantName
                // 
                this.txtTenant2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant2Name.Location = new System.Drawing.Point(90, 18);
                this.txtTenant2Name.Name = "txtTenant2Name";
                this.txtTenant2Name.Size = new System.Drawing.Size(165, 21);
                this.txtTenant2Name.TabIndex = 7;
                // 
                // txtTenantEmail
                // 
                this.txtTenant2Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant2Email.Location = new System.Drawing.Point(542, 18);
                this.txtTenant2Email.Name = "txtTenant2Email";
                this.txtTenant2Email.Size = new System.Drawing.Size(162, 21);
                this.txtTenant2Email.TabIndex = 9;
                // 
                // txtTenantAddress
                // 
                this.txtTenant2Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant2Address.Location = new System.Drawing.Point(543, 52);
                this.txtTenant2Address.Name = "txtTenant2Address";
                this.txtTenant2Address.Size = new System.Drawing.Size(263, 21);
                this.txtTenant2Address.TabIndex = 12;
                // 
                // txtTenant2AadharNo
                // 
                this.txtTenant2AadharNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant2AadharNo.Location = new System.Drawing.Point(340, 52);
                this.txtTenant2AadharNo.Name = "txtTenant2AadharNo";
                this.txtTenant2AadharNo.Size = new System.Drawing.Size(145, 21);
                this.txtTenant2AadharNo.TabIndex = 11;
                // 
                // txtTenant2Pan
                // 
                this.txtTenant2Pan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtTenant2Pan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant2Pan.Location = new System.Drawing.Point(90, 52);
                this.txtTenant2Pan.MaxLength = 10;
                this.txtTenant2Pan.Name = "txtTenant2Pan";
                this.txtTenant2Pan.Size = new System.Drawing.Size(165, 21);
                this.txtTenant2Pan.TabIndex = 10;
                // 
                // btnRemoveTenant2
                // 
                this.btnRemoveTenant2.BackColor = System.Drawing.Color.SlateGray;
                this.btnRemoveTenant2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.btnRemoveTenant2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnRemoveTenant2.ForeColor = System.Drawing.Color.White;
                this.btnRemoveTenant2.Location = new System.Drawing.Point(856, 52);
                this.btnRemoveTenant2.Name = "btnRemoveTenant2";
                this.btnRemoveTenant2.Size = new System.Drawing.Size(95, 23);
                this.btnRemoveTenant2.TabIndex = 35;
                this.btnRemoveTenant2.Text = "Remove Tenant";
                this.btnRemoveTenant2.UseVisualStyleBackColor = false;
                this.btnRemoveTenant2.Click += new System.EventHandler(this.btnRemoveTenant2_Click);

                grpbTenant2Details.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                grpbTenant2Details.Controls.Add(this.btnRemoveTenant2);
                grpbTenant2Details.Controls.Add(this.label47);
                grpbTenant2Details.Controls.Add(this.label48);
                grpbTenant2Details.Controls.Add(this.txtTenant2AadharNo);
                grpbTenant2Details.Controls.Add(this.txtTenant2Pan);
                grpbTenant2Details.Controls.Add(this.label34);
                grpbTenant2Details.Controls.Add(this.label36);
                grpbTenant2Details.Controls.Add(this.label39);
                grpbTenant2Details.Controls.Add(this.label40);
                grpbTenant2Details.Controls.Add(this.label41);
                grpbTenant2Details.Controls.Add(this.txtTenant2Phone);
                grpbTenant2Details.Controls.Add(this.txtTenant2Name);
                grpbTenant2Details.Controls.Add(this.txtTenant2Email);
                grpbTenant2Details.Controls.Add(this.txtTenant2Address);
                grpbTenant2Details.Location = new System.Drawing.Point(4, 232);
                grpbTenant2Details.Name = "grpbTenantDetails" + tenantCount.ToString();
                grpbTenant2Details.Size = new System.Drawing.Size(965, 96);
                grpbTenant2Details.TabIndex = 36;
                grpbTenant2Details.TabStop = false;
                grpbTenant2Details.Text = "Tenant " + tenantCount.ToString() + " Details";
                this.panel2.Controls.Add(grpbTenant2Details);
            }else if (tenantNo == 3)
            {
                grpbTenant3Details = new System.Windows.Forms.GroupBox();
                this.txtTenant3Phone = new System.Windows.Forms.TextBox();
                this.txtTenant3Name = new System.Windows.Forms.TextBox();
                this.txtTenant3Email = new System.Windows.Forms.TextBox();
                this.txtTenant3Address = new System.Windows.Forms.TextBox();
                this.txtTenant3Pan = new System.Windows.Forms.TextBox();
                this.txtTenant3AadharNo = new System.Windows.Forms.TextBox();
                this.btnRemoveTenant3 = new System.Windows.Forms.Button();
                // 
                // txtTenantPhone
                // 
                this.txtTenant3Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant3Phone.Location = new System.Drawing.Point(340, 18);
                this.txtTenant3Phone.MaxLength = 10;
                this.txtTenant3Phone.Name = "txtTenant3Phone";
                this.txtTenant3Phone.Size = new System.Drawing.Size(145, 21);
                this.txtTenant3Phone.TabIndex = 8;
                this.txtTenant3Phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenantPhone_KeyPress);
                // 
                // txtTenantName
                // 
                this.txtTenant3Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant3Name.Location = new System.Drawing.Point(90, 18);
                this.txtTenant3Name.Name = "txtTenant3Name";
                this.txtTenant3Name.Size = new System.Drawing.Size(165, 21);
                this.txtTenant3Name.TabIndex = 7;
                // 
                // txtTenantEmail
                // 
                this.txtTenant3Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant3Email.Location = new System.Drawing.Point(542, 18);
                this.txtTenant3Email.Name = "txtTenant3Email";
                this.txtTenant3Email.Size = new System.Drawing.Size(162, 21);
                this.txtTenant3Email.TabIndex = 9;
                // 
                // txtTenantAddress
                // 
                this.txtTenant3Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant3Address.Location = new System.Drawing.Point(543, 52);
                this.txtTenant3Address.Name = "txtTenant3Address";
                this.txtTenant3Address.Size = new System.Drawing.Size(263, 21);
                this.txtTenant3Address.TabIndex = 12;
                // 
                // txtTenant3AadharNo
                // 
                this.txtTenant3AadharNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant3AadharNo.Location = new System.Drawing.Point(340, 52);
                this.txtTenant3AadharNo.Name = "txtTenant3AadharNo";
                this.txtTenant3AadharNo.Size = new System.Drawing.Size(145, 21);
                this.txtTenant3AadharNo.TabIndex = 11;
                // 
                // txtTenant3Pan
                // 
                this.txtTenant3Pan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtTenant3Pan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtTenant3Pan.Location = new System.Drawing.Point(90, 52);
                this.txtTenant3Pan.MaxLength = 10;
                this.txtTenant3Pan.Name = "txtTenant3Pan";
                this.txtTenant3Pan.Size = new System.Drawing.Size(165, 21);
                this.txtTenant3Pan.TabIndex = 10;
                // 
                // btnRemoveTenant3
                // 
                this.btnRemoveTenant3.BackColor = System.Drawing.Color.SlateGray;
                this.btnRemoveTenant3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.btnRemoveTenant3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnRemoveTenant3.ForeColor = System.Drawing.Color.White;
                this.btnRemoveTenant3.Location = new System.Drawing.Point(856, 52);
                this.btnRemoveTenant3.Name = "btnRemoveTenant3";
                this.btnRemoveTenant3.Size = new System.Drawing.Size(95, 23);
                this.btnRemoveTenant3.TabIndex = 35;
                this.btnRemoveTenant3.Text = "Remove Tenant";
                this.btnRemoveTenant3.UseVisualStyleBackColor = false;
                this.btnRemoveTenant3.Click += new System.EventHandler(this.btnRemoveTenant3_Click);

                grpbTenant3Details.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                grpbTenant3Details.Controls.Add(this.btnRemoveTenant3);
                grpbTenant3Details.Controls.Add(this.label47);
                grpbTenant3Details.Controls.Add(this.label48);
                grpbTenant3Details.Controls.Add(this.txtTenant3AadharNo);
                grpbTenant3Details.Controls.Add(this.txtTenant3Pan);
                grpbTenant3Details.Controls.Add(this.label34);
                grpbTenant3Details.Controls.Add(this.label36);
                grpbTenant3Details.Controls.Add(this.label39);
                grpbTenant3Details.Controls.Add(this.label40);
                grpbTenant3Details.Controls.Add(this.label41);
                grpbTenant3Details.Controls.Add(this.txtTenant3Phone);
                grpbTenant3Details.Controls.Add(this.txtTenant3Name);
                grpbTenant3Details.Controls.Add(this.txtTenant3Email);
                grpbTenant3Details.Controls.Add(this.txtTenant3Address);
                grpbTenant3Details.Location = new System.Drawing.Point(4, 343);
                grpbTenant3Details.Name = "grpbTenantDetails" + tenantCount.ToString();
                grpbTenant3Details.Size = new System.Drawing.Size(965, 96);
                grpbTenant3Details.TabIndex = 36;
                grpbTenant3Details.TabStop = false;
                grpbTenant3Details.Text = "Tenant " + tenantCount.ToString() + " Details";
                this.panel2.Controls.Add(grpbTenant3Details);
            }
        }
    }
}
