using Business;
using System.Windows.Forms;

namespace DVLD.Applications.International_License.Controls
{
    public partial class ctrlInternationalApplicationInfo : UserControl
    {
        private int _LicenseID;
        private clsLicenses _Licenses;
        public ctrlInternationalApplicationInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            _Licenses = clsLicenses.Find(_LicenseID);
        }
    }
}
