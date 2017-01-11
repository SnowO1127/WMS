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
    /// sy_itemdetail 的摘要说明
    /// </summary>
    public class sy_itemdetail : IHttpHandler
    {
        private readonly SysItemDetailBLL bll = new SysItemDetailBLL();
        private JsonResult jr;
        private SysItemDetail sid;
        private string code;
        private string itemdetailid;
        private string itemid;
        private int page, rows;
        private string sort, order;
        private List<SysItemDetail> list;
        private Grid<SysItemDetail> gsid;

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
                        itemid = request["ItemID"];

                        if (!string.IsNullOrEmpty(itemid))
                        {
                            gsid = bll.GetListByPage(page, rows, sort, order, itemid);
                        }
                        else
                        {
                            gsid = new Grid<SysItemDetail>();
                        }

                        jr.Success = true;
                        jr.Obj = gsid;
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex;
                    }
                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                //        case "additemdetail":
                //            jr = new JsonResult();
                //            try
                //            {
                //                sid = Utils.AutoWiredClass<SysItemDetail>(request, sid = new SysItemDetail());

                //                sid.ID = Guid.NewGuid().ToString();
                //                sid.CDate = DateTime.Now;

                //                bll.AddItemDetail(sid);

                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "updateitemdetail":
                //            jr = new JsonResult();
                //            try
                //            {
                //                sid = Utils.AutoWiredClass<SysItemDetail>(request, sid = new SysItemDetail());

                //                bll.UpdateItemDetail(sid);

                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "getoneitemdetail":
                //            sid = new SysItemDetail();
                //            itemdetailid = request["itemdetailid"];
                //            try
                //            {
                //                sid = bll.GetOneItemDetail(itemdetailid);

                //                context.Response.Write(Utils.SerializeObject(sid));
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
                //            }
                //            break;
                case "getCombox":
                    jr = new JsonResult();
                    try
                    {
                        code = request["code"];

                        list = bll.GetListByCode(code);

                        jr.Success = true;
                        jr.Obj = list;
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex;
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                //        case "deleteitemdetail":
                //            itemdetailid = request["itemdetailid"];
                //            jr = new JsonResult();
                //            try
                //            {
                //                bll.DeleteItemDetail(itemdetailid);

                //                jr.Success = true;
                //                jr.Msg = "删除成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
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