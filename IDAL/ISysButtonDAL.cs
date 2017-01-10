using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ISysButtonDAL
    {
        SysButton GetObjectByCondition(string where);

        void Insert(SysButton sysButton);

        void Update(SysButton sysButton);

        long GetCount();

        long GetCount(string where);

        List<SysButton> GetList();

        List<SysButton> GetList(string strWhere);

        List<SysButton> GetList(int pageIndex, int pageSize);

        List<SysButton> GetList(int pageIndex, int pageSize, string where);
    }
}
