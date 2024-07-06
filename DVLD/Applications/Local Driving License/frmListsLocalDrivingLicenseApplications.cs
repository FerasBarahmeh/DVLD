﻿using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmListsLocalDrivingLicenseApplications : Form
    {
        private DataTable _AllLocalLicenseApplication;
        private DataTable _dtLocalLicenseApplication;
        enum IndexsForFilterColumns { NoFilter = 0, LocalDriverLicenseAppID = 1, NationalNo = 2, FullName = 3, Status = 4 }

        private static Dictionary<int, string> _FilterColumns = new Dictionary<int, string>
        {
            {0, "NoFilter" },
            {1, "LocalDrivingLicenseApplicationID" },
            {2, "NationalNo" },
            {3, "FullName" },
            {4, "Status" },
        };

        public frmListsLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _RegreshDGV();
            _SetItemsToFilterColmunsComboBox();
        }
        private static void _SelectDGVNameAndWidthToEachColumn(ref DataGridView DGV)
        {
            Dictionary<string, int> HeaderTable = new Dictionary<string, int>
            {
              { "L.D.L.App ID", 100 },
              { "Driving Class", 300 },
              { "NationalNo", 150 },
              { "Full Name", 350 },
              { "Application Date", 170},
              { "Passed Tests", 100},
              { "Status", 120}
            };

            short Index = 0;
            foreach (var Cell in HeaderTable)
            {
                DGV.Columns[Index].HeaderText = Cell.Key;
                DGV.Columns[Index].Width = Cell.Value;
                Index++;
            }
        }

        private void _RegreshDGV()
        {
            _AllLocalLicenseApplication = clsLocalDrivingLicenseApplication.All();
            _dtLocalLicenseApplication = _AllLocalLicenseApplication;
            dgvListLocalDrivingApplicationLicense.DataSource = _dtLocalLicenseApplication;
            lblRecordsCount.Text = dgvListLocalDrivingApplicationLicense.Rows.Count.ToString();
            if (dgvListLocalDrivingApplicationLicense.Rows.Count > 0)
                _SelectDGVNameAndWidthToEachColumn(ref dgvListLocalDrivingApplicationLicense);
        }

        private void _SetItemsToFilterColmunsComboBox()
        {
            cbFilterBy.DataSource = new BindingSource(_FilterColumns, null);
            cbFilterBy.ValueMember = "Key";
            cbFilterBy.DisplayMember = "Value";
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((IndexsForFilterColumns)cbFilterBy.SelectedIndex == IndexsForFilterColumns.NoFilter)
            {
                txtFilterValue.Visible = false;
            }
            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Focus();
            }
            txtFilterValue.Text = string.Empty;
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            IndexsForFilterColumns SelectedIndexFilter = (IndexsForFilterColumns)cbFilterBy.SelectedIndex;
            if (SelectedIndexFilter == IndexsForFilterColumns.LocalDriverLicenseAppID)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        
        private void _FilterListLocalLicenseApplication()
        {
            IndexsForFilterColumns SelectedFilterColmun = (IndexsForFilterColumns)cbFilterBy.SelectedIndex;
            string FilterString = "";
            
            if (SelectedFilterColmun == IndexsForFilterColumns.NoFilter || string.IsNullOrEmpty(txtFilterValue.Text))
            {
                _dtLocalLicenseApplication.DefaultView.RowFilter = FilterString;
                lblRecordsCount.Text = _dtLocalLicenseApplication.Rows.Count.ToString();
                return;
            }

            if (SelectedFilterColmun == IndexsForFilterColumns.LocalDriverLicenseAppID)
                FilterString = "[{0}] = {1}";
            else
                FilterString = "[{0}] LIKE '{1}%'";

            _dtLocalLicenseApplication.DefaultView.RowFilter = string.Format(FilterString, _FilterColumns[(int)SelectedFilterColmun], txtFilterValue.Text.Trim());
            lblRecordsCount.Text = _dtLocalLicenseApplication.Rows.Count.ToString();
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _FilterListLocalLicenseApplication();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}