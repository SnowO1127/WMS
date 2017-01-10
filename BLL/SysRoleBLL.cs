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

        //public SysRole GetOneRole(string id)
        //{
        //    return dal.GetOneRole(id);
        //}

        //public void AddRole(SysRole sr)
        //{
        //    dal.AddRole(sr);
        //}

        //public void UpdateRole(SysRole sr)
        //{
        //    dal.UpdateRole(sr);
        //}

        //public void DeleteRole(string id)
        //{
        //    dal.DeleteRole(id);
        //}

        //public List<SysRole> GetNoRoleList(string userid)
        //{
        //    return dal.GetNoRoleList(userid);
        //}

        //public List<SysRole> GetHasRoleList(string userid)
        //{
        //    return dal.GetHasRoleList(userid);
        //}
    }
}
