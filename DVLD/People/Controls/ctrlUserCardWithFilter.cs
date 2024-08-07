﻿using Business;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlUserCardWithFilter : UserControl
    {
        public int PersonID
        {
            get { return ctrlPersoneCard.Person.PersonID; }
        }

        public clsPerson SelectedPerson
        {
            get { return ctrlPersoneCard.Person; }
        }
        private enum _enFilterColumns { NationalNo = 0, PersonID = 1 }
        private Dictionary<int, string> _FilterColumns = new Dictionary<int, string>
        {
            {(int)_enFilterColumns.NationalNo, "National No" },
            {(int)_enFilterColumns.PersonID, "Person ID" },
        };

        private void _FillFilterColumnsComboBox()
        {
            cbFilterColumns.DataSource = new BindingSource(_FilterColumns, null);
            cbFilterColumns.DisplayMember = "Value";
            cbFilterColumns.ValueMember = "Key";
        }

        public ctrlUserCardWithFilter()
        {
            InitializeComponent();
            _FillFilterColumnsComboBox();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnSearch.PerformClick();
                txtFilterValue.Text = null;
            }

            _enFilterColumns SelectedFilterKey = (_enFilterColumns)cbFilterColumns.SelectedValue;
            if (SelectedFilterKey == _enFilterColumns.PersonID)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterColumns_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Visible = true;
            txtFilterValue.Focus();
            txtFilterValue.Text = null;

        }

        public void ResetLabelsPersonCard()
        {
            ctrlPersoneCard.ResetLabels();
        }

        public void LoadPersonalCardInformation(int PersonID)
        {
            ctrlPersoneCard.LoadPersonInformation(PersonID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFilterValue.Text.Trim() == "")
            {
                MessageBox.Show("Search value can't be empty");
                txtFilterValue.Focus();
                return;
            }
            string FilterValue = txtFilterValue.Text;
            _enFilterColumns SelectedValue = (_enFilterColumns)cbFilterColumns.SelectedValue;

            if (SelectedValue == _enFilterColumns.PersonID)
                ctrlPersoneCard.LoadPersonInformation(int.Parse(FilterValue));
            else
                ctrlPersoneCard.LoadPersonInformation(FilterValue);
        }

        private void _RetrieveDataAfterAdd(object sender, int PersonID)
        {
            cbFilterColumns.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            LoadPersonalCardInformation(PersonID);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAddEditPerson = new frmAddEditPerson();
            frmAddEditPerson.DataBack += _RetrieveDataAfterAdd;
            frmAddEditPerson.ShowDialog();
        }

        public void DisabledFilterBox()
        {
            gbFilter.Enabled = false;
            cbFilterColumns.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
        }
    }
}
