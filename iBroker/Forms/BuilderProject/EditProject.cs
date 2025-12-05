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

namespace iBroker.Forms.BuilderProject
{
    public partial class EditProject : Form
    {
        private LocationDAL locationDAL;
        private DataTable builderData;
        BuilderDAL builderDAL;
        private int projectId;
        private Entities.BuilderProject objProject;
        private BuilderProjectDAL projectDAL;

        public EditProject()
        {
            InitializeComponent();
        }

        public EditProject(int projectId)
        {
            this.projectId = projectId;

            using (BuilderProjectDAL objDAL = new BuilderProjectDAL())
            {
                this.objProject = objDAL.GetBuilderProject(this.projectId);
            }
            InitializeComponent();
        }

        private void LoadDataInControls(Entities.BuilderProject objProject)
        {
            registrationDate.Value = Convert.ToDateTime(objProject.CreatedDate);
            cbActive.Checked = objProject.IsActive;
            txtProjectName.Text = objProject.Name;
            cmbProjectType.SelectedItem = objProject.ProjectType;
            //objProject.BuilderId = builder.Id;
            cmbBuilder.SelectedValue = objProject.BuilderId;
            cmbLocation.SelectedValue = objProject.Location;
            txtLandmark.Text = objProject.Landmark;
            txtAddress.Text = objProject.Address;
            txtPincode.Text = objProject.Pincode;
            txtSitePhoneNo.Text = objProject.SitePhoneNo1;
            txtSitePhoneNo2.Text = objProject.SitePhoneNo2;
            txtProjectWebsite.Text = objProject.Website;
            txtProjectEmail.Text = objProject.Email;
            launchDate.Value = Convert.ToDateTime(objProject.LaunchDate);
            cmbStatus.SelectedItem = objProject.CurrentStatus;
            possessionDate.Value = Convert.ToDateTime(objProject.PossessionDate);
            cbReraApproved.Checked = objProject.ReraApproved;
            txtReraId.Text = objProject.ReraID;
            txtTotalUnit.Text = objProject.TotalUnits.ToString();
            txtLandArea.Text = objProject.TotalLandArea.ToString();
            cmbLandAreaUnit.SelectedItem = objProject.LandAreaUnit;
            txtStartPrice.Text = objProject.StartPrice;
            txtHighlights.Text = objProject.Highlights;
            txtRemark.Text = objProject.Remark;

            cb1HK.Checked = objProject.UnitTypes.Contains("1HK");
            cb1BHK.Checked = objProject.UnitTypes.Contains("1BHK");
            cb15BHK.Checked = objProject.UnitTypes.Contains("1.5BHK");
            cb2BHK.Checked = objProject.UnitTypes.Contains("2BHK");
            cb25BHK.Checked = objProject.UnitTypes.Contains("25BHK");
            cb3BHK.Checked = objProject.UnitTypes.Contains("3BHK");
            cb4BHK.Checked = objProject.UnitTypes.Contains("4BHK");
            cbShops.Checked = objProject.UnitTypes.Contains("Shop");
            cbOffice.Checked = objProject.UnitTypes.Contains("Office");

            cbLift.Checked = objProject.Amenities.Contains("Lift");
            cbPowerBackup.Checked = objProject.Amenities.Contains("PowerBackup");
            cbCCTV.Checked = objProject.Amenities.Contains("CCTV");
            cbGarden.Checked = objProject.Amenities.Contains("Garden");
            cbClubHouse.Checked = objProject.Amenities.Contains("ClubHouse");
            cbSwimmingPool.Checked = objProject.Amenities.Contains("SwimmingPool");
            cbGym.Checked = objProject.Amenities.Contains("Gym");
            cbKidPlayArea.Checked = objProject.Amenities.Contains("KidPlayArea");
            cbIndoorGames.Checked = objProject.Amenities.Contains("IndoorGames");
            cbWifi.Checked = objProject.Amenities.Contains("Wifi");
            cbTemple.Checked = objProject.Amenities.Contains("Temple");
            cbMultipurposeCourt.Checked = objProject.Amenities.Contains("MultipurposeCourt");
            cbSolarWaterHeater.Checked = objProject.Amenities.Contains("SolarWaterHeater");
            txtAmenities.Text = objProject.AmenitiesOther;

            int j;
            if (objProject.UnitDetails != null)
            {
                for (int i = 1; i <= objProject.UnitDetails.Count; i++)
                {
                    j = i - 1;
                    this.Controls.Find("txtUnitConfId" + i, true)[0].Text = objProject.UnitDetails[j].Id.ToString();
                    this.Controls.Find("txtBuildingName" + i, true)[0].Text = objProject.UnitDetails[j].BuildingName;
                    this.Controls.Find("txtUnitType" + i, true)[0].Text = objProject.UnitDetails[j].UnitName;
                    this.Controls.Find("txtUnitArea" + i, true)[0].Text = objProject.UnitDetails[j].Area;
                    ((this.Controls.Find("cmbAreaUnit" + i, true)[0]) as ComboBox).SelectedItem = objProject.UnitDetails[j].AreaUnit;
                    this.Controls.Find("txtUnitPrice" + i, true)[0].Text = objProject.UnitDetails[j].Price;
                }
            }
        }

