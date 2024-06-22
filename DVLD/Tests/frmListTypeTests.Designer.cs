namespace DVLD.Tests
{
    partial class frmListTypeTests
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCountRecoredApplicationTypes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmsTestTypeOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditTestType = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTestTypes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsTestTypeOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(280, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manage Test Types";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.TestType_512;
            this.pictureBox1.Location = new System.Drawing.Point(281, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(366, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblCountRecoredApplicationTypes
            // 
            this.lblCountRecoredApplicationTypes.AutoSize = true;
            this.lblCountRecoredApplicationTypes.Location = new System.Drawing.Point(201, 608);
            this.lblCountRecoredApplicationTypes.Name = "lblCountRecoredApplicationTypes";
            this.lblCountRecoredApplicationTypes.Size = new System.Drawing.Size(14, 16);
            this.lblCountRecoredApplicationTypes.TabIndex = 6;
            this.lblCountRecoredApplicationTypes.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 608);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number Of Application Types";
            // 
            // cmsTestTypeOperation
            // 
            this.cmsTestTypeOperation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTestTypeOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditTestType});
            this.cmsTestTypeOperation.Name = "cmsApplicationTypeOperation";
            this.cmsTestTypeOperation.Size = new System.Drawing.Size(139, 30);
            // 
            // tsmiEditTestType
            // 
            this.tsmiEditTestType.Image = global::DVLD.Properties.Resources.edit_32;
            this.tsmiEditTestType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiEditTestType.Name = "tsmiEditTestType";
            this.tsmiEditTestType.Size = new System.Drawing.Size(138, 26);
            this.tsmiEditTestType.Text = "Edit Test";
            this.tsmiEditTestType.Click += new System.EventHandler(this.tsmiEditTestType_Click);
            // 
            // dgvTestTypes
            // 
            this.dgvTestTypes.AllowUserToAddRows = false;
            this.dgvTestTypes.AllowUserToDeleteRows = false;
            this.dgvTestTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestTypes.ContextMenuStrip = this.cmsTestTypeOperation;
            this.dgvTestTypes.GridColor = System.Drawing.Color.DarkGray;
            this.dgvTestTypes.Location = new System.Drawing.Point(15, 364);
            this.dgvTestTypes.Name = "dgvTestTypes";
            this.dgvTestTypes.ReadOnly = true;
            this.dgvTestTypes.RowHeadersWidth = 51;
            this.dgvTestTypes.RowTemplate.Height = 24;
            this.dgvTestTypes.Size = new System.Drawing.Size(937, 182);
            this.dgvTestTypes.TabIndex = 8;
            // 
            // frmListTypeTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(964, 633);
            this.Controls.Add(this.dgvTestTypes);
            this.Controls.Add(this.lblCountRecoredApplicationTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmListTypeTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Type Tests";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsTestTypeOperation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCountRecoredApplicationTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsTestTypeOperation;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditTestType;
        private System.Windows.Forms.DataGridView dgvTestTypes;
    }
}