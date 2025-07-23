using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.ElasticExceptions
{
    public class NotSuccesfullException : Exception
    {
        public override string Message => "NotSuccesfullException" + base.Message;
    }
}
