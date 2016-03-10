using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_news 的摘要说明
    /// </summary>
    public class sy_news : IHttpHandler
    {
        //private readonly news_bll bll = new news_bll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;
            //news_model p = new news_model();
            //switch (request["action"])
            //{
            //    case "getnews":
                   
            //        p = utils.AutoWiredClass<news_model>(request, p);
            //        try
            //        {
            //            context.Response.Write(utils.SerializeObjectWithTime<grid<news_model>>(bll.GetNewsGridByPage(p)));
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