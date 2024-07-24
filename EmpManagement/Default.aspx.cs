using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using Entity;

namespace EmpManagement
{
    public partial class _Default : Page
    {
        int pageIndex = 1;
        int pageSize = 5;
        string search = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            search = TxtSearch.Text;
            
            if (!Page.IsPostBack)
            {
                GetAllEmployees(pageSize, pageIndex, search);
            }
        }

        private void GetAllEmployees(int parmPageSize = 5, int parmPageIndex = 1, string parmSearch = "")
        {
            List<Employee> listEmp = new EmployeeMGNT().GetAllEmployees(parmPageSize, parmPageIndex, parmSearch);

            RptEmployee.DataSource = listEmp;
            RptEmployee.DataBind();

            if (listEmp.Count > 0)
            {
                SpnNoRecord.Visible = false;
            }
            else
            {
                SpnNoRecord.Visible = true;
            }

            GetPagination(listEmp[0].RowCount, parmPageIndex);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            long empId = string.IsNullOrEmpty(hdnEmpID.Value) ? 0 : Convert.ToInt64(hdnEmpID.Value);

            int result = new BAL.EmployeeMGNT().DeleteEmployeeByID(empId);
            if (result > 0)
            {
                //User deleted
            }
            GetAllEmployees();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnPageSize.Value = ddlPageSize.SelectedValue;
            GetAllEmployees(Convert.ToInt32(hdnPageSize.Value), 1, search);
        }

        private void GetPagination(int totalCount, int pageIndex = 1)
        {
            pageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            int pagecount = (int)Math.Ceiling((float)totalCount/pageSize);

            List<ListItem> pgnButtonList = new List<ListItem>();

            pgnButtonList.Add(new ListItem { Text = "First", Value = "1", Enabled = pageIndex > 1 });

            for (int i = 1; i <= pagecount; i++)
            {
                string j = Convert.ToString(i);
                pgnButtonList.Add(new ListItem { Text = j, Value = j, Enabled = pageIndex != i });
            }

            pgnButtonList.Add(new ListItem { Text = "Last", Value = Convert.ToString(pagecount), Enabled = pageIndex < pagecount });

            PageRepeater.DataSource = pgnButtonList;
            PageRepeater.DataBind();

            rowsCount.InnerText = totalCount.ToString();
        }

        protected void BtnPagination_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            Button btn = item.FindControl("BtnPagination") as Button;
            pageIndex = Convert.ToInt32(btn.CommandArgument);
            pageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            search = TxtSearch.Text;

            GetAllEmployees(pageSize, pageIndex, search);
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetAllEmployees(pageSize,1, TxtSearch.Text);
        }
    }
}