using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysUserDAL
    {
        public List<SysUser> GetList()
        {
            List<SysUser> list = new List<SysUser>();
            using (var ctx = new SysUserContext(Globe.ConnectionString))
            {
                list = ctx.SysUsers.ToList();
            }
            return list;
        }

        public int GetCount()
        {
            int count = 0;
            using (var ctx = new SysUserContext(Globe.ConnectionString))
            {
                count = ctx.SysUsers.Count();
            }
            return count;
        }

        public List<SysUser> GetListByPage(PageSysUser psysuser)
        {
            List<SysUser> list = new List<SysUser>();
            using (var ctx = new SysUserContext(Globe.ConnectionString))
            {
                list = psysuser.Order == "desc" ? ctx.SysUsers.ToList().OrderByDescending(p => GetPropertyValue(p, psysuser.Sort)).Skip(psysuser.Rows * (psysuser.Page - 1)).Take(psysuser.Rows).ToList() : ctx.SysUsers.ToList().OrderBy(p => GetPropertyValue(p, psysuser.Sort)).Skip(psysuser.Rows * (psysuser.Page - 1)).Take(psysuser.Rows).ToList();
            }
            return list;
        }

        public int GetCountByPage(PageSysUser psysuser)
        {
            int count = 0;
            using (var ctx = new SysUserContext(Globe.ConnectionString))
            {
                count = psysuser.Order == "desc" ? ctx.SysUsers.ToList().OrderByDescending(p => GetPropertyValue(p, psysuser.Sort)).Skip(psysuser.Rows * (psysuser.Page - 1)).Take(psysuser.Rows).Count() : ctx.SysUsers.ToList().OrderBy(p => GetPropertyValue(p, psysuser.Sort)).Skip(psysuser.Rows * (psysuser.Page - 1)).Take(psysuser.Rows).Count();
            }
            return count;
        }

        private static object GetPropertyValue(object obj, string property)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            return propertyInfo.GetValue(obj, null);
        } 
    }
}
