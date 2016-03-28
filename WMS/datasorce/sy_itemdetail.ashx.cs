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
        private readonly SysItemDetailBLL bll = new SysItemDetailBLL();
        private PageSysItemDetail psid;
        private JsonResult jr;
        private SysItemDetail sid;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getitemdetailbypage":
                    try
                    {
                        psid = utils.AutoWiredClass<PageSysItemDetail>(request, psid = new PageSysItemDetail());
                        context.Response.Write(utils.SerializeObject(bll.GetListByPage(psid)));
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
                        sid = utils.AutoWiredClass<SysItemDetail>(request, sid = new SysItemDetail());

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

                    context.Response.Write(utils.SerializeObject(jr));
                    break;
                case "updateitemdetail":
                    jr = new JsonResult();
                    try
                    {
                        sid = utils.AutoWiredClass<SysItemDetail>(request, sid = new SysItemDetail());

                        bll.UpdateItemDetail(sid);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(utils.SerializeObject(jr));
                    break;
                case "getoneitemdetail":
                    sid = new SysItemDetail();
                    try
                    {
                        string id = request["id"];

                        sid = bll.GetOneItemDetail(id);

                        context.Response.Write(utils.SerializeObject(sid));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
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