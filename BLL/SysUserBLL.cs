using Common;
using DalFactory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class SysUserBLL
    {
        private readonly ISysUserDAL sysUserDal = DataAccess.CreateUser();
        //private readonly RoleDAL srdal = new RoleDAL();
        //private readonly MenuDAL smdal = new MenuDAL();
        /// <summary>
        /// 得到所有用户
        /// </summary>
        /// <returns></returns>
        public Grid<SysUser> GetList()
        {
            Grid<SysUser> g = new Grid<SysUser>();

            g.total = sysUserDal.GetCount();
            g.rows = sysUserDal.GetList();

            return g;
        }

        public Grid<SysUser> GetList(int pageIndex, int pageSize, string sortName, string sortOrder)
        {
            Grid<SysUser> g = new Grid<SysUser>();

            string where = "order by " + sortName + " " + sortOrder + "";

            g.total = sysUserDal.GetCount();
            g.rows = sysUserDal.GetList(pageIndex, pageSize, where);

            return g;
        }

        public Grid<SysUser> GetList(int pageIndex, int pageSize)
        {
            Grid<SysUser> g = new Grid<SysUser>();

            g.total = sysUserDal.GetCount();
            g.rows = sysUserDal.GetList(pageIndex, pageSize);
            return g;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="su"></param>
        public void Insert(SysUser su)
        {
            sysUserDal.Insert(su);
        }

        //public void AddRoles(string userid, List<SysRole> list)
        //{
        //    sudal.AddRoles(userid, list);
        //}

        public SysUser GetOneUserByID(string id)
        {
            string where = "ID='" + id + "'";
            return sysUserDal.GetObjectByCondition(where);
        }

        public void Update(SysUser sysUser)
        {
            sysUserDal.Update(sysUser);
        }

        //public List<SysUser> GetUserListBySpell(string q, int page, int rows, string sort, string order)
        //{
        //    return sudal.GetUserListBySpell(q, page, rows, sort, order);
        //}

        public void DeleteUser(string userID)
        {
            SysUser sysUser = GetUserByID(userID);
            sysUser.DeleteMark = true;

            Update(sysUser);
        }

        public void ResetPassWord(string userID, string pwd)
        {
            SysUser sysUser = GetUserByID(userID);
            sysUser.PassWord = pwd;

            Update(sysUser);
        }

        public SysUser GetUserByID(string userID)
        {
            string where = "ID='" + userID + "'";

            return sysUserDal.GetObjectByCondition(where);
        }

        public SysUser GetUserByLoginName(string loginname)
        {
            string where = "LoginName = '" + loginname + "'";

            return sysUserDal.GetObjectByCondition(where);
        }

        /// <summary>
        /// 得到当前登录用户
        /// </summary>
        /// <returns></returns>
        public SysUser GetCurrentUser()
        {
            SysUser su = null;
            if (SessionHelper.GetSession(Globe.UserSessionName) != null)
            {
                string id = SessionHelper.GetSession(Globe.UserSessionName).ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    string where = "ID = '" + id + "'";

                    su = sysUserDal.GetObjectByCondition(id);
                }
            }
            return su;
        }
    }
}
