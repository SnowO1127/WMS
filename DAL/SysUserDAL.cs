using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CYQ.Data;
using IDAL;

namespace DAL
{
    public class SysUserDAL : ISysUserDAL
    {
        private readonly string tableName = "Sys_User";
        public SysUser GetOneUserByKey(string id)
        {
            SysUser sysUser = new SysUser();
            using (MAction action = new MAction(tableName))
            {
                sysUser = action.Get<SysUser>(id);
            }
            return sysUser;
        }

        public SysUser GetOneUserByCondition(string where)
        {
            SysUser sysUser = new SysUser();
            using (MAction action = new MAction(tableName))
            {
                if (action.Fill(where))
                {
                    sysUser = action.Data.ToEntity<SysUser>();
                }
            }
            return sysUser;
        }

        public void Insert(SysUser user)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(user);
                action.Insert();
            }
        }

        public void Update(SysUser user)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(user);
                action.Insert();
            }
        }

        public List<SysUser> GetList()
        {
            List<SysUser> list = new List<SysUser>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select().ToList<SysUser>();
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

        public List<SysUser> GetList(string where)
        {
            List<SysUser> list = new List<SysUser>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(where).ToList<SysUser>();
            }

            return list;
        }
        public List<SysUser> GetList(int pageIndex, int pageSize, string where)
        {
            List<SysUser> list = new List<SysUser>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize, pageSize).ToList<SysUser>();
            }

            return list;
        }
    }
}
