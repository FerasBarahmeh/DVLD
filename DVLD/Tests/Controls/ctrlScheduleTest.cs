using Business;
using DVLD.Properties;
using System;
using System.Windows.Forms;

namespace DVLD.Tests.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        private enum _enMode { Insert, Update }
        private _enMode _Mode;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        private clsTestAppointments _Appointment;
        private int _AppointmentID;
        private bool IsRetackSchedule = false;
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

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }
        private void PrepareScheduleDateTimePicker()
        {
            dtpScheduleDate.CustomFormat = "MM/dd/yyyy hh:mm tt";
            if (_Mode == _enMode.Update)
            {
                dtpScheduleDate.Value = _Appointment.AppointmentDate;
            }
            dtpScheduleDate.MinDate = DateTime.Now;
        }

        private void _PrepareRetackTestInfoSection()
        {
            if (_LocalDrivingLicenseApplication.DoesAttendTestType(TestTypeID))
            {
                IsRetackSchedule = true;
                gbRetackTestInfo.Enabled = true;
                lblDLAppID.Text = clsApplicationType.Find(_LocalDrivingLicenseApplication.ApplicationTypeID).ApplicationTypeFees.ToString();
                lblFeesRetackTest.Text = "";
            }
            else
            {
                gbRetackTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblFeesRetackTest.Text = "0";
                lblDLAppID.Text = "N/A";
            }
        }

        public void LoadInformation(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType, int AppointmentID)
        {

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationData(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString(),
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            _Mode = AppointmentID == -1 ? _enMode.Insert : _enMode.Update;
            TestTypeID = TestType;

            if (_Mode == _enMode.Insert)
            {
                _Appointment = new clsTestAppointments();
                _AppointmentID = AppointmentID;
            }
            else
            {
                _AppointmentID = AppointmentID;
                _Appointment = clsTestAppointments.Find(_AppointmentID);

            }

            PrepareScheduleDateTimePicker();
            _PrepareRetackTestInfoSection();

            lblLocalDrivingLicenseAppID.Text = LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName.ToString();
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblFees.Text = clsTestTypes.FindFeesByID(_TestTypeID).ToString();
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();
        }

        private bool _HandleIfIsRetackSchedule()
        {
            if (_Mode == _enMode.Insert && IsRetackSchedule)
            {
                clsApplication Application = new clsApplication();
                Application.ApplicationPersonID = _LocalDrivingLicenseApplication.ApplicationPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).ApplicationTypeFees;
                Application.CreatedByUserID = 1;
                if (!Application.Save())
                {
                    _Appointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Failed to Create application", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _Appointment.RetakeTestApplicationID = Application.ApplicationID;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleIfIsRetackSchedule())
                return;

            _Appointment.AppointmentDate = dtpScheduleDate.Value;
            _Appointment.TestTypeID = TestTypeID;
            _Appointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _Appointment.CreatedByUserID = 1;
            _Appointment.PaidFees = Convert.ToSingle(lblFees.Text);


            if (_Appointment.Save())
            {
                _Mode = _enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
