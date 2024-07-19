using Business;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmListTypeTests : Form
    {
        private DataTable _AllTests;
        private DataTable _dtTests;

        public frmListTypeTests()
        {
            InitializeComponent();
            _RefreshDGV();
        }

        private static void _SelectDGVColumnNameAndWidth(ref DataGridView DGV)
        {
            Dictionary<string, int> HeaderTable = new Dictionary<string, int>
            {
              { "Test ID", 90},
              { "Test Title", 200 },
              { "Test Description", 300 },
              { "Feed", 70}
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
            _AllTests = clsTestTypes.All();
            _dtTests = _AllTests.DefaultView.ToTable(false, "TestTypeID", "TestTypeTitle", "TestTypeDescription", "TestTypeFees");
        }

        private void _LoadApplicationTypesInDGV()
        {
            dgvTestTypes.DataSource = _dtTests;
            lblCountRecoredApplicationTypes.Text = _dtTests.Rows.Count.ToString();
            if (_AllTests.Rows.Count > 0) _SelectDGVColumnNameAndWidth(ref dgvTestTypes);
        }
        private void _RefreshDGV()
        {
            _UploadApplicationTypes();
            _LoadApplicationTypesInDGV();
        }

        private void tsmiEditTestType_Click(object sender, System.EventArgs e)
        {
            int TestID = (int)dgvTestTypes.CurrentRow.Cells[0].Value;
            frmEditTest frm = new frmEditTest(TestID);
            frm.ShowDialog();
            _RefreshDGV();
        }
    }
}