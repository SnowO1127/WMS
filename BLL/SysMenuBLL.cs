using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SysMenuBLL
    {
        private readonly SysMenuDAL dal = new SysMenuDAL();
        public List<SysMenu> GetList()
        {
            return dal.GetList();
        }
    }
}
