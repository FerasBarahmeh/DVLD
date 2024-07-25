using DVLD.Applications.International_License;
using DVLD.Applications.Local_Driving_License;
using DVLD.Applications.Release_Detained_License;
using DVLD.Applications.Renew_License_Application;
using DVLD.Applications.ReplaceLostOrDamagedLicenseApplication;
using DVLD.ApplicationTypes;
using DVLD.Auth;
using DVLD.Drivers;
using DVLD.General_Class;
using DVLD.License.Detain_License;
using DVLD.People;
using DVLD.Tests;
using DVLD.User;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;
        public frmMain(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void pepoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople ListPeople = new frmListPeople();
            ListPeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frmListUsers = new frmListUsers();
            frmListUsers.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails(clsAuth.User.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsAuth.User.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuth.User = null;
            _frmLogin.Show();
            this.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTypeTests frm = new frmListTypeTests();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListsLocalDrivingLicenseApplications frm = new frmListsLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsertUpdateLocalDrivingLicenseApplication frm = new frmInsertUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListsDrivers frm = new frmListsDrivers();
            frm.ShowDialog();
        }

        private void InternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreateInternationalLicenseApplication frm = new frmCreateInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenseApplications frm = new frmListInternationalLicenseApplications();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenseApplication frm = new frmRenewLicenseApplication();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }
    }
}
