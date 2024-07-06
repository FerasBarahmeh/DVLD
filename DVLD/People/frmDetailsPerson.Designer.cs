namespace DVLD.People
{
    partial class frmDetailsPerson
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
            this.lblDetailsPerso = new System.Windows.Forms.Label();
            this.ctrlPersoneInformation = new DVLD.People.Controls.ctrlPersonCard();
            this.SuspendLayout();
            // 
            // lblDetailsPerso
            // 
            this.lblDetailsPerso.AutoSize = true;
            this.lblDetailsPerso.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailsPerso.Location = new System.Drawing.Point(375, 45);
            this.lblDetailsPerso.Name = "lblDetailsPerso";
            this.lblDetailsPerso.Size = new System.Drawing.Size(266, 32);
            this.lblDetailsPerso.TabIndex = 0;
            this.lblDetailsPerso.Text = "Details For Person";
            // 
            // ctrlPersoneInformation
            // 
            this.ctrlPersoneInformation.Location = new System.Drawing.Point(12, 100);
            this.ctrlPersoneInformation.Name = "ctrlPersoneInformation";
            this.ctrlPersoneInformation.Size = new System.Drawing.Size(1030, 366);
            this.ctrlPersoneInformation.TabIndex = 1;
            // 
            // frmDetailsPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1065, 473);
            this.Controls.Add(this.ctrlPersoneInformation);
            this.Controls.Add(this.lblDetailsPerso);
            this.Name = "frmDetailsPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Details Person";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDetailsPerso;
        private Controls.ctrlPersonCard ctrlPersoneInformation;
    }
}