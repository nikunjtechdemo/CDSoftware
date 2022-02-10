using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CDSoftware.DataAccess
{
    public class clsMembers
    {
        public DataSet GetMembers()
        {
            DataSet ds;
            try
            {
                ds = clsDBconnection.ExecuteStoreProc("usp_GetMembers", null);
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }

        public Boolean InsertMember(string MemberName, string Address, string ContactNo, double AccountBalance, int UserId)
        {
            Boolean blnFlag = false;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@MemberName", SqlDbType.VarChar, 50);
                param[0].Value = MemberName;
                param[1] = new SqlParameter("@Address", SqlDbType.VarChar, 150);
                param[1].Value = Address;
                param[2] = new SqlParameter("@ContactNo", SqlDbType.VarChar, 10);
                param[2].Value = ContactNo;
                param[3] = new SqlParameter("@AccountBalance", SqlDbType.Float);
                param[3].Value = AccountBalance;
                param[4] = new SqlParameter("@UserId", SqlDbType.Int);
                param[4].Value = UserId;

                DataSet ds = clsDBconnection.ExecuteStoreProc("usp_InsertMember", param);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]) > 0)
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

        public Boolean UpdateMembers(int MemberId,string MemberName, string Address, string ContactNo, double AccountBalance, int UserId)
        {
            Boolean blnFlag = false;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@MemberName", SqlDbType.VarChar, 50);
                param[0].Value = MemberName;
                param[1] = new SqlParameter("@Address", SqlDbType.VarChar, 150);
                param[1].Value = Address;
                param[2] = new SqlParameter("@ContactNo", SqlDbType.VarChar, 10);
                param[2].Value = ContactNo;
                param[3] = new SqlParameter("@AccountBalance", SqlDbType.Float);
                param[3].Value = AccountBalance;
                param[4] = new SqlParameter("@UserId", SqlDbType.Int);
                param[4].Value = UserId;
                param[5] = new SqlParameter("@MemberId", SqlDbType.Int);
                param[5].Value = MemberId;

                DataSet ds = clsDBconnection.ExecuteStoreProc("usp_UpdateMember", param);

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

        public Boolean DeleteMember(int MemberId, int UserId)
        {
            Boolean blnFlag = false;
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@UserId", SqlDbType.Int);
                param[0].Value = UserId;
                param[1] = new SqlParameter("@MemberId", SqlDbType.Int);
                param[1].Value = MemberId;

                DataSet ds = clsDBconnection.ExecuteStoreProc("usp_DeleteMember", param);

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
