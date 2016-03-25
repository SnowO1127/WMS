using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class SysRoleDAL
    {
        public List<SysRole> GetList()
        {
            List<SysRole> list = new List<SysRole>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.SysRoles.ToList();
            }
            return list;
        }

        public int GetCount()
        {
            int count = 0;
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                count = ctx.SysRoles.Count();
            }
            return count;
        }

        public List<SysRole> GetListByPage(PageSysRole psr)
        {
            List<SysRole> list = new List<SysRole>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = psr.Order == "desc" ? ctx.SysRoles.ToList().OrderByDescending(p => utils.GetPropertyValue(p, psr.Sort)).Skip(psr.Rows * (psr.Page - 1)).Take(psr.Rows).ToList() : ctx.SysRoles.ToList().OrderBy(p => utils.GetPropertyValue(p, psr.Sort)).Skip(psr.Rows * (psr.Page - 1)).Take(psr.Rows).ToList();
            }
            return list;
        }

        public List<SysRole> GetNonDeleteListByPage(PageSysRole psr)
        {
            List<SysRole> list = new List<SysRole>();

            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.SysRoles.Include(x => x.Users).Where(x => x.DeleteMark.Equals(false)).ToList();
            }

            list = psr.Order == "desc" ? list.OrderByDescending(p => utils.GetPropertyValue(p, psr.Sort)).Skip(psr.Rows * (psr.Page - 1)).Take(psr.Rows).ToList() : list.OrderBy(p => utils.GetPropertyValue(p, psr.Sort)).Skip(psr.Rows * (psr.Page - 1)).Take(psr.Rows).ToList();

            return list;
        }

        //public int GetCountByPage(PageSysUser psu)
        //{
        //    int count = 0;
        //    using (var ctx = new SysUserContext(Globe.ConnectionString))
        //    {
        //        count = psu.Order == "desc" ? ctx.SysUsers.ToList().OrderByDescending(p => utils.GetPropertyValue(p, psu.Sort)).Skip(psu.Rows * (psu.Page - 1)).Take(psu.Rows).Count() : ctx.SysUsers.ToList().OrderBy(p => utils.GetPropertyValue(p, psu.Sort)).Skip(psu.Rows * (psu.Page - 1)).Take(psu.Rows).Count();
        //    }
        //    return count;
        //}


        public void AddRole(SysRole sr)
        {
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                ctx.SysRoles.Add(sr);
                ctx.SaveChanges();
            }
        }

        public void UpdateRole(SysRole sr)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysRole nsr = new SysRole();
                nsr = ctx.SysRoles.Find(sr.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

                utils.Copy(nsr, sr, ie);

                nsr.UDate = DateTime.Now;

                ctx.SaveChanges();
            }
        }

        public void DeleteRole(string id)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysRole sr = new SysRole();
                sr = ctx.SysRoles.Find(id);

                sr.DeleteMark = true;

                ctx.SaveChanges();
            }
        }

        public SysRole GetOneRole(string id)
        {
            SysRole sr = new SysRole();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                sr = ctx.SysRoles.Include(x => x.Users).Where(x => x.ID.Equals(id)).FirstOrDefault();
            }
            return sr;
        }

        public List<SysRole> GetNoRoleList(string userid)
        {
            List<SysRole> list = new List<SysRole>();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                var query = from r in ctx.SysRoles
                            from u in r.Users
                            where u.ID != userid || u.ID == null
                            select r;
                list = query.ToList();
            }
            return list;

            //List<SysRole> haslist = new List<SysRole>();
            //List<SysRole> alllist = new List<SysRole>();
            //using (SysContext ctx = new SysContext(Globe.ConnectionString))
            //{
            //    var query = from r in ctx.SysRoles
            //                from u in r.Users
            //                where u.ID != userid
            //                select r;
            //    haslist = query.ToList();

            //    alllist = ctx.SysRoles.Include(x => x.Users).ToList();
            //}

            //foreach (var sr in haslist)
            //{
            //    alllist.Remove(sr);
            //}
            //return alllist;
        }

        public List<SysRole> GetHasRoleList(string userid)
        {
            List<SysRole> list = new List<SysRole>();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                var query = from r in ctx.SysRoles
                            from u in r.Users
                            where u.ID == userid
                            select r;
                list = query.ToList();
            }
            return list;
        }
    }
}
