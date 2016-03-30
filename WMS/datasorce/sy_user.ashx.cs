using BLL;
using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_user 的摘要说明
    /// </summary>
    public class sy_user : IHttpHandler
    {
        private readonly SysUserBLL bll = new SysUserBLL();
        private string userid, q;
        private string rolesjsonstr;
        private JsonResult jr;
        private SysUser su;
        private PageSysUser psu;
        private Grid<SysUser> gsu;
        private Grid<SysRole> gsr;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getuser":
                    psu = Utils.AutoWiredClass<PageSysUser>(request, psu = new PageSysUser());
                    try
                    {
                        gsu = bll.GetListByPage(psu);
                        context.Response.Write(Utils.SerializeObject(gsu));
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }
                    break;
                case "adduser":
                    jr = new JsonResult();
                    try
                    {
                        su = Utils.AutoWiredClass<SysUser>(request, su = new SysUser());
                        su.ID = Guid.NewGuid().ToString();
                        su.CDate = DateTime.Now;
                        bll.AddUser(su);
                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                case "updateuser":
                    jr = new JsonResult();
                    try
                    {
                        su = Utils.AutoWiredClass<SysUser>(request, su = new SysUser());

                        bll.UpdateUser(su);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "getoneuser":
                    userid = request["id"];
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetOneUser(userid)));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "getuserlistbyspell":
                    q = request["q"];
                    int page = Convert.ToInt32(request["page"]);
                    int rows = Convert.ToInt32(request["Rows"]);
                    string sort = request["Sort"];
                    string order = request["Order"];
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetUserListBySpell(q, page, rows, sort, order)));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "addroles":
                    userid = request["userid"];
                    rolesjsonstr = request["rolesjsonstr"];
                    jr = new JsonResult();

                    try
                    {
                        gsr = Utils.DeserializeJsonToObject<Grid<SysRole>>(rolesjsonstr);

                        bll.AddRoles(userid, gsr.rows);
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