using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.Application.BasicData
{
    public partial class MaterialCategoryAdd : System.Web.UI.Page
    {
        public string materialcategoryid;
        protected void Page_Load(object sender, EventArgs e)
        {
            materialcategoryid = Request.Params["materialcategoryid"];
        }
    }
}