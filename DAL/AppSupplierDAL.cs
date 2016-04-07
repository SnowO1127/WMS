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
    public class AppSupplierDAL
    {
        public List<AppSupplier> GetList()
        {
            List<AppSupplier> list = new List<AppSupplier>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.AppSuppliers.ToList();
            }
            return list;
        }

        public int GetCount()
        {
            int count = 0;
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                count = ctx.AppSuppliers.Count();
            }
            return count;
        }

        public List<AppSupplier> GetListByPage(PageAppSupplier pasu)
        {
            List<AppSupplier> list = new List<AppSupplier>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.AppSuppliers.Where(x => x.DeleteMark.Equals(false)).ToList();

            }
            list = pasu.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, pasu.Sort)).Skip(pasu.Rows * (pasu.Page - 1)).Take(pasu.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, pasu.Sort)).Skip(pasu.Rows * (pasu.Page - 1)).Take(pasu.Rows).ToList();

            return list;
        }

        public void AddSupplier(AppSupplier ac)
        {
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                ctx.AppSuppliers.Add(ac);
                ctx.SaveChanges();
            }
        }

        public void UpdateSupplier(AppSupplier asu)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                AppSupplier nacu = new AppSupplier();
                nacu = ctx.AppSuppliers.Find(asu.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "DDate", "DUserID", "DUserName", "DeleteMark" };

                Utils.Copy(nacu, asu, ie);

                ctx.SaveChanges();
            }
        }

        public void DeleteSupplier(string supplierid)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                AppSupplier asu = new AppSupplier();
                asu = ctx.AppSuppliers.Find(supplierid);

                asu.DeleteMark = true;

                ctx.SaveChanges();
            }
        }

        public AppSupplier GetOneSupplier(string supplierid)
        {
            AppSupplier asu = new AppSupplier();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                asu = ctx.AppSuppliers.Find(supplierid);
            }
            return asu;
        }
    }
}
