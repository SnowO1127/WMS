using BLL;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_login 的摘要说明
    /// </summary>
    public class sy_login : IHttpHandler
    {
        private readonly SysUserBLL bll = new SysUserBLL();
        private string loginname, password;
        private JsonResult jr;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "login":
                    jr = new JsonResult();
                    loginname = request["loginname"];
                    password = request["password"];



                    break;
            }
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