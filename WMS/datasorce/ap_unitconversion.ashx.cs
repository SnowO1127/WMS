using BLL;
using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WMS.datasorce
{
    /// <summary>
    /// ap_unitconversion 的摘要说明
    /// </summary>
    public class ap_unitconversion : IHttpHandler, IRequiresSessionState
    {
        private readonly AppUnitConversionBLL bll = new AppUnitConversionBLL();
        private readonly SysUserBLL subll = new SysUserBLL();
        private PageAppUnitConversion pauc;
        private AppUnitConversion auc;
        private JsonResult jr;
        private string uinitconversionid;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;
            switch (request["action"])
            {
                case "getunitconversionbypage":
                    jr = new JsonResult();
                    try
                    {
                        pauc = Utils.AutoWiredClass<PageAppUnitConversion>(request, pauc = new PageAppUnitConversion());
                        Grid<AppUnitConversion> g = bll.GetUnitConversionByPage(pauc);
                        context.Response.Write(Utils.SerializeObject(g));
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }
                    break;
                case "addunitconversion":
                    jr = new JsonResult();
                    try
                    {
                        auc = Utils.AutoWiredClass<AppUnitConversion>(request, auc = new AppUnitConversion());
                        auc.ID = Guid.NewGuid().ToString();
                        auc.CDate = DateTime.Now;
                        auc.CUserID = subll.GetCurrentUser().ID;
                        auc.CUserName = subll.GetCurrentUser().RealName;

                        bll.AddUnitConversion(auc);
                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "updateunitconversion":
                    jr = new JsonResult();
                    try
                    {
                        auc = Utils.AutoWiredClass<AppUnitConversion>(request, auc = new AppUnitConversion());
                        auc.UDate = DateTime.Now;
                        auc.UUserID = subll.GetCurrentUser().ID;
                        auc.UUserName = subll.GetCurrentUser().RealName;

                        bll.UpdateUnitConversion(auc);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "getoneunitconversion":
                    uinitconversionid = request["unitconversionid"];
                    jr = new JsonResult();
                    try
                    {
                        jr.Success = true;
                        jr.Obj = bll.GetOneUnitConversion(uinitconversionid);
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "deleteunitconversion":
                    uinitconversionid = request["unitconversionid"];
                    jr = new JsonResult();
                    try
                    {
                        bll.DeleteUnitConversion(uinitconversionid);

                        jr.Success = true;
                        jr.Msg = "删除成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
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