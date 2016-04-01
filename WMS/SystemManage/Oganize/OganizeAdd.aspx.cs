using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.SystemManage.Oganize
{
    public partial class OganizeAdd : System.Web.UI.Page
    {
        public string oganizeid;
        protected void Page_Load(object sender, EventArgs e)
        {
            oganizeid = Request.Params["oganizeid"];
        }
    }
}