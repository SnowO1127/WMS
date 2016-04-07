using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppWareHouse
    {
        public string ID { get; set; }

        public string ParentID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string ManagerID { get; set; }

        public string ManagerName { get; set; }

        public int OrderID { get; set; }

        public bool Enabled { get; set; }

        public bool DeleteMark { get; set; }

        public string Description { get; set; }

        public DateTime CDate { get; set; }

        public string CUserID { get; set; }

        public string CUserName { get; set; }

        public DateTime? UDate { get; set; }

        public string UUserID { get; set; }

        public string UUserName { get; set; }

        public List<AppWareHouse> AppWareHouses { get; set; }

        public AppWareHouse PAppWareHouse { get; set; }
    }
}
