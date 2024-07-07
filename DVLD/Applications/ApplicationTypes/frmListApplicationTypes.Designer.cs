namespace DVLD.ApplicationTypes
{
    partial class frmListApplicationTypes
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvApplicationTypes = new System.Windows.Forms.DataGridView();
            this.cmsApplicationTypeOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditApplicationType = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCountRecoredApplicationTypes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).BeginInit();
            this.cmsApplicationTypeOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Application_Types_512;
            this.pictureBox1.Location = new System.Drawing.Point(291, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(366, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(228, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Application Types";
            // 
            // dgvApplicationTypes
            // 
            this.dgvApplicationTypes.AllowUserToAddRows = false;
            this.dgvApplicationTypes.AllowUserToDeleteRows = false;
            this.dgvApplicationTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvApplicationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationTypes.ContextMenuStrip = this.cmsApplicationTypeOperation;
            this.dgvApplicationTypes.Location = new System.Drawing.Point(77, 363);
            this.dgvApplicationTypes.Name = "dgvApplicationTypes";
            this.dgvApplicationTypes.ReadOnly = true;
            this.dgvApplicationTypes.RowHeadersWidth = 51;
            this.dgvApplicationTypes.RowTemplate.Height = 24;
            this.dgvApplicationTypes.Size = new System.Drawing.Size(819, 238);
            this.dgvApplicationTypes.TabIndex = 2;
            // 
            // cmsApplicationTypeOperation
            // 
            this.cmsApplicationTypeOperation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplicationTypeOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditApplicationType});
            this.cmsApplicationTypeOperation.Name = "cmsApplicationTypeOperation";
            this.cmsApplicationTypeOperation.Size = new System.Drawing.Size(225, 58);
            // 
            // tsmiEditApplicationType
            // 
            this.tsmiEditApplicationType.Image = global::DVLD.Properties.Resources.edit_32;
            this.tsmiEditApplicationType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiEditApplicationType.Name = "tsmiEditApplicationType";
            this.tsmiEditApplicationType.Size = new System.Drawing.Size(224, 26);
            this.tsmiEditApplicationType.Text = "Edit Type Application";
            this.tsmiEditApplicationType.Click += new System.EventHandler(this.tsmiEditApplicationType_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 622);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number Of Application Types";
            // 
            // lblCountRecoredApplicationTypes
            // 
            this.lblCountRecoredApplicationTypes.AutoSize = true;
            this.lblCountRecoredApplicationTypes.Location = new System.Drawing.Point(201, 622);
            this.lblCountRecoredApplicationTypes.Name = "lblCountRecoredApplicationTypes";
            this.lblCountRecoredApplicationTypes.Size = new System.Drawing.Size(14, 16);
            this.lblCountRecoredApplicationTypes.TabIndex = 4;
            this.lblCountRecoredApplicationTypes.Text = "?";
            // 
            // frmListApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(971, 647);
            this.Controls.Add(this.lblCountRecoredApplicationTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvApplicationTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmListApplicationTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application Types";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).EndInit();
            this.cmsApplicationTypeOperation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvApplicationTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCountRecoredApplicationTypes;
        private System.Windows.Forms.ContextMenuStrip cmsApplicationTypeOperation;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditApplicationType;
    }
}