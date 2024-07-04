using DVLD.Applications.Local_Driving_License;
using DVLD.ApplicationTypes;
using DVLD.Auth;
using DVLD.People;
using DVLD.Tests;
using System;
using System.Windows.Forms;

namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());
            Application.Run(new frmListsLocalDrivingLicenseApplications());
        }
    }
}
