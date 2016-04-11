using DAL;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SysMenuBLL
    {
        private readonly SysMenuDAL dal = new SysMenuDAL();
        public List<SysMenu> GetList()
        {
            return dal.GetList();
        }

        public List<SysMenu> GetIsMenuList()
        {
            return dal.GetIsMenuList();
        }

        public void AddMenu(SysMenu sm)
        {
            dal.AddMenu(sm);
        }

        public void UpdateMenu(SysMenu sm)
        {
            dal.UpdateMenu(sm);
        }

        public SysMenu GetOneMenu(string id)
        {
            return dal.GetOneMenu(id);
        }

        public List<Tree> GetIsMenuTree()
        {
            List<Tree> tlist = new List<Tree>();
            List<SysMenu> list = GetIsMenuList();
            foreach (SysMenu sm in list)
            {
                Tree t = new Tree() { id = sm.ID, text = sm.MenuName, pid = sm.ParentID, iconCls = sm.IconCls };
                tlist.Add(t);
            }
            return tlist;
        }

        public List<Tree> GetHeadTree()
        {
            List<Tree> tlist = new List<Tree>();

            Tree headtree = new Tree();
            headtree.id = Guid.NewGuid().ToString();
            headtree.text = "全部";

            tlist.Add(headtree);

            List<SysMenu> smlist = dal.GetList();
            if (smlist != null && smlist.Count > 0)
            {
                foreach (SysMenu sm in smlist)
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

        public List<Tree> GetEnabledHeadTree()
        {
            List<Tree> tlist = new List<Tree>();

            Tree headtree = new Tree();
            headtree.id = Guid.NewGuid().ToString();
            headtree.text = "全部";

            tlist.Add(headtree);

            List<SysMenu> smlist = dal.GetEnabledList();
            if (smlist != null && smlist.Count > 0)
            {
                foreach (SysMenu sm in smlist)
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


        public List<Tree> GetMenuTree()
        {
            List<Tree> tlist = new List<Tree>();
            List<SysMenu> smlist = dal.GetEnabledList();
            if (smlist != null && smlist.Count > 0)
            {
                foreach (SysMenu sm in smlist)
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

        public Grid<SysMenu> GetListByPage(PageSysMenu psm)
        {
            Grid<SysMenu> g = new Grid<SysMenu>();

            g.rows = dal.GetListByPage(psm);
            g.total = dal.GetCountByPage(psm);

            return g;
        }

        public void DeleteMenu(string id)
        {
            dal.DeleteMenu(id);
        }
    }
}
