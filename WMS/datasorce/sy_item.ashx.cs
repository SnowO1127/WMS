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
    /// sy_item 的摘要说明
    /// </summary>
    public class sy_item : IHttpHandler
    {
        private readonly SysItemBLL bll = new SysItemBLL();
        private JsonResult jr;
        private List<Tree> treeList;
        //private SysItem si;
        //private string itemid;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            switch (request["action"])
            {
                case "getItemTree":
                    jr = new JsonResult();
                    try
                    {
                        treeList = bll.GetItemTree();

                        jr.Success = true;
                        jr.Obj = treeList;
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = "系统错误！" + ex;
                    }

                    context.Response.Write(Utils.SerializeObject(jr));
                   
                    break;
                //        case "getistree":
                //            try
                //            {
                //                context.Response.Write(Utils.SerializeObject(bll.GetIsTree()));
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
                //            }
                //            break;
                //        case "additem":
                //            jr = new JsonResult();
                //            try
                //            {
                //                si = Utils.AutoWiredClass<SysItem>(request, si = new SysItem());

                //                si.ID = Guid.NewGuid().ToString();
                //                si.CDate = DateTime.Now;

                //                bll.AddItem(si);

                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "updateitem":
                //            jr = new JsonResult();
                //            try
                //            {
                //                si = Utils.AutoWiredClass<SysItem>(request, si = new SysItem());

                //                bll.UpdateItem(si);

                //                jr.Success = true;
                //                jr.Msg = "保存成功！";
                //            }
                //            catch (Exception ex)
                //            {
                //                jr.Msg = ex.ToString();
                //            }

                //            context.Response.Write(Utils.SerializeObject(jr));
                //            break;
                //        case "getoneitem":
                //            si = new SysItem();
                //            itemid = request["itemid"];
                //            try
                //            {
                //                si = bll.GetOneItem(itemid);

                //                context.Response.Write(Utils.SerializeObject(si));
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
                //            }
                //            break;
                //        case "deleteitem":
                //            itemid = request["itemid"];
                //            jr = new JsonResult();
                //            try
                //            {
                //                bll.DeleteItem(itemid);

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