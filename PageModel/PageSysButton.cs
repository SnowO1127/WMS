using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel
{
    public class PageSysButton
    {
        public int Page { get; set; }

        public int Rows { get; set; }

        public string Sort { get; set; }

        public string Order { get; set; }

        public string ID { get; set; }

        public string MenuID { get; set; }

        public string HtmlID { get; set; }

        public string Name { get; set; }

        public int OrderID { get; set; }

        public bool IsPublic { get; set; }

        public bool Enabled { get; set; }

        public bool AllowEdit { get; set; }

        public bool AllowDelete { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
