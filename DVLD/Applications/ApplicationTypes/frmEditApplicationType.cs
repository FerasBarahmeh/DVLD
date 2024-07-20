using Business;
using DVLD.General_Class;
using System;
using System.Windows.Forms;

namespace DVLD.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private clsApplicationType _ApplicationType;
        private int _ApplicationTypeID;
        public frmEditApplicationType(int applicatonTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = applicatonTypeID;
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);
        }

        private void _FillControlValues()
        {
            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            txtTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtFees.Text = _ApplicationType.ApplicationTypeFees.ToString();
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _FillControlValues();
        }

        private void _FireError(Control sender, string ErrorMessage)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
                errorProvider.SetError(sender, ErrorMessage);
            else
                errorProvider.SetError(sender, null);
        }

        private bool _TextBoxTitleValidating()
        {
            Control Input = txtTitle;
            string ErrorMessage = "";
            string Value = Input.Text.Trim();

            if (string.IsNullOrEmpty(Value))
                ErrorMessage = "Title is required.";
            if (Value != _ApplicationType.ApplicationTypeTitle && clsApplicationType.IsExist(Value))
                ErrorMessage = "This title application type already used";

            _FireError(Input, ErrorMessage);
            return string.IsNullOrEmpty(ErrorMessage);
        }

        private bool _TextBoxFeesValidating()
        {
            Control Input = txtFees;
            string ErrorMessage = "";

            if (!clsValidation.IsNumber(Input.Text.Trim()))
                ErrorMessage = "Must be a number";
            _FireError(Input, ErrorMessage);
            return string.IsNullOrEmpty(ErrorMessage);
        }

        private bool _Validated()
        {
            bool flag;
            flag = _TextBoxTitleValidating();
            flag &= _TextBoxFeesValidating();

            return flag;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_Validated())
            {
                MessageBox.Show("Some inputs is not valid hover in icon to describe error", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.ApplicationTypeTitle = txtTitle.Text.Trim();
            if (float.TryParse(txtFees.Text, out float value))
                _ApplicationType.ApplicationTypeFees = value;

            if (_ApplicationType.Save())
            {
                MessageBox.Show("Success save changes", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
