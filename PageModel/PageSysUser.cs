using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel
{
    public class PageSysUser
    {
        private int _page;
        private int _rows;
        private string _sort;
        private string _order;

        public int Page
        {
            set { _page = value; }
            get { return _page; }
        }

        public int Rows
        {
            set { _rows = value; }
            get { return _rows; }
        }

        public string Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }

        public string Order
        {
            set { _order = value; }
            get { return _order; }
        }

        private string _userid;

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private string _loginname;

        /// <summary>
        /// 用户登录名
        /// </summary>
        public string LoginName
        {
            get { return _loginname; }
            set { _loginname = value; }
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
