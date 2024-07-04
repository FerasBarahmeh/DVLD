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

        public int LocalDrivingLicenseApplicationID;

        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo;

        public frmInsertUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.Insert;
            _SetLincesClassInComboBox();
            _SetDefaultValuesInApplicationInfoTab();
        }

        public frmInsertUpdateLocalDrivingLicenseApplication(int LocalLicenceApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            LocalDrivingLicenseApplicationID = LocalLicenceApplicationID;
            _SetLincesClassInComboBox();
            _SetDefaultValuesInApplicationInfoTab();
        }

        private void _SetDefaultValuesInApplicationInfoTab()
        {
            if (_Mode == enMode.Insert)
            {
                lblApplicationDate.Text = DateTime.Now.ToString();
                lblCreatedBy.Text = clsAuth.User?.Username ?? "Authrized user";
            }
        }

        private void _SetLincesClassInComboBox()
        {
            DataTable dtLicenses = clsLicenseClass.All();
            foreach (DataRow Row in dtLicenses.Rows)
                cbLicenseClass.Items.Add(Row["ClassName"]);
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
            }
        }
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (! _CanGoToFillApplicationInformation())
            {
                tcInsertUpdateLocalDrivingLicenseApplication.SelectedIndex = 0;
                _CantGoToFillApplicationInfoBeforeChosePersonMessageBox();
            } else
            {
                tcInsertUpdateLocalDrivingLicenseApplication.SelectedIndex++;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
