using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppMaterialCategoryDAL
    {
        public List<AppMaterialCategory> GetList()
        {
            List<AppMaterialCategory> list = new List<AppMaterialCategory>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.AppMaterialCategorys.ToList();
            }
            return list;
        }

        public int GetCount()
        {
            int count = 0;
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                count = ctx.AppMaterialCategorys.Count();
            }
            return count;
        }

        public List<AppMaterialCategory> GetListByPage(PageAppMaterialCategory pamc)
        {
            List<AppMaterialCategory> list = new List<AppMaterialCategory>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.AppMaterialCategorys.Where(x => x.DeleteMark.Equals(false)).ToList();

            }
            list = pamc.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, pamc.Sort)).Skip(pamc.Rows * (pamc.Page - 1)).Take(pamc.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, pamc.Sort)).Skip(pamc.Rows * (pamc.Page - 1)).Take(pamc.Rows).ToList();

            return list;
        }

        public void AddMaterialCategory(AppMaterialCategory ac)
        {
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                ctx.AppMaterialCategorys.Add(ac);
                ctx.SaveChanges();
            }
        }

        public void UpdateMaterialCategory(AppMaterialCategory amc)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                AppMaterialCategory namc = new AppMaterialCategory();
                namc = ctx.AppMaterialCategorys.Find(amc.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "DDate", "DUserID", "DUserName", "DeleteMark" };

                Utils.Copy(namc, amc, ie);

                ctx.SaveChanges();
            }
        }

        public void DeleteMaterialCategory(string materialcategoryid)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                AppMaterialCategory amc = new AppMaterialCategory();
                amc = ctx.AppMaterialCategorys.Find(materialcategoryid);

                amc.DeleteMark = true;

                ctx.SaveChanges();
            }
        }

        public AppMaterialCategory GetOneMaterialCategory(string materialcategoryid)
        {
            AppMaterialCategory amc = new AppMaterialCategory();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                amc = ctx.AppMaterialCategorys.Find(materialcategoryid);
            }
            return amc;
        }
    }
}
