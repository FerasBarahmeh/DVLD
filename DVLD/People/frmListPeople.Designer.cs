namespace DVLD.People
{
    partial class frmListPeople
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.cmPearsonOperations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDetailsPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCountPeopleRecourd = new System.Windows.Forms.Label();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.cbFilterPersonBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.cmPearsonOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(440, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage People";
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.cmPearsonOperations;
            this.dgvPeople.Location = new System.Drawing.Point(37, 335);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersWidth = 51;
            this.dgvPeople.RowTemplate.Height = 24;
            this.dgvPeople.Size = new System.Drawing.Size(1029, 202);
            this.dgvPeople.TabIndex = 2;
            // 
            // cmPearsonOperations
            // 
            this.cmPearsonOperations.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmPearsonOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDetailsPerson,
            this.toolStripSeparator1,
            this.tsmiAddNewPerson,
            this.tsmiEditPerson,
            this.tsmiDeletePerson,
            this.toolStripSeparator2,
            this.tsmiSendEmail,
            this.tsmiPhone});
            this.cmPearsonOperations.Name = "contextMenuStrip1";
            this.cmPearsonOperations.Size = new System.Drawing.Size(157, 172);
            this.cmPearsonOperations.Text = "Operations";
            // 
            // tsmiDetailsPerson
            // 
            this.tsmiDetailsPerson.Image = global::DVLD.Properties.Resources.Notes_32;
            this.tsmiDetailsPerson.Name = "tsmiDetailsPerson";
            this.tsmiDetailsPerson.Size = new System.Drawing.Size(156, 26);
            this.tsmiDetailsPerson.Text = "Details";
            this.tsmiDetailsPerson.Click += new System.EventHandler(this.tsmiDetailsPerson_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // tsmiAddNewPerson
            // 
            this.tsmiAddNewPerson.Image = global::DVLD.Properties.Resources.Add_New_User_32;
            this.tsmiAddNewPerson.Name = "tsmiAddNewPerson";
            this.tsmiAddNewPerson.Size = new System.Drawing.Size(156, 26);
            this.tsmiAddNewPerson.Text = "Add New";
            this.tsmiAddNewPerson.Click += new System.EventHandler(this.tsmiAddNewPerson_Click);
            // 
            // tsmiEditPerson
            // 
            this.tsmiEditPerson.Image = global::DVLD.Properties.Resources.edit_32;
            this.tsmiEditPerson.Name = "tsmiEditPerson";
            this.tsmiEditPerson.Size = new System.Drawing.Size(156, 26);
            this.tsmiEditPerson.Text = "Edit";
            this.tsmiEditPerson.Click += new System.EventHandler(this.tsmiEditPerson_Click);
            // 
            // tsmiDeletePerson
            // 
            this.tsmiDeletePerson.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.tsmiDeletePerson.Name = "tsmiDeletePerson";
            this.tsmiDeletePerson.Size = new System.Drawing.Size(156, 26);
            this.tsmiDeletePerson.Text = "Delete";
            this.tsmiDeletePerson.Click += new System.EventHandler(this.tsmiDeletePerson_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // tsmiSendEmail
            // 
            this.tsmiSendEmail.Image = global::DVLD.Properties.Resources.Email_32;
            this.tsmiSendEmail.Name = "tsmiSendEmail";
            this.tsmiSendEmail.Size = new System.Drawing.Size(156, 26);
            this.tsmiSendEmail.Text = "Send Email";
            this.tsmiSendEmail.Click += new System.EventHandler(this.tsmiSendEmail_Click);
            // 
            // tsmiPhone
            // 
            this.tsmiPhone.Image = global::DVLD.Properties.Resources.call_32;
            this.tsmiPhone.Name = "tsmiPhone";
            this.tsmiPhone.Size = new System.Drawing.Size(156, 26);
            this.tsmiPhone.Text = "Phone";
            this.tsmiPhone.Click += new System.EventHandler(this.tsmiPhone_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Recourds";
            // 
            // lblCountPeopleRecourd
            // 
            this.lblCountPeopleRecourd.AutoSize = true;
            this.lblCountPeopleRecourd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountPeopleRecourd.Location = new System.Drawing.Point(186, 27);
            this.lblCountPeopleRecourd.Name = "lblCountPeopleRecourd";
            this.lblCountPeopleRecourd.Size = new System.Drawing.Size(27, 29);
            this.lblCountPeopleRecourd.TabIndex = 4;
            this.lblCountPeopleRecourd.Text = "0";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewPerson.Image = global::DVLD.Properties.Resources.Add_New_User_32;
            this.btnAddNewPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewPerson.Location = new System.Drawing.Point(876, 282);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(190, 49);
            this.btnAddNewPerson.TabIndex = 6;
            this.btnAddNewPerson.Text = "Add new person";
            this.btnAddNewPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::DVLD.Properties.Resources.People_400;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(446, 62);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 189);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 87;
            this.pbPersonImage.TabStop = false;
            // 
            // cbFilterPersonBy
            // 
            this.cbFilterPersonBy.FormattingEnabled = true;
            this.cbFilterPersonBy.Location = new System.Drawing.Point(40, 307);
            this.cbFilterPersonBy.Name = "cbFilterPersonBy";
            this.cbFilterPersonBy.Size = new System.Drawing.Size(189, 24);
            this.cbFilterPersonBy.TabIndex = 88;
            this.cbFilterPersonBy.Text = "Filter By";
            this.cbFilterPersonBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterPersonBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(235, 307);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(223, 22);
            this.txtFilterValue.TabIndex = 89;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // frmListPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1083, 554);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbFilterPersonBy);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.lblCountPeopleRecourd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(50, 50);
            this.Name = "frmListPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List People";
            this.Load += new System.EventHandler(this.frmListPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.cmPearsonOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCountPeopleRecourd;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.ContextMenuStrip cmPearsonOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmiDetailsPerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeletePerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmiPhone;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.ComboBox cbFilterPersonBy;
        private System.Windows.Forms.TextBox txtFilterValue;
    }
}