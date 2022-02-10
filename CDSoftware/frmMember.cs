using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDSoftware.DataAccess;
namespace CDSoftware
{
    public partial class frmMember : Form
    {
        public string FormMode { get; set; } = "Add";
        public clsMembers objMember { get; set; } = null;
        public frmMember()
        {
            InitializeComponent();
        }

        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (e.ColumnIndex == 0)
                {
                    txtMembername.Enabled = true;
                    txtAddress.Enabled = true;
                    txtContactNo.Enabled = true;
                    txtAccountBalance.Enabled = false;
                    btnAddEdit.Text = "Save";
                    FormMode = "Edit";
                    dgvMember.Enabled = false;
                    btnRefresh.Enabled = false;
                }
                if (e.ColumnIndex == 1)
                {
                    try
                    {

                        if (MessageBox.Show("Are you sure want to delete selected Member?", "Member Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Boolean blnFlag = objMember.DeleteMember(Convert.ToInt32(dgvMember.Rows[e.RowIndex].Cells["MemberId"].Value),mainModule.LoginUser.userId);
                            if (blnFlag)
                            {
                                MessageBox.Show("Member deleted successfully.", "Member Management");
                                LoadMember();
                            }
                            else
                            {
                                MessageBox.Show("Some problem in deleting member. Please try after sometimes.", "Member Management");
                            }

                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "Member Managment");
                    }
                }
            }
        }

        private void dgvMember_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                if (dgvMember.RowCount > 0 && dgvMember.CurrentRow.Index != -1)
                {
                    lblMemberId.Text = dgvMember.Rows[dgvMember.CurrentRow.Index].Cells["MemberId"].Value.ToString();
                    txtMembername.Text = dgvMember.Rows[dgvMember.CurrentRow.Index].Cells["MemberName"].Value.ToString();
                    txtAddress.Text = dgvMember.Rows[dgvMember.CurrentRow.Index].Cells["Address"].Value.ToString();
                    txtContactNo.Text = dgvMember.Rows[dgvMember.CurrentRow.Index].Cells["ContactNo"].Value.ToString();
                    txtAccountBalance.Text = dgvMember.Rows[dgvMember.CurrentRow.Index].Cells["AccountBalance"].Value.ToString();
                }
                else
                {
                    lblMemberId.Text = "";
                    txtMembername.Text = "";
                    txtAddress.Text = "";
                    txtContactNo.Text = "";
                    txtAccountBalance.Text = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "User Managment");
            }
        }

        private void frmMember_Load(object sender, EventArgs e)
        {
            try
            {
                objMember = new clsMembers();
                LoadMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "User Managment");
            }
        }



        private void LoadMember()
        {
            try
            {
                DataSet ds = objMember.GetMembers();
                if (ds != null && ds.Tables.Count > 0)
                {
                    bsMembers.DataSource = ds;
                    bsMembers.DataMember = ds.Tables[0].TableName;
                    dgvMember.DataSource = bsMembers;
                    lblBalanceAmount.Text = Convert.ToString(ds.Tables[1].Rows[0]["Balance"]) == "" ? "0.0" : Convert.ToString(ds.Tables[1].Rows[0]["Balance"]);
                }
                else
                {
                    lblBalanceAmount.Text = "0.0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "User Managment");
            }
        }

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormMode == "Add" && btnAddEdit.Text == "Add")
                {
                    txtMembername.Text = "";
                    txtAddress.Text = "";
                    txtContactNo.Text = "";
                    txtAccountBalance.Text = "";
                    txtMembername.Enabled = true;
                    txtAddress.Enabled = true;
                    txtContactNo.Enabled = true;
                    txtAccountBalance.Enabled = true;
                    btnAddEdit.Text = "Save";
                    txtMembername.Focus();
                    dgvMember.Enabled = false;
                    btnRefresh.Enabled = false;
                }
                else if (FormMode == "Add" && btnAddEdit.Text == "Save")
                {
                    if (ValidateControls())
                    {
                        Boolean blnFlag = objMember.InsertMember(txtMembername.Text.Trim(),txtAddress.Text.Trim(),txtContactNo.Text.Trim(),Double.Parse(txtAccountBalance.Text.Trim()), mainModule.LoginUser.userId);
                        if (blnFlag)
                        {
                            MessageBox.Show("Member inserted successfully.", "Member Management");
                            LoadMember();
                        }
                        else
                        {
                            MessageBox.Show("Some problem in inserting member. Please try after sometimes.", "Member Management");
                        }
                        EnableControls();
                    }
                }
                else if (FormMode == "Edit" && btnAddEdit.Text == "Save")
                {
                    if (ValidateControls())
                    {
                        Boolean blnFlag = objMember.UpdateMembers(Convert.ToInt32(lblMemberId.Text.Trim()), txtMembername.Text.Trim(), txtAddress.Text.Trim(), txtContactNo.Text.Trim(), Double.Parse(txtAccountBalance.Text.Trim()), mainModule.LoginUser.userId);
                        if (blnFlag)
                        {
                            MessageBox.Show("Member updated successfully.", "Member Management");
                            LoadMember();
                        }
                        else
                        {
                            MessageBox.Show("Some problem in updating Member. Please try after sometimes.", "Member Management");
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMember();
        }

        private Boolean ValidateControls()
        {
            int result;
            Double accountBalance;
            if (string.IsNullOrEmpty(txtMembername.Text.Trim()))
            {
                MessageBox.Show("Membername cannot be empty.", "Member Management");
                txtMembername.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                MessageBox.Show("Address cannot be empty.", "Member Management");
                txtAddress.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtContactNo.Text.Trim()))
            {
                MessageBox.Show("ContactNo cannot be empty.", "Member Management");
                txtContactNo.Focus();
                return false;
            }
            else if (txtContactNo.Text.Trim().Length != 10)
            {
                MessageBox.Show("ContactNo should be 10 number.", "Member Management");
                txtContactNo.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtAccountBalance.Text.Trim()))
            {
                MessageBox.Show("Address cannot be empty.", "Member Management");
                txtAccountBalance.Focus();
                return false;
            }
            else if (!int.TryParse(txtContactNo.Text.Trim(), out result))
            {
                MessageBox.Show("ContactNo should contain numeric value only.", "Member Management");
                txtContactNo.Focus();
                return false;
            }
            else if (!Double.TryParse(txtAccountBalance.Text.Trim(), out accountBalance))
            {
                MessageBox.Show("AccountBalance should contain numeric value only.", "Member Management");
                txtContactNo.Focus();
                return false;
            }

            return true;
        }

        private void EnableControls()
        {
            txtMembername.Enabled = false;
            txtAddress.Enabled = false;
            txtContactNo.Enabled = false;
            txtAccountBalance.Enabled = false;
            btnRefresh.Enabled = true;
            dgvMember.Enabled = true;
            btnAddEdit.Text = "Add";
            FormMode = "Add";
            if (dgvMember.Rows.Count > 0)
            {
                dgvMember_SelectionChanged(null, null);
            }
            
        }

       
       
    }
}
