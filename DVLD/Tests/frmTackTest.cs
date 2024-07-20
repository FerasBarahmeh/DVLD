using Business;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmTackTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _AppointmentID;
        private clsTestTypes.enTestType _TestTypeID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsApplication _Application;
        public frmTackTest(int localDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID, int appointmentID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _AppointmentID = appointmentID;
            _TestTypeID = TestTypeID;
            ctrlScheduledTest.LoadInformation(_LocalDrivingLicenseApplicationID,
            _TestTypeID, _AppointmentID
            );
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            clsTests Test = new clsTests();
            if (!rbFail.Checked && !rbSuccess.Checked) { MessageBox.Show("Must chose result For Test.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
    }
}
