using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.SystemManage.Dict
{
    public partial class DictItemDetailAdd : System.Web.UI.Page
    {
        public string id, itemid;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.Params["id"];
            itemid = Request.Params["itemid"];
        }
    }
}