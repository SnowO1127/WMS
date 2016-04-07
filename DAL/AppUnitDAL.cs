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
    public class AppUnitDAL
    {
        public List<AppUnit> GetList()
        {
            List<AppUnit> list = new List<AppUnit>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.AppUnits.ToList();
            }
            return list;
        }

        public int GetCount()
        {
            int count = 0;
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                count = ctx.AppUnits.Count();
            }
            return count;
        }

        public List<AppUnit> GetListByPage(PageAppUnit pau)
        {
            List<AppUnit> list = new List<AppUnit>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.AppUnits.Where(x => x.DeleteMark.Equals(false)).ToList();

            }
            list = pau.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, pau.Sort)).Skip(pau.Rows * (pau.Page - 1)).Take(pau.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, pau.Sort)).Skip(pau.Rows * (pau.Page - 1)).Take(pau.Rows).ToList();

            return list;
        }

        public void AddUnit(AppUnit au)
        {
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                ctx.AppUnits.Add(au);
                ctx.SaveChanges();
            }
        }

        public void UpdateUnit(AppUnit au)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                AppUnit nac = new AppUnit();
                nac = ctx.AppUnits.Find(au.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "DDate", "DUserID", "DUserName", "DeleteMark" };

                Utils.Copy(nac, au, ie);

                ctx.SaveChanges();
            }
        }

        public void DeleteUnit(string unitid)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                AppUnit ac = new AppUnit();
                ac = ctx.AppUnits.Find(unitid);

                ac.DeleteMark = true;

                ctx.SaveChanges();
            }
        }

        public AppUnit GetOneUnit(string unitid)
        {
            AppUnit ac = new AppUnit();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                ac = ctx.AppUnits.Find(unitid);
            }
            return ac;
        }
    }
}
