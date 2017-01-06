using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Grid<T>
    {
        private long _total;
        private List<T> _rows = new List<T>();

        public long total
        {
            set { _total = value; }
            get { return _total; }
        }

        public List<T> rows
        {
            set { _rows = value; }
            get { return _rows; }
        }
    }
}
