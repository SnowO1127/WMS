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
        private string loginname, password, securitycode;
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
                    securitycode = request["securitycode"];

                    if (securitycode.Equals(SessionHelper.Get(Globe.SecurityCodeSessionName)))
                    {
                        su = bll.GetOneUserByLoginName(loginname);

                        if (su != null)
                        {
                            su = bll.GetOneUserByLogin(loginname, DEncrypt.Encrypt(password));
                            if (su != null)
                            {
                                jr.Success = true;
                            }
                            else
                            {
                                jr.Msg = "3";
                            }
                        }
                        else
                        {
                            jr.Msg = "2";
                        }
                    }
                    else
                    {
                        jr.Msg = "1";
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