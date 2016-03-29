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
    /// sy_role 的摘要说明
    /// </summary>
    public class sy_role : IHttpHandler
    {
        private readonly SysRoleBLL bll = new SysRoleBLL();
        PageSysRole psr;
        SysRole sr;
        JsonResult jr;
        string id, userid;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getrole":
                    jr = new JsonResult();
                    psr = new PageSysRole();
                    try
                    {
                        psr = Utils.AutoWiredClass<PageSysRole>(request, psr);
                        Grid<SysRole> g = bll.GetNonDeleteListByPage(psr);
                        //Grid<SysUser> g = bll.GetListByPage(psu);
                        context.Response.Write(Utils.SerializeObject(g));
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }
                    break;
                case "addrole":
                    sr = new SysRole();
                    jr = new JsonResult();
                    try
                    {
                        sr = Utils.AutoWiredClass<SysRole>(request, sr);
                        sr.ID = Guid.NewGuid().ToString();
                        sr.CDate = DateTime.Now;
                        bll.AddRole(sr);
                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "updaterole":
                    jr = new JsonResult();
                    try
                    {
                        sr = Utils.AutoWiredClass<SysRole>(request, sr = new SysRole());

                        bll.UpdateRole(sr);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "getonerole":
                    id = request["id"];
                    jr = new JsonResult();
                    try
                    {
                        jr.Success = true;
                        jr.Obj = bll.GetOneRole(id);
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "deleterole":
                    id = request["id"];
                    jr = new JsonResult();
                    try
                    {
                        bll.DeleteRole(id);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "getnorole":
                    userid = request["userid"];
                    jr = new JsonResult();
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetNoRoleList(userid)));
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }
                    break;
                case "gethasrole":
                    userid = request["userid"];
                    jr = new JsonResult();
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetHasRoleList(userid)));
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
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