using Common;
using Model;
using PageModel;
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
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.SysMenus.Where(x => x.Enabled.Equals(true) && x.DeleteMark.Equals(false)).OrderBy(x => x.OrderID).ToList();
            }
            return list;
        }

        public List<SysMenu> GetListByPage(PageSysMenu psm)
        {
            List<SysMenu> list = new List<SysMenu>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                var query = ctx.SysMenus.Where(x => x.DeleteMark.Equals(false));
                if (!string.IsNullOrEmpty(psm.ID))
                {
                    query = query.Where(x => x.ParentID.Equals(psm.ID));
                }
                else
                {
                    query = query.Where(x => x.ParentID.Equals(null));
                }

                if (!string.IsNullOrEmpty(psm.MenuName))
                {
                    query = query.Where(x => x.MenuName.Contains(psm.MenuName));
                }

                list = query.ToList();

                list = psm.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, psm.Sort)).Skip(psm.Rows * (psm.Page - 1)).Take(psm.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, psm.Sort)).Skip(psm.Rows * (psm.Page - 1)).Take(psm.Rows).ToList();
            }
            return list;
        }

        public List<SysMenu> GetIsMenuList()
        {
            List<SysMenu> list = new List<SysMenu>();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.SysMenus.Where(x => x.IsMenu.Equals(true) && x.Enabled.Equals(true) && x.DeleteMark.Equals(false)).OrderBy(x => x.OrderID).ToList();
            }
            return list;
        }

        public void AddMenu(SysMenu sm)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
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
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysMenu nsm = new SysMenu();
                nsm = ctx.SysMenus.Find(sm.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

                Utils.Copy(nsm, sm, ie);

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
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                sm = ctx.SysMenus.Find(id);
            }

            return sm;
        }

        public void DeleteMenu(string id)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysMenu sm = new SysMenu();
                sm = ctx.SysMenus.Find(id);

                sm.DeleteMark = true;

                ctx.SaveChanges();
            }
        }
    }
}
