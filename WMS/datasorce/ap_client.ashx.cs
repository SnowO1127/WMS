using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WMS.datasorce
{
    /// <summary>
    /// ap_client 的摘要说明
    /// </summary>
    public class ap_client : IHttpHandler, IRequiresSessionState
    {
        //private readonly ClientBLL bll = new ClientBLL();
        //private readonly UserBLL subll = new UserBLL();
        //private PageAppClient pac;
        //private AppClient ac;
        //private JsonResult jr;
        //private string clientid;
        public void ProcessRequest(HttpContext context)
        {
        //    context.Response.ContentType = "text/plain";
        //    HttpRequest request = context.Request;
        //    switch (request["action"])
        //    {
        //        case "getclientbypage":
        //            jr = new JsonResult();
        //            try
        //            {
        //                pac = Utils.AutoWiredClass<PageAppClient>(request, pac = new PageAppClient());
        //                Grid<AppClient> g = bll.GetClientByPage(pac);
        //                context.Response.Write(Utils.SerializeObject(g));
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }
        //            break;
        //        case "addclient":
        //            jr = new JsonResult();
        //            try
        //            {
        //                ac = Utils.AutoWiredClass<AppClient>(request, ac = new AppClient());
        //                ac.ID = Guid.NewGuid().ToString();
        //                ac.CDate = DateTime.Now;
        //                ac.CUserID = subll.GetCurrentUser().ID;
        //                ac.CUserName = subll.GetCurrentUser().RealName;

        //                bll.AddClient(ac);
        //                jr.Success = true;
        //                jr.Msg = "保存成功！";
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }

        //            context.Response.Write(Utils.SerializeObject(jr));

        //            break;
        //        case "updateclient":
        //            jr = new JsonResult();
        //            try
        //            {
        //                ac = Utils.AutoWiredClass<AppClient>(request, ac = new AppClient());
        //                ac.UDate = DateTime.Now;
        //                ac.UUserID = subll.GetCurrentUser().ID;
        //                ac.UUserName = subll.GetCurrentUser().RealName;

        //                bll.UpdateClient(ac);

        //                jr.Success = true;
        //                jr.Msg = "保存成功！";
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }

        //            context.Response.Write(Utils.SerializeObject(jr));

        //            break;
        //        case "getoneclient":
        //            clientid = request["clientid"];
        //            jr = new JsonResult();
        //            try
        //            {
        //                jr.Success = true;
        //                jr.Obj = bll.GetOneClient(clientid);
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }

        //            context.Response.Write(Utils.SerializeObject(jr));

        //            break;
        //        case "deleteclient":
        //            clientid = request["clientid"];
        //            jr = new JsonResult();
        //            try
        //            {
        //                bll.DeleteClient(clientid);

        //                jr.Success = true;
        //                jr.Msg = "删除成功！";
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }

        //            context.Response.Write(Utils.SerializeObject(jr));
        //            break;
        //    }

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