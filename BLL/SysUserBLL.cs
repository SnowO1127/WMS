using Common;
using DAL;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SysUserBLL
    {
        private readonly SysUserDAL dal = new SysUserDAL();
        public Grid<SysUser> GetList()
        {
            Grid<SysUser> g = new Grid<SysUser>();

            g.total = dal.GetCount();
            g.rows = dal.GetList();
            return g;
        }

        public Grid<SysUser> GetListByPage(PageSysUser psysuser)
        {
            Grid<SysUser> g = new Grid<SysUser>();

            g.total = dal.GetCountByPage(psysuser);
            g.rows = dal.GetListByPage(psysuser);
            return g;
        }
    }
}
