﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ISysUserDAL
    {
        void Insert(SysUser sysUser);

        void Update(SysUser sysUser);

        SysUser GetObjectByCondition(string id);

        long GetCount();

        long GetCount(string where);

        List<SysUser> GetList();

        List<SysUser> GetList(string strWhere);

        List<SysUser> GetList(int pageIndex, int pageSize);

        List<SysUser> GetList(int pageIndex, int pageSize, string where);
    }
}
