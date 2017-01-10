using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ISysMenuDAL
    {
        void Insert(SysMenu SysMenu);

        void Update(SysMenu SysMenu);

        SysMenu GetObjectByCondition(string where);

        long GetCount();

        long GetCount(string where);

        List<SysMenu> GetList();

        List<SysMenu> GetList(string strWhere);

        List<SysMenu> GetList(int pageIndex, int pageSize, string where);

    }
}
