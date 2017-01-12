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
        private SysRole sysRole;
        private string roleID, userID;
        private List<SysRole> list;

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
                        jr.Msg = "系统错误！" + ex.ToString();
                    }
                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "Insert":
                    jr = new JsonResult();
                    try
                    {
                        sysRole = Utils.AutoWiredClass<SysRole>(request, sysRole = new SysRole());

                        sysRole.ID = Guid.NewGuid().ToString();
                        sysRole.CDate = DateTime.Now;

                        bll.Insert(sysRole);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "保存失败！" + ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "Update":
                    jr = new JsonResult();
                    try
                    {
                        sysRole = Utils.AutoWiredClass<SysRole>(request, sysRole = new SysRole());

                        sysRole.UDate = DateTime.Now;

                        bll.Update(sysRole);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "保存失败！" + ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "getRoleByID":

                    jr = new JsonResult();
                    try
                    {
                        roleID = request["RoleID"];

                        sysRole = bll.GetObjectByID(roleID);

                        jr.Success = true;
                        jr.Obj = sysRole;
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "delete":

                    jr = new JsonResult();
                    try
                    {
                        roleID = request["RoleID"];


                        bll.Delete(roleID);

                        jr.Success = true;
                        jr.Msg = "删除成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "删除失败！" + ex;
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "getNoRole":

                    jr = new JsonResult();
                    try
                    {
                        userID = request["UserID"];

                        gsr = bll.GetNoRoleList(userID);

                        jr.Success = true;
                        jr.Obj = gsr;

                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "getHasRole":

                    jr = new JsonResult();
                    try
                    {
                        userID = request["UserID"];

                        gsr = bll.GetHasRoleList(userID);

                        jr.Success = true;
                        jr.Obj = gsr;
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