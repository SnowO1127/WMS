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
        private readonly SysOganizeBLL bll = new SysOganizeBLL();
        JsonResult jr;
        SysOganize so;
        PageSysOganize pso;

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
                    try
                    {
                        string id = request["id"];

                        so = bll.GetOneOganize(id);

                        context.Response.Write(Utils.SerializeObject(so));
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