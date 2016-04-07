using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel
{
    public class PageAppSupplier
    {
        public int Page { get; set; }

        public int Rows { get; set; }

        public string Sort { get; set; }

        public string Order { get; set; }

        public string ID { get; set; }

        public string Name { get; set; }

        public string LinkMan { get; set; }

        public string Tel { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public string Description { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public int OrderID { get; set; }

        public bool Enabled { get; set; }
    }
}
