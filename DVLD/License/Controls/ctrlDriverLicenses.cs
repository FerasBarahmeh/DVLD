using Business;
using DVLD.License.Local_License;
using System.Data;
using System.Windows.Forms;

namespace DVLD.License.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }
        private void _LoadLocalLicenseInfo()
        {
            _dtDriverLocalLicensesHistory = clsLicenses.GetLicenseByDriverID(_DriverID);

            dgvLocalLicensesHistory.DataSource = _dtDriverLocalLicensesHistory;
            lblLocalLicensesRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();

            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
            }
        }
        private void _LoadInternationalsInfo()
        {
            _dtDriverInternationalLicensesHistory = clsInternationalLicense.GetDriverInternationalLicenses(_DriverID);

            dgvInternationalLicensesHistory.DataSource = _dtDriverInternationalLicensesHistory;
            lblInternationalLicensesRecords.Text = dgvInternationalLicensesHistory.Rows.Count.ToString();

            if (dgvInternationalLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
            }
        }

        public void LoadInformationByDriverID(int DriverID)
        {
            _Driver = clsDriver.FindByDriverID(DriverID);
            _DriverID = DriverID;
            _LoadLocalLicenseInfo();
            _LoadInternationalsInfo();
        }

        public void LoadInformationByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);
            _DriverID = _Driver.DriverID;
            _LoadLocalLicenseInfo();
            _LoadInternationalsInfo();
        }

        private void licenseDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int LicenseID = (int)dgvLocalLicensesHistory.CurrentRow.Cells[1].Value;
            frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
            frm.LoadInformation();
            frm.ShowDialog();
        }
    }
}
