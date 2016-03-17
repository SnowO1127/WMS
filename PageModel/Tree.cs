using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel
{
    public class Tree
    {
        private string _id;
        private string _text;
        private string _pid;
        private string _url;
        private string _iconcls;
        private int _order;
        private Object _attributes;

        public Object attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        public string id
        {
            set { _id = value; }
            get { return _id; }
        }

        public string text
        {
            set { _text = value; }
            get { return _text; }
        }

        public string pid
        {
            set { _pid = value; }
            get { return _pid; }
        }

        public string url
        {
            set { _url = value; }
            get { return _url; }
        }

        public string iconCls
        {
            set { _iconcls = value; }
            get { return _iconcls; }
        }

        public int order
        {
            set { _order = value; }
            get { return _order; }
        }
    }
}
