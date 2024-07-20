using Business;
using DVLD.Properties;
using System.Windows.Forms;

namespace DVLD.Tests.Controls
{
    public partial class ctrlScheduledTest : UserControl
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _AppointmentID;
        private clsTestTypes.enTestType _TestTypeID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsApplication _Application;
        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {

                    case clsTestTypes.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            lblTitle.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            lblTitle.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            lblTitle.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.driving_test_512;
                            break;

                        }
                }
            }
        }

        public ctrlScheduledTest()
        {
            InitializeComponent();

        }
        public void LoadInformation(int localDrivingLicenseApplicationID, clsTestTypes.enTestType TestType, int appointmentID)
        {
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _AppointmentID = appointmentID;
            TestTypeID = TestType;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationData(_LocalDrivingLicenseApplicationID);
            _Application = clsApplication.FindBaseApplicationByID(_AppointmentID);
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName.ToString();
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();
            lblDate.Text = _Application.ApplicationDate.ToString();
            lblFees.Text = clsTestTypes.FindFeesByID(_TestTypeID).ToString();
        }
    }
}
