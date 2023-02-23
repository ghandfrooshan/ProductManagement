using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Application
{
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        void ExecuteAsync(TCommand command);
    }
}
