using Business;
using DVLD.People.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmAddEditUser : Form
    {
        private enum _enMode { Add = 0, Edit = 1 }
        private _enMode _Mode;
        private int _UserID;
        private clsUser _User;

        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = _enMode.Add;
            _UserID = -1;
        }
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _Mode= _enMode.Edit;
            _UserID = UserID;
        }

        private bool _VerifyUpgradeToUserPrivileges()
        {
            if (ctrlUserCardWithFilter.SelectedPerson == null)
            {
                MessageBox.Show("Pleas determin the person you want has user privilage", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tcAddEditUser.SelectedIndex = 0;
                return false;
            }

            if (_Mode == _enMode.Add && clsPersone.IsUser(ctrlUserCardWithFilter.SelectedPerson.PersonID))
            {
                MessageBox.Show("The Person Has ID " + ctrlUserCardWithFilter.SelectedPerson.PersonID + " is alrady has user privilage",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcAddEditUser.SelectedIndex = 0;
                return false;
            }
            return true;
        }

        private void tcAddEditUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcAddEditUser.SelectedIndex == 1)
                _VerifyUpgradeToUserPrivileges();
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (_VerifyUpgradeToUserPrivileges())
                tcAddEditUser.SelectedIndex++;
        }

        private void _FireErrorValidating(Control sender, CancelEventArgs e, string ErrorMessage)
        {
            if (! string.IsNullOrEmpty(ErrorMessage))
            {
                errorProvider.SetError(sender, ErrorMessage);
                e.Cancel = true;
            } 
            else
            {
                errorProvider.SetError(sender, string.Empty);
                e.Cancel = false;
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            Control Input = txtUsername;
            string ErrorMessage = "";
            if (string.IsNullOrEmpty(Input.Text))
                ErrorMessage = "Username is required.";


            if (txtUsername.Text != _User.Username && clsUser.IsExist(txtUsername.Text))
                ErrorMessage = "Username is alrady used.";

            _FireErrorValidating(Input, e, ErrorMessage);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            Control Input = txtPassword;
            string ErrorMessage = "";

            if (string.IsNullOrEmpty(Input.Text) && _User.Password != Input.Text)
                ErrorMessage = "Password is required.";
                
            if (Input.Text.Length > 20)
                ErrorMessage = "Password length is 20 as maximaum.";

            _FireErrorValidating(Input, e, ErrorMessage);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            Control Input = txtConfirmPassword;
            string ErrorMessage = "";
            if (Input.Text != txtPassword.Text)
                ErrorMessage = "Not matching with password";

            _FireErrorValidating(Input, e, ErrorMessage);
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (! ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _User.PersonID = ctrlUserCardWithFilter.PersonID;
            _User.Username = txtUsername.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = cbIsActive.Checked;

            if (_User.Save())
            {
                if (_Mode == _enMode.Add)
                {
                    _UserID = _User.UserID;
                    _Mode = _enMode.Edit;
                    lblTitle.Text = "Update User";
                }
                _LoadData();
                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _ResetControls()
        {
            if (_Mode == _enMode.Add)
            {
                _User = new clsUser();
                lblTitle.Text = "Add user";
            } 
            else
            {
                lblTitle.Text = "Update user";
            }
            lblUserID.Text = "??";
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            cbIsActive.Checked = true;
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);
            if (_User  == null)
            {
                ctrlUserCardWithFilter.ResetLabelsPersonCard();
                MessageBox.Show("This user not found");
                return;
            }
            
            ctrlUserCardWithFilter.LoadPersonalCardInformation(_User.PersonID);
            lblUserID.Text = _UserID.ToString();
            txtUsername.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            cbIsActive.Checked = _User.IsActive;
            
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetControls();
            if (_Mode == _enMode.Edit)
            {
                _LoadData();
                ctrlUserCardWithFilter.DisabledFilterBox();
            }
        }
    }
}
