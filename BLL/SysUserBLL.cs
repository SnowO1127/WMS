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
        /// <summary>
        /// 得到所有用户
        /// </summary>
        /// <returns></returns>
        public Grid<SysUser> GetList()
        {
            Grid<SysUser> g = new Grid<SysUser>();

            g.total = dal.GetCount();
            g.rows = dal.GetList();
            return g;
        }

        /// <summary>
        /// 分页得到用户
        /// </summary>
        /// <param name="psu"></param>
        /// <returns></returns>
        public Grid<SysUser> GetListByPage(PageSysUser psu)
        {
            Grid<SysUser> g = new Grid<SysUser>();

            g.total = dal.GetCount();
            g.rows = dal.GetListByPage(psu);
            return g;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="su"></param>
        public void AddUser(SysUser su)
        {
            dal.AddUser(su);
        }

        public void AddRoles(string userid, List<SysRole> list)
        {
            dal.AddRoles(userid, list);
        }

        public SysUser GetOneUser(string id)
        {
            return dal.GetOneUser(id);
        }

        public void UpdateUser(SysUser su)
        {
            dal.UpdateUser(su);
        }

        public List<SysUser> GetUserListBySpell(string q, int page, int rows, string sort, string order)
        {
            return dal.GetUserListBySpell(q, page, rows, sort, order);
        }
    }
}
