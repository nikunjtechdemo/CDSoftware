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
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Login())
            {
                if (!mainModule.LoginUser.IsAdmin)
                {
                    userToolStripMenuItem.Enabled = false;
                    userToolStripMenuItem.Visible = false;
                }
            }
            else
            {
                if (Login())
                {
                    if (!mainModule.LoginUser.IsAdmin)
                    {
                        userToolStripMenuItem.Enabled = false;
                        userToolStripMenuItem.Visible = false;
                    }
                }
                else
                {
                    this.Close();
                }
            }


        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormOpen("frmUser"))
            {
                frmUser user = new frmUser();
                SetFormProperty(user);
                user.Show();
            }
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormOpen("frmMember"))
            {
                frmMember member = new frmMember();
                SetFormProperty(member);
                member.Show();
            }
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormOpen("frmTransaction"))
            {
                frmTransaction transaction = new frmTransaction();
                SetFormProperty(transaction);
                transaction.Show();
            }
        }
        private void transactionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormOpen("frmTransHistory"))
            {
                frmTransHistory transactionHistory = new frmTransHistory();
                SetFormProperty(transactionHistory);
                transactionHistory.Show();
            }
        }

        private void SetFormProperty(System.Windows.Forms.Form form)
        {

            form.MdiParent = this;
            form.ShowInTaskbar = false;
            form.WindowState = FormWindowState.Maximized;
        }



        private Boolean CheckFormOpen(string formName)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == formName)
                {
                    frm.Focus();
                    return true;
                }
            }
            return false;
        }

        public Boolean Login()
        {
            frmLogin login = new frmLogin();
            login.StartPosition = FormStartPosition.CenterScreen;
            //SetFormProperty(login);
            DialogResult dgr = login.ShowDialog();

            if (login.isSuccessfulllogin)
            {
                //MessageBox.Show("Login Successfull");
                mainModule.LoginUser = login.pUser;
                login.Close();
                login.Dispose();
                return true;
            }
            else
            {
                return false;
            }

        }

    }


}

