using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel
{
    public class JsonResult
    {
        private bool _success = false;
        private string _msg = "";
        private object _obj = null;

        public bool Success
        {
            set { _success = value; }
            get { return _success; }
        }

        public string Msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public object Obj
        {
            set { _obj = value; }
            get { return _obj; }
        }
    }
}
