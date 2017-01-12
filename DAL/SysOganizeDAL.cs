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
    public class SysOganizeDAL : ISysOganizeDAL
    {
        private readonly string tableName = "Sys_Oganize";

        public SysOganize GetObjectByCondition(string where)
        {
            SysOganize sysOganize = new SysOganize();
            using (MAction action = new MAction(tableName))
            {
                if (action.Fill(where))
                {
                    sysOganize = action.Data.ToEntity<SysOganize>();
                }
            }
            return sysOganize;
        }

        public void Insert(SysOganize user)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(user);
                action.Insert();
            }
        }

        public void Update(SysOganize user)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(user);
                action.Update();
            }
        }

        public List<SysOganize> GetList()
        {
            List<SysOganize> list = new List<SysOganize>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select().ToList<SysOganize>();
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

        public List<SysOganize> GetList(string where)
        {
            List<SysOganize> list = new List<SysOganize>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(where).ToList<SysOganize>();
            }

            return list;
        }

        public List<SysOganize> GetList(int pageIndex, int pageSize)
        {
            List<SysOganize> list = new List<SysOganize>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize).ToList<SysOganize>();
            }

            return list;
        }

        public List<SysOganize> GetList(int pageIndex, int pageSize, string where)
        {
            List<SysOganize> list = new List<SysOganize>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize, where).ToList<SysOganize>();
            }

            return list;
        }

    }
}
