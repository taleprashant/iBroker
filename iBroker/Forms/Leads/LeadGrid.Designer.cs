namespace iBroker.Forms.Leads
{
    partial class LeadGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cmbTransaction = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPropType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cb3BHK = new System.Windows.Forms.CheckBox();
            this.cb25BHK = new System.Windows.Forms.CheckBox();
            this.cb2BHK = new System.Windows.Forms.CheckBox();
            this.cb1BHK = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.cbNonFurnished = new System.Windows.Forms.CheckBox();
            this.cbSemiFurnished = new System.Windows.Forms.CheckBox();
            this.cbFullyFurnished = new System.Windows.Forms.CheckBox();
            this.lbLocations = new System.Windows.Forms.ListBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBudgetMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBudgetMax = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLeadCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cb1HK = new System.Windows.Forms.CheckBox();
            this.cb4BHK = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.reminderDateTo = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.reminderDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.registrationDateTo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.registrationDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label50 = new System.Windows.Forms.Label();
            this.cb15BHK = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 248);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(1303, 427);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(86, 58);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(161, 20);
            this.txtClientName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ClientName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "PhoneNo";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(86, 88);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(161, 20);
            this.txtPhoneNo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(86, 119);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(161, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // cmbTransaction
            // 
            this.cmbTransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransaction.FormattingEnabled = true;
            this.cmbTransaction.Items.AddRange(new object[] {
            " ",
            "Rent",
            "Buy",
            "ALL"});
            this.cmbTransaction.Location = new System.Drawing.Point(340, 58);
            this.cmbTransaction.Name = "cmbTransaction";
            this.cmbTransaction.Size = new System.Drawing.Size(121, 21);
            this.cmbTransaction.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Transaction";
            // 
            // cmbPropType
            // 
            this.cmbPropType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropType.FormattingEnabled = true;
            this.cmbPropType.Items.AddRange(new object[] {
            " ",
            "Residential",
            "Commercial",
            "Plots",
            "ALL"});
            this.cmbPropType.Location = new System.Drawing.Point(340, 89);
            this.cmbPropType.Name = "cmbPropType";
            this.cmbPropType.Size = new System.Drawing.Size(121, 21);
            this.cmbPropType.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(304, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Type";
            // 
            // cb3BHK
            // 
            this.cb3BHK.AutoSize = true;
            this.cb3BHK.Location = new System.Drawing.Point(868, 58);
            this.cb3BHK.Name = "cb3BHK";
            this.cb3BHK.Size = new System.Drawing.Size(54, 17);
            this.cb3BHK.TabIndex = 17;
            this.cb3BHK.Text = "3BHK";
            this.cb3BHK.UseVisualStyleBackColor = true;
            // 
            // cb25BHK
            // 
            this.cb25BHK.AutoSize = true;
            this.cb25BHK.Location = new System.Drawing.Point(799, 58);
            this.cb25BHK.Name = "cb25BHK";
            this.cb25BHK.Size = new System.Drawing.Size(63, 17);
            this.cb25BHK.TabIndex = 16;
            this.cb25BHK.Text = "2.5BHK";
            this.cb25BHK.UseVisualStyleBackColor = true;
            // 
            // cb2BHK
            // 
            this.cb2BHK.AutoSize = true;
            this.cb2BHK.Location = new System.Drawing.Point(741, 58);
            this.cb2BHK.Name = "cb2BHK";
            this.cb2BHK.Size = new System.Drawing.Size(54, 17);
            this.cb2BHK.TabIndex = 15;
            this.cb2BHK.Text = "2BHK";
            this.cb2BHK.UseVisualStyleBackColor = true;
            // 
            // cb1BHK
            // 
            this.cb1BHK.AutoSize = true;
            this.cb1BHK.Location = new System.Drawing.Point(626, 58);
            this.cb1BHK.Name = "cb1BHK";
            this.cb1BHK.Size = new System.Drawing.Size(54, 17);
            this.cb1BHK.TabIndex = 14;
            this.cb1BHK.Text = "1BHK";
            this.cb1BHK.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(488, 58);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 13;
            this.label16.Text = "No of Bedrooms";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateGray;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.YellowGreen;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(85, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 33);
            this.button1.TabIndex = 18;
            this.button1.Text = "Search Lead";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(86, 150);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(56, 17);
            this.cbActive.TabIndex = 19;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // cbNonFurnished
            // 
            this.cbNonFurnished.AutoSize = true;
            this.cbNonFurnished.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNonFurnished.Location = new System.Drawing.Point(715, 84);
            this.cbNonFurnished.Name = "cbNonFurnished";
            this.cbNonFurnished.Size = new System.Drawing.Size(95, 17);
            this.cbNonFurnished.TabIndex = 29;
            this.cbNonFurnished.Text = "Non Furnished";
            this.cbNonFurnished.UseVisualStyleBackColor = true;
            // 
            // cbSemiFurnished
            // 
            this.cbSemiFurnished.AutoSize = true;
            this.cbSemiFurnished.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSemiFurnished.Location = new System.Drawing.Point(600, 84);
            this.cbSemiFurnished.Name = "cbSemiFurnished";
            this.cbSemiFurnished.Size = new System.Drawing.Size(98, 17);
            this.cbSemiFurnished.TabIndex = 28;
            this.cbSemiFurnished.Text = "Semi Furnished";
            this.cbSemiFurnished.UseVisualStyleBackColor = true;
            // 
            // cbFullyFurnished
            // 
            this.cbFullyFurnished.AutoSize = true;
            this.cbFullyFurnished.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFullyFurnished.Location = new System.Drawing.Point(491, 83);
            this.cbFullyFurnished.Name = "cbFullyFurnished";
            this.cbFullyFurnished.Size = new System.Drawing.Size(96, 17);
            this.cbFullyFurnished.TabIndex = 27;
            this.cbFullyFurnished.Text = "Fully Furnished";
            this.cbFullyFurnished.UseVisualStyleBackColor = true;
            // 
            // lbLocations
            // 
            this.lbLocations.FormattingEnabled = true;
            this.lbLocations.Location = new System.Drawing.Point(553, 107);
            this.lbLocations.Name = "lbLocations";
            this.lbLocations.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbLocations.Size = new System.Drawing.Size(247, 69);
            this.lbLocations.TabIndex = 33;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(489, 107);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(60, 15);
            this.label42.TabIndex = 32;
            this.label42.Text = "Locations";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(878, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Budget Min";
            // 
            // txtBudgetMin
            // 
            this.txtBudgetMin.Location = new System.Drawing.Point(941, 144);
            this.txtBudgetMin.Name = "txtBudgetMin";
            this.txtBudgetMin.Size = new System.Drawing.Size(83, 20);
            this.txtBudgetMin.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1025, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Max";
            // 
            // txtBudgetMax
            // 
            this.txtBudgetMax.Location = new System.Drawing.Point(1051, 144);
            this.txtBudgetMax.Name = "txtBudgetMax";
            this.txtBudgetMax.Size = new System.Drawing.Size(83, 20);
            this.txtBudgetMax.TabIndex = 36;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.SlateGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(306, 200);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 33);
            this.btnRefresh.TabIndex = 38;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1085, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Total Lead Count - ";
            // 
            // lblLeadCount
            // 
            this.lblLeadCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeadCount.AutoSize = true;
            this.lblLeadCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeadCount.Location = new System.Drawing.Point(1179, 226);
            this.lblLeadCount.Name = "lblLeadCount";
            this.lblLeadCount.Size = new System.Drawing.Size(21, 15);
            this.lblLeadCount.TabIndex = 40;
            this.lblLeadCount.Text = "AA";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.cb15BHK);
            this.panel1.Controls.Add(this.btnExcelExport);
            this.panel1.Controls.Add(this.lblSearchCount);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.cb1HK);
            this.panel1.Controls.Add(this.cb4BHK);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.reminderDateTo);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.reminderDateFrom);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbSource);
            this.panel1.Controls.Add(this.registrationDateTo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.registrationDateFrom);
            this.panel1.Controls.Add(this.label50);
            this.panel1.Controls.Add(this.txtClientName);
            this.panel1.Controls.Add(this.lblLeadCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtPhoneNo);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtBudgetMax);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtBudgetMin);
            this.panel1.Controls.Add(this.cmbPropType);
            this.panel1.Controls.Add(this.lbLocations);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbNonFurnished);
            this.panel1.Controls.Add(this.cbSemiFurnished);
            this.panel1.Controls.Add(this.cmbTransaction);
            this.panel1.Controls.Add(this.cbFullyFurnished);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.cbActive);
            this.panel1.Controls.Add(this.cb1BHK);
            this.panel1.Controls.Add(this.cb2BHK);
            this.panel1.Controls.Add(this.cb3BHK);
            this.panel1.Controls.Add(this.cb25BHK);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1303, 247);
            this.panel1.TabIndex = 41;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExcelExport.BackColor = System.Drawing.Color.SlateGray;
            this.btnExcelExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcelExport.ForeColor = System.Drawing.Color.White;
            this.btnExcelExport.Location = new System.Drawing.Point(1215, 220);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(75, 23);
            this.btnExcelExport.TabIndex = 59;
            this.btnExcelExport.Text = "Excel Export";
            this.btnExcelExport.UseVisualStyleBackColor = false;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // lblSearchCount
            // 
            this.lblSearchCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchCount.AutoSize = true;
            this.lblSearchCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCount.Location = new System.Drawing.Point(1048, 226);
            this.lblSearchCount.Name = "lblSearchCount";
            this.lblSearchCount.Size = new System.Drawing.Size(21, 15);
            this.lblSearchCount.TabIndex = 58;
            this.lblSearchCount.Text = "AA";
            this.lblSearchCount.Click += new System.EventHandler(this.lblSearchCount_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(970, 228);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 57;
            this.label18.Text = "Search Count - ";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // cb1HK
            // 
            this.cb1HK.AutoSize = true;
            this.cb1HK.Location = new System.Drawing.Point(576, 58);
            this.cb1HK.Name = "cb1HK";
            this.cb1HK.Size = new System.Drawing.Size(47, 17);
            this.cb1HK.TabIndex = 56;
            this.cb1HK.Text = "1HK";
            this.cb1HK.UseVisualStyleBackColor = true;
            // 
            // cb4BHK
            // 
            this.cb4BHK.AutoSize = true;
            this.cb4BHK.Location = new System.Drawing.Point(927, 58);
            this.cb4BHK.Name = "cb4BHK";
            this.cb4BHK.Size = new System.Drawing.Size(54, 17);
            this.cb4BHK.TabIndex = 55;
            this.cb4BHK.Text = "4BHK";
            this.cb4BHK.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.SlateGray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(214, 200);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 33);
            this.btnReset.TabIndex = 54;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // reminderDateTo
            // 
            this.reminderDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reminderDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.reminderDateTo.Location = new System.Drawing.Point(1050, 115);
            this.reminderDateTo.Name = "reminderDateTo";
            this.reminderDateTo.Size = new System.Drawing.Size(84, 20);
            this.reminderDateTo.TabIndex = 53;
            this.reminderDateTo.Tag = "1";
            this.reminderDateTo.ValueChanged += new System.EventHandler(this.reminderDateTo_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1030, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 52;
            this.label13.Text = "To";
            // 
            // reminderDateFrom
            // 
            this.reminderDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reminderDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.reminderDateFrom.Location = new System.Drawing.Point(940, 115);
            this.reminderDateFrom.Name = "reminderDateFrom";
            this.reminderDateFrom.Size = new System.Drawing.Size(84, 20);
            this.reminderDateFrom.TabIndex = 51;
            this.reminderDateFrom.Tag = "1";
            this.reminderDateFrom.ValueChanged += new System.EventHandler(this.reminderDateFrom_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(836, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 13);
            this.label17.TabIndex = 50;
            this.label17.Text = "Reminder Date From";
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(18, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1277, 1);
            this.label12.TabIndex = 49;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(22, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1277, 1);
            this.label11.TabIndex = 48;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(86, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 17);
            this.label10.TabIndex = 47;
            this.label10.Text = "Lead Search";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(297, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Source";
            // 
            // cmbSource
            // 
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(340, 119);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(121, 21);
            this.cmbSource.TabIndex = 46;
            this.cmbSource.Click += new System.EventHandler(this.cmbSource_Click);
            // 
            // registrationDateTo
            // 
            this.registrationDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.registrationDateTo.Location = new System.Drawing.Point(1050, 85);
            this.registrationDateTo.Name = "registrationDateTo";
            this.registrationDateTo.Size = new System.Drawing.Size(84, 20);
            this.registrationDateTo.TabIndex = 44;
            this.registrationDateTo.Tag = "1";
            this.registrationDateTo.ValueChanged += new System.EventHandler(this.registrationDateTo_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1030, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "To";
            // 
            // registrationDateFrom
            // 
            this.registrationDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.registrationDateFrom.Location = new System.Drawing.Point(940, 85);
            this.registrationDateFrom.Name = "registrationDateFrom";
            this.registrationDateFrom.Size = new System.Drawing.Size(84, 20);
            this.registrationDateFrom.TabIndex = 42;
            this.registrationDateFrom.Tag = "1";
            this.registrationDateFrom.ValueChanged += new System.EventHandler(this.registrationDateFrom_ValueChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(828, 86);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(115, 13);
            this.label50.TabIndex = 41;
            this.label50.Text = "Registration Date From";
            // 
            // cb15BHK
            // 
            this.cb15BHK.AutoSize = true;
            this.cb15BHK.Location = new System.Drawing.Point(678, 58);
            this.cb15BHK.Name = "cb15BHK";
            this.cb15BHK.Size = new System.Drawing.Size(63, 17);
            this.cb15BHK.TabIndex = 60;
            this.cb15BHK.Text = "1.5BHK";
            this.cb15BHK.UseVisualStyleBackColor = true;
            // 
            // LeadGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 677);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LeadGrid";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Lead Search";
            this.Load += new System.EventHandler(this.LeadGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.ComboBox cmbTransaction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPropType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cb3BHK;
        private System.Windows.Forms.CheckBox cb25BHK;
        private System.Windows.Forms.CheckBox cb2BHK;
        private System.Windows.Forms.CheckBox cb1BHK;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.CheckBox cbNonFurnished;
        private System.Windows.Forms.CheckBox cbSemiFurnished;
        private System.Windows.Forms.CheckBox cbFullyFurnished;
        private System.Windows.Forms.ListBox lbLocations;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBudgetMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBudgetMax;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLeadCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.DateTimePicker registrationDateTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker registrationDateFrom;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker reminderDateTo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker reminderDateFrom;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox cb1HK;
        private System.Windows.Forms.CheckBox cb4BHK;
        private System.Windows.Forms.Label lblSearchCount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.CheckBox cb15BHK;
    }
}