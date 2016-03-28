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
using System.Transactions;

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

        public void AddRoles(string userid, List<SysRole> list)
        {
            using (var tran = new TransactionScope())
            {
                using (var ctx = new SysContext(Globe.ConnectionString))
                {
                    SysUser su = ctx.SysUsers.Include(x => x.Roles).Where(x => x.ID.Equals(userid)).FirstOrDefault();

                    var roles = new List<SysRole>();
                    roles.AddRange(su.Roles.Select(x => x));

                    foreach (var sr in roles)
                    {
                        su.Roles.Remove(sr);
                    }

                    List<string> filter = new List<string>();

                    foreach (SysRole sr in list)
                    {
                        filter.Add(sr.ID);
                    }

                    if (filter.Count > 0) su.Roles = ctx.SysRoles.Where(x => filter.Contains(x.ID)).ToList();

                    ctx.SaveChanges();
                    tran.Complete();
                }
            }

        }

        public SysUser GetOneUser(string id)
        {
            SysUser su = new SysUser();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                su = ctx.SysUsers.Find(id);
            }

            return su;
        }
    }
}
