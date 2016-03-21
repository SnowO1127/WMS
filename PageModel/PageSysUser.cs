using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel
{
    public class PageSysUser
    {

        public int Page { get; set; }

        public int Rows { get; set; }

        public string Sort { get; set; }

        public string Order { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID{ get; set; }

        /// <summary>
        /// 用户登录名
        /// </summary>
        public string LoginName{ get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord{ get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName{ get; set; }
    }
}
