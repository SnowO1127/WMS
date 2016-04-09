using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel
{
    public class PageAppMaterial
    {
        public int Page { get; set; }

        public int Rows { get; set; }

        public string Sort { get; set; }

        public string Order { get; set; }

        public string ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string CategoryID { get; set; }

        public string UnitConversionID { get; set; }

        public string Mnemonics { get; set; }

        public decimal Weight { get; set; }

        public decimal Long { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal Volume { get; set; }

        public string Wrappage { get; set; }

        public int WarrantyDays { get; set; }

        public int WarrantyWarnDays { get; set; }

        public string Description { get; set; }

        public int OrderID { get; set; }


        public bool Enabled { get; set; }
    }
}
