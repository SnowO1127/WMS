using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysMenuDAL
    {
        public List<SysMenu> GetList()
        {
            List<SysMenu> list = new List<SysMenu>();
            using (SysMenuContext ctx = new SysMenuContext(Globe.ConnectionString))
            {
                list = ctx.SysMenus.ToList();
            }
            return list;
        }
    }
}
