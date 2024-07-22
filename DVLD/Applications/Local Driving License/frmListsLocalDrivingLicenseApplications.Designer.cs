namespace DVLD.Applications.Local_Driving_License
{
    partial class frmListsLocalDrivingLicenseApplications
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvListLocalDrivingApplicationLicense = new System.Windows.Forms.DataGridView();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCancelApplicaiton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.stmiScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiIssueDrivingLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListLocalDrivingApplicationLicense)).BeginInit();
            this.cmsApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::DVLD.Properties.Resources.Applications;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(645, 14);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 189);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 129;
            this.pbPersonImage.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Local_32;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(840, 51);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 131;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(480, 223);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(568, 50);
            this.lblTitle.TabIndex = 132;
            this.lblTitle.Text = "Local Driving License Applications";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(127, 285);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(210, 24);
            this.cbFilterBy.TabIndex = 135;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(344, 285);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(256, 22);
            this.txtFilterValue.TabIndex = 134;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 133;
            this.label1.Text = "Filter By:";
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewApplication.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewApplication.Location = new System.Drawing.Point(1239, 274);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(144, 36);
            this.btnAddNewApplication.TabIndex = 136;
            this.btnAddNewApplication.Text = "New application";
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 704);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 138;
            this.label2.Text = "Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(128, 711);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(21, 16);
            this.lblRecordsCount.TabIndex = 139;
            this.lblRecordsCount.Text = "??";
            // 
            // btnClose
            // 
            this.btnClose.AutoEllipsis = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1271, 701);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 36);
            this.btnClose.TabIndex = 140;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvListLocalDrivingApplicationLicense
            // 
            this.dgvListLocalDrivingApplicationLicense.AllowUserToAddRows = false;
            this.dgvListLocalDrivingApplicationLicense.AllowUserToDeleteRows = false;
            this.dgvListLocalDrivingApplicationLicense.AllowUserToResizeRows = false;
            this.dgvListLocalDrivingApplicationLicense.BackgroundColor = System.Drawing.Color.White;
            this.dgvListLocalDrivingApplicationLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListLocalDrivingApplicationLicense.ContextMenuStrip = this.cmsApplications;
            this.dgvListLocalDrivingApplicationLicense.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListLocalDrivingApplicationLicense.Location = new System.Drawing.Point(13, 322);
            this.dgvListLocalDrivingApplicationLicense.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvListLocalDrivingApplicationLicense.MultiSelect = false;
            this.dgvListLocalDrivingApplicationLicense.Name = "dgvListLocalDrivingApplicationLicense";
            this.dgvListLocalDrivingApplicationLicense.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListLocalDrivingApplicationLicense.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListLocalDrivingApplicationLicense.RowHeadersWidth = 51;
            this.dgvListLocalDrivingApplicationLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListLocalDrivingApplicationLicense.Size = new System.Drawing.Size(1405, 353);
            this.dgvListLocalDrivingApplicationLicense.TabIndex = 141;
            this.dgvListLocalDrivingApplicationLicense.TabStop = false;
            // 
            // cmsApplications
            // 
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator2,
            this.tsmiEdit,
            this.tsmiDeleteApplication,
            this.toolStripSeparator5,
            this.tsmiCancelApplicaiton,
            this.toolStripSeparator1,
            this.stmiScheduleTests,
            this.toolStripSeparator3,
            this.tsmiIssueDrivingLicenseFirstTime,
            this.toolStripSeparator4,
            this.tsmiShowLicense,
            this.toolStripSeparator6,
            this.tsmiShowPersonLicenseHistory});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.Size = new System.Drawing.Size(309, 372);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showDetailsToolStripMenuItem.Text = "&Show Application Details";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(305, 6);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Image = global::DVLD.Properties.Resources.edit_32;
            this.tsmiEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(308, 38);
            this.tsmiEdit.Text = "&Edit Application";
            // 
            // tsmiDeleteApplication
            // 
            this.tsmiDeleteApplication.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.tsmiDeleteApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiDeleteApplication.Name = "tsmiDeleteApplication";
            this.tsmiDeleteApplication.Size = new System.Drawing.Size(308, 38);
            this.tsmiDeleteApplication.Text = "&Delete Application";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(305, 6);
            // 
            // tsmiCancelApplicaiton
            // 
            this.tsmiCancelApplicaiton.Image = global::DVLD.Properties.Resources.Delete_32;
            this.tsmiCancelApplicaiton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiCancelApplicaiton.Name = "tsmiCancelApplicaiton";
            this.tsmiCancelApplicaiton.Size = new System.Drawing.Size(308, 38);
            this.tsmiCancelApplicaiton.Text = "&Cancel Application";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(305, 6);
            // 
            // stmiScheduleTests
            // 
            this.stmiScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.stmiScheduleTests.Image = global::DVLD.Properties.Resources.Schedule_Test_32;
            this.stmiScheduleTests.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stmiScheduleTests.Name = "stmiScheduleTests";
            this.stmiScheduleTests.Size = new System.Drawing.Size(308, 38);
            this.stmiScheduleTests.Text = "Sechdule &Tests";
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Vision_Test_32;
            this.scheduleVisionTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Written_Test_32;
            this.scheduleWrittenTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            this.scheduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleWrittenTestToolStripMenuItem_Click);
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Street_Test_32;
            this.scheduleStreetTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(305, 6);
            // 
            // tsmiIssueDrivingLicenseFirstTime
            // 
            this.tsmiIssueDrivingLicenseFirstTime.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.tsmiIssueDrivingLicenseFirstTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiIssueDrivingLicenseFirstTime.Name = "tsmiIssueDrivingLicenseFirstTime";
            this.tsmiIssueDrivingLicenseFirstTime.Size = new System.Drawing.Size(308, 38);
            this.tsmiIssueDrivingLicenseFirstTime.Text = "&Issue Driving License (First Time)";
            this.tsmiIssueDrivingLicenseFirstTime.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(305, 6);
            // 
            // tsmiShowLicense
            // 
            this.tsmiShowLicense.Image = global::DVLD.Properties.Resources.License_View_32;
            this.tsmiShowLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowLicense.Name = "tsmiShowLicense";
            this.tsmiShowLicense.Size = new System.Drawing.Size(308, 38);
            this.tsmiShowLicense.Text = "Show &License";
            this.tsmiShowLicense.Click += new System.EventHandler(this.tsmiShowLicense_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(305, 6);
            // 
            // tsmiShowPersonLicenseHistory
            // 
            this.tsmiShowPersonLicenseHistory.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.tsmiShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowPersonLicenseHistory.Name = "tsmiShowPersonLicenseHistory";
            this.tsmiShowPersonLicenseHistory.Size = new System.Drawing.Size(308, 38);
            this.tsmiShowPersonLicenseHistory.Text = "Show Person License History";
            // 
            // frmListsLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1431, 749);
            this.Controls.Add(this.dgvListLocalDrivingApplicationLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbPersonImage);
            this.Name = "frmListsLocalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Driving License Applications";
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListLocalDrivingApplicationLicense)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvListLocalDrivingApplicationLicense;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelApplicaiton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem stmiScheduleTests;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiIssueDrivingLicenseFirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonLicenseHistory;
    }
}