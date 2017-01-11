using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ISysRoleDAL
    {
        SysRole GetObjectByCondition(string where);

        void Insert(SysRole sysRole);

        void Update(SysRole sysRole);

        long GetCount();

        long GetCount(string where);

        List<SysRole> GetList();

        List<SysRole> GetList(string strWhere);

        List<SysRole> GetList(int pageIndex, int pageSize);

        List<SysRole> GetList(int pageIndex, int pageSize, string where);

        List<SysRole> GetNoRoleList(string userID);

        List<SysRole> GetHasRoleList(string userID);
    }
}
