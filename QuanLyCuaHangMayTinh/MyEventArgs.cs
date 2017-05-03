using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh
{
    public class MyEventArgs : EventArgs
    {
        private int type;
        private DateTime fromTime;
        private DateTime toTime;

        public DateTime ToTime
        {
            get { return toTime; }
            set { toTime = value; }
        }

        public DateTime FromTime
        {
            get { return fromTime; }
            set { fromTime = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
