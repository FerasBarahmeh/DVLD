using Business;
using DVLD.License;
using DVLD.Tests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmListsLocalDrivingLicenseApplications : Form
    {
        private DataTable _AllLocalLicenseApplication;
        private DataTable _dtLocalLicenseApplication;
        enum IndexesForFilterColumns { NoFilter = 0, LocalDriverLicenseAppID = 1, NationalNo = 2, FullName = 3, Status = 4 }

        private static Dictionary<int, string> _FilterColumns = new Dictionary<int, string>
        {
            {0, "NoFilter" },
            {1, "LocalDrivingLicenseApplicationID" },
            {2, "NationalNo" },
            {3, "FullName" },
            {4, "Status" },
        };

        public frmListsLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _RefreshDGV();
            _SetItemsToFilterColumnsComboBox();
        }
        private static void _SelectDGVNameAndWidthToEachColumn(ref DataGridView DGV)
        {
            Dictionary<string, int> HeaderTable = new Dictionary<string, int>
            {
              { "L.D.L.App ID", 100 },
              { "Driving Class", 300 },
              { "NationalNo", 150 },
              { "Full Name", 350 },
              { "Application Date", 170},
              { "Passed Tests", 100},
              { "Status", 120}
            };

            short Index = 0;
            foreach (var Cell in HeaderTable)
            {
                DGV.Columns[Index].HeaderText = Cell.Key;
                DGV.Columns[Index].Width = Cell.Value;
                Index++;
            }
        }

        private void _RefreshDGV()
        {
            _AllLocalLicenseApplication = clsLocalDrivingLicenseApplication.All();
            _dtLocalLicenseApplication = _AllLocalLicenseApplication;
            dgvListLocalDrivingApplicationLicense.DataSource = _dtLocalLicenseApplication;
            lblRecordsCount.Text = dgvListLocalDrivingApplicationLicense.Rows.Count.ToString();
            if (dgvListLocalDrivingApplicationLicense.Rows.Count > 0)
                _SelectDGVNameAndWidthToEachColumn(ref dgvListLocalDrivingApplicationLicense);
        }

        private void _SetItemsToFilterColumnsComboBox()
        {
            cbFilterBy.DataSource = new BindingSource(_FilterColumns, null);
            cbFilterBy.ValueMember = "Key";
            cbFilterBy.DisplayMember = "Value";
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((IndexesForFilterColumns)cbFilterBy.SelectedIndex == IndexesForFilterColumns.NoFilter)
            {
                txtFilterValue.Visible = false;
            }
            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Focus();
            }
            txtFilterValue.Text = string.Empty;
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            IndexesForFilterColumns SelectedIndexFilter = (IndexesForFilterColumns)cbFilterBy.SelectedIndex;
            if (SelectedIndexFilter == IndexesForFilterColumns.LocalDriverLicenseAppID)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void _FilterListLocalLicenseApplication()
        {
            IndexesForFilterColumns SelectedFilterColumn = (IndexesForFilterColumns)cbFilterBy.SelectedIndex;
            string FilterString = "";

            if (SelectedFilterColumn == IndexesForFilterColumns.NoFilter || string.IsNullOrEmpty(txtFilterValue.Text))
            {
                _dtLocalLicenseApplication.DefaultView.RowFilter = FilterString;
                lblRecordsCount.Text = _dtLocalLicenseApplication.Rows.Count.ToString();
                return;
            }

            if (SelectedFilterColumn == IndexesForFilterColumns.LocalDriverLicenseAppID)
                FilterString = "[{0}] = {1}";
            else
                FilterString = "[{0}] LIKE '{1}%'";

            _dtLocalLicenseApplication.DefaultView.RowFilter = string.Format(FilterString, _FilterColumns[(int)SelectedFilterColumn], txtFilterValue.Text.Trim());
            lblRecordsCount.Text = _dtLocalLicenseApplication.Rows.Count.ToString();
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _FilterListLocalLicenseApplication();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmInsertUpdateLocalDrivingLicenseApplication frm = new frmInsertUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void cmsApplications_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int LocalDrivingLicenseID = (int)dgvListLocalDrivingApplicationLicense.CurrentRow.Cells[0].Value;
            string ClassName = (string)dgvListLocalDrivingApplicationLicense.CurrentRow.Cells[1].Value;
            int LicenseClassID = clsLicenseClass.FindIDByName(ClassName);
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationData(LocalDrivingLicenseID);
            bool HasLicense = LocalDrivingLicenseApplication.HasLicense(LicenseClassID);

            bool PassVisionTest = clsLocalDrivingLicenseApplication.IsPassTestType(LocalDrivingLicenseID, (int)clsTestTypes.enTestType.VisionTest);
            bool PassWrittenTest = clsLocalDrivingLicenseApplication.IsPassTestType(LocalDrivingLicenseID, (int)clsTestTypes.enTestType.WrittenTest);
            bool PassStreetTest = clsLocalDrivingLicenseApplication.IsPassTestType(LocalDrivingLicenseID, (int)clsTestTypes.enTestType.StreetTest);

            stmiScheduleTests.Enabled = (!PassStreetTest || !PassWrittenTest || !PassVisionTest) && LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New;

            if (cmsApplications.Enabled)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = !PassVisionTest;
                scheduleWrittenTestToolStripMenuItem.Enabled = PassVisionTest && !PassWrittenTest;
                scheduleStreetTestToolStripMenuItem.Enabled = PassVisionTest && PassWrittenTest && !PassStreetTest;
            }
            tsmiCancelApplicaiton.Enabled = !HasLicense;
            tsmiDeleteApplication.Enabled = !HasLicense;
            tsmiEdit.Enabled = !HasLicense;
            tsmiIssueDrivingLicenseFirstTime.Enabled = !HasLicense;
            tsmiShowLicense.Enabled = HasLicense;
        }

        private void _ScheduleTest(clsTestTypes.enTestType TestType)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalDrivingApplicationLicense.CurrentRow.Cells[0].Value;
            frmListTestAppointments frm = new frmListTestAppointments(LocalDrivingLicenseApplicationID, TestType);
            frm.ShowDialog();
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.VisionTest);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.WrittenTest);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.StreetTest);
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseID = (int)dgvListLocalDrivingApplicationLicense.CurrentRow.Cells[0].Value;
            frmIssueLicense frm = new frmIssueLicense(LocalDrivingLicenseID);
            frm.ShowDialog();
            _RefreshDGV();
        }
    }
}
