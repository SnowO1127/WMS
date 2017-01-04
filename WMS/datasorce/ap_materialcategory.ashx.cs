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
    /// ap_materialcategory 的摘要说明
    /// </summary>
    public class ap_materialcategory : IHttpHandler, IRequiresSessionState
    {
        private readonly MaterialCategoryBLL bll = new MaterialCategoryBLL();
        private readonly UserBLL subll = new UserBLL();
        private PageAppMaterialCategory pamc;
        private AppMaterialCategory amc;
        private JsonResult jr;
        private string materialcategoryid;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;
            switch (request["action"])
            {
                case "getheadtree":
                    jr = new JsonResult();
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetHeadTree()));
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }
                    break;
                case "getmaterialcategorybypage":
                    jr = new JsonResult();
                    try
                    {
                        pamc = Utils.AutoWiredClass<PageAppMaterialCategory>(request, pamc = new PageAppMaterialCategory());
                        Grid<AppMaterialCategory> g = bll.GetMaterialCategoryByPage(pamc);
                        context.Response.Write(Utils.SerializeObject(g));
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }
                    break;
                case "addmaterialcategory":
                    jr = new JsonResult();
                    try
                    {
                        amc = Utils.AutoWiredClass<AppMaterialCategory>(request, amc = new AppMaterialCategory());
                        amc.ID = Guid.NewGuid().ToString();
                        amc.CDate = DateTime.Now;
                        amc.CUserID = subll.GetCurrentUser().ID;
                        amc.CUserName = subll.GetCurrentUser().RealName;

                        bll.AddMaterialCategory(amc);
                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "updatematerialcategory":
                    jr = new JsonResult();
                    try
                    {
                        amc = Utils.AutoWiredClass<AppMaterialCategory>(request, amc = new AppMaterialCategory());
                        amc.UDate = DateTime.Now;
                        amc.UUserID = subll.GetCurrentUser().ID;
                        amc.UUserName = subll.GetCurrentUser().RealName;

                        bll.UpdateMaterialCategory(amc);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "getonematerialcategory":
                    materialcategoryid = request["materialcategoryid"];
                    jr = new JsonResult();
                    try
                    {
                        jr.Success = true;
                        jr.Obj = bll.GetOneMaterialCategory(materialcategoryid);
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "deletematerialcategory":
                    materialcategoryid = request["materialcategoryid"];
                    jr = new JsonResult();
                    try
                    {
                        bll.DeleteMaterialCategory(materialcategoryid);

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