using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpManagement.Handler
{
    /// <summary>
    /// Summary description for EmpHandler
    /// </summary>
    public class EmpHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}