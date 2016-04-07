using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel
{
    public class PageAppMaterialCategory
    {
        public int Page { get; set; }

        public int Rows { get; set; }

        public string Sort { get; set; }

        public string Order { get; set; }

        public string ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int OrderID { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }
    }
}
