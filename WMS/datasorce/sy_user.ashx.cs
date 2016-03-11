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
            switch (request["action"])
            {
                case "getuser":

                    //u = utils.AutoWiredClass<user_model>(request, u);
                    try
                    {
                        //Grid<SysUser> g = bll.GetUserGridByPage();
                        context.Response.Write(utils.SerializeObjectWithTime<Grid<SysUser>>(bll.GetList()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                //case "adduser":
                //    jsonresult j = new jsonresult();
                //    try
                //    {
                //        u = utils.AutoWiredClass<user_model>(request, u);
                //        bll.AddUser(u);
                //        j.success = true;
                //        j.msg = "添加成功";
                //    }
                //    catch (Exception ex)
                //    {

                //        j.msg = ex.ToString();
                //    }

                //    break;
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