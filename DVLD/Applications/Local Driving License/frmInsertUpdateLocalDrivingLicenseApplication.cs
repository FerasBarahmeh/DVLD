using Business;
using DVLD.General_Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmInsertUpdateLocalDrivingLicenseApplication : Form
    {
        private enum enMode { Insert = 1, Update = 2 }

        private enMode _Mode;

        public int _LocalDrivingLicenseApplicationID;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _LicenseClassID = -1;

        public frmInsertUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.Insert;
            _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
        }

        public frmInsertUpdateLocalDrivingLicenseApplication(int LocalLicenceApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalLicenceApplicationID;
        }

        private void frmInsertUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _SetDefaultValuesInApplicationInfoTab();
            if (_Mode == enMode.Update)
                _LoadDate();
        }
        private void _SetLincesClassInComboBox()
        {
            DataTable dtLicenses = clsLicenseClass.All();
            foreach (DataRow Row in dtLicenses.Rows)
                cbLicenseClass.Items.Add(Row["ClassName"]);
        }

        private void _LoadDate()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationData(_LocalDrivingLicenseApplicationID);

            ctrlUserCardWithFilter.LoadPersonalCardInformation(_LocalDrivingLicenseApplication.ApplicationPersonID);
            MessageBox.Show(_LocalDrivingLicenseApplicationID.ToString());
            cbLicenseClass.SelectedIndex = -- _LocalDrivingLicenseApplication.LicenseClassID;
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToString("dd-MM-yyyy");
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.CreatedByInfo.Username;
        }

        private void _SetDefaultValuesInApplicationInfoTab()
        {
            _SetLincesClassInComboBox();
            if (_Mode == enMode.Insert)
            {
                lblTitle.Text = "Insert Local Driving License Application";
                cbLicenseClass.SelectedIndex = 2;
                lblApplicationDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                lblCreatedBy.Text = clsAuth.User?.Username ?? "Authrized user";
            }
            else
            {
                _LoadDate();
                lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                lblTitle.Text = "Update Local Driving License Application";
              
            }
            lblApplicationFees.Text = "$ " + clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationTypeFees.ToString();
        }

        private bool _CanGoToFillApplicationInformation()
        {
            return ctrlUserCardWithFilter.SelectedPerson != null;
        }

        private void _CantGoToFillApplicationInfoBeforeChosePersonMessageBox()
        {
            MessageBox.Show("Chose person you want tack application", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tcInsertUpdateLocalDrivingLicenseApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcInsertUpdateLocalDrivingLicenseApplication.SelectedIndex == 1
                && !_CanGoToFillApplicationInformation())
            {
                tcInsertUpdateLocalDrivingLicenseApplication.SelectedIndex = 0;
                _CantGoToFillApplicationInfoBeforeChosePersonMessageBox();
            }
        }
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (!_CanGoToFillApplicationInformation())
            {
                tcInsertUpdateLocalDrivingLicenseApplication.SelectedIndex = 0;
                _CantGoToFillApplicationInfoBeforeChosePersonMessageBox();
            }
            else
            {
                tcInsertUpdateLocalDrivingLicenseApplication.SelectedIndex++;
            }
        }
        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LicenseClassID = cbLicenseClass.SelectedIndex;
            _LicenseClassID++;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int ActiveApplicationID =
                clsApplication.
                GetActiveApplicationIDForLicenseClass(ctrlUserCardWithFilter.PersonID, clsApplication.enApplicationType.NewDrivingLicense, _LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            _LocalDrivingLicenseApplication.LicenseClassID = _LicenseClassID;
            _LocalDrivingLicenseApplication.ApplicationPersonID = ctrlUserCardWithFilter.SelectedPerson.PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = _LocalDrivingLicenseApplication.ApplicationDate;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicenseApplication.CreatedByUserID = 1;
            _LocalDrivingLicenseApplication.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationTypeFees;

            if (_LocalDrivingLicenseApplication.Save())
            {
                _Mode = enMode.Update;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _SetDefaultValuesInApplicationInfoTab();
                _LoadDate();
            }
            else
            {
                MessageBox.Show("Data Saved Fail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
