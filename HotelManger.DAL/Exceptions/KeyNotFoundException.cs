using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.BLL.Exceptions
{
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException(string msg) : base(msg)
        {

        }
    }
}
