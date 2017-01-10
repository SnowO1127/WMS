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
    /// sy_button 的摘要说明
    /// </summary>
    public class sy_button : IHttpHandler
    {
        private readonly SysButtonBLL bll = new SysButtonBLL();
        private JsonResult jr;
        private string menuID;
        private int page, rows;
        private string sort, order;
        private Grid<SysButton> gsb;
        //private PageSysButton psb;
        //private SysButton sb;

        //private string buttonid;

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

                        menuID = request["MenuID"];

                        if (!string.IsNullOrEmpty(menuID))
                        {
                            gsb = bll.GetListByPage(page, rows, sort, order, menuID);
                        }
                        else
                        {
                            gsb = new Grid<SysButton>();
                        }

                        jr.Success = true;
                        jr.Obj = gsb;
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex;
                    }

                    context.Response.Write(Utils.SerializeObject(jr));

                    break;
                //        case "addbutton":
                //            jr = new JsonResult();
                //            try
                //            {
                //                sb = Utils.AutoWiredClass<SysButton>(request, sb = new SysButton());

                //                sb.ID = Guid.NewGuid().ToString();
                //                sb.CDate = DateTime.Now;


                //                bll.AddButton(sb);

                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "updatebutton":
                //            jr = new JsonResult();
                //            try
                //            {
                //                sb = Utils.AutoWiredClass<SysButton>(request, sb = new SysButton());

                //                bll.UpdateButton(sb);
                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "getonebutton":
                //            buttonid = request["buttonid"];
                //            try
                //            {
                //                sb = bll.GetOneButton(buttonid);

                //                context.Response.Write(Utils.SerializeObject(sb));
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
                //            }
                //            break;
                //        case "deletebutton":
                //            buttonid = request["buttonid"];
                //            jr = new JsonResult();
                //            try
                //            {
                //                bll.DeleteButton(buttonid);

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