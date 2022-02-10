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
    public partial class frmTransHistory : Form
    {
        public clsMembers objMember { get; set; } = null;
        public clsTransaction objTransaction { get; set; } = null;

        public int TransId { get; set; }

        #region "Form Events"
        public frmTransHistory()
        {
            InitializeComponent();
        }
        private void frmTransHistory_Load(object sender, EventArgs e)
        {
            try
            {
                objMember = new clsMembers();
                objTransaction = new clsTransaction();
                dtpFrom.MaxDate = DateTime.Now;
                dtpTo.MaxDate = DateTime.Now;
                dtpFrom.Value = DateTime.Today;
                dtpTo.Value = DateTime.Today;
                LoadAccountCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "Transaction History", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFrom.Value > dtpTo.Value)
                {
                    MessageBox.Show("From date should be less than to date.", "Transaction History", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadTransactions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "Transaction History", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region "Methods"
        private void LoadAccountCombo()
        {
            try
            {
                DataSet ds = objMember.GetMembers();
                if (ds != null && ds.Tables.Count > 0)
                {

                    DataTable accountSource = ds.Tables[0].Copy();
                    DataRow dr = accountSource.NewRow();
                    dr.ItemArray = new object[] { 0, "--Select Member--", "", "", 0.0 };
                    accountSource.Rows.InsertAt(dr, 0);
                    cmbAccount.DataSource = accountSource.Copy();
                    cmbAccount.DisplayMember = "Membername";
                    cmbAccount.ValueMember = "MemberId";

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadTransactions()
        {
            try
            {
                DataSet ds = objTransaction.TransactionHistory(dtpFrom.Text.Trim(), dtpTo.Text.Trim(), Convert.ToInt32(cmbAccount.SelectedValue));
                if (ds != null && ds.Tables.Count == 2)
                {

                    bsTransactionHistory.DataSource = ds;
                    bsTransactionHistory.DataMember = ds.Tables[0].TableName;
                    dgvTransactionHistory.DataSource = bsTransactionHistory;

                    lblCreditAmount.Text = Convert.ToString(ds.Tables[1].Rows[0]["Credit"])==""?"0.0": Convert.ToString(ds.Tables[1].Rows[0]["Credit"]);
                    lblDebitAmount.Text = Convert.ToString(ds.Tables[1].Rows[0]["Debit"])==""?"0.0": Convert.ToString(ds.Tables[1].Rows[0]["Debit"]);
                    lblBalanceAmount.Text = Convert.ToString(ds.Tables[1].Rows[0]["Balance"]) == "" ? "0.0" : Convert.ToString(ds.Tables[1].Rows[0]["Balance"]);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No transactions found.", "Transaction History", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblCreditAmount.Text = "0.0";
                        lblDebitAmount.Text = "0.0";
                        lblBalanceAmount.Text = "0.0";
                    }


                }
                else
                {
                    MessageBox.Show("No transactions found.", "Transaction History", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblCreditAmount.Text = "0.0";
                    lblDebitAmount.Text = "0.0";
                    dgvTransactionHistory.DataSource = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        private void dgvTransactionHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        TransId = Convert.ToInt32(dgvTransactionHistory.Rows[e.RowIndex].Cells["TransId"].Value);
                        if (!(dgvTransactionHistory.Rows[e.RowIndex].Cells["Credit"].Value==System.DBNull.Value))
                        {
                            txtAmount.Text = dgvTransactionHistory.Rows[e.RowIndex].Cells["Credit"].Value.ToString();
                            
                        }
                        else
                        {
                            txtAmount.Text = dgvTransactionHistory.Rows[e.RowIndex].Cells["Debit"].Value.ToString();
                            
                        }
                        gpEdit.Enabled = true;
                        gpSearch.Enabled = false;
                        dgvTransactionHistory.Enabled = false;

                    }
                    if (e.ColumnIndex == 1)
                    {
                        try
                        {

                            if (MessageBox.Show("Are you sure want to delete selected Transaction?", "Transaction History", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Boolean blnFlag = objTransaction.UpdateTransaction(Convert.ToInt32(dgvTransactionHistory.Rows[e.RowIndex].Cells["TransId"].Value),0,true,mainModule.LoginUser.userId);
                                if (blnFlag)
                                {
                                    MessageBox.Show("Transaction deleted successfully.", "Transaction History");
                                    LoadTransactions();
                                }
                                else
                                {
                                    MessageBox.Show("Some problem in deleting Transaction. Please try after sometimes.", "Transaction History");
                                }

                            }

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "Transaction History");
                            gpEdit.Enabled = false;
                            gpSearch.Enabled = true;
                            dgvTransactionHistory.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "Transaction History");
                gpEdit.Enabled = false;
                gpSearch.Enabled = true;
                dgvTransactionHistory.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean blnFlag = objTransaction.UpdateTransaction(TransId,Double.Parse(txtAmount.Text.Trim()),false,mainModule.LoginUser.userId);
                if (blnFlag)
                {
                    MessageBox.Show("Transaction updated successfully", "Transaction History", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gpEdit.Enabled = false;
                    dgvTransactionHistory.Enabled = true;
                    gpSearch.Enabled = true;
                    txtAmount.Text = "";
                    LoadTransactions();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "Transaction History");
                gpEdit.Enabled = false;
                gpSearch.Enabled = true;
                dgvTransactionHistory.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportViewer frm = new frmReportViewer();
                frm.FromDate = dtpFrom.Text.Trim();
                frm.ToDate = dtpTo.Text.Trim();
                frm.MemberId = Convert.ToInt32(cmbAccount.SelectedValue);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
