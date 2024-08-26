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
        int pageSize = 10;
        string search = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            search = TxtSearch.Text;

            if (!Page.IsPostBack)
            {
                GetAllEmployees(pageSize, pageIndex, search);
            }
        }

        private void GetAllEmployees(int parmPageSize = 10, int parmPageIndex = 1, string parmSearch = "")
        {
            List<Entity.Employee> listEmp = new EmployeeMGNT().GetAllEmployees(parmPageSize, parmPageIndex, parmSearch);

            RptEmployee.DataSource = listEmp;
            RptEmployee.DataBind();

            if (listEmp.Count > 0)
            {
                SpnNoRecord.Visible = false;
                divPagination.Visible = true;
                GetPagination(listEmp[0].RowCount, parmPageIndex);
            }
            else
            {
                SpnNoRecord.Visible = true;
                divPagination.Visible = false;
            }

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
            int pagecount = (int)Math.Ceiling((float)totalCount / pageSize);

            int blockSize = 10;
            int currentBlock = (pageIndex - 1) / blockSize;
            int startPage = currentBlock * blockSize + 1;
            int endPage = Math.Min(startPage + blockSize - 1, pagecount);

            List<ListItem> pgnButtonList = new List<ListItem>();

            pgnButtonList.Add(new ListItem { Text = "First", Value = "1", Enabled = pageIndex > 1 });

            if (currentBlock > 0)
            {
                pgnButtonList.Add(new ListItem { Text = "Previous", Value = Convert.ToString(startPage - blockSize), Enabled = startPage > blockSize });
            }

            for (int i = startPage; i <= endPage; i++)
            {
                string j = Convert.ToString(i);
                pgnButtonList.Add(new ListItem { Text = j, Value = j, Enabled = pageIndex != i });
            }

            if (endPage < pagecount)
            {
                pgnButtonList.Add(new ListItem { Text = "Next", Value = Convert.ToString(endPage + 1), Enabled = endPage < pagecount });
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
            GetAllEmployees(pageSize, 1, TxtSearch.Text);
        }
    }
}