using Business;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmTackTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _AppointmentID;
        private clsTestTypes.enTestType _TestTypeID;

        public frmTackTest(int localDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID, int appointmentID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _AppointmentID = appointmentID;
            _TestTypeID = TestTypeID;
            ctrlScheduledTest.LoadInformation(_LocalDrivingLicenseApplicationID, _TestTypeID, _AppointmentID);
            _CheckStatusSaveBtn();
        }

        private void _CheckStatusSaveBtn()
        {
            if (!rbFail.Checked && !rbSuccess.Checked)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;
            if (!rbFail.Checked && !rbSuccess.Checked) { MessageBox.Show("Must chose result For Test.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            clsTests Test = new clsTests();
            Test.TestResult = rbSuccess.Checked;
            Test.TestAppointmentID = _AppointmentID;
            Test.Notes = txtNotes.Text.Trim();
            Test.CreatedByUserID = 1;
            if (!Test.Save())
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = false;

        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void rbSuccess_CheckedChanged(object sender, System.EventArgs e)
        {
            _CheckStatusSaveBtn();
        }

        private void rbFail_CheckedChanged(object sender, System.EventArgs e)
        {
            _CheckStatusSaveBtn();
        }
    }
}
