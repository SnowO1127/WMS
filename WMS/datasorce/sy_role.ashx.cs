using BLL;
using Common;
using Model;
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
        private JsonResult jr;
        private int page, rows;
        private string sort, order;
        private Grid<SysRole> gsr;
        //private SysRole psr;
        //private SysRole sr;
        //private string roleid, userid;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getListByPage":
                    jr = new JsonResult();
                    try
                    {
                        page = Convert.ToInt32(request["page"]);
                        rows = Convert.ToInt32(request["rows"]);
                        sort = request["sort"];
                        order = request["order"];

                        gsr = bll.GetListByPage(page, rows, sort, order);

                        jr.Success = true;
                        jr.Obj = gsr;
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }
                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                //        case "addrole":
                //            sr = new SysRole();
                //            jr = new JsonResult();
                //            try
                //            {
                //                sr = Utils.AutoWiredClass<SysRole>(request, sr);
                //                sr.ID = Guid.NewGuid().ToString();
                //                sr.CDate = DateTime.Now;
                //                //bll.AddRole(sr);
                //                jr.IsSuccess = true;
                //                jr.Message = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Message = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));

                //            break;
                //        case "updaterole":
                //            jr = new JsonResult();
                //            try
                //            {
                //                sr = Utils.AutoWiredClass<SysRole>(request, sr = new SysRole());

                //                //bll.UpdateRole(sr);

                //                jr.IsSuccess = true;
                //                jr.Message = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Message = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));

                //            break;
                //        case "getonerole":
                //            roleid = request["roleid"];
                //            jr = new JsonResult();
                //            try
                //            {
                //                jr.IsSuccess = true;
                //                //jr.Obj = bll.GetOneRole(roleid);
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Message = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));

                //            break;
                //        case "deleterole":
                //            roleid = request["roleid"];
                //            jr = new JsonResult();
                //            try
                //            {
                //                //bll.DeleteRole(roleid);

                //                jr.IsSuccess = true;
                //                jr.Message = "删除成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Message = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "getnorole":
                //            userid = request["userid"];
                //            jr = new JsonResult();
                //            try
                //            {
                //                //context.Response.Write(Utils.SerializeObject(bll.GetNoRoleList(userid)));
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Message = ex.ToString();
                //            }
                //            break;
                //        case "gethasrole":
                //            userid = request["userid"];
                //            jr = new JsonResult();
                //            try
                //            {
                //                //context.Response.Write(Utils.SerializeObject(bll.GetHasRoleList(userid)));
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Message = ex.ToString();
                //            }
                //            break;
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