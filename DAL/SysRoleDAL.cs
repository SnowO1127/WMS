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
    public class SysRoleDAL : ISysRoleDAL
    {
        private readonly string tableName = "Sys_Role";

        private SysRole sysRole;
        private List<SysRole> list;
        private long count = 0;
        public SysRole GetObjectByCondition(string where)
        {
            sysRole = new SysRole();
            using (MAction action = new MAction(tableName))
            {
                if (action.Fill(where))
                {
                    sysRole = action.Data.ToEntity<SysRole>();
                }
            }
            return sysRole;
        }

        public void Insert(SysRole user)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(user);
                action.Insert();
            }
        }

        public void Update(SysRole user)
        {
            using (MAction action = new MAction(tableName))
            {
                action.Data.LoadFrom(user);
                action.Insert();
            }
        }

        public List<SysRole> GetList()
        {
            list = new List<SysRole>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select().ToList<SysRole>();
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

        public List<SysRole> GetList(string where)
        {
            list = new List<SysRole>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(where).ToList<SysRole>();
            }

            return list;
        }

        public List<SysRole> GetList(int pageIndex, int pageSize)
        {
            list = new List<SysRole>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize).ToList<SysRole>();
            }

            return list;
        }

        public List<SysRole> GetList(int pageIndex, int pageSize, string where)
        {
            list = new List<SysRole>();

            using (MAction action = new MAction(tableName))
            {
                list = action.Select(pageIndex, pageSize, where).ToList<SysRole>();
            }

            return list;
        }

        public List<SysRole> GetNoRoleList(string userID)
        {
            string sql = "select a.* from [WMS].[dbo].[Sys_Role] as a join [WMS].[dbo].[Sys_UserRole] as b on a.ID = b.RoleID where b.UserID = '" + userID + "'";

            using (MAction action = new MAction(sql))
            {
                list = action.Select().ToList<SysRole>();
            }

            return list;
        }

        public List<SysRole> GetHasRoleList(string userID)
        {
            string sql = "select a.* from [WMS].[dbo].[Sys_Role] as a join [WMS].[dbo].[Sys_UserRole] as b on a.ID = b.RoleID where b.UserID = '" + userID + "'";

            using (MAction action = new MAction(sql))
            {
                list = action.Select().ToList<SysRole>();
            }

            return list;
        }

    }
}
