﻿using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysButtonDAL
    {
        public List<SysButton> GetListByPage(PageSysButton psb)
        {
            List<SysButton> list = new List<SysButton>();

            if (!string.IsNullOrEmpty(psb.MenuID))
            {
                using (var ctx = new SysContext(Globe.ConnectionString))
                {
                    var query = ctx.SysButtons.Where(x => x.MenuID.Equals(psb.MenuID) && x.DeleteMark.Equals(false));
                    list = query.ToList();

                    list = psb.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, psb.Sort)).Skip(psb.Rows * (psb.Page - 1)).Take(psb.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, psb.Sort)).Skip(psb.Rows * (psb.Page - 1)).Take(psb.Rows).ToList();
                }
            }
            return list;
        }

        public void AddButton(SysButton sb)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                sb.SysMenu = ctx.SysMenus.Find(sb.MenuID);

                ctx.SysButtons.Add(sb);

                ctx.SaveChanges();
            }
        }

        public void UpdateButton(SysButton sb)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysButton nsb = new SysButton();

                nsb = ctx.SysButtons.Find(sb.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

                Utils.Copy(nsb, sb, ie);

                nsb.UDate = DateTime.Now;

                ctx.SaveChanges();
            }
        }

        public SysButton GetOneButton(string id)
        {
            SysButton sb = new SysButton();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                sb = ctx.SysButtons.Find(id);
            }

            return sb;
        }

        public void DeleteButton(string id)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysButton sb = new SysButton();
                sb = ctx.SysButtons.Find(id);

                sb.DeleteMark = true;

                ctx.SaveChanges();
            }
        }
    }
}
