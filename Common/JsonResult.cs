using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class JsonResult
    {
        private bool _sucess;
        public JsonResult()
        {
            this.Success = false;
        }

        public bool Success
        {
            get { return _sucess; }
            set { _sucess = value; }
        }

        private string _msg;

        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        private Object _obj;

        public Object Obj
        {
            get { return _obj; }
            set { _obj = value; }
        }
     
    }
}
