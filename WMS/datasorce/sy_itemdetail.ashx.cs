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
    /// sy_itemdetail 的摘要说明
    /// </summary>
    public class sy_itemdetail : IHttpHandler
    {
        private readonly ItemDetailBLL bll = new ItemDetailBLL();
        private PageSysItemDetail psid;
        private JsonResult jr;
        private SysItemDetail sid;
        private string code;
        private string itemdetailid;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getitemdetailbypage":
                    try
                    {
                        psid = Utils.AutoWiredClass<PageSysItemDetail>(request, psid = new PageSysItemDetail());
                        context.Response.Write(Utils.SerializeObject(bll.GetListByPage(psid)));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    break;
                case "additemdetail":
                    jr = new JsonResult();
                    try
                    {
                        sid = Utils.AutoWiredClass<SysItemDetail>(request, sid = new SysItemDetail());

                        sid.ID = Guid.NewGuid().ToString();
                        sid.CDate = DateTime.Now;

                        bll.AddItemDetail(sid);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "updateitemdetail":
                    jr = new JsonResult();
                    try
                    {
                        sid = Utils.AutoWiredClass<SysItemDetail>(request, sid = new SysItemDetail());

                        bll.UpdateItemDetail(sid);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "getoneitemdetail":
                    sid = new SysItemDetail();
                    itemdetailid = request["itemdetailid"];
                    try
                    {
                        sid = bll.GetOneItemDetail(itemdetailid);

                        context.Response.Write(Utils.SerializeObject(sid));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "getcombox":
                    code = request["code"];
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetItemDetailsByCode(code)));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "deleteitemdetail":
                    itemdetailid = request["itemdetailid"];
                    jr = new JsonResult();
                    try
                    {
                        bll.DeleteItemDetail(itemdetailid);

                        jr.Success = true;
                        jr.Msg = "删除成功！";
                    }
                    catch (Exception ex)
                    {
                        throw ex;
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