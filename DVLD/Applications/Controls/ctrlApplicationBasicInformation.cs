using Business;
using DVLD.General_Class;
using DVLD.People;
using System.Windows.Forms;

namespace DVLD.Applications.Controls
{
    public partial class ctrlApplicationBasicInformation : UserControl
    {
        private int _ApplicationID = -1;
        private clsApplication _Application;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }
        public ctrlApplicationBasicInformation()
        {
            InitializeComponent();
        }
        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
        }
        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.ApplicationStatus.ToString();
            lblType.Text = _Application.ApplicationType.ApplicationTypeTitle;
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.ApplicationPersonID.ToString();
            lblDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
            lblCreatedByUser.Text = _Application.CreatedByInfo.Username;
        }

        public void LoadApplicationInformation(int ApplicationID)
        {
            _Application = clsApplication.FindBaseApplicationByID(ApplicationID);
            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillApplicationInfo();
        }

        private void btnShowPersonInfo_Click(object sender, System.EventArgs e)
        {
            frmDetailsPerson frm = new frmDetailsPerson(_Application.ApplicationPersonID);
            frm.ShowDialog();
        }
    }
}
