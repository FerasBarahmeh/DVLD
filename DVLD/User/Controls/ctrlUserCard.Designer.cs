namespace DVLD.User.Controls
{
    partial class ctrlUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlPersoneCard = new DVLD.People.Controls.ctrlPersoneCard();
            this.gbUserInformation = new System.Windows.Forms.GroupBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbUserInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersoneCard
            // 
            this.ctrlPersoneCard.BackColor = System.Drawing.Color.White;
            this.ctrlPersoneCard.Location = new System.Drawing.Point(20, 13);
            this.ctrlPersoneCard.Name = "ctrlPersoneCard";
            this.ctrlPersoneCard.Size = new System.Drawing.Size(1053, 361);
            this.ctrlPersoneCard.TabIndex = 0;
            // 
            // gbUserInformation
            // 
            this.gbUserInformation.Controls.Add(this.lblIsActive);
            this.gbUserInformation.Controls.Add(this.label3);
            this.gbUserInformation.Controls.Add(this.lblUsername);
            this.gbUserInformation.Controls.Add(this.label6);
            this.gbUserInformation.Controls.Add(this.lblUserID);
            this.gbUserInformation.Controls.Add(this.label1);
            this.gbUserInformation.Location = new System.Drawing.Point(36, 402);
            this.gbUserInformation.Name = "gbUserInformation";
            this.gbUserInformation.Size = new System.Drawing.Size(1037, 102);
            this.gbUserInformation.TabIndex = 1;
            this.gbUserInformation.TabStop = false;
            this.gbUserInformation.Text = "User Information";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(573, 59);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(14, 16);
            this.lblIsActive.TabIndex = 5;
            this.lblIsActive.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(532, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Is Active";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(351, 59);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(14, 16);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(306, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Username";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(153, 59);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(14, 16);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID";
            // 
            // ctrlUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbUserInformation);
            this.Controls.Add(this.ctrlPersoneCard);
            this.Name = "ctrlUserCard";
            this.Size = new System.Drawing.Size(1104, 529);
            this.gbUserInformation.ResumeLayout(false);
            this.gbUserInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private People.Controls.ctrlPersoneCard ctrlPersoneCard;
        private System.Windows.Forms.GroupBox gbUserInformation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIsActive;
    }
}
