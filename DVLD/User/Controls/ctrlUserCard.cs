using Business;
using System.Windows.Forms;

namespace DVLD.User.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        public clsUser User { get; set; }
        public int UserID {  get; set; }

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void _ResetLabels()
        {
            lblUserID.Text = "??";
            lblIsActive.Text = "??";
            lblUsername.Text = "??";
        }

        private void _FillUserLabels()
        {
            lblUserID.Text = User.UserID.ToString();
            lblIsActive.Text = User.IsActive ? "Yes" : "No";
            lblUsername.Text = User.Username.ToString();
        }

        public void LoadInformation(int UserID)
        {
            User = clsUser.Find(UserID);
            if (User == null)
            {
                ctrlPersoneCard.ResetLabels();
                MessageBox.Show("Not find user has ID = " + UserID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ctrlPersoneCard.LoadPersonInformation(User.PersonID);

            _FillUserLabels();
        }
    }
}
