using Business;
using DVLD.General_Class;
using DVLD.License;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.International_License
{
    public partial class frmCreateInternationalLicenseApplication : Form
    {
        private clsLicenses _Licenses = null;
        private int _LicensesID = -1;
        private int _InternationalLicenseID = -1;
        private clsInternationalLicense _InternationalLicense = null;
        public frmCreateInternationalLicenseApplication()
        {
            InitializeComponent();
            ctrlDriverLicenseInfoWithFilter.FoundedLicense += _FillInternationalLicense;
        }
        private void _FillInternationalLicense(clsLicenses licenses)
        {
            if (licenses == null)
            {
                MessageBox.Show("Not founded this license in our credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LicensesID = licenses.LicenseID;

            _Licenses = licenses;
            if (!_CheckValidationLicense())
            {
                ctrlDriverLicenseInfoWithFilter.ResetInformation();
                return;
            }

            _InternationalLicense = new clsInternationalLicense();
            _InternationalLicense.ApplicationDate = DateTime.Now;
            _InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            _InternationalLicense.LastStatusDate = DateTime.Now;
            _InternationalLicense.IssuedUsingLocalLicenseID = _Licenses.LicenseID;
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationTypeFees;
            _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            _InternationalLicense.ApplicationPersonID = _Licenses.DriverInfo.PersonID;
            _InternationalLicense.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            _InternationalLicense.CreatedByUserID = clsAuth.User.UserID;
            _InternationalLicense.DriverID = _Licenses.DriverID;
            _FillInternationalApplicationSection();
        }
        private void _FillInternationalApplicationSection()
        {
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString();
            lblLocalLicenseID.Text = _Licenses.LicenseID.ToString();
            lblFees.Text = _InternationalLicense.PaidFees.ToString();
            lblExpiredDate.Text = _Licenses.ExpirationDate.ToString("D");
            lblCreatedByUser.Text = _Licenses.DriverInfo.PersonInfo.FullName;
            lblApplicationDate.Text = DateTime.Now.ToString("D");

            if (_InternationalLicense.ApplicationID != -1)
                lblInternationalApplicationID.Text = _InternationalLicense?.ApplicationID.ToString() ?? "When Created";
            if (_InternationalLicense?.InternationalLicenseID != 0)
                lblInternationalLicenseID.Text = _InternationalLicense?.InternationalLicenseID.ToString() ?? "When Created";
        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        private bool _CheckValidationLicense()
        {
            bool Flag = true;
            if (!_Licenses.CanUpgradeToBeInternational())
            {
                MessageBox.Show("International license created depend by license class-3", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Flag = false;
            }
            int ActiveInternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(_Licenses.DriverID);
            if (ActiveInternationalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternationalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Flag = false;
            }
            if (!Flag)
            {
                _LicensesID = -1;
                _Licenses = null;
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            if (_LicensesID == -1 || _Licenses == null)
            {
                _LicensesID = -1;
                _Licenses = null;
                MessageBox.Show("Must chose license carry third class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult Result = MessageBox.Show("Are you sure you want to issue the license ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.No) return;

            if (!_InternationalLicense.Save())
            {
                MessageBox.Show("Issued international license fail  try again later", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Person {_Licenses.DriverInfo.PersonInfo.FullName} has a international license validate to 1 year", "Issued License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _FillInternationalApplicationSection();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Licenses == null)
            {
                MessageBox.Show("Select License", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory();
            frm.LoadLicenses(_Licenses.DriverInfo.PersonID);
            frm.ShowDialog();
        }
    }
}
