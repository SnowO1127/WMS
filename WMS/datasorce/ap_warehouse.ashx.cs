using BLL;
using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WMS.datasorce
{
    /// <summary>
    /// ap_warehouse 的摘要说明
    /// </summary>
    public class ap_warehouse : IHttpHandler, IRequiresSessionState
    {
        private readonly WareHouseBLL bll = new WareHouseBLL();
        private readonly UserBLL subll = new UserBLL();
        private JsonResult jr;
        private AppWareHouse awh;
        private PageAppWareHouse pawh;
        private string warehouseid;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getwarehousetree":
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetWareHouseTree()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "getheadtree":
                    try
                    {
                        context.Response.Write(Utils.SerializeObject(bll.GetHeadTree()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "getwarehousebypage":
                    try
                    {
                        pawh = Utils.AutoWiredClass<PageAppWareHouse>(request, pawh = new PageAppWareHouse());
                        context.Response.Write(Utils.SerializeObject(bll.GetListByPage(pawh)));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "addwarehouse":
                    jr = new JsonResult();
                    try
                    {
                        awh = Utils.AutoWiredClass<AppWareHouse>(request, awh = new AppWareHouse());

                        awh.ID = Guid.NewGuid().ToString();
                        awh.CDate = DateTime.Now;
                        awh.CUserID = subll.GetCurrentUser().ID;
                        awh.CUserName = subll.GetCurrentUser().RealName;

                        bll.AddWareHouse(awh);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "updatewarehouse":
                    jr = new JsonResult();
                    try
                    {
                        awh = Utils.AutoWiredClass<AppWareHouse>(request, awh = new AppWareHouse());

                        awh.UDate = DateTime.Now;
                        awh.UUserID = subll.GetCurrentUser().ID;
                        awh.UUserName = subll.GetCurrentUser().RealName;

                        bll.UpdateWareHouse(awh);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "getonewarehouse":
                    warehouseid = request["warehouseid"];
                    jr = new JsonResult();
                    try
                    {
                        awh = bll.GetOneWareHouse(warehouseid);

                        jr.Success = true;
                        jr.Obj = awh;
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }
                    context.Response.Write(Utils.SerializeObject(jr));
                    break;
                case "deletewarehouse":
                    warehouseid = request["warehouseid"];
                    jr = new JsonResult();
                    try
                    {
                        bll.DeleteWareHouse(warehouseid);

                        jr.Success = true;
                        jr.Msg = "删除成功！";
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