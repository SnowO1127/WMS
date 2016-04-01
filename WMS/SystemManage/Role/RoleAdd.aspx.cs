using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.SystemManage.Role
{
    public partial class RoleAdd : System.Web.UI.Page
    {
        public string roleid;
        protected void Page_Load(object sender, EventArgs e)
        {
            roleid = Request.Params["roleid"];
        }
    }
}