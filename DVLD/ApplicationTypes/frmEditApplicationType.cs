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

namespace DVLD.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private clsApplicationType _ApplicationType;
        private int _ApplicatonTypeID;
        public frmEditApplicationType(int applicatonTypeID)
        {
            InitializeComponent();
            _ApplicatonTypeID = applicatonTypeID;
            _ApplicationType = clsApplicationType.Find(_ApplicatonTypeID);
        }

        private void _FillControleValues()
        {
            lblApplicationTypeID.Text = _ApplicatonTypeID.ToString();
            txtTitle.Text = _ApplicationType.ApplicatonTypeTitle;
            txtFees.Text = _ApplicationType.ApplicationTypeFees;
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
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
            if (Value != _ApplicationType.ApplicatonTypeTitle && clsApplicationType.IsExist(Value))
                ErrorMessage = "This title application type alrady used";

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
            flag = _TextBoxTitlValidating();
            flag &= _TextBoxFeesValidating();

            return flag;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (! _Validated())
            {
                MessageBox.Show("Some inputs is not valid hover in icone to describe error", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.ApplicatonTypeTitle = txtTitle.Text.Trim();
            _ApplicationType.ApplicationTypeFees = txtFees.Text.Trim();
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
