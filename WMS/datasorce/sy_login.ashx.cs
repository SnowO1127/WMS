using BLL;
using Common;
using Model;
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

                    try
                    {
                        loginname = request["loginname"];
                        password = request["password"];
                        securitycode = request["securitycode"];

                        if (loginname.Equals(Globe.SuperUser) && password.Equals(Globe.SuperPassWord))
                        {
                            jr.Success = true;

                            SessionHelper.SetSession(Globe.UserSessionName, loginname);

                            jr.Obj = SessionHelper.GetSession(Globe.LastUrlSessionName) != null ? SessionHelper.GetSession(Globe.LastUrlSessionName) : "/Index.aspx";
                        }
                        else
                        {
                            if (SessionHelper.GetSession(Globe.SecurityCodeSessionName) == null)
                            {
                                jr.Msg = "0"; //验证码失效
                            }
                            else
                            {
                                if (!securitycode.Equals(SessionHelper.GetSession(Globe.SecurityCodeSessionName)) && !securitycode.Equals(SessionHelper.GetSession(Globe.SecurityCodeSessionName).ToString().ToLower()))
                                {
                                    jr.Msg = "1"; //验证码错误
                                }
                                else
                                {
                                    su = bll.GetOneUserByLoginName(loginname);
                                    if (su == null)
                                    {
                                        jr.Msg = "2"; //用户不存在
                                    }
                                    else
                                    {
                                        if (DEncrypt.Encrypt(su.PassWord).Equals(password))
                                        {

                                            if (!su.Enabled)
                                            {
                                                jr.Msg = "3"; //用户不可用
                                            }
                                            else
                                            {
                                                SessionHelper.SetSession(Globe.UserSessionName, loginname);

                                                jr.Success = true;

                                                jr.Obj = SessionHelper.GetSession(Globe.LastUrlSessionName) != null ? SessionHelper.GetSession(Globe.LastUrlSessionName) : "/Index.aspx";
                                            }
                                        }
                                        else
                                        {
                                            jr.Msg = "4"; //密码错误
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex;
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