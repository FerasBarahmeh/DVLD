namespace DVLD.User
{
    partial class frmListUsers
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
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.lblCountPeopleRecourd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilterNotStrict = new System.Windows.Forms.TextBox();
            this.cbFilterUsersBy = new System.Windows.Forms.ComboBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.cmsUserOperations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDetailsUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilterStrict = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.cmsUserOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::DVLD.Properties.Resources.Users_2_400;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(464, 64);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 189);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 91;
            this.pbPersonImage.TabStop = false;
            // 
            // lblCountPeopleRecourd
            // 
            this.lblCountPeopleRecourd.AutoSize = true;
            this.lblCountPeopleRecourd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountPeopleRecourd.Location = new System.Drawing.Point(132, 51);
            this.lblCountPeopleRecourd.Name = "lblCountPeopleRecourd";
            this.lblCountPeopleRecourd.Size = new System.Drawing.Size(27, 29);
            this.lblCountPeopleRecourd.TabIndex = 90;
            this.lblCountPeopleRecourd.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 32);
            this.label2.TabIndex = 89;
            this.label2.Text = "Users:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(475, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 32);
            this.label1.TabIndex = 88;
            this.label1.Text = "Manage Users";
            // 
            // txtFilterNotStrict
            // 
            this.txtFilterNotStrict.Location = new System.Drawing.Point(213, 308);
            this.txtFilterNotStrict.Name = "txtFilterNotStrict";
            this.txtFilterNotStrict.Size = new System.Drawing.Size(223, 22);
            this.txtFilterNotStrict.TabIndex = 93;
            this.txtFilterNotStrict.Visible = false;
            this.txtFilterNotStrict.TextChanged += new System.EventHandler(this.txtFilterNotStrict_TextChanged);
            this.txtFilterNotStrict.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterNotStrict_KeyPress);
            // 
            // cbFilterUsersBy
            // 
            this.cbFilterUsersBy.FormattingEnabled = true;
            this.cbFilterUsersBy.Location = new System.Drawing.Point(18, 306);
            this.cbFilterUsersBy.Name = "cbFilterUsersBy";
            this.cbFilterUsersBy.Size = new System.Drawing.Size(189, 24);
            this.cbFilterUsersBy.TabIndex = 1000;
            this.cbFilterUsersBy.Text = "Filter By";
            this.cbFilterUsersBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterUsersBy_SelectedIndexChanged);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewPerson.Image = global::DVLD.Properties.Resources.Add_New_User_32;
            this.btnAddNewPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1009, 279);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(119, 49);
            this.btnAddNewPerson.TabIndex = 94;
            this.btnAddNewPerson.Text = "Add User";
            this.btnAddNewPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.ContextMenuStrip = this.cmsUserOperations;
            this.dgvUsers.Location = new System.Drawing.Point(18, 338);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new System.Drawing.Size(1110, 227);
            this.dgvUsers.TabIndex = 95;
            // 
            // cmsUserOperations
            // 
            this.cmsUserOperations.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsUserOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDetailsUser,
            this.toolStripSeparator1,
            this.tsmiAddNewPerson,
            this.tsmiEditPerson,
            this.tsmiDeletePerson,
            this.toolStripSeparator2,
            this.tsmiSendEmail,
            this.tsmiPhone});
            this.cmsUserOperations.Name = "contextMenuStrip1";
            this.cmsUserOperations.Size = new System.Drawing.Size(215, 200);
            this.cmsUserOperations.Text = "Operations";
            // 
            // tsmiDetailsUser
            // 
            this.tsmiDetailsUser.Image = global::DVLD.Properties.Resources.Notes_32;
            this.tsmiDetailsUser.Name = "tsmiDetailsUser";
            this.tsmiDetailsUser.Size = new System.Drawing.Size(214, 26);
            this.tsmiDetailsUser.Text = "Details";
            this.tsmiDetailsUser.Click += new System.EventHandler(this.tsmiDetailsUser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // tsmiAddNewPerson
            // 
            this.tsmiAddNewPerson.Image = global::DVLD.Properties.Resources.Add_New_User_32;
            this.tsmiAddNewPerson.Name = "tsmiAddNewPerson";
            this.tsmiAddNewPerson.Size = new System.Drawing.Size(214, 26);
            this.tsmiAddNewPerson.Text = "Add New";
            // 
            // tsmiEditPerson
            // 
            this.tsmiEditPerson.Image = global::DVLD.Properties.Resources.edit_32;
            this.tsmiEditPerson.Name = "tsmiEditPerson";
            this.tsmiEditPerson.Size = new System.Drawing.Size(214, 26);
            this.tsmiEditPerson.Text = "Edit";
            this.tsmiEditPerson.Click += new System.EventHandler(this.tsmiEditPerson_Click);
            // 
            // tsmiDeletePerson
            // 
            this.tsmiDeletePerson.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.tsmiDeletePerson.Name = "tsmiDeletePerson";
            this.tsmiDeletePerson.Size = new System.Drawing.Size(214, 26);
            this.tsmiDeletePerson.Text = "Delete";
            this.tsmiDeletePerson.Click += new System.EventHandler(this.tsmiDeletePerson_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // tsmiSendEmail
            // 
            this.tsmiSendEmail.Image = global::DVLD.Properties.Resources.Email_32;
            this.tsmiSendEmail.Name = "tsmiSendEmail";
            this.tsmiSendEmail.Size = new System.Drawing.Size(214, 26);
            this.tsmiSendEmail.Text = "Send Email";
            // 
            // tsmiPhone
            // 
            this.tsmiPhone.Image = global::DVLD.Properties.Resources.call_32;
            this.tsmiPhone.Name = "tsmiPhone";
            this.tsmiPhone.Size = new System.Drawing.Size(214, 26);
            this.tsmiPhone.Text = "Phone";
            // 
            // cbFilterStrict
            // 
            this.cbFilterStrict.FormattingEnabled = true;
            this.cbFilterStrict.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbFilterStrict.Location = new System.Drawing.Point(213, 308);
            this.cbFilterStrict.Name = "cbFilterStrict";
            this.cbFilterStrict.Size = new System.Drawing.Size(121, 24);
            this.cbFilterStrict.TabIndex = 96;
            this.cbFilterStrict.Visible = false;
            this.cbFilterStrict.SelectedIndexChanged += new System.EventHandler(this.cbFilterStrict_SelectedIndexChanged);
            // 
            // frmListUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1161, 576);
            this.Controls.Add(this.cbFilterStrict);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.txtFilterNotStrict);
            this.Controls.Add(this.cbFilterUsersBy);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.lblCountPeopleRecourd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmListUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Users";
            this.Load += new System.EventHandler(this.frmListUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.cmsUserOperations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblCountPeopleRecourd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilterNotStrict;
        private System.Windows.Forms.ComboBox cbFilterUsersBy;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.ComboBox cbFilterStrict;
        private System.Windows.Forms.ContextMenuStrip cmsUserOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmiDetailsUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeletePerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmiPhone;
    }
}