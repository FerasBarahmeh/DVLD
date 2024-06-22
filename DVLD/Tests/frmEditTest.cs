using Business;
using DVLD.General_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmEditTest : Form
    {
        private int _TestID;
        private clsTestTypes _Test;
        public frmEditTest(int TestID)
        {
            InitializeComponent();
            _TestID = TestID;
            _Test = clsTestTypes.Find(_TestID);
        }

        private void _FillControleValues()
        {
            lblTestTypeID.Text = _TestID.ToString();
            txtTitle.Text = _Test.TestTypeTitle;
            txtDescription.Text = _Test.TestTypeDescription;
            txtFees.Text = _Test.TestTypeFees;
        }

        private void frmEditTest_Load(object sender, EventArgs e)
        {
            _FillControleValues();
        }
        private void _FireError(Control sender, string ErrorMessage)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
                errorProvider.SetError(sender, ErrorMessage);
            else
                errorProvider.SetError(sender, null);
        }

        private bool _TextBoxTitlValidating()
        {
            Control Input = txtTitle;
            string ErrorMessage = "";
            string Value = Input.Text.Trim();

            if (string.IsNullOrEmpty(Value))
                ErrorMessage = "Title is required.";
            if (Value != _Test.TestTypeTitle && clsTestTypes.IsExist(Value))
                ErrorMessage = "This title test type alrady used";

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

        private bool _TextBoxDescriptionValidating()
        {
            Control Input = txtDescription;
            string ErrorMessage = "";

            if (string.IsNullOrEmpty(Input.Text.Trim()))
                ErrorMessage = "Description is required.";

            _FireError(Input, ErrorMessage);
            return string.IsNullOrEmpty(ErrorMessage);
        }


        private bool _Validated()
        {
            bool flag;
            flag = _TextBoxTitlValidating();
            flag &= _TextBoxFeesValidating();
            flag &= _TextBoxDescriptionValidating();

            return flag;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_Validated())
            {
                MessageBox.Show("Some inputs is not valid hover in icone to describe error", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Test.TestTypeTitle = txtTitle.Text.Trim();
            _Test.TestTypeFees = txtFees.Text.Trim();
            _Test.TestTypeDescription = txtDescription.Text.Trim();
            if (_Test.Save())
            {
                MessageBox.Show("Success save changes", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
