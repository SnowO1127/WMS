using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ISysOganizeDAL
    {
        SysOganize GetObjectByCondition(string where);

        void Insert(SysOganize sysOganize);

        void Update(SysOganize sysOganize);

        long GetCount();

        long GetCount(string where);

        List<SysOganize> GetList();

        List<SysOganize> GetList(string strWhere);

        List<SysOganize> GetList(int pageIndex, int pageSize);

        List<SysOganize> GetList(int pageIndex, int pageSize, string where);

    }
}
