using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmDetailsPerson : Form
    {
        public frmDetailsPerson(int PersonID)
        {
            InitializeComponent();
            ctrlPersoneInformation.LoadPersonInformation(PersonID);
        }
    }
}