        private void EditProject_Load(object sender, EventArgs e)
        {
            //DrawRectangleRectangle(new PaintEventArgs( 30, 125, 230, 425);
            cbActive.Checked = true;
            registrationDate.CustomFormat = "dd/MM/yyyy";
            registrationDate.Value = DateTime.Now;

            launchDate.CustomFormat = "dd/MM/yyyy";
            launchDate.Value = DateTime.Now;

            possessionDate.CustomFormat = "dd/MM/yyyy";
            //launchDate.Value = DateTime.Now;
            lblReraId.Visible = false;
            txtReraId.Visible = false;
            cmbLandAreaUnit.SelectedIndex = 0;
            cmbAreaUnit1.SelectedIndex = 0;
            cmbAreaUnit2.SelectedIndex = 0;
            cmbAreaUnit3.SelectedIndex = 0;
            cmbAreaUnit4.SelectedIndex = 0;
            cmbAreaUnit5.SelectedIndex = 0;
            cmbProjectType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            projectDAL = new BuilderProjectDAL();
            lblProjectNo.Text = (projectDAL.GetLatestBuilderProjectId() + 1).ToString();

            locationDAL = new LocationDAL();
            cmbLocation.DataSource = locationDAL.GetLocations();
            cmbLocation.DisplayMember = "Location";
            cmbLocation.ValueMember = "Location";

            builderDAL = new BuilderDAL();
            builderData = builderDAL.GetBuilders();
            cmbBuilder.DataSource = builderData;
            cmbBuilder.DisplayMember = "Name";
            cmbBuilder.ValueMember = "Id";

            if(this.objProject != null)
            {
                LoadDataInControls(this.objProject);
            }
        }

        public void DrawRectangleRectangle(PaintEventArgs e, int x1, int y1, int x2, int y2)
        {

            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create rectangle.
            Rectangle rect = new Rectangle(x1, y1, x2, y2);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, rect);
        }

        private void cbReraApproved_CheckedChanged(object sender, EventArgs e)
        {
            if(cbReraApproved.Checked)
            {
                lblReraId.Visible = true;
                txtReraId.Visible = true;
            }
            else
            {
                lblReraId.Visible = false;
                txtReraId.Visible = false;
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cmbStatus.SelectedItem.ToString() == "")
        }

