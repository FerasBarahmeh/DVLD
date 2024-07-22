using System.Windows.Forms;

namespace DVLD.License.Local_License.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        private int _LicenseID;
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        public void LoadInformation(int LicenseID)
        {
            ctrlDriverLicenseInfo.LoadInformation(LicenseID);
        }

        private void btnFind_Click(object sender, System.EventArgs e)
        {
            int LicenseID = -1;
            if (int.TryParse(txtLicenseID.Text.Trim(), out int value))
                LicenseID = value;

            LoadInformation(LicenseID);
        }
        public void DisabledFilterSection()
        {
            gbFilters.Enabled = false;
        }
    }
}
