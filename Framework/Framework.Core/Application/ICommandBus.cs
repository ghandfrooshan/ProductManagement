using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Application
{
    public interface ICommandBus
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : Command;
    }
}
