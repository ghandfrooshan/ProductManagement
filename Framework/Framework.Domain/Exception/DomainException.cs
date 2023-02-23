using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Exception
{
    public class DomainException : ApplicationException
    {
        public DomainException()
        {
        }


        public DomainException(string message) : base(message)
        {
        }
    }
}
