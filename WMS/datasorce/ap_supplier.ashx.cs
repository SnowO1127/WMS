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
    /// ap_supplier 的摘要说明
    /// </summary>
    public class ap_supplier : IHttpHandler, IRequiresSessionState
    {
        //private readonly SupplierBLL bll = new SupplierBLL();
        //private readonly UserBLL subll = new UserBLL();
        //private PageAppSupplier pasu;
        //private AppSupplier asu;
        //private JsonResult jr;
        //private string supplierid;
        public void ProcessRequest(HttpContext context)
        {
        //    context.Response.ContentType = "text/plain";
        //    HttpRequest request = context.Request;
        //    switch (request["action"])
        //    {
        //        case "getsupplierbypage":
        //            jr = new JsonResult();
        //            try
        //            {
        //                pasu = Utils.AutoWiredClass<PageAppSupplier>(request, pasu = new PageAppSupplier());
        //                Grid<AppSupplier> g = bll.GetSupplierByPage(pasu);
        //                context.Response.Write(Utils.SerializeObject(g));
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }
        //            break;
        //        case "addsupplier":
        //            jr = new JsonResult();
        //            try
        //            {
        //                asu = Utils.AutoWiredClass<AppSupplier>(request, asu = new AppSupplier());
        //                asu.ID = Guid.NewGuid().ToString();
        //                asu.CDate = DateTime.Now;
        //                asu.CUserID = subll.GetCurrentUser().ID;
        //                asu.CUserName = subll.GetCurrentUser().RealName;

        //                bll.AddSupplier(asu);
        //                jr.Success = true;
        //                jr.Msg = "保存成功！";
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }

        //            context.Response.Write(Utils.SerializeObject(jr));

        //            break;
        //        case "updatesupplier":
        //            jr = new JsonResult();
        //            try
        //            {
        //                asu = Utils.AutoWiredClass<AppSupplier>(request, asu = new AppSupplier());
        //                asu.UDate = DateTime.Now;
        //                asu.UUserID = subll.GetCurrentUser().ID;
        //                asu.UUserName = subll.GetCurrentUser().RealName;

        //                bll.UpdateSupplier(asu);

        //                jr.Success = true;
        //                jr.Msg = "保存成功！";
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }

        //            context.Response.Write(Utils.SerializeObject(jr));

        //            break;
        //        case "getonesupplier":
        //            supplierid = request["supplierid"];
        //            jr = new JsonResult();
        //            try
        //            {
        //                jr.Success = true;
        //                jr.Obj = bll.GetOneSupplier(supplierid);
        //            }
        //            catch (Exception ex)
        //            {
        //                jr.Msg = ex.ToString();
        //            }

        //            context.Response.Write(Utils.SerializeObject(jr));

        //            break;
        //        case "deletesupplier":
        //            supplierid = request["supplierid"];
        //            jr = new JsonResult();
        //            try
        //            {
        //                bll.DeleteSupplier(supplierid);

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