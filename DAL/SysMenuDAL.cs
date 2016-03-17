using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysMenuDAL
    {
        public List<SysMenu> GetList()
        {
            List<SysMenu> list = new List<SysMenu>();
            using (SysMenuContext ctx = new SysMenuContext(Globe.ConnectionString))
            {
                list = ctx.SysMenus.ToList();
            }
            return list;
        }

        public List<SysMenu> GetIsMenuList()
        {
            List<SysMenu> list = new List<SysMenu>();
            using (SysMenuContext ctx = new SysMenuContext(Globe.ConnectionString))
            {
                list = ctx.SysMenus.Where(x => x.IsMenu.Equals(true)).ToList();
            }
            return list;
        }

        public void AddMenu(SysMenu sm)
        {
            using (SysMenuContext ctx = new SysMenuContext(Globe.ConnectionString))
            {
                if (!string.IsNullOrEmpty(sm.ParentID))
                {
                    sm.PSysMenu = ctx.SysMenus.Find(sm.ParentID);
                }
                else
                {
                    sm.ParentID = null;
                }

                ctx.SysMenus.Add(sm);
                ctx.SaveChanges();
            }
        }

        public void UpdateMenu(SysMenu sm)
        {
            using (SysMenuContext ctx = new SysMenuContext(Globe.ConnectionString))
            {
                SysMenu nsm = new SysMenu();
                nsm = ctx.SysMenus.Find(sm.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

                utils.Copy(nsm, sm, ie);

                nsm.UDate = DateTime.Now;

                if (!string.IsNullOrEmpty(nsm.ParentID))
                {
                    nsm.PSysMenu = ctx.SysMenus.Find(nsm.ParentID);
                }
                else
                {
                    nsm.ParentID = null;
                }

                ctx.SaveChanges();
            }
        }

        public SysMenu GetOneMenu(string id)
        {
            SysMenu sm = new SysMenu();
            using (SysMenuContext ctx = new SysMenuContext(Globe.ConnectionString))
            {
                sm = ctx.SysMenus.Find(id);
            }

            return sm;
        }
    }
}
