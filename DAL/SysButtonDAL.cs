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
    public class SysButtonDAL : ISysButtonDAL
    {
        private readonly string tableName = "Sys_Button";

        public SysButton GetObjectByCondition(string where)
        {
            SysButton sysButton = new SysButton();
            using (MAction action = new MAction(tableName))
            {
                if (action.Fill(where))
                {
                    sysButton = action.Data.ToEntity<SysButton>();
                }
            }
            return sysButton;
        }

        public void Insert(SysButton user)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(user);
                action.Insert();
            }
        }

        public void Update(SysButton user)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(user);
                action.Insert();
            }
        }

        public List<SysButton> GetList()
        {
            List<SysButton> list = new List<SysButton>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select().ToList<SysButton>();
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

        public List<SysButton> GetList(string where)
        {
            List<SysButton> list = new List<SysButton>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(where).ToList<SysButton>();
            }

            return list;
        }

        public List<SysButton> GetList(int pageIndex, int pageSize)
        {
            List<SysButton> list = new List<SysButton>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize).ToList<SysButton>();
            }

            return list;
        }

        public List<SysButton> GetList(int pageIndex, int pageSize, string where)
        {
            List<SysButton> list = new List<SysButton>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize, where).ToList<SysButton>();
            }

            return list;
        }
    }
}
