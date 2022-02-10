using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDSoftware.Objects;

namespace CDSoftware
{
    public static class mainModule
    {
        public static User LoginUser { get; set; }
        public static Boolean Login()
        {
            frmLogin login = new frmLogin();
            login.StartPosition = FormStartPosition.CenterScreen;
            DialogResult dgr = login.ShowDialog();
            
            if (dgr == DialogResult.OK)
            {
                //MessageBox.Show("Login Successfull");
                LoginUser = login.pUser;
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
