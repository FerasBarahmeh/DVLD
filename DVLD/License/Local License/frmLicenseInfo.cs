using System.Windows.Forms;

namespace DVLD.License.Local_License
{
    public partial class frmLicenseInfo : Form
    {
        private int _LicenseID;
        public frmLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }
        public void LoadInformation()
        {
            ctrlDriverLicenseInfo1.LoadInformation(_LicenseID);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
