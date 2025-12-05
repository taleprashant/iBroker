namespace iBroker.Forms.Admin
{
    partial class DatabaseBackup
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
            this.fbdBackupFileLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBackupFileLocation = new System.Windows.Forms.TextBox();
            this.btnGenerateBackup = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUploadGCloud = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Backup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Backup File Location";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(529, 27);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(56, 24);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBackupFileLocation
            // 
            this.txtBackupFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupFileLocation.Location = new System.Drawing.Point(148, 27);
            this.txtBackupFileLocation.Name = "txtBackupFileLocation";
            this.txtBackupFileLocation.Size = new System.Drawing.Size(375, 21);
            this.txtBackupFileLocation.TabIndex = 3;
            // 
            // btnGenerateBackup
            // 
            this.btnGenerateBackup.BackColor = System.Drawing.Color.SlateGray;
            this.btnGenerateBackup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateBackup.ForeColor = System.Drawing.Color.White;
            this.btnGenerateBackup.Location = new System.Drawing.Point(148, 81);
            this.btnGenerateBackup.Name = "btnGenerateBackup";
            this.btnGenerateBackup.Size = new System.Drawing.Size(112, 27);
            this.btnGenerateBackup.TabIndex = 4;
            this.btnGenerateBackup.Text = "Generate Backup";
            this.btnGenerateBackup.UseVisualStyleBackColor = false;
            this.btnGenerateBackup.Click += new System.EventHandler(this.btnGenerateBackup_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SlateGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(443, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUploadGCloud
            // 
            this.btnUploadGCloud.BackColor = System.Drawing.Color.SlateGray;
            this.btnUploadGCloud.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUploadGCloud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadGCloud.ForeColor = System.Drawing.Color.White;
            this.btnUploadGCloud.Location = new System.Drawing.Point(277, 81);
            this.btnUploadGCloud.Name = "btnUploadGCloud";
            this.btnUploadGCloud.Size = new System.Drawing.Size(151, 27);
            this.btnUploadGCloud.TabIndex = 6;
            this.btnUploadGCloud.Text = "Upload To Google Drive";
            this.btnUploadGCloud.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.txtBackupFileLocation);
            this.panel1.Controls.Add(this.btnUploadGCloud);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.btnGenerateBackup);
            this.panel1.Location = new System.Drawing.Point(88, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 158);
            this.panel1.TabIndex = 7;
            // 
            // DatabaseBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 556);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DatabaseBackup";
            this.Text = "DatabaseBackup";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdBackupFileLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBackupFileLocation;
        private System.Windows.Forms.Button btnGenerateBackup;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUploadGCloud;
        private System.Windows.Forms.Panel panel1;
    }
}