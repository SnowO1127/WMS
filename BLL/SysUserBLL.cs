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

        public Grid<SysUser> GetList()
        {
            List<SysUser> l = new List<SysUser>();
            int count = 0;
            Grid<SysUser> g = new Grid<SysUser>();

            using (var ctx = new SysUserDAL(Globe.ConnectionString)) {
                l = ctx.SysUsers.ToList();
                count = ctx.SysUsers.Count();
            }


            g.total = count;
            g.rows = l;
            return g;
        }
    }
}
