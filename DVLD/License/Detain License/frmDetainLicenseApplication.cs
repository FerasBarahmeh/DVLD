using Business;
using DVLD.General_Class;
using DVLD.License.Local_License;
using System;
using System.Windows.Forms;

namespace DVLD.License.Detain_License
{
    public partial class frmDetainLicenseApplication : Form
    {
        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;
        private clsLicenses _License;
        public frmDetainLicenseApplication()
        {
            InitializeComponent();
            ctrlDriverLicenseInfoWithFilter1.FoundedLicense += _WhenSelectedLicense;
        }

        private void _WhenSelectedLicense(clsLicenses License)
        {
            _License = License;
            _SelectedLicenseID = _License?.LicenseID ?? -1;
            lblLicenseID.Text = _SelectedLicenseID.ToString();

            llShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1) return;

            if (_License.IsDetained)
            {
                MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void btnDetain_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _DetainID = _License.Detain(Convert.ToSingle(txtFineFees.Text.Trim()), clsAuth.User.UserID);
            if (_DetainID == -1)
            {
                MessageBox.Show("Failed to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.DisabledFilterSection();
            txtFineFees.Enabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = clsAuth.User.Username;
        }

        private void txtFineFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);

            };


            if (!clsValidation.IsNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
            };
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory();
            frm.LoadLicenses(_License.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
