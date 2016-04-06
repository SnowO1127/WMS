using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS
{
    public partial class Index : System.Web.UI.Page
    {
        private readonly SysUserBLL bll = new SysUserBLL();
        public SysUser su;
        protected void Page_Load(object sender, EventArgs e)
        {
            su = new SysUser();
            su = bll.GetOneUser(SessionHelper.GetSession("UserID").ToString());
        }
    }
}