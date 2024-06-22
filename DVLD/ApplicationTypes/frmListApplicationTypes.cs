using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVLD.ApplicationTypes
{
    public partial class frmListApplicationTypes : Form
    {
        private DataTable _AllApplicationTypes;
        
        private DataTable _dtApplicationTypes;

        public frmListApplicationTypes()
        {
            InitializeComponent();
            _RefreshDGV();
        }


        private static void _SelectDGVColumnNameAndWidth(ref DataGridView DGV)
        {
            Dictionary<string, int> HeaderTable = new Dictionary<string, int>
            {
              { "Application Type ID", 150},
              { "Application Type Tiltle", 300 },
              { "Feed", 100}
            };

            short Index = 0;
            foreach (var Cell in HeaderTable)
            {
                DGV.Columns[Index].HeaderText = Cell.Key;
                DGV.Columns[Index].Width = Cell.Value;
                Index++;
            }
        }

        private void _UploadApplicationTypes()
        {
            _AllApplicationTypes = clsApplicationType.All();
            _dtApplicationTypes = _AllApplicationTypes.DefaultView.ToTable(false, "ApplicationTypeID", "ApplicationTypeTitle", "ApplicationFees");
        }
        private void _LoadApplicationTypesInDGV()
        {
            dgvApplicationTypes.DataSource = _dtApplicationTypes;
            lblCountRecoredApplicationTypes.Text = _dtApplicationTypes.Rows.Count.ToString();
            if (_AllApplicationTypes.Rows.Count > 0) _SelectDGVColumnNameAndWidth(ref dgvApplicationTypes);

        }
        private void _RefreshDGV()
        {
            _UploadApplicationTypes();
            _LoadApplicationTypesInDGV();
        }

        private void tsmiEditApplicationType_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = (int)dgvApplicationTypes.CurrentRow.Cells[0].Value;
            frmEditApplicationType frm = new frmEditApplicationType(ApplicationTypeID);
            frm.ShowDialog();
            _RefreshDGV();
        }
    }
}
