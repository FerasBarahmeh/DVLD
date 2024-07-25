using Business;
using DVLD.General_Class;
using DVLD.License;
using DVLD.License.Local_License;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.Release_Detained_License
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        private int _SelectedLicenseID;
        private clsLicenses _Licenses;
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
            ctrlDriverLicenseInfoWithFilter1.FoundedLicense += _WhenSelectedLicense;
        }
        public frmReleaseDetainedLicenseApplication(int licenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = licenseID;
            ctrlDriverLicenseInfoWithFilter1.LoadInformation(licenseID);
            ctrlDriverLicenseInfoWithFilter1.Find(licenseID);
            _WhenSelectedLicense(clsLicenses.Find(licenseID));
        }
        private void _WhenSelectedLicense(clsLicenses Licenses)
        {
            _Licenses = Licenses;
            _SelectedLicenseID = _Licenses?.LicenseID ?? -1;

            lblLicenseID.Text = _SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);
            if (_SelectedLicenseID == -1) return;
            if (!_Licenses.IsDetained)
            {
                MessageBox.Show("Selected License i is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationTypeFees.ToString();
            lblCreatedByUser.Text = clsAuth.User.Username;

            lblDetainID.Text = _Licenses.DetainedInfo?.DetainID.ToString();
            lblLicenseID.Text = _Licenses.LicenseID.ToString();

            lblCreatedByUser.Text = _Licenses.DetainedInfo.CreatedByUserInfo.Username;
            lblDetainDate.Text = clsFormat.DateToShort(_Licenses.DetainedInfo.DetainDate);
            lblFineFees.Text = _Licenses.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();

            btnRelease.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory();
            frm.LoadLicenses(_Licenses.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;


            bool IsReleased = _Licenses.ReleaseDetainedLicense(clsAuth.User.UserID, ref ApplicationID); ;

            lblApplicationID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Failed to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.DisabledFilterSection();
            llShowLicenseInfo.Enabled = true;
        }
    }
}
