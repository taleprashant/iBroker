namespace iBroker.Forms.BuilderProject
{
    partial class ProjectSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProject = new System.Windows.Forms.DataGridView();
            this.grpbLeaseSearch = new System.Windows.Forms.Panel();
            this.lbLocations = new System.Windows.Forms.CheckedListBox();
            this.txtLocationSearch = new System.Windows.Forms.TextBox();
            this.cb15BHK = new System.Windows.Forms.CheckBox();
            this.cb1HK = new System.Windows.Forms.CheckBox();
            this.cb4BHK = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb1BHK = new System.Windows.Forms.CheckBox();
            this.cb2BHK = new System.Windows.Forms.CheckBox();
            this.cb3BHK = new System.Windows.Forms.CheckBox();
            this.cb25BHK = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBuilderName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.possessionDateTo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.possessionDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label50 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblProjectCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearchLease = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).BeginInit();
            this.grpbLeaseSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProject
            // 
            this.dgvProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProject.Location = new System.Drawing.Point(2, 256);
            this.dgvProject.Name = "dgvProject";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvProject.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProject.Size = new System.Drawing.Size(1299, 393);
            this.dgvProject.TabIndex = 3;
            this.dgvProject.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProject_CellDoubleClick);
            // 
            // grpbLeaseSearch
            // 
            this.grpbLeaseSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbLeaseSearch.AutoSize = true;
            this.grpbLeaseSearch.BackColor = System.Drawing.Color.LightBlue;
            this.grpbLeaseSearch.Controls.Add(this.lbLocations);
            this.grpbLeaseSearch.Controls.Add(this.txtLocationSearch);
            this.grpbLeaseSearch.Controls.Add(this.cb15BHK);
            this.grpbLeaseSearch.Controls.Add(this.cb1HK);
            this.grpbLeaseSearch.Controls.Add(this.cb4BHK);
            this.grpbLeaseSearch.Controls.Add(this.label2);
            this.grpbLeaseSearch.Controls.Add(this.cb1BHK);
            this.grpbLeaseSearch.Controls.Add(this.cb2BHK);
            this.grpbLeaseSearch.Controls.Add(this.cb3BHK);
            this.grpbLeaseSearch.Controls.Add(this.cb25BHK);
            this.grpbLeaseSearch.Controls.Add(this.label16);
            this.grpbLeaseSearch.Controls.Add(this.label14);
            this.grpbLeaseSearch.Controls.Add(this.txtBuilderName);
            this.grpbLeaseSearch.Controls.Add(this.label3);
            this.grpbLeaseSearch.Controls.Add(this.label12);
            this.grpbLeaseSearch.Controls.Add(this.label10);
            this.grpbLeaseSearch.Controls.Add(this.possessionDateTo);
            this.grpbLeaseSearch.Controls.Add(this.label8);
            this.grpbLeaseSearch.Controls.Add(this.possessionDateFrom);
            this.grpbLeaseSearch.Controls.Add(this.label50);
            this.grpbLeaseSearch.Controls.Add(this.txtProjectName);
            this.grpbLeaseSearch.Controls.Add(this.label1);
            this.grpbLeaseSearch.Controls.Add(this.cbActive);
            this.grpbLeaseSearch.Controls.Add(this.btnExcelExport);
            this.grpbLeaseSearch.Controls.Add(this.lblSearchCount);
            this.grpbLeaseSearch.Controls.Add(this.label18);
            this.grpbLeaseSearch.Controls.Add(this.btnReset);
            this.grpbLeaseSearch.Controls.Add(this.lblProjectCount);
            this.grpbLeaseSearch.Controls.Add(this.label7);
            this.grpbLeaseSearch.Controls.Add(this.btnRefresh);
            this.grpbLeaseSearch.Controls.Add(this.btnSearchLease);
            this.grpbLeaseSearch.Controls.Add(this.label11);
            this.grpbLeaseSearch.Location = new System.Drawing.Point(0, 0);
            this.grpbLeaseSearch.Name = "grpbLeaseSearch";
            this.grpbLeaseSearch.Size = new System.Drawing.Size(1299, 255);
            this.grpbLeaseSearch.TabIndex = 4;
            // 
            // lbLocations
            // 
            this.lbLocations.FormattingEnabled = true;
            this.lbLocations.Location = new System.Drawing.Point(277, 83);
            this.lbLocations.Name = "lbLocations";
            this.lbLocations.Size = new System.Drawing.Size(231, 64);
            this.lbLocations.TabIndex = 128;
            // 
            // txtLocationSearch
            // 
            this.txtLocationSearch.Location = new System.Drawing.Point(363, 63);
            this.txtLocationSearch.Name = "txtLocationSearch";
            this.txtLocationSearch.Size = new System.Drawing.Size(145, 20);
            this.txtLocationSearch.TabIndex = 127;
            this.txtLocationSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cb15BHK
            // 
            this.cb15BHK.AutoSize = true;
            this.cb15BHK.Location = new System.Drawing.Point(682, 98);
            this.cb15BHK.Name = "cb15BHK";
            this.cb15BHK.Size = new System.Drawing.Size(63, 17);
            this.cb15BHK.TabIndex = 126;
            this.cb15BHK.Text = "1.5BHK";
            this.cb15BHK.UseVisualStyleBackColor = true;
            // 
            // cb1HK
            // 
            this.cb1HK.AutoSize = true;
            this.cb1HK.Location = new System.Drawing.Point(584, 98);
            this.cb1HK.Name = "cb1HK";
            this.cb1HK.Size = new System.Drawing.Size(47, 17);
            this.cb1HK.TabIndex = 125;
            this.cb1HK.Text = "1HK";
            this.cb1HK.UseVisualStyleBackColor = true;
            // 
            // cb4BHK
            // 
            this.cb4BHK.AutoSize = true;
            this.cb4BHK.Location = new System.Drawing.Point(911, 98);
            this.cb4BHK.Name = "cb4BHK";
            this.cb4BHK.Size = new System.Drawing.Size(54, 17);
            this.cb4BHK.TabIndex = 124;
            this.cb4BHK.Text = "4BHK";
            this.cb4BHK.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(525, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 119;
            this.label2.Text = "Unity Type";
            // 
            // cb1BHK
            // 
            this.cb1BHK.AutoSize = true;
            this.cb1BHK.Location = new System.Drawing.Point(631, 98);
            this.cb1BHK.Name = "cb1BHK";
            this.cb1BHK.Size = new System.Drawing.Size(54, 17);
            this.cb1BHK.TabIndex = 120;
            this.cb1BHK.Text = "1BHK";
            this.cb1BHK.UseVisualStyleBackColor = true;
            // 
            // cb2BHK
            // 
            this.cb2BHK.AutoSize = true;
            this.cb2BHK.Location = new System.Drawing.Point(746, 98);
            this.cb2BHK.Name = "cb2BHK";
            this.cb2BHK.Size = new System.Drawing.Size(54, 17);
            this.cb2BHK.TabIndex = 121;
            this.cb2BHK.Text = "2BHK";
            this.cb2BHK.UseVisualStyleBackColor = true;
            // 
            // cb3BHK
            // 
            this.cb3BHK.AutoSize = true;
            this.cb3BHK.Location = new System.Drawing.Point(860, 98);
            this.cb3BHK.Name = "cb3BHK";
            this.cb3BHK.Size = new System.Drawing.Size(54, 17);
            this.cb3BHK.TabIndex = 123;
            this.cb3BHK.Text = "3BHK";
            this.cb3BHK.UseVisualStyleBackColor = true;
            // 
            // cb25BHK
            // 
            this.cb25BHK.AutoSize = true;
            this.cb25BHK.Location = new System.Drawing.Point(800, 98);
            this.cb25BHK.Name = "cb25BHK";
            this.cb25BHK.Size = new System.Drawing.Size(63, 17);
            this.cb25BHK.TabIndex = 122;
            this.cb25BHK.Text = "2.5BHK";
            this.cb25BHK.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(276, 65);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 118;
            this.label16.Text = "Location";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(524, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 114;
            this.label14.Text = "Possession By";
            // 
            // txtBuilderName
            // 
            this.txtBuilderName.Location = new System.Drawing.Point(102, 99);
            this.txtBuilderName.Name = "txtBuilderName";
            this.txtBuilderName.Size = new System.Drawing.Size(145, 20);
            this.txtBuilderName.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 102;
            this.label3.Text = "Builder Name";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Window;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(25, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1247, 1);
            this.label12.TabIndex = 100;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(51, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 17);
            this.label10.TabIndex = 99;
            this.label10.Text = "Project Search";
            // 
            // possessionDateTo
            // 
            this.possessionDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.possessionDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.possessionDateTo.Location = new System.Drawing.Point(738, 66);
            this.possessionDateTo.Name = "possessionDateTo";
            this.possessionDateTo.Size = new System.Drawing.Size(84, 20);
            this.possessionDateTo.TabIndex = 96;
            this.possessionDateTo.Tag = "1";
            this.possessionDateTo.ValueChanged += new System.EventHandler(this.possessionDateTo_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(718, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 95;
            this.label8.Text = "To";
            // 
            // possessionDateFrom
            // 
            this.possessionDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.possessionDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.possessionDateFrom.Location = new System.Drawing.Point(632, 66);
            this.possessionDateFrom.Name = "possessionDateFrom";
            this.possessionDateFrom.Size = new System.Drawing.Size(84, 20);
            this.possessionDateFrom.TabIndex = 94;
            this.possessionDateFrom.Tag = "1";
            this.possessionDateFrom.ValueChanged += new System.EventHandler(this.possessionDateFrom_ValueChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(597, 69);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(33, 13);
            this.label50.TabIndex = 93;
            this.label50.Text = " From";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(102, 64);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(146, 20);
            this.txtProjectName.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Project Name";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(103, 137);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(56, 17);
            this.cbActive.TabIndex = 83;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExcelExport.BackColor = System.Drawing.Color.SlateGray;
            this.btnExcelExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcelExport.ForeColor = System.Drawing.Color.White;
            this.btnExcelExport.Location = new System.Drawing.Point(1213, 232);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(75, 20);
            this.btnExcelExport.TabIndex = 67;
            this.btnExcelExport.Text = "Excel Export";
            this.btnExcelExport.UseVisualStyleBackColor = false;
            // 
            // lblSearchCount
            // 
            this.lblSearchCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchCount.AutoSize = true;
            this.lblSearchCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCount.Location = new System.Drawing.Point(1046, 236);
            this.lblSearchCount.Name = "lblSearchCount";
            this.lblSearchCount.Size = new System.Drawing.Size(21, 15);
            this.lblSearchCount.TabIndex = 66;
            this.lblSearchCount.Text = "AA";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(968, 238);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 65;
            this.label18.Text = "Search Count - ";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.SlateGray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(170, 206);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 33);
            this.btnReset.TabIndex = 64;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblProjectCount
            // 
            this.lblProjectCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProjectCount.AutoSize = true;
            this.lblProjectCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectCount.Location = new System.Drawing.Point(1177, 236);
            this.lblProjectCount.Name = "lblProjectCount";
            this.lblProjectCount.Size = new System.Drawing.Size(21, 15);
            this.lblProjectCount.TabIndex = 63;
            this.lblProjectCount.Text = "AA";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1079, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Total Project Count - ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.SlateGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(262, 206);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 33);
            this.btnRefresh.TabIndex = 61;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnSearchLease
            // 
            this.btnSearchLease.BackColor = System.Drawing.Color.SlateGray;
            this.btnSearchLease.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnSearchLease.FlatAppearance.MouseDownBackColor = System.Drawing.Color.YellowGreen;
            this.btnSearchLease.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnSearchLease.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchLease.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchLease.ForeColor = System.Drawing.Color.White;
            this.btnSearchLease.Location = new System.Drawing.Point(41, 206);
            this.btnSearchLease.Name = "btnSearchLease";
            this.btnSearchLease.Size = new System.Drawing.Size(116, 33);
            this.btnSearchLease.TabIndex = 60;
            this.btnSearchLease.Text = "Search Project";
            this.btnSearchLease.UseVisualStyleBackColor = false;
            this.btnSearchLease.Click += new System.EventHandler(this.btnSearchLease_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Window;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(25, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1250, 1);
            this.label11.TabIndex = 5;
            // 
            // ProjectSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 652);
            this.Controls.Add(this.grpbLeaseSearch);
            this.Controls.Add(this.dgvProject);
            this.Name = "ProjectSearch";
            this.Text = "Project Search";
            this.Load += new System.EventHandler(this.ProjectSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).EndInit();
            this.grpbLeaseSearch.ResumeLayout(false);
            this.grpbLeaseSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProject;
        private System.Windows.Forms.Panel grpbLeaseSearch;
        private System.Windows.Forms.CheckBox cb15BHK;
        private System.Windows.Forms.CheckBox cb1HK;
        private System.Windows.Forms.CheckBox cb4BHK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb1BHK;
        private System.Windows.Forms.CheckBox cb2BHK;
        private System.Windows.Forms.CheckBox cb3BHK;
        private System.Windows.Forms.CheckBox cb25BHK;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBuilderName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker possessionDateTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker possessionDateFrom;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.Label lblSearchCount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblProjectCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearchLease;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckedListBox lbLocations;
        private System.Windows.Forms.TextBox txtLocationSearch;
    }
}