using IDAL;
using Model;
using DalFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BLL
{
    public class SysMenuBLL
    {
        private readonly ISysMenuDAL sysMenuDal = DataAccess.CreateMenu();
        private readonly SysUserBLL sysUserBll = new SysUserBLL();

        private List<Tree> tlist;
        private List<SysMenu> mlist;

        //public List<SysMenu> GetList()
        //{
        //    return dal.GetList();
        //}

        public List<SysMenu> GetIsMenuList()
        {
            string where = "IsMenu=1";
            return sysMenuDal.GetList(where);
        }

        //public void AddMenu(SysMenu sm)
        //{
        //    dal.AddMenu(sm);
        //}

        //public void UpdateMenu(SysMenu sm)
        //{
        //    dal.UpdateMenu(sm);
        //}

        //public SysMenu GetOneMenu(string id)
        //{
        //    return dal.GetOneMenu(id);
        //}

        public List<Tree> GetIsMenuTree()
        {
            tlist = new List<Tree>();
            mlist = GetIsMenuList();
            foreach (SysMenu sm in mlist)
            {
                Tree t = new Tree() { id = sm.ID, text = sm.MenuName, pid = sm.ParentID, iconCls = sm.IconCls };
                tlist.Add(t);
            }
            return tlist;
        }

        public List<Tree> GetHeadTree()
        {
            tlist = new List<Tree>();

            Tree headtree = new Tree();
            headtree.id = Guid.NewGuid().ToString();
            headtree.text = "全部";

            tlist.Add(headtree);

            mlist = sysMenuDal.GetList();
            if (mlist != null && mlist.Count > 0)
            {
                foreach (SysMenu sm in mlist)
                {
                    Tree t = new Tree() { id = sm.ID, text = sm.MenuName, pid = string.IsNullOrEmpty(sm.ParentID) ? headtree.id : sm.ParentID, iconCls = sm.IconCls };
                    Dictionary<String, Object> attributes = new Dictionary<String, Object>();
                    attributes.Add("url", sm.MenuUrl);
                    attributes.Add("ismenu", sm.IsMenu);
                    t.attributes = attributes;
                    tlist.Add(t);
                }
            }
            return tlist;
        }

        //public List<Tree> GetEnabledHeadTree()
        //{
        //    List<Tree> tlist = new List<Tree>();

        //    Tree headtree = new Tree();
        //    headtree.id = Guid.NewGuid().ToString();
        //    headtree.text = "全部";

        //    tlist.Add(headtree);

        //    List<SysMenu> smlist = dal.GetEnabledList();
        //    if (smlist != null && smlist.Count > 0)
        //    {
        //        foreach (SysMenu sm in smlist)
        //        {
        //            Tree t = new Tree() { id = sm.ID, text = sm.MenuName, pid = string.IsNullOrEmpty(sm.ParentID) ? headtree.id : sm.ParentID, iconCls = sm.IconCls };
        //            Dictionary<String, Object> attributes = new Dictionary<String, Object>();
        //            attributes.Add("url", sm.MenuUrl);
        //            attributes.Add("ismenu", sm.IsMenu);
        //            t.attributes = attributes;
        //            tlist.Add(t);
        //        }
        //    }
        //    return tlist;
        //}

        public List<SysMenu> GetEnabledList()
        {
            string where = "Enabled = 1";

            return sysMenuDal.GetList(where);
        }

        public List<Tree> GetEnabledMenuTree()
        {
            tlist = new List<Tree>();

            mlist = GetEnabledList();

            if (mlist != null && mlist.Count > 0)
            {
                foreach (SysMenu sm in mlist)
                {
                    Tree t = new Tree() { id = sm.ID, text = sm.MenuName, pid = sm.ParentID, iconCls = sm.IconCls };
                    Dictionary<String, Object> attributes = new Dictionary<String, Object>();
                    attributes.Add("url", sm.MenuUrl);
                    t.attributes = attributes;
                    tlist.Add(t);
                }
            }
            return tlist;
        }

        public Grid<SysMenu> GetListByPage(int pageIndex, int PageSize, string sortName, string sortOrder, string parentID)
        {
            Grid<SysMenu> g = new Grid<SysMenu>();

            string rwhere = string.Empty;
            string twhere = string.Empty;

            if (!string.IsNullOrEmpty(parentID))
            {
                rwhere = "parentID='" + parentID + "' order by " + sortName + " " + sortOrder + "";
                twhere = "parentID='" + parentID + "'";
            }
            else
            {
                rwhere = "parentID is null order by " + sortName + " " + sortOrder + "";
                twhere = "parentID is null";
            }

            g.rows = sysMenuDal.GetList(pageIndex, PageSize, rwhere);
            g.total = sysMenuDal.GetCount(twhere);

            return g;
        }

        //public void DeleteMenu(string id)
        //{
        //    dal.DeleteMenu(id);
        //}

        /// <summary>
        /// 得到权限菜单
        /// </summary>
        /// <param name="su"></param>
        /// <returns></returns>
        public List<SysMenu> GetPermissionMenus()
        {
            SysUser sysUser = sysUserBll.GetCurrentUser();

            mlist = new List<SysMenu>();

            if (sysUser.IsAdmin)
            {
                string where = "Enabled = 1";
                mlist = sysMenuDal.GetList(where);
            }
            else
            {
                //smlist = su.Menus;

                //foreach (var sr in su.Roles)
                //{
                //    foreach (var sm in sr.Menus)
                //    {
                //        if (!smlist.Contains(sm))
                //        {
                //            smlist.Add(sm);
                //        }
                //    }
                //}
            }
            return mlist;
        }

        /// <summary>
        /// 生成菜单树
        /// </summary>
        /// <param name="smlist"></param>
        /// <returns></returns>
        public List<Tree> GetPermissionMenuTree()
        {
            tlist = new List<Tree>();

            mlist = GetPermissionMenus();

            if (mlist != null && mlist.Count > 0)
            {
                foreach (SysMenu sm in mlist)
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

        ///// <summary>
        ///// 得到权限菜单
        ///// </summary>
        ///// <param name="su"></param>
        ///// <returns></returns>
        //public List<SysMenu> GetEnabledPessionMenus(string userid)
        //{
        //    SysUser su = sudal.GetOneUserWithMany(userid);

        //    List<SysMenu> smlist = new List<SysMenu>();

        //    if (su.IsAdmin)
        //    {
        //        smlist = smdal.GetEnabledList();
        //    }
        //    else
        //    {
        //        smlist = su.Menus.Where(x => x.Enabled).ToList();

        //        foreach (var sr in su.Roles)
        //        {
        //            foreach (var sm in sr.Menus)
        //            {
        //                if (!smlist.Contains(sm))
        //                {
        //                    smlist.Add(sm);
        //                }
        //            }
        //        }
        //    }
        //    return smlist;
        //}
    }
}
