using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class JsonResult
    {
        private bool _isSucess;
        public JsonResult()
        {
            this.IsSuccess = false;
        }

        public bool IsSuccess
        {
            get { return _isSucess; }
            set { _isSucess = value; }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private Object _obj;

        public Object Obj
        {
            get { return _obj; }
            set { _obj = value; }
        }
     
    }
}
