using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmUserDetails : Form
    {
        public int UserID { get; set; }
        public frmUserDetails(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
            ctrlUserCard1.LoadInformation(UserID);
        }
    }
}
