using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDSoftware.DataAccess;

namespace CDSoftware
{
    public partial class frmTransaction : Form
    {
        public clsMembers objMember { get; set; } = null;

        public clsTransaction objTransactions { get; set; } = null;

        public DataTable accountSource { get; set; }

        public DataTable dtAccountTo = null;

        #region "Form Events"
        public frmTransaction()
        {
            InitializeComponent();
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                objMember = new clsMembers();
                objTransactions = new clsTransaction();
                dtpAT.MinDate = Convert.ToDateTime("01-Jan-2021");
                dtpAT.MaxDate = DateTime.Today;
                dtpCD.MinDate = Convert.ToDateTime("01-Jan-2021");
                dtpCD.MaxDate = DateTime.Today;
                LoadAccountCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "Transactions_Load");
            }
        }

        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetAccountBalance(cmbAccount, lblBalance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "Transaction");
            }
        }

        private void cmbAccountFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetAccountBalance(cmbAccountFrom, lblAFBalance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "Transaction");
            }
        }

        private void cmbAccountTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetAccountBalance(cmbAccountTo, lblATBalance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "Transaction");
            }
        }

        private void btnCdSumbit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValiddateCDControl())
                {
                    string strDate = dtpCD.Text.Trim();
                    Byte bTransType = Convert.ToByte(rbCredit.Checked == true ? 0 : 1);
                    Double Amount = Double.Parse(txtAmount.Text.Trim());
                    string Description = rbCredit.Checked == true ? "Credited to " + cmbAccount.Text.Trim() : "Debited from " + cmbAccount.Text.Trim();
                    string comments = txtComment.Text.Trim();
                    Boolean blnFlag = objTransactions.InsertTransaction(Convert.ToInt32(cmbAccount.SelectedValue), bTransType, strDate, Amount, Description, comments, mainModule.LoginUser.userId);
                    if (blnFlag)
                    {
                        MessageBox.Show("Transaction completed successfully.", "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAccountCombo();
                        txtComment.Text = "";
                        txtAmount.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Some problem in transaction. Please try after sometime.", "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "" + ex.StackTrace.ToString(), "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnATSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateATControl())
                {
                    string strDate = dtpAT.Text.Trim();
                    //Double Amount = Double.Parse(txtATAmount.Text.Trim());
                    //string DescriptionFrom = "Transfered to " + cmbAccountTo.Text.Trim();
                    //string DescriptionTo = "Credited from " + cmbAccountFrom.Text.Trim();
                    string comments = txtATComment.Text.Trim();
                    //Boolean blnFlag = objTransactions.TransferMoney(Convert.ToInt32(cmbAccountFrom.SelectedValue), Convert.ToInt32(cmbAccountTo.SelectedValue), Amount, strDate, DescriptionFrom, DescriptionTo, comments, mainModule.LoginUser.userId);
                    Boolean blnFlag = objTransactions.TransferMoney(Convert.ToInt32(cmbAccountFrom.SelectedValue), dtAccountTo, strDate, comments, mainModule.LoginUser.userId);
                    if (blnFlag)
                    {
                        MessageBox.Show("Transaction completed successfully.", "Transactions");
                        LoadAccountCombo();
                        dtAccountTo.Rows.Clear();
                        txtATAmount.Text = "0";
                        txtKhepAmount.Text = "0";
                        txtCommision.Text = "0";
                        txtATComment.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Some problem in transaction. Please try after sometime.", "Transactions");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "" + ex.StackTrace.ToString(), "Transactions");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtAccountTo == null)
                {
                    dtAccountTo = new DataTable();
                    dtAccountTo.Columns.Add("MemberId", Type.GetType("System.Int32"));
                    dtAccountTo.Columns.Add("Membername", Type.GetType("System.String"));
                    dtAccountTo.Columns.Add("Amount", Type.GetType("System.Double"));
                }
                if (ValidateATAddControl())
                {
                    DataRow dr = dtAccountTo.NewRow();
                    dr["MemberId"] = cmbAccountTo.SelectedValue;
                    dr["Membername"] = cmbAccountTo.Text;
                    dr["Amount"] = txtATAmount.Text.Trim();

                    dtAccountTo.Rows.Add(dr);
                    
                    if (Convert.ToDouble(txtKhepAmount.Text.Trim()) > 0)
                    {
                        DataRow dr1 = dtAccountTo.NewRow();
                        dr1["MemberId"] = ConfigurationManager.AppSettings.Get("KhepAccountNo");
                        dr1["Membername"] = "Khep";
                        dr1["Amount"] = txtKhepAmount.Text.Trim();
                        dtAccountTo.Rows.Add(dr1);
                        dtAccountTo.AcceptChanges();
                    }

                    if (Convert.ToDouble(txtCommision.Text.Trim()) > 0)
                    {
                        DataRow dr2 = dtAccountTo.NewRow();
                        dr2["MemberId"] = ConfigurationManager.AppSettings.Get("CommisionAccountNo");
                        dr2["Membername"] = "Commision";
                        dr2["Amount"] = txtCommision.Text.Trim();
                        dtAccountTo.Rows.Add(dr2);
                        
                    }
                    dtAccountTo.AcceptChanges();
                    dgvAccountTo.DataSource = dtAccountTo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString(), "Transactions_Load");
            }
        }


        private void dgvAccountTo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        if (MessageBox.Show("Are you sure want to delete selected transaction?", "Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DataRow[] dr = dtAccountTo.Select("MemberId=" + dgvAccountTo.Rows[e.RowIndex].Cells["MemberId"].Value + " and Amount=" + dgvAccountTo.Rows[e.RowIndex].Cells["Amount"].Value + "");
                            foreach (DataRow r in dr)
                            {
                                dtAccountTo.Rows.Remove(r);
                            }

                            dtAccountTo.AcceptChanges();
                            dgvAccountTo.DataSource = dtAccountTo;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "" + ex.StackTrace.ToString(), "Transactions");
            }

        }
        private void btnATCancel_Click(object sender, EventArgs e)
        {
            dtAccountTo.Rows.Clear();
            dtAccountTo.AcceptChanges();
            txtATAmount.Text = "";
            txtATComment.Text = "";
            cmbAccountFrom.SelectedIndex = 0;
            cmbAccountTo.SelectedIndex = 0;
        }

        private void btnCDCancel_Click(object sender, EventArgs e)
        {
            txtAmount.Text = "";
            txtComment.Text = "";
            cmbAccount.SelectedIndex = 0;
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

                    accountSource = ds.Tables[0].Copy();
                    DataRow dr = accountSource.NewRow();
                    dr.ItemArray = new object[] { 0, "--Select Member--", "", "", 0.0 };
                    accountSource.Rows.InsertAt(dr, 0);
                    cmbAccount.DataSource = accountSource.Copy();
                    cmbAccount.DisplayMember = "Membername";
                    cmbAccount.ValueMember = "MemberId";

                    cmbAccountFrom.DataSource = accountSource.Copy();
                    cmbAccountFrom.DisplayMember = "Membername";
                    cmbAccountFrom.ValueMember = "MemberId";

                    cmbAccountTo.DataSource = accountSource.Copy();
                    cmbAccountTo.DisplayMember = "Membername";
                    cmbAccountTo.ValueMember = "MemberId";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private Double GetAccountBalance(int MemberId)
        {
            Double dbl = 0;
            try
            {
                DataRow[] dr = accountSource.Select("MemberId=" + MemberId);
                if (dr != null && dr.Length > 0)
                {
                    dbl = Convert.ToDouble(dr[0]["AccountBalance"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dbl;
        }

        private void SetAccountBalance(ComboBox cmb, Label lbl)
        {
            try
            {
                if (cmb.SelectedIndex != 0)
                {
                    lbl.Text = Convert.ToString(GetAccountBalance(Convert.ToInt32(cmb.SelectedValue)));
                }
                else
                {
                    lbl.Text = "0.0";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Boolean ValiddateCDControl()
        {
            try
            {
                Double result;
                if (cmbAccount.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select account.", "Transactions");
                    cmbAccount.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
                {
                    MessageBox.Show("Please enter amount.", "Transactions");
                    txtAmount.Focus();
                    return false;
                }
                else if (!Double.TryParse(txtAmount.Text.Trim(), out result))
                {
                    MessageBox.Show("Please enter numeric value in amount.", "Transactions");
                    txtAmount.Focus();
                    return false;
                }
                else if (Convert.ToDouble(txtAmount.Text.Trim()) <= 0)
                {
                    MessageBox.Show("Amount should be greater than 0.", "Transactions");
                    txtAmount.Focus();
                    return false;
                }
                //else if (rbDebit.Checked && Convert.ToDouble(lblBalance.Text) < Convert.ToDouble(txtAmount.Text.Trim()))
                //{
                //    MessageBox.Show("Insufficient Balance.", "Transactions");
                //    txtAmount.Focus();
                //    return false;
                //}

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Boolean ValidateATControl()
        {
            //Double result;
            if (cmbAccountFrom.SelectedIndex == 0)
            {
                MessageBox.Show("Please select account from where you want to transfer money.", "Transactions");
                cmbAccountFrom.Focus();
                return false;
            }
            //else if (cmbAccountTo.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please select account to in which you want to transfer money.", "Transactions");
            //    cmbAccountTo.Focus();
            //    return false;
            //}
            //else if (string.IsNullOrEmpty(txtATAmount.Text.Trim()))
            //{
            //    MessageBox.Show("Please enter amount.", "Transactions");
            //    txtATAmount.Focus();
            //    return false;
            //}
            //else if (!Double.TryParse(txtATAmount.Text.Trim(), out result))
            //{
            //    MessageBox.Show("Please enter numeric value in amount.", "Transactions");
            //    txtATAmount.Focus();
            //    return false;
            //}
            //else if (Convert.ToDouble(txtATAmount.Text.Trim()) <= 0)
            //{
            //    MessageBox.Show("Amount should be greater than 0.", "Transactions");
            //    txtATAmount.Focus();
            //    return false;
            //}
            //else if (Convert.ToDouble(lblAFBalance.Text) < Convert.ToDouble(txtATAmount.Text.Trim()))
            //{
            //    MessageBox.Show("Insufficient Balance.", "Transactions");
            //    txtATAmount.Focus();
            //    return false;
            //}
            else if (dtAccountTo == null || dtAccountTo.Rows.Count == 0)
            {
                MessageBox.Show("Please select account to Transfer money.", "Transaction");
                cmbAccountTo.Focus();
                return false;
            }

            return true;
        }

        private Boolean ValidateATAddControl()
        {
            Double result = 0;
            if (cmbAccountTo.SelectedIndex == 0)
            {
                MessageBox.Show("Please select account to transfer.", "Transactions");
                cmbAccountTo.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtATAmount.Text.Trim()))
            {
                MessageBox.Show("Please enter amount.", "Transactions");
                txtATAmount.Focus();
                return false;
            }
            else if (!Double.TryParse(txtATAmount.Text.Trim(), out result))
            {
                MessageBox.Show("Please enter numeric value in amount.", "Transactions");
                txtATAmount.Focus();
                return false;
            }
            else if (Convert.ToDouble(txtATAmount.Text.Trim()) <= 0)
            {
                MessageBox.Show("Amount should be greater than 0.", "Transactions");
                txtATAmount.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtKhepAmount.Text.Trim()))
            {
                MessageBox.Show("Please enter khep amount.", "Transactions");
                txtKhepAmount.Focus();
                return false;
            }
            else if (!Double.TryParse(txtKhepAmount.Text.Trim(), out result))
            {
                MessageBox.Show("Please enter numeric value in khep amount.", "Transactions");
                txtKhepAmount.Focus();
                return false;
            }
            else if (Convert.ToDouble(txtKhepAmount.Text.Trim()) < 0)
            {
                MessageBox.Show("Khep amount should be greater than or equal to 0.", "Transactions");
                txtKhepAmount.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtCommision.Text.Trim()))
            {
                MessageBox.Show("Please enter commision amount.", "Transactions");
                txtCommision.Focus();
                return false;
            }
            else if (!Double.TryParse(txtCommision.Text.Trim(), out result))
            {
                MessageBox.Show("Please enter numeric value in commision amount.", "Transactions");
                txtCommision.Focus();
                return false;
            }
            else if (Convert.ToDouble(txtCommision.Text.Trim()) < 0)
            {
                MessageBox.Show("commision amount should be greater than or equal to 0.", "Transactions");
                txtCommision.Focus();
                return false;
            }

            return true;

        }










        #endregion


    }
}
