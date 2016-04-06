using BLL;
using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_menu 的摘要说明
    /// </summary>
    public class sy_menu : IHttpHandler
    {
        private readonly SysMenuBLL bll = new SysMenuBLL();
        private JsonResult jr;
        private SysMenu sm;
        private PageSysMenu psm;
        private string menuid, userid;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getmenutree":
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetMenuTree()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "getheadtree":
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetHeadTree()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "getmenu":
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetList()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    break;
                case "getmenubypage":
                    try
                    {
                        psm = Utils.AutoWiredClass<PageSysMenu>(request, psm = new PageSysMenu());
                        context.Response.Write(Utils.SerializeObject(bll.GetListByPage(psm)));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    break;
                case "getismenu":
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetIsMenuTree()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "addmenu":
                    jr = new JsonResult();
                    try
                    {
                        sm = Utils.AutoWiredClass<SysMenu>(request, sm = new SysMenu());

                        sm.ID = Guid.NewGuid().ToString();
                        sm.CDate = DateTime.Now;

                        bll.AddMenu(sm);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "updatemenu":
                    jr = new JsonResult();
                    try
                    {
                        sm = Utils.AutoWiredClass<SysMenu>(request, sm = new SysMenu());

                        bll.UpdateMenu(sm);
                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "getonemenu":
                    menuid = request["menuid"];
                    try
                    {
                        sm = bll.GetOneMenu(menuid);

                        context.Response.Write(Utils.SerializeObject(sm));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "deletemenu":
                    menuid = request["menuid"];
                    jr = new JsonResult();
                    try
                    {
                        bll.DeleteMenu(menuid);

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