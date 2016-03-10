using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_unit 的摘要说明
    /// </summary>
    public class sy_unit : IHttpHandler
    {

        //private readonly unit_bll bll = new unit_bll();
        private string id;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;
            //unit_model u = new unit_model();
            //jsonresult j = new jsonresult();
            //switch (request["action"])
            //{
            //    case "getunit":
            //        u = utils.AutoWiredClass<unit_model>(request, u);
            //        if (u.id == null)
            //        {
            //            context.Response.Write("[]");
            //        }
            //        else
            //        {
            //            try
            //            {
            //                context.Response.Write(utils.SerializeObjectWithTime<grid<unit_model>>(bll.GetUnitList(u)));
            //            }
            //            catch (Exception ex)
            //            {
            //                throw ex;
            //            }
            //        }
            //        break;
            //    case "getallunit":
            //        try
            //        {
            //            context.Response.Write(utils.SerializeListWithTime<unit_model>(bll.GetAllUnit()));
            //        }
            //        catch (Exception ex)
            //        {
            //            throw ex;
            //        }
            //        break;
            //    case "addunit":
            //        try
            //        {
            //            u = utils.AutoWiredClass<unit_model>(request, u);
            //            u = bll.AddUnit(u);
            //            j.success = true;
            //            j.msg = "添加成功";
            //            j.obj = u;
            //        }
            //        catch (Exception ex)
            //        {
            //            j.msg = ex.ToString();
            //        }

            //        context.Response.Write(utils.SerializeObject<jsonresult>(j));
            //        break;
            //    case "updateunit":
            //        try
            //        {
            //            u = utils.AutoWiredClass<unit_model>(request, u);
            //            u = bll.UpdateUnit(u);
            //            j.success = true;
            //            j.msg = "修改成功";
            //            j.obj = u;
            //        }
            //        catch (Exception ex)
            //        {
            //            j.msg = ex.ToString();
            //        }

            //        context.Response.Write(utils.SerializeObject<jsonresult>(j));
            //        break;
            //    case "getoneunit":
            //        id = request["id"];
            //        try
            //        {
            //            context.Response.Write(utils.SerializeObjectWithTime<unit_model>(bll.GetById(id)));
            //        }
            //        catch (Exception ex)
            //        {
            //            throw ex;
            //        }
            //        break;
            //    case "getunitdepttree":
            //        try
            //        {
            //            context.Response.Write(utils.SerializeList<tree>(bll.GetUnitDeptTree()));
            //        }
            //        catch (Exception ex)
            //        {
            //            throw ex;
            //        }
            //        break;
            //    case "getunittree":
            //        try
            //        {
            //            context.Response.Write(utils.SerializeList<tree>(bll.GetUnitTree()));
            //        }
            //        catch (Exception ex)
            //        {
            //            throw ex;
            //        }
            //        break;
            //}
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