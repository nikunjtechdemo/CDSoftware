using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDSoftware.Objects;
namespace CDSoftware.DataAccess
{
    public class clsUser
    {
        public User CheckUserLogin(string Username, String password)
        {
            User objUser = null;
            try
            {
                SqlParameter[] param=new SqlParameter[2];
                param[0] = new SqlParameter("@Username", System.Data.SqlDbType.NVarChar,50);
                param[0].Value = Username;
                param[1] = new SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 50);
                param[1].Value = password;

                DataSet ds = clsDBconnection.ExecuteStoreProc("usp_ValidateLogin", param);

                if (ds != null && ds.Tables.Count>0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        objUser = new User()
                        {
                            userId = Convert.ToInt32(dr["Id"]),
                            userName = Convert.ToString(dr["username"]),
                            IsAdmin = Convert.ToBoolean(dr["IsAdmin"]),
                            IsActive = Convert.ToBoolean(dr["IsActive"]),
                            CreatedyBy = Convert.ToInt32(dr["CreatedBy"])
                        };
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
            return objUser;
        }

        public DataSet LoadUser()
        {
            DataSet ds=null;
            try
            {
                ds = clsDBconnection.ExecuteStoreProc("usp_GetUsers", null);
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }

        public Boolean UpdateUser(int UserId, string Username, string Password)
        {
            Boolean blnFlag = false;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Username", System.Data.SqlDbType.NVarChar, 50);
                param[0].Value = Username;
                param[1] = new SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 50);
                param[1].Value = Password;
                param[2] = new SqlParameter("@UserId", SqlDbType.Int);
                param[2].Value = UserId;

                DataSet ds = clsDBconnection.ExecuteStoreProc("usp_UpdateUser", param);

                if (ds != null && ds.Tables.Count > 0)
                {
                    blnFlag = Convert.ToBoolean(ds.Tables[0].Rows[0].ItemArray[0]);
                }

            }
            catch (Exception )
            {
                throw;
            }
            return blnFlag;
        }

        public Boolean InsertUser(string Username, string Password,int UserId)
        {
            Boolean blnFlag = false;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Username", System.Data.SqlDbType.NVarChar, 50);
                param[0].Value = Username;
                param[1] = new SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 50);
                param[1].Value = Password;
                param[2] = new SqlParameter("@UserId", System.Data.SqlDbType.Int);
                param[2].Value = UserId;

                DataSet ds = clsDBconnection.ExecuteStoreProc("usp_InsertUser", param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]) >0)
                    {
                        blnFlag = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return blnFlag;
        }

        public Boolean DeleteUser(int UserId)
        {
            Boolean blnFlag = false;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                
                param[0] = new SqlParameter("@UserId", SqlDbType.Int);
                param[0].Value = UserId;

                DataSet ds = clsDBconnection.ExecuteStoreProc("usp_DeleteUser", param);

                if (ds != null && ds.Tables.Count > 0)
                {
                    blnFlag = Convert.ToBoolean(ds.Tables[0].Rows[0].ItemArray[0]);
                }

            }
            catch (Exception)
            {
                throw;
            }
            return blnFlag;
        }
    }
}
