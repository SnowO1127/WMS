using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel
{
    public class Tree
    {
        public Tree()
        {
            ischecked = false;
        }

        public Object attributes { get; set; }

        public string id { get; set; }

        public string text { get; set; }

        [JsonProperty(PropertyName = "checked")]
        public bool ischecked { get; set; }

        public string pid { get; set; }

        public string url { get; set; }

        public string iconCls { get; set; }

        public int order { get; set; }
    }
}
