namespace DVLD.Applications.Local_Driving_License
{
    partial class frmInsertUpdateLocalDrivingLicenseApplication
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tcInsertUpdateLocalDrivingLicenseApplication = new System.Windows.Forms.TabControl();
            this.tpPersonInformation = new System.Windows.Forms.TabPage();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.ctrlUserCardWithFilter = new DVLD.People.Controls.ctrlUserCardWithFilter();
            this.tpApplicationInformation = new System.Windows.Forms.TabPage();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLocalDrivingLicebseApplicationID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcInsertUpdateLocalDrivingLicenseApplication.SuspendLayout();
            this.tpPersonInformation.SuspendLayout();
            this.tpApplicationInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1042, 672);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 43);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(365, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(698, 38);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "Add New Local Driving Liceense Application";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1183, 672);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 43);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tcInsertUpdateLocalDrivingLicenseApplication
            // 
            this.tcInsertUpdateLocalDrivingLicenseApplication.Controls.Add(this.tpPersonInformation);
            this.tcInsertUpdateLocalDrivingLicenseApplication.Controls.Add(this.tpApplicationInformation);
            this.tcInsertUpdateLocalDrivingLicenseApplication.Location = new System.Drawing.Point(87, 50);
            this.tcInsertUpdateLocalDrivingLicenseApplication.Name = "tcInsertUpdateLocalDrivingLicenseApplication";
            this.tcInsertUpdateLocalDrivingLicenseApplication.SelectedIndex = 0;
            this.tcInsertUpdateLocalDrivingLicenseApplication.Size = new System.Drawing.Size(1213, 593);
            this.tcInsertUpdateLocalDrivingLicenseApplication.TabIndex = 16;
            this.tcInsertUpdateLocalDrivingLicenseApplication.SelectedIndexChanged += new System.EventHandler(this.tcInsertUpdateLocalDrivingLicenseApplication_SelectedIndexChanged);
            // 
            // tpPersonInformation
            // 
            this.tpPersonInformation.BackColor = System.Drawing.Color.White;
            this.tpPersonInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tpPersonInformation.Controls.Add(this.btnNextStep);
            this.tpPersonInformation.Controls.Add(this.ctrlUserCardWithFilter);
            this.tpPersonInformation.Location = new System.Drawing.Point(4, 25);
            this.tpPersonInformation.Name = "tpPersonInformation";
            this.tpPersonInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonInformation.Size = new System.Drawing.Size(1205, 564);
            this.tpPersonInformation.TabIndex = 0;
            this.tpPersonInformation.Text = "Person Information";
            // 
            // btnNextStep
            // 
            this.btnNextStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextStep.Image = global::DVLD.Properties.Resources.Next_32;
            this.btnNextStep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNextStep.Location = new System.Drawing.Point(935, 492);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(131, 44);
            this.btnNextStep.TabIndex = 3;
            this.btnNextStep.Text = "Next";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // ctrlUserCardWithFilter
            // 
            this.ctrlUserCardWithFilter.AutoSize = true;
            this.ctrlUserCardWithFilter.BackColor = System.Drawing.Color.White;
            this.ctrlUserCardWithFilter.Location = new System.Drawing.Point(24, 15);
            this.ctrlUserCardWithFilter.Name = "ctrlUserCardWithFilter";
            this.ctrlUserCardWithFilter.Size = new System.Drawing.Size(1167, 530);
            this.ctrlUserCardWithFilter.TabIndex = 0;
            // 
            // tpApplicationInformation
            // 
            this.tpApplicationInformation.BackColor = System.Drawing.Color.White;
            this.tpApplicationInformation.Controls.Add(this.lblCreatedBy);
            this.tpApplicationInformation.Controls.Add(this.lblApplicationDate);
            this.tpApplicationInformation.Controls.Add(this.lblApplicationFees);
            this.tpApplicationInformation.Controls.Add(this.cbLicenseClass);
            this.tpApplicationInformation.Controls.Add(this.pictureBox3);
            this.tpApplicationInformation.Controls.Add(this.pictureBox2);
            this.tpApplicationInformation.Controls.Add(this.pictureBox6);
            this.tpApplicationInformation.Controls.Add(this.pictureBox5);
            this.tpApplicationInformation.Controls.Add(this.label1);
            this.tpApplicationInformation.Controls.Add(this.lblLocalDrivingLicebseApplicationID);
            this.tpApplicationInformation.Controls.Add(this.label5);
            this.tpApplicationInformation.Controls.Add(this.label4);
            this.tpApplicationInformation.Controls.Add(this.label3);
            this.tpApplicationInformation.Controls.Add(this.pictureBox1);
            this.tpApplicationInformation.Controls.Add(this.label2);
            this.tpApplicationInformation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tpApplicationInformation.Location = new System.Drawing.Point(4, 25);
            this.tpApplicationInformation.Name = "tpApplicationInformation";
            this.tpApplicationInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInformation.Size = new System.Drawing.Size(1205, 564);
            this.tpApplicationInformation.TabIndex = 1;
            this.tpApplicationInformation.Text = "Application Info";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblCreatedBy.Location = new System.Drawing.Point(633, 286);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(21, 16);
            this.lblCreatedBy.TabIndex = 144;
            this.lblCreatedBy.Text = "??";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblApplicationDate.Location = new System.Drawing.Point(619, 127);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(21, 16);
            this.lblApplicationDate.TabIndex = 143;
            this.lblApplicationDate.Text = "??";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblApplicationFees.Location = new System.Drawing.Point(633, 376);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(21, 16);
            this.lblApplicationFees.TabIndex = 142;
            this.lblApplicationFees.Text = "??";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(624, 198);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(267, 24);
            this.cbLicenseClass.TabIndex = 141;
            this.cbLicenseClass.SelectedIndexChanged += new System.EventHandler(this.cbLicenseClass_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(352, 362);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 140;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Renew_Driving_License_32;
            this.pictureBox2.Location = new System.Drawing.Point(349, 198);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 137;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.pictureBox6.Location = new System.Drawing.Point(350, 130);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(31, 26);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 133;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD.Properties.Resources.User_32__2;
            this.pictureBox5.Location = new System.Drawing.Point(351, 281);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(412, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Created By";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLocalDrivingLicebseApplicationID
            // 
            this.lblLocalDrivingLicebseApplicationID.AutoSize = true;
            this.lblLocalDrivingLicebseApplicationID.BackColor = System.Drawing.Color.White;
            this.lblLocalDrivingLicebseApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalDrivingLicebseApplicationID.ForeColor = System.Drawing.Color.Blue;
            this.lblLocalDrivingLicebseApplicationID.Location = new System.Drawing.Point(619, 58);
            this.lblLocalDrivingLicebseApplicationID.Name = "lblLocalDrivingLicebseApplicationID";
            this.lblLocalDrivingLicebseApplicationID.Size = new System.Drawing.Size(36, 25);
            this.lblLocalDrivingLicebseApplicationID.TabIndex = 9;
            this.lblLocalDrivingLicebseApplicationID.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(415, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Application Fees";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(412, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "License Class";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(415, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Application Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(349, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(412, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "D.L Application ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmInsertUpdateLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1431, 749);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcInsertUpdateLocalDrivingLicenseApplication);
            this.Name = "frmInsertUpdateLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert | Update Local Driving License Application";
            this.Load += new System.EventHandler(this.frmInsertUpdateLocalDrivingLicenseApplication_Load);
            this.tcInsertUpdateLocalDrivingLicenseApplication.ResumeLayout(false);
            this.tpPersonInformation.ResumeLayout(false);
            this.tpPersonInformation.PerformLayout();
            this.tpApplicationInformation.ResumeLayout(false);
            this.tpApplicationInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tcInsertUpdateLocalDrivingLicenseApplication;
        private System.Windows.Forms.TabPage tpPersonInformation;
        private System.Windows.Forms.Button btnNextStep;
        private People.Controls.ctrlUserCardWithFilter ctrlUserCardWithFilter;
        private System.Windows.Forms.TabPage tpApplicationInformation;
        private System.Windows.Forms.Label lblLocalDrivingLicebseApplicationID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblCreatedBy;
    }
}