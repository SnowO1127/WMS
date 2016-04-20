using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysNews
    {
        public string ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CUserID { get; set; }

        public string CUserName { get; set; }

        public string CDeptID { get; set; }

        public string CDeptName { get; set; }

        public DateTime CDate { get; set; }
    }
}
