using Business;
using DVLD.General_Class;
using DVLD.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        private clsPersone _Person;

        private int _PersonID = -1;
        private enum Mode { Add = 0, Edit = 1 }
        private enum Gender { Male = 0, Female = 1 }

        private Mode _Mode = Mode.Add;

        public frmAddEditPerson()
        {
            InitializeComponent();
            this._Mode = Mode.Add;
        }

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            this._Mode = Mode.Edit;
        }

        private void _FillCountriesComboBox()
        {
            DataTable Countries = clsCountry.GetAllCountries();
            foreach (DataRow Country in Countries.Rows)
            {
                cbCountry.Items.Add(Country["CountryName"]);
            }
        }

        private void _ResetFieldsToDefault()
        {
            _FillCountriesComboBox();

            if (_Mode == Mode.Add)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPersone();
            }
            else
                lblTitle.Text = "Update Person";

            pbPersonImage.Image = rbMale.Checked ? Resources.Male_512 : Resources.Female_512;

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");
            txtFirstName.Text = "";
            txtSecoundName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void _LoadData()
        {
            _Person = clsPersone.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("Not Found This Person in out records", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtFirstName.Text = _Person.FirstaName;
            txtSecoundName.Text = _Person.SectoundName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastaName;
            txtNationalNo.Text = _Person.NationalNo;
            rbMale.Checked = _Person.Gender == 0;
            rbFemale.Checked = _Person.Gender == 1;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
                pbPersonImage.ImageLocation = _Person.ImagePath;

            llRemoveImage.Visible = !(string.IsNullOrEmpty(_Person.ImagePath));
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInformation.CountryName);
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetFieldsToDefault();

            if (_Mode == Mode.Edit) _LoadData();

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = openFileDialog.FileName;
                pbPersonImage.Load(selectedPath);
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            llRemoveImage.Visible = false;

            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;

            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;

            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                ep.SetError(temp, "Can't be Empty Value");
            }
            else
            {
                ep.SetError(temp, null);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            string Message = "";

            if (string.IsNullOrEmpty(temp.Text.Trim()))
                Message = "Can't be Empty Value";

            if (_Person.NationalNo != txtNationalNo.Text && clsPersone.IsPersonExist(temp.Text.Trim()))
                Message = "This national No. is used";

            if (!string.IsNullOrEmpty(Message))
            {
                e.Cancel = true;
                ep.SetError(temp, Message);
            }
            else
            {
                ep.SetError(temp, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim())
                && !clsValidation.IsValidEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                ep.SetError(temp, "Not valid email format");
            }
            else
            {
                ep.SetError(temp, null);
            }
        }

        private bool _HandeldPersonIamge()
        {
            // If image changed
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (!string.IsNullOrEmpty(_Person.ImagePath))
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (Exception) { }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    string Source = pbPersonImage.ImageLocation.ToString();
                    if (clsFilesHandler.CopyFileToProjectFilesFolder(ref Source))
                    {
                        pbPersonImage.ImageLocation = Source;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandeldPersonIamge()) return;

            int NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;

            _Person.FirstaName = txtFirstName.Text.Trim();
            _Person.LastaName = txtLastName.Text.Trim();
            _Person.SectoundName = txtSecoundName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Gender = (short)(rbFemale.Checked ? Gender.Female : Gender.Male);
            _Person.NationalCountyID = NationalityCountryID;
            _Person.ImagePath = pbPersonImage.ImageLocation != null ? pbPersonImage.ImageLocation : "";
            _Person.DataOfBirth = dtpDateOfBirth.Value;

            if (_Person.Save())
            {
                _Mode = Mode.Edit;

                lblTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
