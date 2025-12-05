namespace iBroker.Forms.Lease
{
    partial class LeaseSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLease = new System.Windows.Forms.DataGridView();
            this.grpbLeaseSearch = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSocietySearch = new System.Windows.Forms.TextBox();
            this.lbSocieties = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtLocationSearch = new System.Windows.Forms.TextBox();
            this.leaseEndDateTo = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.leaseEndDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTokenNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGRNNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenantName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenantPhoneNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.registrationDateTo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.registrationDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label50 = new System.Windows.Forms.Label();
            this.txtOwnerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOwnerPhoneNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLocations = new System.Windows.Forms.ListBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblLeadCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearchLease = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLease)).BeginInit();
            this.grpbLeaseSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLease
            // 
            this.dgvLease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLease.Location = new System.Drawing.Point(0, 258);
            this.dgvLease.Name = "dgvLease";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dgvLease.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLease.Size = new System.Drawing.Size(1299, 393);
            this.dgvLease.TabIndex = 0;
            this.dgvLease.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLease_CellDoubleClick);
            // 
            // grpbLeaseSearch
            // 
            this.grpbLeaseSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbLeaseSearch.AutoSize = true;
            this.grpbLeaseSearch.BackColor = System.Drawing.Color.LightBlue;
            this.grpbLeaseSearch.Controls.Add(this.label17);
            this.grpbLeaseSearch.Controls.Add(this.label16);
            this.grpbLeaseSearch.Controls.Add(this.txtSocietySearch);
            this.grpbLeaseSearch.Controls.Add(this.lbSocieties);
            this.grpbLeaseSearch.Controls.Add(this.label15);
            this.grpbLeaseSearch.Controls.Add(this.label14);
            this.grpbLeaseSearch.Controls.Add(this.txtLocationSearch);
            this.grpbLeaseSearch.Controls.Add(this.leaseEndDateTo);
            this.grpbLeaseSearch.Controls.Add(this.label9);
            this.grpbLeaseSearch.Controls.Add(this.leaseEndDateFrom);
            this.grpbLeaseSearch.Controls.Add(this.label13);
            this.grpbLeaseSearch.Controls.Add(this.txtTokenNo);
            this.grpbLeaseSearch.Controls.Add(this.label5);
            this.grpbLeaseSearch.Controls.Add(this.txtGRNNo);
            this.grpbLeaseSearch.Controls.Add(this.label6);
            this.grpbLeaseSearch.Controls.Add(this.txtTenantName);
            this.grpbLeaseSearch.Controls.Add(this.label3);
            this.grpbLeaseSearch.Controls.Add(this.txtTenantPhoneNo);
            this.grpbLeaseSearch.Controls.Add(this.label4);
            this.grpbLeaseSearch.Controls.Add(this.label12);
            this.grpbLeaseSearch.Controls.Add(this.label10);
            this.grpbLeaseSearch.Controls.Add(this.registrationDateTo);
            this.grpbLeaseSearch.Controls.Add(this.label8);
            this.grpbLeaseSearch.Controls.Add(this.registrationDateFrom);
            this.grpbLeaseSearch.Controls.Add(this.label50);
            this.grpbLeaseSearch.Controls.Add(this.txtOwnerName);
            this.grpbLeaseSearch.Controls.Add(this.label1);
            this.grpbLeaseSearch.Controls.Add(this.txtOwnerPhoneNo);
            this.grpbLeaseSearch.Controls.Add(this.label2);
            this.grpbLeaseSearch.Controls.Add(this.lbLocations);
            this.grpbLeaseSearch.Controls.Add(this.cbActive);
            this.grpbLeaseSearch.Controls.Add(this.btnExcelExport);
            this.grpbLeaseSearch.Controls.Add(this.lblSearchCount);
            this.grpbLeaseSearch.Controls.Add(this.label18);
            this.grpbLeaseSearch.Controls.Add(this.btnReset);
            this.grpbLeaseSearch.Controls.Add(this.lblLeadCount);
            this.grpbLeaseSearch.Controls.Add(this.label7);
            this.grpbLeaseSearch.Controls.Add(this.btnRefresh);
            this.grpbLeaseSearch.Controls.Add(this.btnSearchLease);
            this.grpbLeaseSearch.Controls.Add(this.label11);
            this.grpbLeaseSearch.Location = new System.Drawing.Point(0, 0);
            this.grpbLeaseSearch.Name = "grpbLeaseSearch";
            this.grpbLeaseSearch.Size = new System.Drawing.Size(1299, 255);
            this.grpbLeaseSearch.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(938, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 13);
            this.label17.TabIndex = 119;
            this.label17.Text = "Society";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(700, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 118;
            this.label16.Text = "Location";
            // 
            // txtSocietySearch
            // 
            this.txtSocietySearch.Location = new System.Drawing.Point(998, 65);
            this.txtSocietySearch.Name = "txtSocietySearch";
            this.txtSocietySearch.Size = new System.Drawing.Size(142, 20);
            this.txtSocietySearch.TabIndex = 117;
            this.txtSocietySearch.TextChanged += new System.EventHandler(this.txtSocietySearch_TextChanged);
            // 
            // lbSocieties
            // 
            this.lbSocieties.FormattingEnabled = true;
            this.lbSocieties.Location = new System.Drawing.Point(940, 84);
            this.lbSocieties.Name = "lbSocieties";
            this.lbSocieties.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbSocieties.Size = new System.Drawing.Size(200, 69);
            this.lbSocieties.TabIndex = 116;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(333, 127);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 115;
            this.label15.Text = "Lease End Date";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(94, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 114;
            this.label14.Text = "Registration Date";
            // 
            // txtLocationSearch
            // 
            this.txtLocationSearch.Location = new System.Drawing.Point(762, 65);
            this.txtLocationSearch.Name = "txtLocationSearch";
            this.txtLocationSearch.Size = new System.Drawing.Size(147, 20);
            this.txtLocationSearch.TabIndex = 113;
            this.txtLocationSearch.TextChanged += new System.EventHandler(this.txtLocationSearch_TextChanged);
            // 
            // leaseEndDateTo
            // 
            this.leaseEndDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaseEndDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.leaseEndDateTo.Location = new System.Drawing.Point(446, 140);
            this.leaseEndDateTo.Name = "leaseEndDateTo";
            this.leaseEndDateTo.Size = new System.Drawing.Size(84, 20);
            this.leaseEndDateTo.TabIndex = 112;
            this.leaseEndDateTo.Tag = "1";
            this.leaseEndDateTo.ValueChanged += new System.EventHandler(this.leaseEndDateTo_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(426, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 111;
            this.label9.Text = "To";
            // 
            // leaseEndDateFrom
            // 
            this.leaseEndDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaseEndDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.leaseEndDateFrom.Location = new System.Drawing.Point(336, 140);
            this.leaseEndDateFrom.Name = "leaseEndDateFrom";
            this.leaseEndDateFrom.Size = new System.Drawing.Size(84, 20);
            this.leaseEndDateFrom.TabIndex = 110;
            this.leaseEndDateFrom.Tag = "1";
            this.leaseEndDateFrom.ValueChanged += new System.EventHandler(this.leaseEndDateFrom_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(307, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 109;
            this.label13.Text = "From";
            // 
            // txtTokenNo
            // 
            this.txtTokenNo.Location = new System.Drawing.Point(550, 65);
            this.txtTokenNo.Name = "txtTokenNo";
            this.txtTokenNo.Size = new System.Drawing.Size(127, 20);
            this.txtTokenNo.TabIndex = 105;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(494, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "Token No";
            // 
            // txtGRNNo
            // 
            this.txtGRNNo.Location = new System.Drawing.Point(551, 95);
            this.txtGRNNo.Name = "txtGRNNo";
            this.txtGRNNo.Size = new System.Drawing.Size(126, 20);
            this.txtGRNNo.TabIndex = 107;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 108;
            this.label6.Text = "GRN No";
            // 
            // txtTenantName
            // 
            this.txtTenantName.Location = new System.Drawing.Point(336, 64);
            this.txtTenantName.Name = "txtTenantName";
            this.txtTenantName.Size = new System.Drawing.Size(145, 20);
            this.txtTenantName.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 102;
            this.label3.Text = "Tenant Name";
            // 
            // txtTenantPhoneNo
            // 
            this.txtTenantPhoneNo.Location = new System.Drawing.Point(336, 94);
            this.txtTenantPhoneNo.Name = "txtTenantPhoneNo";
            this.txtTenantPhoneNo.Size = new System.Drawing.Size(145, 20);
            this.txtTenantPhoneNo.TabIndex = 103;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 104;
            this.label4.Text = "Tenant PhoneNo";
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
            this.label10.Size = new System.Drawing.Size(108, 17);
            this.label10.TabIndex = 99;
            this.label10.Text = "Lease Search";
            // 
            // registrationDateTo
            // 
            this.registrationDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.registrationDateTo.Location = new System.Drawing.Point(204, 139);
            this.registrationDateTo.Name = "registrationDateTo";
            this.registrationDateTo.Size = new System.Drawing.Size(84, 20);
            this.registrationDateTo.TabIndex = 96;
            this.registrationDateTo.Tag = "1";
            this.registrationDateTo.ValueChanged += new System.EventHandler(this.registrationDateTo_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(184, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 95;
            this.label8.Text = "To";
            // 
            // registrationDateFrom
            // 
            this.registrationDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.registrationDateFrom.Location = new System.Drawing.Point(98, 139);
            this.registrationDateFrom.Name = "registrationDateFrom";
            this.registrationDateFrom.Size = new System.Drawing.Size(84, 20);
            this.registrationDateFrom.TabIndex = 94;
            this.registrationDateFrom.Tag = "1";
            this.registrationDateFrom.ValueChanged += new System.EventHandler(this.registrationDateFrom_ValueChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(60, 140);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(33, 13);
            this.label50.TabIndex = 93;
            this.label50.Text = " From";
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.Location = new System.Drawing.Point(98, 64);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(146, 20);
            this.txtOwnerName.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Owner Name";
            // 
            // txtOwnerPhoneNo
            // 
            this.txtOwnerPhoneNo.Location = new System.Drawing.Point(98, 94);
            this.txtOwnerPhoneNo.Name = "txtOwnerPhoneNo";
            this.txtOwnerPhoneNo.Size = new System.Drawing.Size(146, 20);
            this.txtOwnerPhoneNo.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Owner PhoneNo";
            // 
            // lbLocations
            // 
            this.lbLocations.FormattingEnabled = true;
            this.lbLocations.Location = new System.Drawing.Point(702, 84);
            this.lbLocations.Name = "lbLocations";
            this.lbLocations.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbLocations.Size = new System.Drawing.Size(207, 69);
            this.lbLocations.TabIndex = 88;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(551, 142);
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
            // lblLeadCount
            // 
            this.lblLeadCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeadCount.AutoSize = true;
            this.lblLeadCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeadCount.Location = new System.Drawing.Point(1177, 236);
            this.lblLeadCount.Name = "lblLeadCount";
            this.lblLeadCount.Size = new System.Drawing.Size(21, 15);
            this.lblLeadCount.TabIndex = 63;
            this.lblLeadCount.Text = "AA";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1079, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Total Lease Count - ";
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
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.btnSearchLease.Text = "Search Lease";
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
            // LeaseSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 652);
            this.Controls.Add(this.grpbLeaseSearch);
            this.Controls.Add(this.dgvLease);
            this.Name = "LeaseSearch";
            this.Text = "Lease Search";
            this.Load += new System.EventHandler(this.LeaseSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLease)).EndInit();
            this.grpbLeaseSearch.ResumeLayout(false);
            this.grpbLeaseSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLease;
        private System.Windows.Forms.Panel grpbLeaseSearch;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSocietySearch;
        private System.Windows.Forms.ListBox lbSocieties;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtLocationSearch;
        private System.Windows.Forms.DateTimePicker leaseEndDateTo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker leaseEndDateFrom;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTokenNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGRNNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenantName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenantPhoneNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker registrationDateTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker registrationDateFrom;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox txtOwnerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOwnerPhoneNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbLocations;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.Label lblSearchCount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblLeadCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearchLease;
        private System.Windows.Forms.Label label11;
    }
}