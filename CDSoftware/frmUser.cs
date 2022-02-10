using CDSoftware.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDSoftware
{
    public partial class frmUser : Form
    {
        public string FormMode { get; set; } = "Add";

        public clsUser objUser { get; set; }
        #region "Form Events"
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            try
            {
                objUser = new clsUser();
                LoadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "User Managment");
            }
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvUser.RowCount > 0 && dgvUser.CurrentRow.Index != -1)
                {
                    lblUserId.Text = dgvUser.Rows[dgvUser.CurrentRow.Index].Cells["UserId"].Value.ToString();
                    txtUsername.Text = dgvUser.Rows[dgvUser.CurrentRow.Index].Cells["Username"].Value.ToString();
                    txtPassword.Text = CryptoEngine.Decrypt(dgvUser.Rows[dgvUser.CurrentRow.Index].Cells["Password"].Value.ToString());
                }
                else
                {
                    lblUserId.Text = "";
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "User Managment");
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (e.ColumnIndex == 0)
                {
                    txtUsername.Enabled = true;
                    txtPassword.Enabled = true;
                    btnAddEdit.Text = "Save";
                    FormMode = "Edit";
                    dgvUser.Enabled = false;
                }
                if (e.ColumnIndex == 1)
                {
                    try
                    {
                        if (!(mainModule.LoginUser.IsAdmin && mainModule.LoginUser.userId== Convert.ToInt32(dgvUser.Rows[e.RowIndex].Cells["UserId"].Value)))
                        {
                            if (MessageBox.Show("Are you sure want to delete selected user?", "User Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                Boolean blnFlag = objUser.DeleteUser(Convert.ToInt32(dgvUser.Rows[e.RowIndex].Cells["UserId"].Value));
                                if (blnFlag)
                                {
                                    MessageBox.Show("User deleted successfully.", "User Management");
                                    LoadUser();
                                }
                                else
                                {
                                    MessageBox.Show("Some problem in deleting user. Please try after sometimes.", "User Management");
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("You cannot delete Admin user.", "User Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "User Managment");
                    }
                }
            }
        }

        #endregion

        #region "User Methods"

        private void LoadUser()
        {
            try
            {
                DataSet ds = objUser.LoadUser();
                if (ds != null && ds.Tables.Count > 0)
                {
                    bsUser.DataSource = ds;
                    bsUser.DataMember = ds.Tables[0].TableName;
                    dgvUser.DataSource = bsUser;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "User Managment");
            }
        }

        private Boolean ValidateControls()
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username cannot be empty.", "User Management");
                txtUsername.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Password cannot be empty.", "User Management");
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void EnableControls()
        {
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            dgvUser.Enabled = true;
            btnAddEdit.Text = "Add";
            FormMode = "Add";
            if (dgvUser.Rows.Count > 0)
            {
                dgvUser_SelectionChanged(null, null);
            }
        }



        #endregion

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormMode == "Add" && btnAddEdit.Text == "Add")
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Enabled = true;
                    txtPassword.Enabled = true;
                    btnAddEdit.Text = "Save";
                    txtUsername.Focus();
                    dgvUser.Enabled = false;
                }
                else if (FormMode == "Add" && btnAddEdit.Text == "Save")
                {
                    if (ValidateControls())
                    {
                        Boolean blnFlag = objUser.InsertUser(txtUsername.Text.Trim(),CryptoEngine.Encrypt(txtPassword.Text.Trim()),mainModule.LoginUser.userId);
                        if (blnFlag)
                        {
                            MessageBox.Show("User inserted successfully.", "User Management");
                            LoadUser();
                        }
                        else
                        {
                            MessageBox.Show("Some problem in inserting user. Please try after sometimes.", "User Management");
                        }
                        EnableControls();
                    }
                }
                else if (FormMode == "Edit" && btnAddEdit.Text == "Save")
                {
                    if (ValidateControls())
                    {
                        Boolean blnFlag = objUser.UpdateUser(Convert.ToInt32(lblUserId.Text.Trim()), txtUsername.Text.Trim(),CryptoEngine.Encrypt(txtPassword.Text.Trim()));
                        if (blnFlag)
                        {
                            MessageBox.Show("User updated successfully.", "User Management");
                            LoadUser();
                        }
                        else
                        {
                            MessageBox.Show("Some problem in updating user. Please try after sometimes.", "User Management");
                        }
                        EnableControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "User Management");
                EnableControls();
            }
            finally
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableControls();
        }
    }
}
