using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmListPeople : Form
    {

        private static DataTable _AllPeople = clsPersone.GetAllPeople();
        private DataTable _Peoples = _AllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "GenderName", "DateOfBirth", "CountryName", "Phone", "Email");
        private enum FilterColumns { NoFilter = 0, PersonID = 1, NationalNo = 2, FirstName = 3, SecondName = 4, ThirdName = 5, LastName = 6, Nationality = 7, Gender = 8, Phone = 9, Email = 10 };

        private Dictionary<int, string> _FilterValues = new Dictionary<int, string>
        {
            { 0, "NoFilter" },
            { 1, "PersonID" },
            { 2, "NationalNo" },
            { 3, "FirstName" },
            { 4, "SecondName" },
            { 5, "ThirdName" },
            { 6, "LastName" },
            { 7, "Nationality" },
            { 8, "Gendor" },
            { 9, "Phone" },
            { 10, "Email" }
        };

        public frmListPeople()
        {
            InitializeComponent();
            _SetFilterCompoBoxValues();
        }

        private static void _SelectDGVPeopleColumnNameAndWidth(ref DataGridView dgv)
        {
            Dictionary<string, int> columnSettings = new Dictionary<string, int>
                    {
                        { "Person ID", 110 },
                        { "National No.", 120 },
                        { "First Name", 120 },
                        { "Second Name", 140 },
                        { "Third Name", 120 },
                        { "Last Name", 120 },
                        { "Gender", 120 },
                        { "Date Of Birth", 140 },
                        { "Nationality", 120 },
                        { "Phone", 120 },
                        { "Email", 170 }
                    };
            int columnIndex = 0;
            foreach (var column in columnSettings)
            {
                dgv.Columns[columnIndex].HeaderText = column.Key;
                dgv.Columns[columnIndex].Width = column.Value;
                columnIndex++;
            }
        }

        private void _SetFilterCompoBoxValues()
        {
            cbFilterPersonBy.DataSource = new BindingSource(_FilterValues, null);
            cbFilterPersonBy.DisplayMember = "Value";
            cbFilterPersonBy.ValueMember = "Key";
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {
            dgvPeople.DataSource = _Peoples;
            lblCountPeopleRecourd.Text = _Peoples.Rows.Count.ToString();

            if (_Peoples.Rows.Count > 0) _SelectDGVPeopleColumnNameAndWidth(ref dgvPeople);

        }

        private void _RefreshDGV()
        {
            _AllPeople = clsPersone.GetAllPeople();
            _Peoples = _AllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GenderName", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgvPeople.DataSource = _Peoples;
            lblCountPeopleRecourd.Text = dgvPeople.Rows.Count.ToString();

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAddPerson = new frmAddEditPerson();
            frmAddPerson.ShowDialog();
            _RefreshDGV();
        }

        private void tsmiDetailsPerson_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmDetailsPerson Details = new frmDetailsPerson(PersonID);
            Details.ShowDialog();
        }

        private void tsmiEditPerson_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmAddEditPerson UpdateForm = new frmAddEditPerson(PersonID);
            UpdateForm.ShowDialog();
            _RefreshDGV();
        }

        private void tsmiSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature under implemented", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsmiPhone_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature under implemented", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsmiDeletePerson_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;

            DialogResult Result = MessageBox.Show($"Are you sure you want to Delete {PersonID}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                try
                {
                    if (clsPersone.Delete(PersonID))
                    {
                        MessageBox.Show($"Success Delete Person {PersonID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshDGV();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Fail Delete Person {ex.Message}", ex);
                }
            }
        }

        private void tsmiAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAddPerson = new frmAddEditPerson();
            frmAddPerson.ShowDialog();
            _RefreshDGV();
        }

        private void cbFilterPersonBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((FilterColumns)cbFilterPersonBy.SelectedIndex != FilterColumns.NoFilter)
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Text = null;
                txtFilterValue.Focus();
            }
            else
            {
                txtFilterValue.Visible = false;
                _Peoples.DefaultView.RowFilter = "";
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((FilterColumns)cbFilterPersonBy.SelectedValue == FilterColumns.PersonID)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            int FilterColumnChosen = (int)cbFilterPersonBy.SelectedValue;

            if ((FilterColumns)FilterColumnChosen == FilterColumns.NoFilter || string.IsNullOrEmpty(txtFilterValue.Text))
            {
                _Peoples.DefaultView.RowFilter = "";
                lblCountPeopleRecourd.Text = _Peoples.Rows.Count.ToString();
                return;
            }

            if ((FilterColumns)FilterColumnChosen == FilterColumns.PersonID)
                _Peoples.DefaultView.RowFilter = string.Format("[{0}] = {1}", _FilterValues[FilterColumnChosen], txtFilterValue.Text.Trim());
            else
                _Peoples.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", _FilterValues[FilterColumnChosen], txtFilterValue.Text.Trim());

            lblCountPeopleRecourd.Text = _Peoples.DefaultView.Count.ToString();
        }
    }
}
