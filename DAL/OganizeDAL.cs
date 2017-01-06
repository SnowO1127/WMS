using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OganizeDAL
    {
        ///// <summary>
        ///// 得到未删除所有组织机构
        ///// </summary>
        ///// <returns></returns>
        //public List<SysOganize> GetList()
        //{
        //    List<SysOganize> list = new List<SysOganize>();
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        list = ctx.SysOganizes.Where(x => x.DeleteMark.Equals(false)).OrderBy(x => x.OrderID).ToList();
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// 分页得到未删除的组织机构
        ///// </summary>
        ///// <param name="pso"></param>
        ///// <returns></returns>
        //public List<SysOganize> GetListByPage(PageSysOganize pso)
        //{
        //    List<SysOganize> list = new List<SysOganize>();
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        var query = ctx.SysOganizes.Where(x => x.DeleteMark.Equals(false));

        //        if (!string.IsNullOrEmpty(pso.ID))
        //        {
        //            query = query.Where(x => x.ParentID.Equals(pso.ID));
        //        }
        //        else
        //        {
        //            query = query.Where(x => x.ParentID.Equals(null));
        //        }

        //        if (!string.IsNullOrEmpty(pso.Name))
        //        {
        //            query = query.Where(x => x.Name.Contains(pso.Name));
        //        }
        //        list = query.OrderBy(x => x.OrderID).ToList();

        //        list = pso.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, pso.Sort)).Skip(pso.Rows * (pso.Page - 1)).Take(pso.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, pso.Sort)).Skip(pso.Rows * (pso.Page - 1)).Take(pso.Rows).ToList();
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// 增加组织机构
        ///// </summary>
        ///// <param name="so"></param>
        //public void AddOganize(SysOganize so)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        if (!string.IsNullOrEmpty(so.ParentID))
        //        {
        //            so.PSysOganize = ctx.SysOganizes.Find(so.ParentID);
        //        }
        //        else
        //        {
        //            so.ParentID = null;
        //        }

        //        ctx.SysOganizes.Add(so);
        //        ctx.SaveChanges();
        //    }
        //}

        ///// <summary>
        ///// 更新组织机构
        ///// </summary>
        ///// <param name="so"></param>
        //public void UpdateOganize(SysOganize so)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        SysOganize nso = new SysOganize();
        //        nso = ctx.SysOganizes.Find(so.ID);

        //        IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

        //        Utils.Copy(nso, so, ie);

        //        nso.UDate = DateTime.Now;

        //        if (!string.IsNullOrEmpty(nso.ParentID))
        //        {
        //            nso.PSysOganize = ctx.SysOganizes.Find(nso.ParentID);
        //        }
        //        else
        //        {
        //            nso.ParentID = null;
        //        }

        //        ctx.SaveChanges();
        //    }
        //}

        ///// <summary>
        ///// 得到一个组织机构
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public SysOganize GetOneOganize(string id)
        //{
        //    SysOganize sm = new SysOganize();
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        sm = ctx.SysOganizes.Find(id);
        //    }

        //    return sm;
        //}

        ///// <summary>
        ///// 伪删除
        ///// </summary>
        ///// <param name="oganizeid"></param>
        //public void DeleteOganize(string oganizeid)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        SysOganize so = new SysOganize();
        //        so = ctx.SysOganizes.Find(oganizeid);

        //        so.DeleteMark = true;

        //        ctx.SaveChanges();
        //    }
        //}
    }
}
