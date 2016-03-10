using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_menu 的摘要说明
    /// </summary>
    public class sy_menu : IHttpHandler
    {
        //private readonly menu_bll menubll = new menu_bll();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;
            //switch (request["action"])
            //{
            //    case "getmenu":
            //        context.Response.Write(utils.SerializeList<tree>(menubll.GetMenuList()));
            //        break;
            //}
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