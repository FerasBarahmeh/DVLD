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
                dgvLocalLicensesHistory.Columns[0].Width = 110;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 110;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 270;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 170;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 170;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 110;
            }
        }

        public void LoadInformationByDriverID(int DriverID)
        {
            _Driver = clsDriver.FindByDriverID(DriverID);
            _DriverID = DriverID;
            _LoadLocalLicenseInfo();
        }

        public void LoadInformationByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);
            _DriverID = _Driver.DriverID;
            _LoadLocalLicenseInfo();
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
