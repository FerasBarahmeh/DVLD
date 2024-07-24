using Business;
using DVLD.General_Class;
using DVLD.License;
using DVLD.License.Local_License;
using DVLD.License.Local_License.Controls;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.Renew_License_Application
{
    public partial class frmRenewLicenseApplication : Form
    {
        private int _LicenseID = -1;
        private clsLicenses _License;

        public frmRenewLicenseApplication()
        {
            InitializeComponent();
            ctrlDriverLicenseInfoWithFilter.FoundedLicense += _SetLicense;

        }
        private void _FillApplicationSectionLabels()
        {
            lblIssueDate.Text = DateTime.Now.ToString("D");
            lblLicenseFees.Text = _License.LicenseClassIfo.ClassFees.ToString();
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationTypeFees.ToString();
            lblOldLicenseID.Text = _License.LicenseID.ToString();
            lblNewExpiredDate.Text = DateTime.Now.AddYears(_License.LicenseClassIfo.DefaultValidityLength).ToString("D");
            lblCreatedByUser.Text = clsAuth.User.Username.ToString();
            lblTotalFees.Text = (_License.LicenseClassIfo.ClassFees + Convert.ToSingle(lblApplicationFees.Text.Trim())).ToString();
            txtNotes.Text = _License.Notes.ToString();
        }

        private void _SetStatusButtons()
        {
            btnRenew.Enabled = _License != null;
            btnShowHistory.Enabled = _License != null;
        }
        private void _SetLicense(clsLicenses License)
        {
            _License = License;

            if (!_CheckValidationLicense())
            {
                return;
            }
            _SetStatusButtons();
            _FillApplicationSectionLabels();
        }
        private bool _CheckValidationLicense()
        {
            bool Flag = true;
            if (_License == null || !_License.IsActive)
            {
                MessageBox.Show("Chose license, chose active license", "Not complete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Flag = false;
            }
            if (Flag && !_License.IsLicenseExpired())
            {
                MessageBox.Show($"License not expired yet it expired in {_License.ExpirationDate.ToString("d")}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Flag = false;
            }
            return Flag;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLicenses License = _License.RenewLicense(txtNotes.Text.Trim(), clsAuth.User.UserID);
            if (License == null)
            {
                MessageBox.Show("Failed to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblRenewApplicationID.Text = License.ApplicationID.ToString();
            _LicenseID = License.LicenseID;
            lblRenewLicenseID.Text = License.LicenseID.ToString();
            lblApplicationDate.Text = clsApplication.FindBaseApplicationByID(License.ApplicationID).ApplicationDate.ToString("D");
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            btnDetailsNewLicense.Enabled = true;
            ctrlDriverLicenseInfoWithFilter.DisabledFilterSection();

        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            if (_License == null) return;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory();
            frm.LoadLicenses(_License.DriverInfo.PersonID);
            frm.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDetailsNewLicense_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_LicenseID);
            frm.LoadInformation();
            frm.ShowDialog();
        }
    }
}
