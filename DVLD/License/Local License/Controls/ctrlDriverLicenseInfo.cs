using Business;
using DVLD.Properties;
using System.IO;
using System.Windows.Forms;

namespace DVLD.License.Local_License.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID;
        private clsLicenses _License;
        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicenses SelectedLicense
        {
            get { return _License; }
        }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void _SetImagePerson()
        {
            if (_LicenseID == -1 || _License == null) return;
            if (_License.DriverInfo.PersonInfo.Gender == 1)
                pbPersonImage.Image = Resources.Female_512;
            else
                pbPersonImage.Image = Resources.Male_512;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath == "") return;

            if (File.Exists(ImagePath))
                pbPersonImage.Load(ImagePath);
            else
                MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void LoadInformation(int LicenseID)
        {

            _LicenseID = LicenseID;
            _License = clsLicenses.Find(_LicenseID);
            _SetImagePerson();
            if (_License == null || _LicenseID == -1) return;
            lblClass.Text = _License.LicenseClassIfo.ClassName;
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _License.DriverInfo.PersonInfo.GenderName;
            lblIssueDate.Text = _License.IssueDate.ToString("D");
            lblIssueReason.Text = _License.IssueReason.ToString();
            lblNotes.Text = _License.Notes.ToString();
            lblIsActive.Text = _License.IsActiveText;
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DataOfBirth.ToString("d");
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString("D");
            //lblIsDetained.Text = _License.
        }
        public void ResetLabel()
        {
            _LicenseID = -1;
            _SetImagePerson();

            lblClass.Text = "???";
            lblFullName.Text = "???";
            lblLicenseID.Text = "???";
            lblNationalNo.Text = "???";
            lblGendor.Text = "???";
            lblIssueDate.Text = "???";
            lblIssueReason.Text = "???";
            lblNotes.Text = "???";
            lblIsActive.Text = "???";
            lblDateOfBirth.Text = "???";
            lblDriverID.Text = "???";
            lblExpirationDate.Text = "???";
            //lblIsDetained.Text = _License.
        }
    }
}
