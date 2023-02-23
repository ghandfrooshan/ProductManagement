using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Application
{
    public abstract class Command
    {
        public Command()
        {
            TimeStamp = DateTime.Now;
        }


        private DateTime TimeStamp { get; set; }


        public DateTime GetTimeStamp()
        {
            return TimeStamp;
        }
    }
}
