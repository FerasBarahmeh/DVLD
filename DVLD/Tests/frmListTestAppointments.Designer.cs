namespace DVLD.Tests
{
    partial class frmListTestAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListTestAppointments));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbTestTypeImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewAppointment = new System.Windows.Forms.Button();
            this.dgvLicenseTestAppointments = new System.Windows.Forms.DataGridView();
            this.cmsAppointmentOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTackTest = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.ctrlDrivingLicenseApplicationInfo = new DVLD.Applications.Local_Driving_License.Controls.ctrlDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseTestAppointments)).BeginInit();
            this.cmsAppointmentOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(200, 107);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(441, 39);
            this.lblTitle.TabIndex = 135;
            this.lblTitle.Text = "Vision Test Appointments";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTestTypeImage
            // 
            this.pbTestTypeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTestTypeImage.Image = ((System.Drawing.Image)(resources.GetObject("pbTestTypeImage.Image")));
            this.pbTestTypeImage.InitialImage = null;
            this.pbTestTypeImage.Location = new System.Drawing.Point(359, 10);
            this.pbTestTypeImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbTestTypeImage.Name = "pbTestTypeImage";
            this.pbTestTypeImage.Size = new System.Drawing.Size(113, 92);
            this.pbTestTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestTypeImage.TabIndex = 134;
            this.pbTestTypeImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 25);
            this.label2.TabIndex = 138;
            this.label2.Text = "Appointments:";
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewAppointment.Image")));
            this.btnAddNewAppointment.Location = new System.Drawing.Point(749, 532);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(49, 36);
            this.btnAddNewAppointment.TabIndex = 139;
            this.btnAddNewAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewAppointment.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // dgvLicenseTestAppointments
            // 
            this.dgvLicenseTestAppointments.AllowUserToAddRows = false;
            this.dgvLicenseTestAppointments.AllowUserToDeleteRows = false;
            this.dgvLicenseTestAppointments.AllowUserToResizeRows = false;
            this.dgvLicenseTestAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvLicenseTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicenseTestAppointments.ContextMenuStrip = this.cmsAppointmentOptions;
            this.dgvLicenseTestAppointments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLicenseTestAppointments.Location = new System.Drawing.Point(12, 579);
            this.dgvLicenseTestAppointments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLicenseTestAppointments.MultiSelect = false;
            this.dgvLicenseTestAppointments.Name = "dgvLicenseTestAppointments";
            this.dgvLicenseTestAppointments.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLicenseTestAppointments.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLicenseTestAppointments.RowHeadersWidth = 51;
            this.dgvLicenseTestAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLicenseTestAppointments.Size = new System.Drawing.Size(814, 161);
            this.dgvLicenseTestAppointments.TabIndex = 140;
            this.dgvLicenseTestAppointments.TabStop = false;
            // 
            // cmsAppointmentOptions
            // 
            this.cmsAppointmentOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAppointmentOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditTool,
            this.tsmiTackTest});
            this.cmsAppointmentOptions.Name = "cmsAppointmentOptions";
            this.cmsAppointmentOptions.Size = new System.Drawing.Size(215, 84);
            // 
            // tsmiEditTool
            // 
            this.tsmiEditTool.Image = global::DVLD.Properties.Resources.edit_32;
            this.tsmiEditTool.Name = "tsmiEditTool";
            this.tsmiEditTool.Size = new System.Drawing.Size(214, 26);
            this.tsmiEditTool.Text = "Edit";
            this.tsmiEditTool.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // tsmiTackTest
            // 
            this.tsmiTackTest.Image = global::DVLD.Properties.Resources.Test_32;
            this.tsmiTackTest.Name = "tsmiTackTest";
            this.tsmiTackTest.Size = new System.Drawing.Size(214, 26);
            this.tsmiTackTest.Text = "Tack Test";
            this.tsmiTackTest.Click += new System.EventHandler(this.tackTestToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 762);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 141;
            this.label1.Text = "# Records:";
            // 
            // btnClose
            // 
            this.btnClose.AutoEllipsis = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(691, 759);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 142;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(150, 768);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(14, 16);
            this.lblRecordCount.TabIndex = 143;
            this.lblRecordCount.Text = "?";
            // 
            // ctrlDrivingLicenseApplicationInfo
            // 
            this.ctrlDrivingLicenseApplicationInfo.BackColor = System.Drawing.Color.White;
            this.ctrlDrivingLicenseApplicationInfo.Location = new System.Drawing.Point(12, 149);
            this.ctrlDrivingLicenseApplicationInfo.Name = "ctrlDrivingLicenseApplicationInfo";
            this.ctrlDrivingLicenseApplicationInfo.Size = new System.Drawing.Size(814, 370);
            this.ctrlDrivingLicenseApplicationInfo.TabIndex = 136;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(841, 798);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLicenseTestAppointments);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbTestTypeImage);
            this.Name = "frmListTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmListTestAppointments";
            this.Load += new System.EventHandler(this.frmListTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseTestAppointments)).EndInit();
            this.cmsAppointmentOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbTestTypeImage;
        private Applications.Local_Driving_License.Controls.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewAppointment;
        private System.Windows.Forms.DataGridView dgvLicenseTestAppointments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.ContextMenuStrip cmsAppointmentOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditTool;
        private System.Windows.Forms.ToolStripMenuItem tsmiTackTest;
    }
}