using Business;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class frmIssueLicense : Form
    {
        private int _LocalLicenseDrivingID = -1;
        private clsLocalDrivingLicenseApplication _LocalLicenseDriving;
        public frmIssueLicense(int LocalLicenseDrivingID)
        {
            InitializeComponent();
            _LocalLicenseDrivingID = LocalLicenseDrivingID;
        }

        private void frmIssueLicense_Load(object sender, System.EventArgs e)
        {
            _LocalLicenseDriving = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationData(_LocalLicenseDrivingID);
            if (_LocalLicenseDriving == null)
            {
                MessageBox.Show("This Local Driving License not set  in our credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrlDrivingLicenseApplicationInfo1.LoadDrivingLicenseInfo(_LocalLicenseDrivingID);
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Are you sure for issue license", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (Result == DialogResult.OK)
            {
                int LicenseID = _LocalLicenseDriving.IssueLicense(txtNotes.Text.Trim(), 1);
                if (LicenseID == -1)
                {
                    MessageBox.Show("Fail Issue License", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Successfully Issue License", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }


    }
}
