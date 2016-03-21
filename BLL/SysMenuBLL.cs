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

        public List<Tree> GetMenuTree()
        {
            List<Tree> tlist = new List<Tree>();
            List<SysMenu> smlist = dal.GetList();
            if (smlist != null && smlist.Count > 0)
            {
                foreach (SysMenu sm in smlist)
                {
                    Tree t = new Tree() { id = sm.ID, text = sm.MenuName, pid = sm.ParentID, iconCls = sm.IconCls };
                    Dictionary<String, Object> attributes = new Dictionary<String, Object>();
                    attributes.Add("url", sm.Url);
                    t.attributes = attributes;
                    tlist.Add(t);
                }
            }
            return tlist;
        }

        public object GetListByPage(PageSysMenu psm)
        {
            return dal.GetListByPage(psm);
        }
    }
}
