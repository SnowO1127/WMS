using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_user 的摘要说明
    /// </summary>
    public class sy_user : IHttpHandler
    {
        //private readonly user_bll bll = new user_bll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;
            //user_model u = new user_model();
            //switch (request["action"])
            //{
            //    case "getuser":

            //        u = utils.AutoWiredClass<user_model>(request, u);
            //        try
            //        {
            //            context.Response.Write(utils.SerializeObjectWithTime<grid<user_model>>(bll.GetUserGridByPage(u)));
            //        }
            //        catch (Exception ex)
            //        {
            //            throw ex;
            //        }
            //        break;
            //    case "adduser":
            //        jsonresult j = new jsonresult();
            //        try
            //        {
            //            u = utils.AutoWiredClass<user_model>(request, u);
            //            bll.AddUser(u);
            //            j.success = true;
            //            j.msg = "添加成功";
            //        }
            //        catch (Exception ex)
            //        {

            //            j.msg = ex.ToString();
            //        }

            //        break;
            //    case "getoneuser":
            //        string id = request["id"];
            //        try
            //        {
            //            context.Response.Write(utils.SerializeObjectWithTime<user_model>(bll.GetById(id)));
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