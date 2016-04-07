using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.Application.BasicData
{
    public partial class ClientAdd : System.Web.UI.Page
    {
        public string clientid;
        protected void Page_Load(object sender, EventArgs e)
        {
            clientid = Request.Params["clientid"];
        }
    }
}