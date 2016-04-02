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

        /// <summary>
        /// 得到未删除的个数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            int count = 0;
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                count = ctx.SysUsers.Where(x => x.DeleteMark.Equals(false)).Count();
            }
            return count;
        }

        /// <summary>
        /// 分页得到数据（未删除）
        /// </summary>
        /// <param name="psu"></param>
        /// <returns></returns>
        public List<SysUser> GetListByPage(PageSysUser psu)
        {
            List<SysUser> list = new List<SysUser>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.SysUsers.Where(x => x.DeleteMark.Equals(false)).ToList();

                list = psu.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, psu.Sort)).Skip(psu.Rows * (psu.Page - 1)).Take(psu.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, psu.Sort)).Skip(psu.Rows * (psu.Page - 1)).Take(psu.Rows).ToList();
            }
            return list;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="su"></param>
        public void AddUser(SysUser su)
        {
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                ctx.SysUsers.Add(su);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="list"></param>
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
                        su.Roles.Remove(sr); // 删除角色
                    }

                    List<string> filter = new List<string>();

                    foreach (SysRole sr in list)
                    {
                        filter.Add(sr.ID);
                    }

                    if (filter.Count > 0) su.Roles = ctx.SysRoles.Where(x => filter.Contains(x.ID)).ToList(); // 添加角色

                    ctx.SaveChanges();
                    tran.Complete();
                }
            }
        }

        /// <summary>
        /// 得到一个用户（不含关联关系）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysUser GetOneUser(string id)
        {
            SysUser su = new SysUser();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                su = ctx.SysUsers.Find(id);
            }

            return su;
        }

        /// <summary>
        /// 得到一个用户（包含关联关系）
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public SysUser GetOneUserWithMany(string userid)
        {
            SysUser su = new SysUser();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                su = ctx.SysUsers.Include(x => x.Menus).Include(x => x.Buttons).Include(x => x.Roles).Where(x => x.ID.Equals(userid)).FirstOrDefault();
            }
            return su;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="su"></param>
        public void UpdateUser(SysUser su)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysUser nsu = new SysUser();
                nsu = ctx.SysUsers.Find(su.ID);

                IEnumerable<string> ie = new List<string> { "ID", "PassWord", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

                Utils.Copy(nsu, su, ie);

                nsu.UDate = DateTime.Now;

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 快速检索
        /// </summary>
        /// <param name="q"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<SysUser> GetUserListBySpell(string q, int page, int rows, string sort, string order)
        {
            List<SysUser> list = new List<SysUser>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                var query = ctx.SysUsers.AsQueryable();
                if (!string.IsNullOrEmpty(q))
                {
                    query = query.Where(x => x.SpellQuery.Contains(q));
                }
                list = order == "desc" ? query.ToList().OrderByDescending(x => Utils.GetPropertyValue(x, sort)).Skip(rows * (page - 1)).Take(rows).ToList() : query.ToList().OrderBy(x => Utils.GetPropertyValue(x, sort)).Skip(rows * (page - 1)).Take(rows).ToList();
            }
            return list;
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="smlist"></param>
        /// <param name="sblist"></param>
        public void AddUserPermission(string userid, List<SysMenu> smlist, List<SysButton> sblist)
        {
            using (var tran = new TransactionScope())
            {
                using (var ctx = new SysContext(Globe.ConnectionString))
                {
                    SysUser su = ctx.SysUsers.Include(x => x.Menus).Include(x => x.Buttons).Where(x => x.ID.Equals(userid)).FirstOrDefault();

                    var menus = new List<SysMenu>();
                    menus.AddRange(su.Menus.Select(x => x));

                    foreach (var m in menus)
                    {
                        su.Menus.Remove(m);
                    }

                    var buttons = new List<SysButton>();
                    buttons.AddRange(su.Buttons.Select(x => x));

                    foreach (var b in buttons)
                    {
                        su.Buttons.Remove(b);
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

                    if (smfilter.Count > 0) su.Menus = ctx.SysMenus.Where(x => smfilter.Contains(x.ID)).ToList();
                    if (sbfilter.Count > 0) su.Buttons = ctx.SysButtons.Where(x => sbfilter.Contains(x.ID)).ToList();

                    ctx.SaveChanges();
                    tran.Complete();
                }
            }
        }

        /// <summary>
        /// 删除用户（伪删除）
        /// </summary>
        /// <param name="userid"></param>
        public void DeleteUser(string userid)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysUser su = new SysUser();
                su = ctx.SysUsers.Find(userid);

                su.DeleteMark = true;

                ctx.SaveChanges();
            }
        }

        public void ResetPassWord(string userid, string password)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysUser su = new SysUser();
                su = ctx.SysUsers.Find(userid);

                su.PassWord = password;

                ctx.SaveChanges();
            }
        }

        public SysUser GetOneUserByLoginName(string loginname)
        {
            SysUser su = new SysUser();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                su = ctx.SysUsers.Where(x => x.LoginName.Equals(loginname)).FirstOrDefault();
            }

            return su;
        }

        public SysUser GetOneUserByLogin(string loginname, string password)
        {
            SysUser su = new SysUser();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                su = ctx.SysUsers.Where(x => x.LoginName.Equals(loginname) && x.PassWord.Equals(password)).FirstOrDefault();
            }

            return su;
        }
    }
}
