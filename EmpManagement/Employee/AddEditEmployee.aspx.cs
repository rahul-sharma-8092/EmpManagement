﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpManagement.Employee
{
    public partial class AddEditEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add Employee";
        }

        [WebMethod]
        public static string SaveEmployee()
        {
           
            return "";
        }
    }
}