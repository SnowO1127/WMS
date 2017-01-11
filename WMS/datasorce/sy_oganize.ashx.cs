using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_oganize 的摘要说明
    /// </summary>
    public class sy_oganize : IHttpHandler
    {
        private readonly SysOganizeBLL bll = new SysOganizeBLL();
        private JsonResult jr;
        private string parentID;
        private int page, rows;
        private string sort, order;
        private Grid<SysOganize> gso;
        //private SysOganize so;
        //private PageSysOganize pso;
        //private string oganizeid;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getOganizeTree":
                    try
                    {
                        //context.Response.Write(Utils.SerializeObject(bll.GetOganizeTree()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "getHeadTree":
                    jr = new JsonResult();
                    try
                    {
                        List<Tree> list = new List<Tree>();

                        list = bll.GetHeadTree();

                        jr.Success = true;
                        jr.Obj = list;

                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex;
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                //        case "getoganize":
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

                        parentID = request["ParentID"];

                        gso = bll.GetListByPage(page, rows, sort, order, parentID);

                        jr.Success = true;
                        jr.Obj = gso;

                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex;
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                //        case "addoganize":
                //            jr = new JsonResult();
                //            try
                //            {
                //                so = Utils.AutoWiredClass<SysOganize>(request, so = new SysOganize());

                //                so.ID = Guid.NewGuid().ToString();
                //                so.CDate = DateTime.Now;

                //                bll.AddOganize(so);

                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "updateoganize":
                //            jr = new JsonResult();
                //            try
                //            {
                //                so = Utils.AutoWiredClass<SysOganize>(request, so = new SysOganize());

                //                bll.UpdateOganize(so);

                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "getoneoganize":
                //            oganizeid = request["oganizeid"];
                //            try
                //            {
                //                so = bll.GetOneOganize(oganizeid);

                //                context.Response.Write(Utils.SerializeObject(so));
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
                //            }
                //            break;
                //        case "deleteoganize":
                //            oganizeid = request["oganizeid"];
                //            jr = new JsonResult();
                //            try
                //            {
                //                bll.DeleteOganize(oganizeid);

                //                jr.Success = true;
                //                jr.Msg = "删除成功！";
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