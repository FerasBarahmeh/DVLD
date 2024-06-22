using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmListUsers : Form
    {
        private static DataTable _Users = clsUser.All();
        private static DataTable _dtUsers = _Users.DefaultView.ToTable(false, "UserID", "PersonID", "Username", "IsActive", "FullName");
        enum IndexsForFilterColumns { NoFilter = 0, UserId=1, PersonID= 2, Username=3, IsActive=4, FullName=5 }
        private static Dictionary<int, string> _FilterColumns = new Dictionary<int, string> 
        {
            {0, "NoFilter" },
            {1, "UserID" },
            {2, "PersonID" },
            {3, "Username" },
            {4, "IsActive" },
            {5, "FullName" },
        };

        public frmListUsers()
        {
            InitializeComponent();
            _FillComboBoxFilterUsers();
        }

        private void _RefreshDGV()
        {
            _Users = clsUser.All();
            _dtUsers = _Users.DefaultView.ToTable(false, "UserID", "PersonID", "Username", "IsActive", "FullName");

            dgvUsers.DataSource = _dtUsers;
            lblCountPeopleRecourd.Text = _dtUsers.Rows.Count.ToString();

            if (_Users.Rows.Count > 0) _SelectDGVPeopleColumnNameAndWidth(ref dgvUsers);
        }

        private void _FillComboBoxFilterUsers()
        {
            cbFilterUsersBy.DataSource = new BindingSource(_FilterColumns, null);
            cbFilterUsersBy.DisplayMember = "Value";
            cbFilterUsersBy.ValueMember= "Key";
        }

        private static void _SelectDGVPeopleColumnNameAndWidth(ref DataGridView DGV)
        {
            Dictionary<string, int> HeaderTable = new Dictionary<string, int>
            {
              { "Person ID", 110 },
              { "User ID", 110 },
              { "UserName", 120 },
              { "Is Active", 90},
              { "Full Name", 250}
            };

            short Index = 0;
            foreach (var Cell in HeaderTable)
            {
                DGV.Columns[Index].HeaderText = Cell.Key;
                DGV.Columns[Index].Width = Cell.Value;
                Index++;
            }
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = _dtUsers;
            lblCountPeopleRecourd.Text = _dtUsers.Rows.Count.ToString();

            if (_Users.Rows.Count > 0) _SelectDGVPeopleColumnNameAndWidth(ref dgvUsers);
        }

        private void cbFilterUsersBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexsForFilterColumns SelectedItem = (IndexsForFilterColumns) cbFilterUsersBy.SelectedIndex;
            txtFilterNotStrict.Visible = !(SelectedItem == IndexsForFilterColumns.NoFilter);
            txtFilterNotStrict.Text = null;
            txtFilterNotStrict.Focus();
            cbFilterStrict.SelectedIndex = 0;

            if (SelectedItem == IndexsForFilterColumns.IsActive)
            {
                cbFilterStrict.Visible = true;
                txtFilterNotStrict.Visible = false;
                cbFilterStrict.Focus();
            }
        }

        private void txtFilterNotStrict_KeyPress(object sender, KeyPressEventArgs e)
        {
            IndexsForFilterColumns SelectedValue = (IndexsForFilterColumns)cbFilterUsersBy.SelectedValue;
            if (SelectedValue == IndexsForFilterColumns.PersonID || SelectedValue == IndexsForFilterColumns.UserId)
                e.Handled = ! char.IsDigit(e.KeyChar) && ! char.IsControl(e.KeyChar);
        }

        private void txtFilterNotStrict_TextChanged(object sender, EventArgs e)
        {
            IndexsForFilterColumns FilterTypeKey = (IndexsForFilterColumns)cbFilterUsersBy.SelectedValue;
            string FilterValue = txtFilterNotStrict.Text.Trim();
            string FilterBy = _FilterColumns[(int)cbFilterUsersBy.SelectedValue];

            if (FilterTypeKey == IndexsForFilterColumns.NoFilter || string.IsNullOrEmpty(txtFilterNotStrict.Text))
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblCountPeopleRecourd.Text = _dtUsers.Rows.Count.ToString();
                return;
            }
            
            if (FilterTypeKey == IndexsForFilterColumns.PersonID || FilterTypeKey == IndexsForFilterColumns.UserId)
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterBy, FilterValue);
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterBy, FilterValue);
        }

        private void cbFilterStrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive", FilterValue = cbFilterStrict.Text;
            switch (FilterValue)
            {
                case "All": break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtUsers.DefaultView.RowFilter = "";
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblCountPeopleRecourd.Text = _dtUsers.Rows.Count.ToString();

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddEditUser = new frmAddEditUser();
            frmAddEditUser.ShowDialog();
            _RefreshDGV();
        }

        private void tsmiDetailsUser_Click(object sender, EventArgs e)
        {
            frmUserDetails frmUserDetails = new frmUserDetails((int)dgvUsers.CurrentRow.Cells[0].Value);
            frmUserDetails.ShowDialog();
        }

        private void tsmiEditPerson_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddEditUser = new frmAddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frmAddEditUser.ShowDialog();
            _RefreshDGV();
        }

        private void tsmiDeletePerson_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            DialogResult Result = MessageBox.Show("Are you sure you want delete user oun id " + UserID, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (Result == DialogResult.Yes)
            {
                if (clsUser.Delete(UserID))
                {
                    _RefreshDGV();
                    MessageBox.Show("Success delete user oun ID " + UserID, "Success Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("User is not deleted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
