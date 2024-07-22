namespace DVLD.License
{
    partial class frmShowPersonLicenseHistory
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
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlDriverLicenses = new DVLD.License.Controls.ctrlDriverLicenses();
            this.ctrlUserCardWithFilter1 = new DVLD.People.Controls.ctrlUserCardWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_512;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(13, 266);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 189);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 131;
            this.pbPersonImage.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(164, -4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1062, 58);
            this.lblTitle.TabIndex = 133;
            this.lblTitle.Text = "License History";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1175, 880);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 43);
            this.btnClose.TabIndex = 136;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.ctrlDriverLicenses.AutoSize = true;
            this.ctrlDriverLicenses.BackColor = System.Drawing.Color.White;
            this.ctrlDriverLicenses.Location = new System.Drawing.Point(266, 531);
            this.ctrlDriverLicenses.Name = "ctrlDriverLicenses";
            this.ctrlDriverLicenses.Size = new System.Drawing.Size(1065, 343);
            this.ctrlDriverLicenses.TabIndex = 135;
            // 
            // ctrlUserCardWithFilter1
            // 
            this.ctrlUserCardWithFilter1.AutoSize = true;
            this.ctrlUserCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlUserCardWithFilter1.Location = new System.Drawing.Point(253, 57);
            this.ctrlUserCardWithFilter1.Name = "ctrlUserCardWithFilter1";
            this.ctrlUserCardWithFilter1.Size = new System.Drawing.Size(1078, 499);
            this.ctrlUserCardWithFilter1.TabIndex = 134;
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1575, 935);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDriverLicenses);
            this.Controls.Add(this.ctrlUserCardWithFilter1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbPersonImage);
            this.Name = "frmShowPersonLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmShowPersonLicenseHistory";
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblTitle;
        private People.Controls.ctrlUserCardWithFilter ctrlUserCardWithFilter1;
        private Controls.ctrlDriverLicenses ctrlDriverLicenses;
        private System.Windows.Forms.Button btnClose;
    }
}