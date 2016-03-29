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
    /// sy_item 的摘要说明
    /// </summary>
    public class sy_item : IHttpHandler
    {
        private readonly SysItemBLL bll = new SysItemBLL();
        private JsonResult jr;
        private SysItem si;
        private string id, code;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getitemtree":
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetItemTree()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "getistree":
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetIsTree()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "additem":
                    jr = new JsonResult();
                    try
                    {
                        si = Utils.AutoWiredClass<SysItem>(request, si = new SysItem());

                        si.ID = Guid.NewGuid().ToString();
                        si.CDate = DateTime.Now;

                        bll.AddItem(si);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "updateitem":
                    jr = new JsonResult();
                    try
                    {
                        si = Utils.AutoWiredClass<SysItem>(request, si = new SysItem());

                        bll.UpdateItem(si);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "getoneitem":
                    si = new SysItem();
                    id = request["id"];
                    try
                    {
                        si = bll.GetOneItem(id);

                        context.Response.Write(Utils.SerializeObject(si));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                //case "getcombox":
                //    code = request["code"];
                //    try
                //    {
                //        si = bll.GetOneItemByCode(code);

                //        context.Response.Write(Utils.SerializeObject(si.SysItemDetails.OrderBy(x => x.OrderID).ToList()));
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