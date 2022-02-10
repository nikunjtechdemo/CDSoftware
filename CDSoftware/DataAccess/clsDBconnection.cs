using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CDSoftware.DataAccess
{
    public static class clsDBconnection
    {
        private static string connectionString;
        private static SqlConnection con;
        static clsDBconnection()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            con = new SqlConnection(connectionString);
        }

        private static void openConnection()
        {
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void closeConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }    
        }

        public static DataSet ExecuteStoreProc(string storprocname, SqlParameter[] param)
        {
            DataSet ds = null;
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand(storprocname, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                SqlDataAdapter da;
                da = new SqlDataAdapter(cmd);
                ds=new DataSet();
                da.Fill(ds);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                closeConnection();
            }
            return ds;
        }
        

    }
}
