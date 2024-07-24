using Business;
using DVLD.General_Class;
using DVLD.License;
using DVLD.License.Local_License;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.ReplaceLostOrDamagedLicenseApplication
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        private clsLicenses _License;
        private clsLicenses _NewLicense;
        private clsApplication.enApplicationType _ApplicationType = clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
            _SetTagsToReplacementTypeRadioBox();
            ctrlDriverLicenseInfoWithFilter1.FoundedLicense += _SetLicense;
        }
        private void _SetApplicationFeesLabel()
        {
            if (rbDamagedLicense.Checked)
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).ApplicationTypeFees.ToString();
            else if (rbLostLicense.Checked)
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReplaceLostDrivingLicense).ApplicationTypeFees.ToString();
        }
        private void _SetLabelsForNewLicense()
        {
            _SetApplicationFeesLabel();
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblOldLicenseID.Text = _License.LicenseID.ToString();
            lblCreatedByUser.Text = clsAuth.User.Username;
        }
        private void _SetLicense(clsLicenses License)
        {
            if (License == null)
            {
                MessageBox.Show("Can't found this license in our credentials, chose correct license", "Not Allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!License.IsActive)
            {
                _License = null;
                llShowLicenseHistory.Enabled = false;
                btnIssueReplacement.Enabled = false;
                MessageBox.Show("This license is in active, chose active license", "Not Allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _License = License;
            llShowLicenseHistory.Enabled = true;
            btnIssueReplacement.Enabled = true;
            _SetLabelsForNewLicense();
        }
        private void _SetTagsToReplacementTypeRadioBox()
        {
            rbDamagedLicense.Tag = clsApplication.enApplicationType.ReplaceDamagedDrivingLicense.ToString();
            rbLostLicense.Tag = clsApplication.enApplicationType.ReplaceLostDrivingLicense.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory();
            frm.LoadLicenses(_License.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _ApplicationType = clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            _SetApplicationFeesLabel();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            _ApplicationType = clsApplication.enApplicationType.ReplaceLostDrivingLicense;
            _SetApplicationFeesLabel();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want replacement this license", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            clsLicenses _NewLicense = _License.Replacement(_ApplicationType, clsAuth.User.UserID);
            if (_NewLicense == null)
            {
                MessageBox.Show("Replacement fail try again later", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssueReplacement.Enabled = false;
            lblApplicationID.Text = _NewLicense.ApplicationID.ToString();
            lblRreplacedLicenseID.Text = _NewLicense.LicenseID.ToString();
            llShowLicenseInfo.Enabled = true;
            ctrlDriverLicenseInfoWithFilter1.DisabledFilterSection();
            gbReplacementFor.Enabled = false;
            MessageBox.Show($"Successfully Replacement License has ID {_NewLicense.LicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_License.LicenseID);
            frm.LoadInformation();
            frm.ShowDialog();
        }
    }
}
