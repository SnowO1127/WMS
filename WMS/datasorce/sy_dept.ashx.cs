using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_dept 的摘要说明
    /// </summary>
    public class sy_dept : IHttpHandler
    {
        //private readonly dept_bll bll = new dept_bll();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;
            //dept_model d = new dept_model();
            //switch (request["action"])
            //{
            //    case "getdept":
            //        string id = request["id"];
            //        bool type = Convert.ToBoolean(request["type"]);
            //        try
            //        {
            //            if (type)
            //            {
            //                context.Response.Write(utils.SerializeListWithTime<dept_model>(bll.FindByUnitId(id)));
            //            }
            //            else
            //            {
            //                context.Response.Write(utils.SerializeListWithTime<dept_model>(bll.FindByDeptId(id)));
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            throw ex;
            //        }
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