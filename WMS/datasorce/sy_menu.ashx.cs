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
    /// sy_menu 的摘要说明
    /// </summary>
    public class sy_menu : IHttpHandler, IRequiresSessionState
    {
        private readonly SysMenuBLL bll = new SysMenuBLL();
        private JsonResult jr;
        private int page, rows;
        private string sort, order;
        private string parentID;

        private Grid<SysMenu> gsm;
        //private SysMenu sm;
        //private PageSysMenu psm;
        //private string menuid;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getMenuTree":
                    jr = new JsonResult();
                    try
                    {
                        List<Tree> list = bll.GetEnabledMenuTree();

                        jr.Success = true;
                        jr.Obj = list;
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex;
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                //        case "getenabledheadtree":
                //            try
                //            {
                //                context.Response.Write(Utils.SerializeObject(bll.GetEnabledHeadTree()));
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
                //            }
                //            break;
                case "getHeadTree":
                    jr = new JsonResult();
                    try
                    {
                        List<Tree> list = bll.GetHeadTree();

                        jr.Success = true;
                        jr.Obj = list;
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex;
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                //        case "getmenu":
                //            try
                //            {
                //                context.Response.Write(Utils.SerializeObject(bll.GetList()));
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
                //            }

                //            break;
                case "getListByPage":
                    jr = new JsonResult();
                    try
                    {
                        page = Convert.ToInt32(request["page"]);
                        rows = Convert.ToInt32(request["rows"]);
                        sort = request["sort"];
                        order = request["order"];

                        parentID = request["parentID"];

                        gsm = bll.GetListByPage(page, rows, sort, order, parentID);

                        jr.Success = true;
                        jr.Obj = gsm;

                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex;
                    }
                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                //        case "getismenu":
                //            try
                //            {
                //                context.Response.Write(Utils.SerializeObject(bll.GetIsMenuTree()));
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
                //            }
                //            break;
                //        case "addmenu":
                //            jr = new JsonResult();
                //            try
                //            {
                //                sm = Utils.AutoWiredClass<SysMenu>(request, sm = new SysMenu());

                //                sm.ID = Guid.NewGuid().ToString();
                //                sm.CDate = DateTime.Now;

                //                bll.AddMenu(sm);

                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "updatemenu":
                //            jr = new JsonResult();
                //            try
                //            {
                //                sm = Utils.AutoWiredClass<SysMenu>(request, sm = new SysMenu());

                //                bll.UpdateMenu(sm);
                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "getonemenu":
                //            menuid = request["menuid"];
                //            try
                //            {
                //                sm = bll.GetOneMenu(menuid);

                //                context.Response.Write(Utils.SerializeObject(sm));
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
                //            }
                //            break;
                //        case "deletemenu":
                //            menuid = request["menuid"];
                //            jr = new JsonResult();
                //            try
                //            {
                //                bll.DeleteMenu(menuid);

                //                jr.Success = true;
                //                jr.Msg = "删除成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }
                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                case "getPermissionMenuTree":
                    jr = new JsonResult();
                    try
                    {
                        jr.Success = true;
                        jr.Obj = bll.GetPermissionMenuTree();
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