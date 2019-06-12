using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WT_Exception
{
    public class WTException: Exception
    {
        public WTException() : base()
        {
          
        }
       
        public WTException(string message) : base(message)
        {

        }
       
        public WTException(string message, Exception innerException) : base(message,innerException)
        {

        }
    }
}
