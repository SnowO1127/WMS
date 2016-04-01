using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.SystemManage.Menu
{
    public partial class MenuAdd : System.Web.UI.Page
    {
        public string menuid;
        protected void Page_Load(object sender, EventArgs e)
        {
            menuid = Request.Params["menuid"];
        }
    }
}