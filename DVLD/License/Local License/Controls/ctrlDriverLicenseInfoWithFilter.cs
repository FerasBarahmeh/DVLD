using Business;
using System.Windows.Forms;

namespace DVLD.License.Local_License.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public delegate void ResaveLicense(clsLicenses e);
        public event ResaveLicense FoundedLicense;

        private int _LicenseID;
        private clsLicenses _License = null;
        public int LicenseID
        {
            get { return _LicenseID; }
        }
        public clsLicenses License
        {
            get { return _License; }
        }

        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        public void LoadInformation(int LicenseID)
        {
            ctrlDriverLicenseInfo.LoadInformation(LicenseID);
        }
        public void ResetInformation()
        {
            ctrlDriverLicenseInfo.ResetLabel();
        }

        private void btnFind_Click(object sender, System.EventArgs e)
        {
            int LicenseID = -1;
            if (int.TryParse(txtLicenseID.Text.Trim(), out int value))
            {
                LicenseID = value;
                _License = clsLicenses.Find(LicenseID);
            }
            txtLicenseID.Text = "";
            LoadInformation(LicenseID);
            FoundedLicense?.Invoke(_License);
        }
        public void DisabledFilterSection()
        {
            gbFilters.Enabled = false;
        }
        public void FocusFilterInput()
        {
            txtLicenseID.Focus();
        }
        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnFind.PerformClick();
            }
        }
    }
}
