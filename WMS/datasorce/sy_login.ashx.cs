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
    /// sy_login 的摘要说明
    /// </summary>
    public class sy_login : IHttpHandler
    {
        private readonly SysUserBLL bll = new SysUserBLL();
        private string loginname, password;
        private JsonResult jr;
        private SysUser su;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "login":
                    jr = new JsonResult();
                    loginname = request["loginname"];
                    password = request["password"];

                    su = bll.GetOneUserByLoginName(loginname);

                    if (su != null)
                    {
                        su = bll.GetOneUserByLogin(loginname, DEncrypt.Encrypt(password));
                        if (su != null)
                        {
                            jr.Success = true;
                            jr.Msg = "登录成功！";
                        }
                        else
                        {
                            jr.Msg = "登录密码错误！";
                        }
                    }
                    else
                    {
                        jr.Msg = "用户名不存在！";
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