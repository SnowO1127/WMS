using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class SysUserDAL
    {
        public List<SysUser> GetList()
        {
            List<SysUser> list = new List<SysUser>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.SysUsers.ToList();
            }
            return list;
        }

        public int GetCount()
        {
            int count = 0;
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                count = ctx.SysUsers.Count();
            }
            return count;
        }

        public List<SysUser> GetListByPage(PageSysUser psu)
        {
            List<SysUser> list = new List<SysUser>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = psu.Order == "desc" ? ctx.SysUsers.Include(x => x.Roles).ToList().OrderByDescending(p => utils.GetPropertyValue(p, psu.Sort)).Skip(psu.Rows * (psu.Page - 1)).Take(psu.Rows).ToList() : ctx.SysUsers.Include(x => x.Roles).ToList().OrderBy(p => utils.GetPropertyValue(p, psu.Sort)).Skip(psu.Rows * (psu.Page - 1)).Take(psu.Rows).ToList();
            }
            return list;
        }

        public int GetCountByPage(PageSysUser psu)
        {
            int count = 0;
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                count = psu.Order == "desc" ? ctx.SysUsers.ToList().OrderByDescending(p => utils.GetPropertyValue(p, psu.Sort)).Skip(psu.Rows * (psu.Page - 1)).Take(psu.Rows).Count() : ctx.SysUsers.ToList().OrderBy(p => utils.GetPropertyValue(p, psu.Sort)).Skip(psu.Rows * (psu.Page - 1)).Take(psu.Rows).Count();
            }
            return count;
        }

        public void AddUser(SysUser su)
        {
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                ctx.SysUsers.Add(su);
                ctx.SaveChanges();
            }
        }
    }
}
