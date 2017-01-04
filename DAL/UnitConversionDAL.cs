using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitConversionDAL
    {
        //public List<AppUnitConversion> GetList()
        //{
        //    List<AppUnitConversion> list = new List<AppUnitConversion>();
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        list = ctx.AppUnitConversions.ToList();
        //    }
        //    return list;
        //}

        //public int GetCount()
        //{
        //    int count = 0;
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        count = ctx.AppUnitConversions.Count();
        //    }
        //    return count;
        //}

        //public List<AppUnitConversion> GetListByPage(PageAppUnitConversion pauc)
        //{
        //    List<AppUnitConversion> list = new List<AppUnitConversion>();
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        list = ctx.AppUnitConversions.Where(x => !x.DeleteMark).ToList();

        //    }
        //    list = pauc.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, pauc.Sort)).Skip(pauc.Rows * (pauc.Page - 1)).Take(pauc.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, pauc.Sort)).Skip(pauc.Rows * (pauc.Page - 1)).Take(pauc.Rows).ToList();

        //    return list;
        //}

        //public void AddUnitConversion(AppUnitConversion auc)
        //{
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        ctx.AppUnitConversions.Add(auc);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void UpdateUnitConversion(AppUnitConversion auc)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        AppUnitConversion nauc = new AppUnitConversion();
        //        nauc = ctx.AppUnitConversions.Find(auc.ID);

        //        IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "DDate", "DUserID", "DUserName", "DeleteMark" };

        //        Utils.Copy(nauc, auc, ie);

        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteUnitConversion(string unitconversionid)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        AppUnitConversion auc = new AppUnitConversion();
        //        auc = ctx.AppUnitConversions.Find(unitconversionid);

        //        auc.DeleteMark = true;

        //        ctx.SaveChanges();
        //    }
        //}

        //public AppUnitConversion GetOneUnitConversion(string unitconversionid)
        //{
        //    AppUnitConversion ac = new AppUnitConversion();
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        ac = ctx.AppUnitConversions.Find(unitconversionid);
        //    }
        //    return ac;
        //}
    }
}
