using Business;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestTypes.enTestType _TestType;
        private int _AppointmentID;
        private enum enMode { Insert, Update }

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType, int AppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
            _AppointmentID = AppointmentID;
            ctrlScheduleTest.LoadInformation(_LocalDrivingLicenseApplicationID, _TestType, _AppointmentID);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
