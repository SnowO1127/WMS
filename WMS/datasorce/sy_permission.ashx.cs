using BLL;
using Common;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_permission 的摘要说明
    /// </summary>
    public class sy_permission : IHttpHandler
    {
        private readonly PermissionBLL bll = new PermissionBLL();
        private JsonResult jr;
        private string userid, roleid, jsonstr;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getuserpermissiontree":
                    userid = request.Params["userid"];
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetUserPermissionTree(userid)));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "getrolepermissiontree":
                    roleid = request.Params["roleid"];
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetRolePermissionTree(roleid)));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "adduerpermission":
                    jr = new JsonResult();
                    userid = request.Params["userid"];
                    jsonstr = request.Params["jsonstr"];

                    try
                    {
                        bll.AddUserPermission(userid, jsonstr);
                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;

                case "addrolepermission":
                    jr = new JsonResult();
                    roleid = request.Params["roleid"];
                    jsonstr = request.Params["jsonstr"];

                    try
                    {
                        bll.AddRolePermission(roleid, jsonstr);
                        jr.Success = true;
                        jr.Msg = "保存成功！";
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