using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using iBroker.DAL;

namespace iBroker.Forms.BuilderProject
{
    public partial class ProjectSearch : Form
    {
        private BuilderProjectDAL objProjectDAL;
        private LocationDAL locationDAL;
        private List<CheckedListBoxItem> locationList;

        public ProjectSearch()
        {
            InitializeComponent();
        }

        private void ProjectSearch_Load(object sender, EventArgs e)
        {
            cbActive.Checked = true;
            possessionDateFrom.CustomFormat = " ";
            possessionDateTo.CustomFormat = " ";

            locationDAL = new LocationDAL();
            DataTable locationData = locationDAL.GetLocations();
            locationList = (from loc in locationData.AsEnumerable()
                            where !string.IsNullOrEmpty(loc["Location"].ToString())
                            select new CheckedListBoxItem { Text = loc["Location"].ToString() }).ToList();
            lbLocations.Items.AddRange(locationList.ToArray());

            BindingSource bSource = new BindingSource();
            objProjectDAL = new BuilderProjectDAL();
            DataTable projects = objProjectDAL.GetBuilderProjects();
            bSource.DataSource = projects;
            int projectCount = projects != null ? projects.Rows.Count : 0;
            lblProjectCount.Text = projectCount.ToString();
            lblSearchCount.Text = projectCount.ToString();
            dgvProject.DataSource = bSource;
            //adjustColumnOrder();
        }

        private void dgvProject_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var projectId = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;
                Form childForm = new BuilderProject.EditProject(Convert.ToInt32(projectId));
                childForm.MdiParent = this.MdiParent;
                childForm.Text = "Project";
                childForm.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
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

        private void btnSearchLease_Click(object sender, EventArgs e)
        {
            Entities.BuilderProjectSearch objProjectSearch = new Entities.BuilderProjectSearch();
            objProjectSearch.Active = cbActive.Checked;
            objProjectSearch.ProjectName = txtProjectName.Text;
            objProjectSearch.BuilderName = txtBuilderName.Text;

            List<string> locations = new List<string>();
            foreach (CheckedListBoxItem loc in lbLocations.CheckedItems)
            {
                locations.Add(loc.Text);
            }
            objProjectSearch.Locations = locations;

            objProjectSearch.PossessionFrom = Convert.ToInt16(possessionDateFrom.Tag) == 2 ? possessionDateFrom.Value.ToString("dd'/'MM'/'yyyy") : null;
            objProjectSearch.PossessionTo = Convert.ToInt16(possessionDateTo.Tag) == 2 ? possessionDateTo.Value.ToString("dd'/'MM'/'yyyy") : null;

            BindingSource bSource = new BindingSource();
            objProjectDAL = new BuilderProjectDAL();
            DataTable projects = objProjectDAL.GetBuilderProjects(objProjectSearch);
            bSource.DataSource = projects;
            int projectCount = projects != null ? projects.Rows.Count : 0;
            lblSearchCount.Text = projectCount.ToString();
            dgvProject.DataSource = bSource;
            //adjustColumnOrder();
        }

        private void possessionDateFrom_ValueChanged(object sender, EventArgs e)
        {
            possessionDateFrom.CustomFormat = "dd'/'MM'/'yyyy";
            possessionDateFrom.Tag = 2;
        }

        private void possessionDateTo_ValueChanged(object sender, EventArgs e)
        {
            possessionDateTo.CustomFormat = "dd'/'MM'/'yyyy";
            possessionDateTo.Tag = 2;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbActive.Checked = true;
            txtProjectName.Text = "";
            txtBuilderName.Text = "";
            possessionDateFrom.CustomFormat = " ";
            possessionDateFrom.Tag = 1;
            possessionDateTo.CustomFormat = " ";
            possessionDateTo.Tag = 1;

            cb1HK.Checked = false;
            cb1BHK.Checked = false;
            cb15BHK.Checked = false;
            cb2BHK.Checked = false;
            cb25BHK.Checked = false;
            cb3BHK.Checked = false;
            cb4BHK.Checked = false;
            foreach (int i in lbLocations.CheckedIndices)
            {
                lbLocations.SetItemCheckState(i, CheckState.Unchecked);
            }

            BindingSource bSource = new BindingSource();
            objProjectDAL = new BuilderProjectDAL();
            DataTable projects = objProjectDAL.GetBuilderProjects();
            bSource.DataSource = projects;
            int projectCount = projects != null ? projects.Rows.Count : 0;
            lblSearchCount.Text = projectCount.ToString();
            dgvProject.DataSource = bSource;
            //adjustColumnOrder();
        }
    }
}
