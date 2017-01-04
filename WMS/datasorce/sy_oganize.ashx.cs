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
    /// sy_oganize 的摘要说明
    /// </summary>
    public class sy_oganize : IHttpHandler
    {
        private readonly OganizeBLL bll = new OganizeBLL();
        private JsonResult jr;
        private SysOganize so;
        private PageSysOganize pso;
        private string oganizeid;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getoganizetree":
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetOganizeTree()));
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
                case "getoganize":
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetList()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    break;
                case "getoganizebypage":
                    try
                    {
                        pso = Utils.AutoWiredClass<PageSysOganize>(request, pso = new PageSysOganize());
                        context.Response.Write(Utils.SerializeObject(bll.GetListByPage(pso)));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    break;
                case "addoganize":
                    jr = new JsonResult();
                    try
                    {
                        so = Utils.AutoWiredClass<SysOganize>(request, so = new SysOganize());

                        so.ID = Guid.NewGuid().ToString();
                        so.CDate = DateTime.Now;

                        bll.AddOganize(so);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "updateoganize":
                    jr = new JsonResult();
                    try
                    {
                        so = Utils.AutoWiredClass<SysOganize>(request, so = new SysOganize());

                        bll.UpdateOganize(so);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "getoneoganize":
                    oganizeid = request["oganizeid"];
                    try
                    {
                        so = bll.GetOneOganize(oganizeid);

                        context.Response.Write(Utils.SerializeObject(so));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "deleteoganize":
                    oganizeid = request["oganizeid"];
                    jr = new JsonResult();
                    try
                    {
                        bll.DeleteOganize(oganizeid);

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