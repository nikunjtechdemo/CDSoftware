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
using Microsoft.Reporting.WebForms;

namespace CDSoftware
{
    public partial class frmReportViewer : Form
    {
        public String FromDate { get; set; }
        public String ToDate { get; set; }
        public int MemberId { get; set; }
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                clsTransaction objTransaction = new clsTransaction();
                //DataSet ds = objTransaction.TransactionHistory(FromDate, ToDate, MemberId);
                DataSet ds = objTransaction.DailyReport(FromDate, ToDate);
                if (ds != null && ds.Tables.Count == 2 )
                {
                    
                    reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\DailyReport.rdlc";
                    this.Name = "Daily Report";
                    //reportViewer1.LocalReport.DisplayName = "Transaction Report From " + FromDate + " To " + ToDate;
                    reportViewer1.LocalReport.DisplayName = "Daily Report";
                    
                    reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("FromDate", FromDate));
                    reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ToDate", ToDate));


                    Double totalIncome = 0;
                    if (ds.Tables[0].Rows.Count > 0)
                    { 
                        totalIncome= Convert.ToDouble(ds.Tables[0].Compute("SUM(Amount)", string.Empty));
                    }
                    Double totalExpense = 0;
                    if(ds.Tables[1].Rows.Count>0)
                    { 
                        totalExpense = Convert.ToDouble(ds.Tables[1].Compute("SUM(Amount)", string.Empty));
                    }
                    reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CashAvailable", Convert.ToString(totalIncome - totalExpense)));
                    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("Income", ds.Tables[0]);
                    Microsoft.Reporting.WinForms.ReportDataSource rDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("Expense", ds.Tables[1]);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                    reportViewer1.LocalReport.DataSources.Add(rDataSource);
                    reportViewer1.LocalReport.Refresh();
                }
                else {

                    MessageBox.Show("Insufficiant Data for this report");
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

            this.reportViewer1.RefreshReport();







               
        }
    }
}
