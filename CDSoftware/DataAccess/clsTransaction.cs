using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CDSoftware.DataAccess
{
    public class clsTransaction
    {
        public Boolean InsertTransaction(int MemberId, Byte TransType, string TransDate, Double Amount, string Description, string Comment, int UserId)
        {
            Boolean blnFlag = false;
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@MemberId", SqlDbType.Int);
                param[0].Value = MemberId;
                param[1] = new SqlParameter("@TransType", SqlDbType.Bit);
                param[1].Value = TransType;
                param[2] = new SqlParameter("@TransDate", SqlDbType.VarChar, 25);
                param[2].Value = TransDate;
                param[3] = new SqlParameter("@Description", SqlDbType.VarChar, 500);
                param[3].Value = Description;
                param[4] = new SqlParameter("@Comment", SqlDbType.VarChar, 200);
                param[4].Value = Comment;
                param[5] = new SqlParameter("@UserId", SqlDbType.Int);
                param[5].Value = UserId;
                param[6] = new SqlParameter("@Amount", SqlDbType.Float);
                param[6].Value = Amount;

                DataSet ds = clsDBconnection.ExecuteStoreProc("usp_InsertTransaction", param);
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

        //public Boolean TransferMoney(int AccountFrom, int AccountTo, Double Amount, string TransDate, string DescriptionFrom, string DescriptionTo, string Comment, int UserId)
        public Boolean TransferMoney(int AccountFrom, DataTable dtAccountTo, string TransDate, string Comment, int UserId)
        {
            Boolean blnFlag = false;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@AccountFrom", SqlDbType.Int);
                param[0].Value = AccountFrom;
                param[1] = new SqlParameter("@dtAccountTo", SqlDbType.Structured);
                param[1].Value = dtAccountTo;
                param[2] = new SqlParameter("@TransDate", SqlDbType.VarChar, 25);
                param[2].Value = TransDate;
                //param[3] = new SqlParameter("@DescriptionFrom", SqlDbType.VarChar, 500);
                //param[3].Value = DescriptionFrom;
                param[3] = new SqlParameter("@Comment", SqlDbType.VarChar, 200);
                param[3].Value = Comment;
                param[4] = new SqlParameter("@UserId", SqlDbType.Int);
                param[4].Value = UserId;
                //param[6] = new SqlParameter("@Amount", SqlDbType.Float);
                //param[6].Value = Amount;
                //param[7] = new SqlParameter("@DescriptionTo", SqlDbType.VarChar, 500);
                //param[7].Value = DescriptionTo;

                DataSet ds = clsDBconnection.ExecuteStoreProc("usp_TransferMoney", param);
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

        public DataSet TransactionHistory(string TransFromDate, string TransToDate, int MemberId)
        {
            DataSet ds = null;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@TransFromDate", SqlDbType.VarChar, 25);
                param[0].Value = TransFromDate;
                param[1] = new SqlParameter("@TransToDate", SqlDbType.VarChar, 25);
                param[1].Value = TransToDate;
                param[2] = new SqlParameter("@MemberId", SqlDbType.Int);
                param[2].Value = MemberId;

                ds = clsDBconnection.ExecuteStoreProc("usp_TransactionHistory", param);

            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }

        public DataSet DailyReport(string FromDate, string ToDate)
        {
            DataSet ds = null;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FromDate", SqlDbType.VarChar, 25);
                param[0].Value = FromDate;
                param[1] = new SqlParameter("@ToDate", SqlDbType.VarChar, 25);
                param[1].Value = ToDate;

                ds = clsDBconnection.ExecuteStoreProc("usp_GetDailyReport", param);
            }
            catch (Exception)
            {

                throw;
            }
            return ds;
        }

        public Boolean UpdateTransaction(int TransId, Double Amount,Boolean IsDelete,int UserId)
        {
            Boolean blnFlag=false;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@TransId", SqlDbType.Int);
                param[0].Value = TransId;
                param[1] = new SqlParameter("@Amount", SqlDbType.Float);
                param[1].Value = Amount;
                param[2] = new SqlParameter("@IsDelete", SqlDbType.Bit);
                param[2].Value = Amount;
                param[3] = new SqlParameter("@UserId", SqlDbType.Int);
                param[3].Value = UserId;

                DataSet ds = clsDBconnection.ExecuteStoreProc("usp_UpdateTransaction", param);

                if (ds != null && ds.Tables.Count > 0)
                {
                    blnFlag = Convert.ToBoolean(ds.Tables[0].Rows[0].ItemArray[0]);
                }
                else
                {
                    blnFlag = false;
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
