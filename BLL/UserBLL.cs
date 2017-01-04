using Common;
using DAL;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class UserBLL
    {
        private readonly UserDAL sudal = new UserDAL();
        private readonly RoleDAL srdal = new RoleDAL();
        private readonly MenuDAL smdal = new MenuDAL();
        /// <summary>
        /// 得到所有用户
        /// </summary>
        /// <returns></returns>
        public Grid<SysUser> GetList()
        {
            Grid<SysUser> g = new Grid<SysUser>();

            g.total = sudal.GetCount();
            g.rows = sudal.GetList();
            return g;
        }

        /// <summary>
        /// 分页得到用户
        /// </summary>
        /// <param name="psu"></param>
        /// <returns></returns>
        public Grid<SysUser> GetListByPage(PageSysUser psu)
        {
            Grid<SysUser> g = new Grid<SysUser>();

            g.total = sudal.GetCount();
            g.rows = sudal.GetListByPage(psu);
            return g;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="su"></param>
        public void AddUser(SysUser su)
        {
            sudal.AddUser(su);
        }

        public void AddRoles(string userid, List<SysRole> list)
        {
            sudal.AddRoles(userid, list);
        }

        public SysUser GetOneUser(string id)
        {
            return sudal.GetOneUser(id);
        }

        public void UpdateUser(SysUser su)
        {
            sudal.UpdateUser(su);
        }

        public List<SysUser> GetUserListBySpell(string q, int page, int rows, string sort, string order)
        {
            return sudal.GetUserListBySpell(q, page, rows, sort, order);
        }

        public void DeleteUser(string userid)
        {
            sudal.DeleteUser(userid);
        }

        public void ResetPassWord(string userid, string password)
        {
            sudal.ResetPassWord(userid, password);
        }

        public SysUser GetOneUserByLoginName(string loginname)
        {
            return sudal.GetOneUserByLoginName(loginname);
        }

        public SysUser GetOneUserByLogin(string loginname, string password)
        {
            return sudal.GetOneUserByLogin(loginname, password);
        }

        /// <summary>
        /// 根据用户生成菜单树
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Tree> GetMenuTreeByUser(string userid)
        {
            return CreateTreeList(GetEnabledPessionMenus(userid));
        }

        /// <summary>
        /// 得到当前登录用户
        /// </summary>
        /// <returns></returns>
        public SysUser GetCurrentUser()
        {
            SysUser su = null;
            if (SessionHelper.GetSession(Globe.UserSessionName) != null)
            {
                string userid = SessionHelper.GetSession(Globe.UserSessionName).ToString();
                if (!string.IsNullOrEmpty(userid))
                {
                    su = sudal.GetOneUser(userid);
                }
            }
            return su;
        }

        /// <summary>
        /// 得到权限菜单
        /// </summary>
        /// <param name="su"></param>
        /// <returns></returns>
        public List<SysMenu> GetEnabledPessionMenus(string userid)
        {
            SysUser su = sudal.GetOneUserWithMany(userid);

            List<SysMenu> smlist = new List<SysMenu>();

            if (su.IsAdmin)
            {
                smlist = smdal.GetEnabledList();
            }
            else
            {
                smlist = su.Menus.Where(x => x.Enabled).ToList();

                foreach (var sr in su.Roles)
                {
                    foreach (var sm in sr.Menus)
                    {
                        if (!smlist.Contains(sm))
                        {
                            smlist.Add(sm);
                        }
                    }
                }
            }
            return smlist;
        }

        /// <summary>
        /// 得到权限菜单
        /// </summary>
        /// <param name="su"></param>
        /// <returns></returns>
        public List<SysMenu> GetPessionMenus(string userid)
        {
            SysUser su = sudal.GetOneUserWithMany(userid);

            List<SysMenu> smlist = new List<SysMenu>();

            if (su.IsAdmin)
            {
                smlist = smdal.GetList();
            }
            else
            {
                smlist = su.Menus;

                foreach (var sr in su.Roles)
                {
                    foreach (var sm in sr.Menus)
                    {
                        if (!smlist.Contains(sm))
                        {
                            smlist.Add(sm);
                        }
                    }
                }
            }
            return smlist;
        }

        /// <summary>
        /// 生成菜单树
        /// </summary>
        /// <param name="smlist"></param>
        /// <returns></returns>
        public List<Tree> CreateTreeList(List<SysMenu> smlist)
        {
            List<Tree> tlist = new List<Tree>();
            if (smlist != null && smlist.Count > 0)
            {
                foreach (SysMenu sm in smlist)
                {
                    Tree t = new Tree() { id = sm.ID, text = sm.MenuName, pid = sm.ParentID, iconCls = sm.IconCls, order = sm.OrderID };
                    Dictionary<String, Object> attributes = new Dictionary<String, Object>();
                    attributes.Add("url", sm.MenuUrl);
                    t.attributes = attributes;
                    tlist.Add(t);
                }
            }
            return tlist.OrderBy(x => x.order).ToList();
        }
    }
}
