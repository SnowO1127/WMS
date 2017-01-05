using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CYQ.Data;

namespace DAL
{
    public class SysUserDAL
    {
        public SysUser GetOneUser(string id)
        {
            SysUser sysUser = new SysUser();
            using (MAction action = new MAction("Sys_User"))
            {
                sysUser = action.Get<SysUser>(id);
            }
            return sysUser;
        }

        public void Insert()
        {
            using (MAction action = new MAction("Sys_User"))
            {
                action.Set("ID", new Guid().ToString());
                action.Insert();
            }
        }
    }
}
