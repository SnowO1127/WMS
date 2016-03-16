using BLL;
using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_menu 的摘要说明
    /// </summary>
    public class sy_menu : IHttpHandler
    {
        private readonly SysMenuBLL bll = new SysMenuBLL();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;
            JsonResult jr = new JsonResult();
            SysMenu sm = new SysMenu();
            switch (request["action"])
            {
                case "getmenu":
                    try
                    {
                        context.Response.Write(utils.SerializeListWithTime<SysMenu>(bll.GetList()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    break;
                case "getismenu":
                    try
                    {
                        context.Response.Write(utils.SerializeList<Tree>(bll.GetIsMenuTree()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "addmenu":

                    try
                    {
                        sm = utils.AutoWiredClass<SysMenu>(request, sm);

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

                    context.Response.Write(utils.SerializeObject<JsonResult>(jr));
                    break;
                case "updatemenu":
                    try
                    {
                        sm = utils.AutoWiredClass<SysMenu>(request, sm);

                        bll.UpdateMenu(sm);
                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(utils.SerializeObject<JsonResult>(jr));
                    break;
                case "getonemenu":
                    try
                    {
                        string id = request["id"];

                        sm = bll.GetOneMenu(id);

                        context.Response.Write(utils.SerializeObjectWithTime<SysMenu>(sm));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
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