using BLL;
using Common;
using Model;
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
        private string userID, q;
        //private string rolesjsonstr;
        private JsonResult jr;
        private SysUser su;
        private int page, rows;
        private string sort, order;
        private Grid<SysUser> gsu;
        //private Grid<SysRole> gsr;
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

                        gsu = bll.GetList(page, rows, sort, order);

                        jr.Success = true;
                        jr.Obj = gsu;
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                //        case "adduser":
                //            jr = new JsonResult();
                //            try
                //            {
                //                su = Utils.AutoWiredClass<SysUser>(request, su = new SysUser());

                //                su.ID = Guid.NewGuid().ToString();
                //                su.PassWord = DEncrypt.Encrypt(Globe.DefaultPassWord);
                //                su.CDate = DateTime.Now;
                //                bll.AddUser(su);
                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));

                //            break;
                //        case "updateuser":
                //            jr = new JsonResult();
                //            try
                //            {
                //                su = Utils.AutoWiredClass<SysUser>(request, su = new SysUser());

                //                bll.UpdateUser(su);

                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                case "getUserByID":
                    jr = new JsonResult();
                    try
                    {
                        userID = request["UserID"];

                        su = bll.GetUserByID(userID);

                        jr.Success = true;
                        jr.Obj = su;
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex;
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                //        case "getuserlistbyspell":
                //            q = request["q"];
                //            int page = Convert.ToInt32(request["page"]);
                //            int rows = Convert.ToInt32(request["Rows"]);
                //            string sort = request["Sort"];
                //            string order = request["Order"];
                //            try
                //            {
                //                context.Response.Write(Utils.SerializeObject(bll.GetUserListBySpell(q, page, rows, sort, order)));
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
                //            }
                //            break;
                //        case "addroles":
                //            userid = request["userid"];
                //            rolesjsonstr = request["rolesjsonstr"];
                //            jr = new JsonResult();

                //            try
                //            {
                //                gsr = Utils.DeserializeJsonToObject<Grid<SysRole>>(rolesjsonstr);

                //                bll.AddRoles(userid, gsr.rows);
                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "deleteuser":
                //            userid = request["userid"];
                //            jr = new JsonResult();
                //            try
                //            {
                //                bll.DeleteUser(userid);

                //                jr.Success = true;
                //                jr.Msg = "删除成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }
                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "resetpassword":
                //            userid = request["userid"];
                //            jr = new JsonResult();
                //            try
                //            {
                //                bll.ResetPassWord(userid, DEncrypt.Encrypt(Globe.DefaultPassWord));

                //                jr.Success = true;
                //                jr.Msg = "重置成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }
                //            context.Response.Write(Utils.SerializeObject(jr));
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