        private void cmbProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbProjectType.SelectedItem.ToString() == "Residencial")
            {
                cb1HK.Enabled = true;
                cb1BHK.Enabled = true;
                cb15BHK.Enabled = true;
                cb2BHK.Enabled = true;
                cb25BHK.Enabled = true;
                cb3BHK.Enabled = true;
                cb4BHK.Enabled = true;
                cbShops.Enabled = false;
                cbShops.Checked = false;
                cbOffice.Enabled = false;
                cbOffice.Checked = false;
            }
            else if(cmbProjectType.SelectedItem.ToString() == "Commercial")
            {
                cb1HK.Enabled = false;
                cb1BHK.Enabled = false;
                cb15BHK.Enabled = false;
                cb2BHK.Enabled = false;
                cb25BHK.Enabled = false;
                cb3BHK.Enabled = false;
                cb4BHK.Enabled = false;

                cb1HK.Checked = false;
                cb1BHK.Checked = false;
                cb15BHK.Checked = false;
                cb2BHK.Checked = false;
                cb25BHK.Checked = false;
                cb3BHK.Checked = false;
                cb4BHK.Checked = false;

                cbShops.Enabled = true;
                cbOffice.Enabled = true;
            }
            else if(cmbProjectType.SelectedItem.ToString() == "Both")
            {
                cb1HK.Enabled = true;
                cb1BHK.Enabled = true;
                cb15BHK.Enabled = true;
                cb2BHK.Enabled = true;
                cb25BHK.Enabled = true;
                cb3BHK.Enabled = true;
                cb4BHK.Enabled = true;
                cbShops.Enabled = true;
                cbOffice.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddItem(string address, string contactNum, string email)
        {
            //get a reference to the previous existent 
            RowStyle temp = tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowCount - 1];
            //increase panel rows count by one
            tableLayoutPanel1.RowCount++;
            //add a new RowStyle as a copy of the previous one
            tableLayoutPanel1.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            //add your three controls
            //tableLayoutPanel1.Controls.Add(new Label() { Text = address }, 0, tableLayoutPanel1.RowCount - 1);
            //tableLayoutPanel1.Controls.Add(new Label() { Text = contactNum }, 1, tableLayoutPanel1.RowCount - 1);
            //tableLayoutPanel1.Controls.Add(new Label() { Text = email }, 2, tableLayoutPanel1.RowCount - 1);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddItem("a","b","c");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cmbBuilder.SelectedValue == null  || cmbBuilder.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Select Builder Name for the Project", "Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtSitePhoneNo.Text.Length > 10 || txtSitePhoneNo.Text.Length < 10)
            {
                MessageBox.Show("Invalid phone no1, Please enter 10 digit phone no", "Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSitePhoneNo2.Text.Length > 0 && (txtSitePhoneNo2.Text.Length > 10 || txtSitePhoneNo2.Text.Length < 10))
            {
                MessageBox.Show("Invalid phone no2, Please enter 10 digit phone no", "Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Entities.BuilderProject builderProject = new Entities.BuilderProject();
            builderProject.CreatedDate = registrationDate.Value.ToString("dd'/'MM'/'yyyy");
            builderProject.IsActive = cbActive.Checked;
            builderProject.Name = txtProjectName.Text;
            builderProject.ProjectType = cmbProjectType.SelectedItem != null ? cmbProjectType.SelectedItem.ToString() : "";

            Entities.Builder builder = builderDAL.GetBuilder(cmbBuilder.Text.ToString());
            builderProject.BuilderId = builder.Id;
            builderProject.Location = cmbLocation.Text != null ? cmbLocation.Text.ToString() : "";
            builderProject.Landmark = txtLandmark.Text;
            builderProject.Address = txtAddress.Text;
            builderProject.Pincode = txtPincode.Text;
            builderProject.SitePhoneNo1 = txtSitePhoneNo.Text;
            builderProject.SitePhoneNo2 = txtSitePhoneNo2.Text;
            builderProject.Website = txtProjectWebsite.Text;
            builderProject.Email = txtProjectEmail.Text;
            builderProject.LaunchDate = launchDate.Value.ToString("dd'/'MM'/'yyyy");
            builderProject.CurrentStatus = cmbStatus.SelectedItem.ToString();
            builderProject.PossessionDate = possessionDate.Value.ToString("dd'/'MM'/'yyyy");
            builderProject.ReraApproved = cbReraApproved.Checked;
            builderProject.ReraID = txtReraId.Text;
            try
            {
                builderProject.TotalUnits = txtTotalUnit.Text != "" ? Convert.ToInt32(txtTotalUnit.Text) : 0;
                builderProject.TotalLandArea = txtLandArea.Text != "" ? Convert.ToInt32(txtLandArea.Text) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Only numbers allowed in Total Unit and Total Land Area", "Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            builderProject.LandAreaUnit = cmbLandAreaUnit.SelectedItem != null ? cmbLandAreaUnit.SelectedItem.ToString() : "";
            builderProject.StartPrice = txtStartPrice.Text;
            builderProject.Highlights = txtHighlights.Text;
            builderProject.Remark = txtRemark.Text;

            builderProject.UnitTypes = new List<string>();
            if (cb1HK.Checked)
            {
                builderProject.UnitTypes.Add("1HK");
            }
            if (cb1BHK.Checked)
            {
                builderProject.UnitTypes.Add("1BHK");
            }
            if (cb15BHK.Checked)
            {
                builderProject.UnitTypes.Add("1.5BHK");
            }
            if (cb2BHK.Checked)
            {
                builderProject.UnitTypes.Add("2BHK");
            }
            if (cb25BHK.Checked)
            {
                builderProject.UnitTypes.Add("25BHK");
            }
            if (cb3BHK.Checked)
            {
                builderProject.UnitTypes.Add("3BHK");
            }
            if (cb4BHK.Checked)
            {
                builderProject.UnitTypes.Add("4BHK");
            }
            if (cbShops.Checked)
            {
                builderProject.UnitTypes.Add("Shop");
            }
            if (cbOffice.Checked)
            {
                builderProject.UnitTypes.Add("Office");
            }

            builderProject.Amenities = new List<string>();
            if (cbLift.Checked)
            {
                builderProject.Amenities.Add("Lift");
            }
            if (cbPowerBackup.Checked)
            {
                builderProject.Amenities.Add("PowerBackup");
            }
            if (cbCCTV.Checked)
            {
                builderProject.UnitTypes.Add("CCTV");
            }
            if (cbGarden.Checked)
            {
                builderProject.Amenities.Add("Garden");
            }
            if (cbClubHouse.Checked)
            {
                builderProject.Amenities.Add("ClubHouse");
            }
            if (cbSwimmingPool.Checked)
            {
                builderProject.Amenities.Add("SwimmingPool");
            }
            if (cbGym.Checked)
            {
                builderProject.Amenities.Add("Gym");
            }
            if (cbKidPlayArea.Checked)
            {
                builderProject.Amenities.Add("KidPlayArea");
            }
            if (cbIndoorGames.Checked)
            {
                builderProject.Amenities.Add("IndoorGames");
            }
            if (cbSolarWaterHeater.Checked)
            {
                builderProject.UnitTypes.Add("SolarWaterHeater");
            }
            if (cbWifi.Checked)
            {
                builderProject.Amenities.Add("Wifi");
            }
            if (cbTemple.Checked)
            {
                builderProject.Amenities.Add("Temple");
            }
            if (cbMultipurposeCourt.Checked)
            {
                builderProject.Amenities.Add("MultipurposeCourt");
            }

            builderProject.AmenitiesOther = txtAmenities.Text;

            builderProject.UnitDetails = new List<Entities.UnitConfiguration>();

            if (unitInfoPresent("1"))
            {
                Entities.UnitConfiguration unit1Conf = new Entities.UnitConfiguration();
                unit1Conf.Id = txtUnitConfId1.Text != "" ? Convert.ToInt32(txtUnitConfId1.Text) : 0;
                unit1Conf.BuildingName = txtBuildingName1.Text;
                unit1Conf.UnitName = txtUnitType1.Text;
                unit1Conf.Area = txtUnitArea1.Text;
                unit1Conf.AreaUnit = cmbAreaUnit1.SelectedItem != null ? cmbAreaUnit1.SelectedItem.ToString() : "";
                unit1Conf.Price = txtUnitPrice1.Text;
                builderProject.UnitDetails.Add(unit1Conf);
            }

            if (unitInfoPresent("2"))
            {
                Entities.UnitConfiguration unit2Conf = new Entities.UnitConfiguration();
                unit2Conf.Id = txtUnitConfId2.Text != "" ? Convert.ToInt32(txtUnitConfId2.Text) : 0;
                unit2Conf.BuildingName = txtBuildingName2.Text;
                unit2Conf.UnitName = txtUnitType1.Text;
                unit2Conf.Area = txtUnitArea2.Text;
                unit2Conf.AreaUnit = cmbAreaUnit2.SelectedItem != null ? cmbAreaUnit2.SelectedItem.ToString() : "";
                unit2Conf.Price = txtUnitPrice2.Text;
                builderProject.UnitDetails.Add(unit2Conf);
            }

            if (unitInfoPresent("3"))
            {
                Entities.UnitConfiguration unit3Conf = new Entities.UnitConfiguration();
                unit3Conf.Id = txtUnitConfId3.Text != "" ? Convert.ToInt32(txtUnitConfId3.Text) : 0;
                unit3Conf.BuildingName = txtBuildingName3.Text;
                unit3Conf.UnitName = txtUnitType1.Text;
                unit3Conf.Area = txtUnitArea3.Text;
                unit3Conf.AreaUnit = cmbAreaUnit3.SelectedItem != null ? cmbAreaUnit3.SelectedItem.ToString() : "";
                unit3Conf.Price = txtUnitPrice3.Text;
                builderProject.UnitDetails.Add(unit3Conf);
            }

            if (unitInfoPresent("4"))
            {
                Entities.UnitConfiguration unit4Conf = new Entities.UnitConfiguration();
                unit4Conf.Id = txtUnitConfId4.Text != "" ? Convert.ToInt32(txtUnitConfId4.Text) : 0;
                unit4Conf.BuildingName = txtBuildingName4.Text;
                unit4Conf.UnitName = txtUnitType1.Text;
                unit4Conf.Area = txtUnitArea4.Text;
                unit4Conf.AreaUnit = cmbAreaUnit4.SelectedItem != null ? cmbAreaUnit4.SelectedItem.ToString() : "";
                unit4Conf.Price = txtUnitPrice4.Text;
                builderProject.UnitDetails.Add(unit4Conf);
            }

            if (unitInfoPresent("5"))
            {
                Entities.UnitConfiguration unit5Conf = new Entities.UnitConfiguration();
                unit5Conf.Id = txtUnitConfId5.Text != "" ? Convert.ToInt32(txtUnitConfId5.Text) : 0;
                unit5Conf.BuildingName = txtBuildingName5.Text;
                unit5Conf.UnitName = txtUnitType1.Text;
                unit5Conf.Area = txtUnitArea5.Text;
                unit5Conf.AreaUnit = cmbAreaUnit5.SelectedItem != null ? cmbAreaUnit5.SelectedItem.ToString() : "";
                unit5Conf.Price = txtUnitPrice5.Text;
                builderProject.UnitDetails.Add(unit5Conf);
            }

            if (this.projectId == 0)
            {
                using (BuilderProjectDAL objDAL = new BuilderProjectDAL())
                {
                    objDAL.Insert(builderProject);
                }

                MessageBox.Show("Project saved successfully.", "project", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                builderProject.Id = this.projectId;
                using (BuilderProjectDAL objDAL = new BuilderProjectDAL())
                {
                    objDAL.Update(builderProject);
                }

                MessageBox.Show("Project saved successfully.", "project", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool unitInfoPresent(string rowNo)
        {
            if(this.Controls.Find("txtBuildingName" + rowNo, true)[0].Text != "" ||
            this.Controls.Find("txtUnitType" + rowNo, true)[0].Text != "" ||
            this.Controls.Find("txtUnitArea" + rowNo, true)[0].Text != "" ||
            //((this.Controls.Find("cmbAreaUnit" + rowNo, true)[0]) as ComboBox).SelectedItem != null ||
            this.Controls.Find("txtBuildingName" + rowNo, true)[0].Text != ""){
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtSitePhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSitePhoneNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
