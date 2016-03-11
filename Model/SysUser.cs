using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysUser
    {
        private Guid _userid;

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private string _usercode;

        /// <summary>
        /// 用户登录名
        /// </summary>
        public string UserCode
        {
            get { return _usercode; }
            set { _usercode = value; }
        }

        private string _password;

        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _username;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
    }
}
