﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.Application.BasicData
{
    public partial class WareHouseAdd : BasePage
    {
        public string warehouseid;
        protected void Page_Load(object sender, EventArgs e)
        {
            warehouseid = Request.Params["warehouseid"];
        }
    }
}