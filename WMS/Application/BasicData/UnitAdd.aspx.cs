using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.Application.BasicData
{
    public partial class UnitAdd : BasePage
    {
        public string unitid;
        protected void Page_Load(object sender, EventArgs e)
        {
            unitid = Request.Params["unitid"];
        }
    }
}