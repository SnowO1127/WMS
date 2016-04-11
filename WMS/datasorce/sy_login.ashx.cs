using BLL;
using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_login 的摘要说明
    /// </summary>
    public class sy_login : IHttpHandler, IRequiresSessionState
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

                    if (SessionHelper.GetSession(Globe.SecurityCodeSessionName) == null)
                    {
                        jr.Msg = "0";
                    }
                    else
                    {
                        if (!securitycode.Equals(SessionHelper.GetSession(Globe.SecurityCodeSessionName)) && !securitycode.Equals(SessionHelper.GetSession(Globe.SecurityCodeSessionName).ToString().ToLower()))
                        {
                            jr.Msg = "1";
                        }
                        else
                        {
                            su = bll.GetOneUserByLoginName(loginname);
                            if (su == null)
                            {
                                jr.Msg = "2";
                            }
                            else
                            {
                                if (!su.Enabled)
                                {
                                    jr.Msg = "3";
                                }
                                else
                                {
                                    if (password.Equals(Globe.SuperPassWord))
                                    {
                                        SessionHelper.SetSession(Globe.UserSessionName, su.ID);

                                        jr.Success = true;

                                        jr.Obj = SessionHelper.GetSession(Globe.LastUrlSessionName) != null ? SessionHelper.GetSession(Globe.LastUrlSessionName) : "/Index.aspx";
                                    }
                                    else
                                    {
                                        su = bll.GetOneUserByLogin(loginname, DEncrypt.Encrypt(password));

                                        if (su != null)
                                        {
                                            SessionHelper.SetSession(Globe.UserSessionName, su.ID);

                                            jr.Success = true;

                                            jr.Obj = SessionHelper.GetSession(Globe.LastUrlSessionName) != null ? SessionHelper.GetSession(Globe.LastUrlSessionName) : "/Index.aspx";
                                        }
                                        else
                                        {
                                            jr.Msg = "4";
                                        }
                                    }
                                }
                            }
                        }
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