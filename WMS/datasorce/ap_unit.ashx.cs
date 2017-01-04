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
    /// ap_unit 的摘要说明
    /// </summary>
    public class ap_unit : IHttpHandler, IRequiresSessionState
    {
        //private readonly UnitBLL bll = new UnitBLL();
        //private readonly UserBLL subll = new UserBLL();
        //private PageAppUnit pau;
        //private AppUnit au;
        //private JsonResult jr;
        //private string unitid;
        public void ProcessRequest(HttpContext context)
        {
        //    context.Response.ContentType = "text/plain";
        //    HttpRequest request = context.Request;
        //    switch (request["action"])
        //    {
        //        case "getunit":
        //            jr = new JsonResult();
        //            try
        //            {
        //                context.Response.Write(Utils.SerializeObject(bll.GetUnitList()));
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }
        //            break;
        //        case "getunitbypage":
        //            jr = new JsonResult();
        //            try
        //            {
        //                pau = Utils.AutoWiredClass<PageAppUnit>(request, pau = new PageAppUnit());
        //                Grid<AppUnit> g = bll.GetUnitByPage(pau);
        //                context.Response.Write(Utils.SerializeObject(g));
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }
        //            break;
        //        case "addunit":
        //            jr = new JsonResult();
        //            try
        //            {
        //                au = Utils.AutoWiredClass<AppUnit>(request, au = new AppUnit());
        //                au.ID = Guid.NewGuid().ToString();
        //                au.CDate = DateTime.Now;
        //                au.CUserID = subll.GetCurrentUser().ID;
        //                au.CUserName = subll.GetCurrentUser().RealName;

        //                bll.AddUnit(au);
        //                jr.Success = true;
        //                jr.Msg = "保存成功！";
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }

        //            context.Response.Write(Utils.SerializeObject(jr));

        //            break;
        //        case "updateunit":
        //            jr = new JsonResult();
        //            try
        //            {
        //                au = Utils.AutoWiredClass<AppUnit>(request, au = new AppUnit());
        //                au.UDate = DateTime.Now;
        //                au.UUserID = subll.GetCurrentUser().ID;
        //                au.UUserName = subll.GetCurrentUser().RealName;

        //                bll.UpdateUnit(au);

        //                jr.Success = true;
        //                jr.Msg = "保存成功！";
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }

        //            context.Response.Write(Utils.SerializeObject(jr));

        //            break;
        //        case "getoneunit":
        //            unitid = request["unitid"];
        //            jr = new JsonResult();
        //            try
        //            {
        //                jr.Success = true;
        //                jr.Obj = bll.GetOneUnit(unitid);
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }

        //            context.Response.Write(Utils.SerializeObject(jr));

        //            break;
        //        case "deleteunit":
        //            unitid = request["unitid"];
        //            jr = new JsonResult();
        //            try
        //            {
        //                bll.DeleteUnit(unitid);

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