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
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;
            PageSysUser psu = new PageSysUser();
            SysUser su = new SysUser();
            JsonResult jr = new JsonResult();
            switch (request["action"])
            {
                case "getuser":

                    psu = utils.AutoWiredClass<PageSysUser>(request, psu);
                    try
                    {
                        Grid<SysUser> g = bll.GetListByPage(psu);
                        context.Response.Write(utils.SerializeObject(g));
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }
                    break;
                case "adduser":
                   
                    try
                    {
                        su = utils.AutoWiredClass<SysUser>(request, su);
                        su.ID = Guid.NewGuid().ToString();
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