using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ISysItemDetailDAL
    {
        void Insert(SysItemDetail sysItemDetail);

        void Update(SysItemDetail sysItemDetail);

        SysItemDetail GetObjectByCondition(string where);

        long GetCount();

        long GetCount(string where);

        List<SysItemDetail> GetList();

        List<SysItemDetail> GetList(string strWhere);

        List<SysItemDetail> GetList(int pageIndex, int pageSize);

        List<SysItemDetail> GetList(int pageIndex, int pageSize, string where);
    }
}
