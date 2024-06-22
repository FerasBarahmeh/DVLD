using Business;
using System;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        private clsUser _User;
        
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User = clsUser.Find(_UserID);
            ctrlUserCard.LoadInformation(_UserID);
        }

        private void _FireError(Control sender, string ErrorMessage)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
                errorProvider.SetError(sender, ErrorMessage);
            else
                errorProvider.SetError(sender, null);
        }

        private bool _TextBoxCurrentPasswordValidating()
        {
            Control Input = txtCurrentPassword;
            string ErrorMessage = "";

            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
                ErrorMessage = "Password is required.";

            if (_User.Password != Input.Text)
                ErrorMessage = "Password not match with currrent password.";

            _FireError(Input, ErrorMessage);
            return string.IsNullOrEmpty(ErrorMessage);
        }

        private bool _TextBoxNewPasswordValidating()
        {
            Control Input = txtNewPassword;
            string ErrorMessage = "";

            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
                ErrorMessage = "Password is required.";

            if (Input.Text.Length > 20)
                ErrorMessage = "Password length is 20 as maximaum.";

            _FireError(Input, ErrorMessage);
            return string.IsNullOrEmpty(ErrorMessage);
        }

        private bool _TextBoxConfirmPasswordValidating()
        {
            Control Input = txtConfirmPassword;
            string ErrorMessage = "";

            if (Input.Text.Trim() != txtNewPassword.Text.Trim())
                ErrorMessage = "Not matching with new password";

            _FireError(Input, ErrorMessage);
            return string.IsNullOrEmpty(ErrorMessage);
        }

        private bool _Validated()
        {
            bool flag;
            flag = _TextBoxCurrentPasswordValidating();
            flag &= _TextBoxNewPasswordValidating();
            flag &= _TextBoxConfirmPasswordValidating();

            return flag;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (! _Validated())
            {
                MessageBox.Show("Some inputs is not valid hover in icone to describe error", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string NewPassword = txtNewPassword.Text.Trim();
            if (clsUser.ChangePassword(_UserID, NewPassword))
            {
                MessageBox.Show("Success save password", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }


    }
}
