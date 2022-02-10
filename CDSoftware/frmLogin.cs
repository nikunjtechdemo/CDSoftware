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
using CDSoftware.Objects;
namespace CDSoftware
{
    public partial class frmLogin : Form
    {
        public User pUser { get; set; }
        public Boolean isSuccessfulllogin { get; set; } = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    clsUser objUser = new clsUser();
                    pUser = objUser.CheckUserLogin(txtUsername.Text.Trim(),CryptoEngine.Encrypt(txtPassword.Text.Trim()));
                    if (pUser != null)
                    {
                        this.btnLogin.DialogResult = DialogResult.OK;
                        MessageBox.Show("Login Successfull", "CD Software",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        isSuccessfulllogin = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username and Password", this.Name);
                        isSuccessfulllogin = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n" + ex.StackTrace.ToString());
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private Boolean ValidateControls()
        {
            Boolean bResult = true;
            if (String.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username cannot be null", this.Name);
                bResult = false;
                txtUsername.Focus();
            }
            else if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Password cannot be null", this.Name);
                bResult = false;
                txtPassword.Focus();
            }
            return bResult;
        }
    }
}
