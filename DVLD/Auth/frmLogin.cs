using Business;
using DVLD.General_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Auth
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
            if (cbRememperMe.Checked)
            {
                clsAuth.SetParameters(out string Username, out string Password);
                txtUsername.Text = Username;
                txtPassword.Text = Password;
                btnLogin.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Password = txtPassword.Text.Trim(), Username = txtUsername.Text.Trim();
            clsUser User = clsUser.FindUserByAuthRequirment(Username, Password);

            if (User == null )
            {
                MessageBox.Show("Not found this username or password in credential", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (! User.IsActive)
            {
                MessageBox.Show($"{Username} not active, pls contact with mangment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsAuth.User = User;

            if (cbRememperMe.Checked)
                clsAuth.RememperAuthorizedUser(Username, Password);
            else
                clsAuth.CleanRememperAuthorizedUser();

            frmMain frmMain = new frmMain(this);
            frmMain.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
