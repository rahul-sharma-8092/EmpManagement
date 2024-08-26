using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace EmpManagement.Reports
{
    public partial class EmpListReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindRDLC();
            }
        }

        public void BindRDLC()
        {
            System.Data.DataSet DS = new BAL.EmployeeMGNT().GetAllEmployeesDataSet(100000, 1, "");

            ReportEmpListViwer.ProcessingMode = ProcessingMode.Local;
            ReportEmpListViwer.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/EmpListReport.rdlc");
            ReportDataSource datasource = new ReportDataSource("EmpListDataSet", DS.Tables[0]);

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Header", "Employee List"));
            reportParameters.Add(new ReportParameter("SubHeader", "Using RDLC Report"));

            ReportEmpListViwer.LocalReport.SetParameters(reportParameters);
            ReportEmpListViwer.LocalReport.Refresh();
            
            ReportEmpListViwer.LocalReport.DataSources.Clear();
            ReportEmpListViwer.LocalReport.DataSources.Add(datasource);

            ReportEmpListViwer.Width = 1300;
            ReportEmpListViwer.Height = 750;
        }
    }
}