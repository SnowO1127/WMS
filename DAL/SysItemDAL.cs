using CYQ.Data;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysItemDAL : ISysItemDAL
    {
        private readonly string tableName = "Sys_Item";

        public SysItem GetObjectByCondition(string where)
        {
            SysItem sysItem = new SysItem();
            using (MAction action = new MAction(tableName))
            {
                if (action.Fill(where))
                {
                    sysItem = action.Data.ToEntity<SysItem>();
                }
            }
            return sysItem;
        }

        public void Insert(SysItem sysItem)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(sysItem);
                action.Insert();
            }
        }

        public void Update(SysItem sysItem)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(sysItem);
                action.Insert();
            }
        }

        public List<SysItem> GetList()
        {
            List<SysItem> list = new List<SysItem>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select().ToList<SysItem>();
            }

            return list;
        }

        public long GetCount()
        {
            long count = 0;

            using (MAction action = new MAction(tableName))
            {
                count = action.GetCount();
            }

            return count;
        }

        public long GetCount(string where)
        {
            long count = 0;

            using (MAction action = new MAction(tableName))
            {
                count = action.GetCount(where);
            }

            return count;
        }

        public List<SysItem> GetList(string where)
        {
            List<SysItem> list = new List<SysItem>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(where).ToList<SysItem>();
            }

            return list;
        }

        public List<SysItem> GetList(int pageIndex, int pageSize)
        {
            List<SysItem> list = new List<SysItem>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize).ToList<SysItem>();
            }

            return list;
        }

        public List<SysItem> GetList(int pageIndex, int pageSize, string where)
        {
            List<SysItem> list = new List<SysItem>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize, where).ToList<SysItem>();
            }

            return list;
        }
    }
}
