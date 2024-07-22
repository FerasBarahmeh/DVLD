using Business;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _PersonID;
        private clsPerson _Person;
        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
        }

        public void LoadLicenses(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            _PersonID = _Person.PersonID;
            ctrlUserCardWithFilter1.LoadPersonalCardInformation(_PersonID);
            ctrlUserCardWithFilter1.DisabledFilterBox();
            ctrlDriverLicenses.LoadInformationByPersonID(_PersonID);
        }

        public void LoadLicenses(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            _PersonID = _Person.PersonID;
            ctrlUserCardWithFilter1.LoadPersonalCardInformation(_PersonID);
            ctrlUserCardWithFilter1.DisabledFilterBox();
            ctrlDriverLicenses.LoadInformationByPersonID(_PersonID);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
