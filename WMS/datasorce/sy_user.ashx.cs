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
        private string userid;
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
                    psu = utils.AutoWiredClass<PageSysUser>(request, psu = new PageSysUser());
                    try
                    {
                        gsu = bll.GetListByPage(psu);
                        context.Response.Write(utils.SerializeObject(gsu));
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }
                    break;
                case "adduser":
                    try
                    {
                        su = utils.AutoWiredClass<SysUser>(request, su = new SysUser());
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

                    context.Response.Write(utils.SerializeObject(jr));

                    break;
                //case "getoneuser":
                //    string id = request["id"];
                //    try
                //    {
                //        context.Response.Write(utils.SerializeObjectWithTime<user_model>(bll.GetById(id)));
                //    }
                //    catch (Exception ex)
                //    {
                //        throw ex;
                //    }
                //    break;
                case "addroles":
                    userid = request["userid"];
                    rolesjsonstr = request["rolesjsonstr"];
                    jr = new JsonResult();

                    try
                    {
                        gsr = utils.DeserializeJsonToObject<Grid<SysRole>>(rolesjsonstr);

                        bll.AddRoles(userid, gsr.rows);
                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(utils.SerializeObject(jr));
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