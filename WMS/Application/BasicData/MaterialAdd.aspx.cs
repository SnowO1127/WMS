using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.Application.BasicData
{
    public partial class MaterialAdd : BasePage
    {
        public string materialid;
        protected void Page_Load(object sender, EventArgs e)
        {
            materialid = Request.Params["materialid"];
        }
    }
}