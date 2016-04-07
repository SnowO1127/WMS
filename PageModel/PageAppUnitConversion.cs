using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel
{
    public class PageAppUnitConversion
    {
        public int Page { get; set; }

        public int Rows { get; set; }

        public string Sort { get; set; }

        public string Order { get; set; }

        public string ID { get; set; }

        public string Code { get; set; }

        public string MainUnitName { get; set; }

        public string AssistUnitName { get; set; }

        public int TranslateRate { get; set; }

        public int OrderID { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }
    }
}
