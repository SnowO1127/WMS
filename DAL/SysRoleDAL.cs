using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Transactions;

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
                list = psr.Order == "desc" ? ctx.SysRoles.ToList().OrderByDescending(p => Utils.GetPropertyValue(p, psr.Sort)).Skip(psr.Rows * (psr.Page - 1)).Take(psr.Rows).ToList() : ctx.SysRoles.ToList().OrderBy(p => Utils.GetPropertyValue(p, psr.Sort)).Skip(psr.Rows * (psr.Page - 1)).Take(psr.Rows).ToList();
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

            list = psr.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, psr.Sort)).Skip(psr.Rows * (psr.Page - 1)).Take(psr.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, psr.Sort)).Skip(psr.Rows * (psr.Page - 1)).Take(psr.Rows).ToList();

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

                Utils.Copy(nsr, sr, ie);

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
            List<SysRole> haslist = new List<SysRole>();
            List<SysRole> alllist = new List<SysRole>();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                var query = from r in ctx.SysRoles
                            from u in r.Users
                            where u.ID == userid
                            select r;
                haslist = query.ToList();

                alllist = ctx.SysRoles.Include(x => x.Users).ToList();

                foreach (var sr in haslist)
                {
                    alllist.Remove(sr);
                }
            }
            return alllist;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public SysRole GetOneRoleWithMany(string roleid)
        {
            SysRole sr = new SysRole();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                sr = ctx.SysRoles.Include(x => x.Users).Include(x => x.Menus).Include(x => x.Buttons).Where(x => x.ID.Equals(roleid)).FirstOrDefault();
            }
            return sr;
        }

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="smlist"></param>
        /// <param name="sblist"></param>
        public void AddRolePermission(string roleid, List<SysMenu> smlist, List<SysButton> sblist)
        {
            using (var tran = new TransactionScope())
            {
                using (var ctx = new SysContext(Globe.ConnectionString))
                {
                    SysRole sr = ctx.SysRoles.Include(x => x.Menus).Include(x => x.Buttons).Where(x => x.ID.Equals(roleid)).FirstOrDefault();

                    var menus = new List<SysMenu>();
                    menus.AddRange(sr.Menus.Select(x => x));

                    foreach (var m in menus)
                    {
                        sr.Menus.Remove(m);
                    }

                    var buttons = new List<SysButton>();
                    buttons.AddRange(sr.Buttons.Select(x => x));

                    foreach (var b in buttons)
                    {
                        sr.Buttons.Remove(b);
                    }

                    List<string> smfilter = new List<string>();

                    foreach (SysMenu sm in smlist)
                    {
                        smfilter.Add(sm.ID);
                    }

                    List<string> sbfilter = new List<string>();

                    foreach (SysButton sb in sblist)
                    {
                        sbfilter.Add(sb.ID);
                    }

                    if (smfilter.Count > 0) sr.Menus = ctx.SysMenus.Where(x => smfilter.Contains(x.ID)).ToList();
                    if (sbfilter.Count > 0) sr.Buttons = ctx.SysButtons.Where(x => sbfilter.Contains(x.ID)).ToList();

                    ctx.SaveChanges();
                    tran.Complete();
                }
            }
        }
    }
}
