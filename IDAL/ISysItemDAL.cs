using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ISysItemDAL
    {
        void Insert(SysItem sysItem);

        void Update(SysItem sysItem);

        SysItem GetObjectByCondition(string where);

        long GetCount();

        long GetCount(string where);

        List<SysItem> GetList();

        List<SysItem> GetList(string strWhere);

        List<SysItem> GetList(int pageIndex, int pageSize);

        List<SysItem> GetList(int pageIndex, int pageSize, string where);

    }
}
