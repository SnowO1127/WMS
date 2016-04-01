using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.SystemManage.User
{
    public partial class UserAdd : System.Web.UI.Page
    {
        public string userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = Request.Params["userid"];
        }
    }
}