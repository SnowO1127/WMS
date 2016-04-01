using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysPermission
    {
        public string ID { get; set; }

        public string ParentID { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string IconCls { get; set; }

        public int OrderID { get; set; }
    }
}
