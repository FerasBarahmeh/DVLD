using Business;
using DVLD.Properties;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;
        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return _TestType;
            }
            set
            {
                _TestType = value;
                switch (_TestType)
                {

                    case clsTestTypes.enTestType.VisionTest:
                        {
                            lblTitle.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            lblTitle.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            lblTitle.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.driving_test_512;
                            break;
                        }
                }
            }
        }

        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.TestTypeID = TestType;
            ctrlDrivingLicenseApplicationInfo.LoadDrivingLicenseInfo(_LocalDrivingLicenseApplicationID);
        }

        private void _SetColumnsDGV()
        {

            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[0].Width = 150;

                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[1].Width = 200;

                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[2].Width = 150;

                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns[3].Width = 100;
            }
        }

        private void _SetStatusForOptionButtons()
        {
            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {
                bool IsLocked = !(bool)dgvLicenseTestAppointments.CurrentRow.Cells[3].Value;
                tsmiTackTest.Enabled = IsLocked;
                tsmiEditTool.Enabled = IsLocked;
            }
        }

        private void frmListTestAppointments_Load(object sender, System.EventArgs e)
        {
            _dtLicenseTestAppointments = clsTestAppointments.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);
            dgvLicenseTestAppointments.DataSource = _dtLicenseTestAppointments;
            lblRecordCount.Text = _dtLicenseTestAppointments.Rows.Count.ToString();
            _SetColumnsDGV();
            _SetStatusForOptionButtons();
        }

        private void btnAddNewAppointment_Click(object sender, System.EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationData(_LocalDrivingLicenseApplicationID);
            if (LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsTests LastTest = LocalDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                frmScheduleTest frmScheduleTest = new frmScheduleTest(LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, _TestType);
                frmScheduleTest.ShowDialog();
                frmListTestAppointments_Load(null, null);
                return;
            }

            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake fails test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm = new frmScheduleTest(LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int AppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;

            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, AppointmentID);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void tackTestToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int AppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;

            frmTackTest frm = new frmTackTest(_LocalDrivingLicenseApplicationID, _TestType, AppointmentID);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }
    }
}
