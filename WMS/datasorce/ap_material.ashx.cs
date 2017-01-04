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
    /// ap_material 的摘要说明
    /// </summary>
    public class ap_material : IHttpHandler, IRequiresSessionState
    {
        private readonly MaterialBLL bll = new MaterialBLL();
        private readonly UserBLL subll = new UserBLL();
        private PageAppMaterial pam;
        private AppMaterial am;
        private JsonResult jr;
        private string materialid;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;
            switch (request["action"])
            {
                case "getmaterialbypage":
                    jr = new JsonResult();
                    try
                    {
                        pam = Utils.AutoWiredClass<PageAppMaterial>(request, pam = new PageAppMaterial());
                        Grid<AppMaterial> g = bll.GetMaterialByPage(pam);
                        context.Response.Write(Utils.SerializeObject(g));
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }
                    break;
                case "addmaterial":
                    jr = new JsonResult();
                    try
                    {
                        am = Utils.AutoWiredClass<AppMaterial>(request, am = new AppMaterial());
                        am.ID = Guid.NewGuid().ToString();
                        am.CDate = DateTime.Now;
                        am.CUserID = subll.GetCurrentUser().ID;
                        am.CUserName = subll.GetCurrentUser().RealName;

                        bll.AddMaterial(am);
                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "updatematerial":
                    jr = new JsonResult();
                    try
                    {
                        am = Utils.AutoWiredClass<AppMaterial>(request, am = new AppMaterial());
                        am.UDate = DateTime.Now;
                        am.UUserID = subll.GetCurrentUser().ID;
                        am.UUserName = subll.GetCurrentUser().RealName;

                        bll.UpdateMaterial(am);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "getonematerial":
                    materialid = request["materialid"];
                    jr = new JsonResult();
                    try
                    {
                        jr.Success = true;
                        jr.Obj = bll.GetOneMaterial(materialid);
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "deletematerial":
                    materialid = request["materialid"];
                    jr = new JsonResult();
                    try
                    {
                        bll.DeleteMaterial(materialid);

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