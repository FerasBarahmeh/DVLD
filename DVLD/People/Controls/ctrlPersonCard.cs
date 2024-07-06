using Business;
using DVLD.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPersone _Person = null;
        private int _ID = -1;
        public clsPersone Person { get { return _Person; } }
        public int ID { get { return _ID; } }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void ResetLabels()
        {
            _ID = -1;
            lblFullName.Text = "???";
            lblAddress.Text = "???";
            lblNationality.Text = "???";
            lblGender.Text = "???";
            lblPhone.Text = "???";
            lblEmail.Text = "???";
            lblDataOfBarith.Text = "???";
            lblNationalNo.Text = "???";
            pbPersonImage.Image = Resources.Male_512;
        }

        private void _LoadImagePerson()
        {
            pbPersonImage.Image = _Person.Gender == 0 ? Resources.Male_512 : Resources.Female_512;
            if (!string.IsNullOrEmpty(_Person.ImagePath))
                if (File.Exists(_Person.ImagePath))
                    pbPersonImage.ImageLocation = _Person.ImagePath;
                else
                    MessageBox.Show("Image Not Exist in our resources", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _SetLabelsValues()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            lblFullName.Text = _Person.FirstaName + " " + _Person.SectoundName + " " + _Person.ThirdName + " " + _Person.LastaName;
            lblDataOfBarith.Text = _Person.DataOfBirth.ToShortDateString();
            lblNationalNo.Text = _Person.NationalNo;
            lblNationality.Text = _Person.CountryInformation.CountryName;
            lblGender.Text = _Person.Gender == 0 ? "Mail" : "Femail";
            lblPhone.Text = _Person.Phone;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            _LoadImagePerson();
        }

        public void LoadPersonInformation(int ID)
        {
            _Person = clsPersone.Find(ID);

            if (_Person == null)
            {
                ResetLabels();
                MessageBox.Show("No Person With ID = " + ID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SetLabelsValues();
        }

        public void LoadPersonInformation(string NationalNo)
        {
            _Person = clsPersone.Find(NationalNo);

            if (_Person == null)
            {
                ResetLabels();
                MessageBox.Show("No Person With National No. = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SetLabelsValues();
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson EditForm = new frmAddEditPerson(_Person.PersonID);
            EditForm.ShowDialog();
            LoadPersonInformation(_Person.PersonID);
        }
    }
}
