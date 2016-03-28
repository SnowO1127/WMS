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
    public class SysOganizeDAL
    {
        public List<SysOganize> GetList()
        {
            List<SysOganize> list = new List<SysOganize>();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.SysOganizes.ToList();
            }
            return list;
        }

        public List<SysOganize> GetListByPage(PageSysOganize pso)
        {
            List<SysOganize> list = new List<SysOganize>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                var query = ctx.SysOganizes.AsQueryable();
                if (!string.IsNullOrEmpty(pso.ID))
                {
                    query = query.Where(x => x.ParentID.Equals(pso.ID));
                }
                if (!string.IsNullOrEmpty(pso.Name))
                {
                    query = query.Where(x => x.Name.Contains(pso.Name));
                }
                list = query.ToList();

                list = pso.Order == "desc" ? list.OrderByDescending(p => utils.GetPropertyValue(p, pso.Sort)).Skip(pso.Rows * (pso.Page - 1)).Take(pso.Rows).ToList() : list.OrderBy(p => utils.GetPropertyValue(p, pso.Sort)).Skip(pso.Rows * (pso.Page - 1)).Take(pso.Rows).ToList();
            }
            return list;
        }

        public void AddOganize(SysOganize so)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                if (!string.IsNullOrEmpty(so.ParentID))
                {
                    so.PSysOganize = ctx.SysOganizes.Find(so.ParentID);
                }
                else
                {
                    so.ParentID = null;
                }

                ctx.SysOganizes.Add(so);
                ctx.SaveChanges();
            }
        }

        public void UpdateOganize(SysOganize so)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysOganize nso = new SysOganize();
                nso = ctx.SysOganizes.Find(so.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

                utils.Copy(nso, so, ie);

                nso.UDate = DateTime.Now;

                if (!string.IsNullOrEmpty(nso.ParentID))
                {
                    nso.PSysOganize = ctx.SysOganizes.Find(nso.ParentID);
                }
                else
                {
                    nso.ParentID = null;
                }

                ctx.SaveChanges();
            }
        }

        public SysOganize GetOneOganize(string id)
        {
            SysOganize sm = new SysOganize();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                sm = ctx.SysOganizes.Find(id);
            }

            return sm;
        }
    }
}
