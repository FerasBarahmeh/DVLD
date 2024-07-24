using Business;
using DVLD.License;
using DVLD.People;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.International_License
{
    public partial class frmListInternationalLicenseApplications : Form
    {
        private DataTable _dtInternationalLicenseApplications;

        public frmListInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmListInternationalLicenseApplications_Load(object sender, System.EventArgs e)
        {
            _dtInternationalLicenseApplications = clsInternationalLicense.All();
            cbFilterBy.SelectedIndex = 0;

            dgvInternationalLicenses.DataSource = _dtInternationalLicenseApplications;
            lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
            }
        }

        private void btnNewApplication_Click(object sender, System.EventArgs e)
        {
            frmCreateInternationalLicenseApplication frm = new frmCreateInternationalLicenseApplication();
            frm.ShowDialog();
            // Refresh
            frmListInternationalLicenseApplications_Load(null, null);
        }

        private void PersonDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;

            frmDetailsPerson frm = new frmDetailsPerson(PersonID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory();
            frm.LoadLicenses(PersonID);
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;
                txtFilterValue.Enabled = cbFilterBy.Text != "None";
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }
    }
}
