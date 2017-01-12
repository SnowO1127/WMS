using Common;
using DalFactory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SysRoleBLL
    {
        private readonly ISysRoleDAL sysRoleDal = DataAccess.CreateRole();

        private SysRole sysRole;

        public Grid<SysRole> GetList()
        {
            Grid<SysRole> g = new Grid<SysRole>();

            g.total = sysRoleDal.GetCount();
            g.rows = sysRoleDal.GetList();
            return g;
        }

        public Grid<SysRole> GetListByPage(int pageIndex, int pageSize, string sortName, string sortOrder)
        {
            Grid<SysRole> g = new Grid<SysRole>();

            string where = "order by " + sortName + " " + sortOrder + "";

            g.total = sysRoleDal.GetCount();
            g.rows = sysRoleDal.GetList(pageIndex, pageSize, where);

            return g;
        }

        ///// 分页得到用户
        ///// </summary>
        ///// <param name="psu"></param>
        ///// <returns></returns>
        //public Grid<SysRole> GetNonDeleteListByPage(PageSysRole psr)
        //{
        //    Grid<SysRole> g = new Grid<SysRole>();

        //    g.total = dal.GetCount();
        //    g.rows = dal.GetNonDeleteListByPage(psr);
        //    return g;
        //}

        public SysRole GetObjectByID(string roleID)
        {
            string where = "ID='" + roleID + "'";
            return sysRoleDal.GetObjectByCondition(where);
        }

        public void Insert(SysRole sysRole)
        {
            sysRoleDal.Insert(sysRole);
        }

        public void Update(SysRole sysRole)
        {
            sysRoleDal.Update(sysRole);
        }

        public void Delete(string roleID)
        {
            sysRole = GetObjectByID(roleID);

            sysRole.DeleteMark = true;

            Update(sysRole);
        }

        public Grid<SysRole> GetNoRoleList(string userID)
        {
            Grid<SysRole> g = new Grid<SysRole>();

            List<SysRole> list = sysRoleDal.GetNoRoleList(userID);

            g.total = list.Count;
            g.rows = list;

            return g;
        }

        public Grid<SysRole> GetHasRoleList(string userID)
        {
            Grid<SysRole> g = new Grid<SysRole>();

            List<SysRole> list = sysRoleDal.GetHasRoleList(userID);

            g.total = list.Count;
            g.rows = list;

            return g;
        }
    }
}
