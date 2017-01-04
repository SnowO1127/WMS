using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class MaterialDAL
    {
        //public List<AppMaterial> GetList()
        //{
        //    List<AppMaterial> list = new List<AppMaterial>();
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        list = ctx.AppMaterials.ToList();
        //    }
        //    return list;
        //}

        //public int GetCount()
        //{
        //    int count = 0;
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        count = ctx.AppMaterials.Count();
        //    }
        //    return count;
        //}

        //public List<AppMaterial> GetListByPage(PageAppMaterial pam)
        //{
        //    List<AppMaterial> list = new List<AppMaterial>();

        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        list = ctx.AppMaterials.Include(x => x.UnitConversion).Include(x => x.MaterialCategory).Where(x => !x.DeleteMark).ToList();
        //    }

        //    list = pam.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, pam.Sort)).Skip(pam.Rows * (pam.Page - 1)).Take(pam.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, pam.Sort)).Skip(pam.Rows * (pam.Page - 1)).Take(pam.Rows).ToList();

        //    return list;
        //}

        //public void AddMaterial(AppMaterial am)
        //{
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        am.MaterialCategory = ctx.AppMaterialCategorys.Find(am.CategoryID);
        //        am.UnitConversion = ctx.AppUnitConversions.Find(am.UnitConversionID);

        //        ctx.AppMaterials.Add(am);

        //        ctx.SaveChanges();
        //    }
        //}

        //public void UpdateMaterial(AppMaterial am)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        AppMaterial nam = new AppMaterial();
        //        nam = ctx.AppMaterials.Find(am.ID);

        //        IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "DDate", "DUserID", "DUserName", "DeleteMark" };

        //        Utils.Copy(nam, am, ie);

        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteMaterial(string materialid)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        AppMaterial am = new AppMaterial();
        //        am = ctx.AppMaterials.Find(materialid);

        //        am.DeleteMark = true;

        //        ctx.SaveChanges();
        //    }
        //}

        //public AppMaterial GetOneMaterial(string materialid)
        //{
        //    AppMaterial am = new AppMaterial();
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        am = ctx.AppMaterials.Include(x => x.MaterialCategory).Include(x => x.UnitConversion).FirstOrDefault(x => x.ID.Equals(materialid));
        //    }
        //    return am;
        //}
    }
}
