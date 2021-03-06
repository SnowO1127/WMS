﻿using CYQ.Data;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysMenuDAL : ISysMenuDAL
    {
        private readonly string tableName = "Sys_Menu";
        private SysMenu sysMenu;
        private List<SysMenu> list;
        private long count = 0;

        public SysMenu GetObjectByCondition(string where)
        {
            sysMenu = new SysMenu();
            using (MAction action = new MAction(tableName))
            {
                if (action.Fill(where))
                {
                    sysMenu = action.Data.ToEntity<SysMenu>();
                }
            }
            return sysMenu;
        }

        public void Insert(SysMenu menu)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(menu);
                action.Insert();
            }
        }

        public void Update(SysMenu menu)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(menu);
                action.Update();
            }
        }
        public List<SysMenu> GetList()
        {
            list = new List<SysMenu>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select().ToList<SysMenu>();
            }

            return list;
        }

        public long GetCount()
        {
            using (MAction action = new MAction(tableName))
            {
                count = action.GetCount();
            }

            return count;
        }

        public long GetCount(string where)
        {
            using (MAction action = new MAction(tableName))
            {
                count = action.GetCount(where);
            }

            return count;
        }

        public List<SysMenu> GetList(string where)
        {
            list = new List<SysMenu>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(where).ToList<SysMenu>();
            }

            return list;
        }
        public List<SysMenu> GetList(int pageIndex, int pageSize, string where)
        {
            list = new List<SysMenu>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize, where).ToList<SysMenu>();
            }

            return list;
        }

        //public List<SysMenu> GetList()
        //{
        //    List<SysMenu> list = new List<SysMenu>();
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        list = ctx.SysMenus.Where(x => !x.DeleteMark).OrderBy(x => x.OrderID).ToList();
        //    }
        //    return list;
        //}

        //public List<SysMenu> GetEnabledList()
        //{
        //    List<SysMenu> list = new List<SysMenu>();
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        list = ctx.SysMenus.Where(x => x.Enabled && !x.DeleteMark).OrderBy(x => x.OrderID).ToList();
        //    }
        //    return list;
        //}

        //public List<SysMenu> GetListByPage(PageSysMenu psm)
        //{
        //    return psm.Order == "desc" ? GetAllListByPage(psm).OrderByDescending(p => Utils.GetPropertyValue(p, psm.Sort)).Skip(psm.Rows * (psm.Page - 1)).Take(psm.Rows).ToList() : GetAllListByPage(psm).OrderBy(p => Utils.GetPropertyValue(p, psm.Sort)).Skip(psm.Rows * (psm.Page - 1)).Take(psm.Rows).ToList();
        //}

        //public List<SysMenu> GetAllListByPage(PageSysMenu psm)
        //{
        //    List<SysMenu> list = new List<SysMenu>();
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        var query = ctx.SysMenus.Where(x => x.DeleteMark.Equals(false));
        //        if (!string.IsNullOrEmpty(psm.ID))
        //        {
        //            query = query.Where(x => x.ParentID.Equals(psm.ID));
        //        }
        //        else
        //        {
        //            query = query.Where(x => x.ParentID.Equals(null));
        //        }

        //        if (!string.IsNullOrEmpty(psm.MenuName))
        //        {
        //            query = query.Where(x => x.MenuName.Contains(psm.MenuName));
        //        }

        //        list = query.ToList();
        //    }
        //    return list;
        //}

        //public long GetCountByPage(PageSysMenu psm)
        //{
        //    return GetAllListByPage(psm).Count;
        //}

        //public List<SysMenu> GetIsMenuList()
        //{
        //    List<SysMenu> list = new List<SysMenu>();
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        list = ctx.SysMenus.Where(x => x.IsMenu.Equals(true) && x.Enabled.Equals(true) && x.DeleteMark.Equals(false)).OrderBy(x => x.OrderID).ToList();
        //    }
        //    return list;
        //}

        //public void AddMenu(SysMenu sm)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        if (!string.IsNullOrEmpty(sm.ParentID))
        //        {
        //            sm.PSysMenu = ctx.SysMenus.Find(sm.ParentID);
        //        }
        //        else
        //        {
        //            sm.ParentID = null;
        //        }

        //        ctx.SysMenus.Add(sm);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void UpdateMenu(SysMenu sm)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        SysMenu nsm = new SysMenu();
        //        nsm = ctx.SysMenus.Find(sm.ID);

        //        IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

        //        Utils.Copy(nsm, sm, ie);

        //        nsm.UDate = DateTime.Now;

        //        if (!string.IsNullOrEmpty(nsm.ParentID))
        //        {
        //            nsm.PSysMenu = ctx.SysMenus.Find(nsm.ParentID);
        //        }
        //        else
        //        {
        //            nsm.ParentID = null;
        //        }

        //        ctx.SaveChanges();
        //    }
        //}

        //public SysMenu GetOneMenu(string id)
        //{
        //    SysMenu sm = new SysMenu();
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        sm = ctx.SysMenus.Find(id);
        //    }

        //    return sm;
        //}

        //public void DeleteMenu(string id)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        SysMenu sm = new SysMenu();
        //        sm = ctx.SysMenus.Find(id);

        //        sm.DeleteMark = true;

        //        ctx.SaveChanges();
        //    }
        //}
    }
}
