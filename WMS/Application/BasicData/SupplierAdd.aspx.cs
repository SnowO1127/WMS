using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.Application.BasicData
{
    public partial class SupplierAdd : System.Web.UI.Page
    {
        public string supplierid;
        protected void Page_Load(object sender, EventArgs e)
        {
            supplierid = Request.Params["supplierid"];
        }
    }
}