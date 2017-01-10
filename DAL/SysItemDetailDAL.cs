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
    public class SysItemDetailDAL : ISysItemDetailDAL
    {
        private readonly string tableName = "Sys_ItemDetail";

        public SysItemDetail GetObjectByCondition(string where)
        {
            SysItemDetail sysItemDetail = new SysItemDetail();
            using (MAction action = new MAction(tableName))
            {
                if (action.Fill(where))
                {
                    sysItemDetail = action.Data.ToEntity<SysItemDetail>();
                }
            }
            return sysItemDetail;
        }

        public void Insert(SysItemDetail sysItemDetail)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(sysItemDetail);
                action.Insert();
            }
        }

        public void Update(SysItemDetail sysItemDetail)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(sysItemDetail);
                action.Insert();
            }
        }

        public List<SysItemDetail> GetList()
        {
            List<SysItemDetail> list = new List<SysItemDetail>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select().ToList<SysItemDetail>();
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
        public List<SysItemDetail> GetList(string where)
        {
            List<SysItemDetail> list = new List<SysItemDetail>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(where).ToList<SysItemDetail>();
            }

            return list;
        }

        public List<SysItemDetail> GetList(int pageIndex, int pageSize)
        {
            List<SysItemDetail> list = new List<SysItemDetail>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize).ToList<SysItemDetail>();
            }

            return list;
        }

        public List<SysItemDetail> GetList(int pageIndex, int pageSize, string where)
        {
            List<SysItemDetail> list = new List<SysItemDetail>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize, where).ToList<SysItemDetail>();
            }

            return list;
        }
    }
}
