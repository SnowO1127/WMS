using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.SystemManage.Button
{
    public partial class ButtonAdd : System.Web.UI.Page
    {
        public string buttonid, menuid;
        protected void Page_Load(object sender, EventArgs e)
        {
            buttonid = Request.Params["buttonid"];
            menuid = Request.Params["menuid"];
        }
    }
}