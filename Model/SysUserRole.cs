using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysUserRole
    {
        public string UserID { get; set; }

        public string RoleID { get; set; }

        public SysUser User { get; set; }

        public SysRole Role { get; set; }

        public string CUserID { get; set; }

        public string CUserName { get; set; }

        public DateTime CDate { get; set; }
    }
}
