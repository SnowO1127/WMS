using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.SystemManage.Unit
{
    public partial class unit_add : System.Web.UI.Page
    {
        public string treeid, id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.Params["id"];
            treeid = Request.Params["treeid"];
        }
    }
}