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
        public string id,menuid;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.Params["id"];
            menuid = Request.Params["menuid"];
        }
    }
}