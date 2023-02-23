using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class ExceptionCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
    {
        private readonly ICommandHandler<TCommand> commandHandler;


        public ExceptionCommandHandler(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }


        public void ExecuteAsync(TCommand command)
        {
            try
            {
                commandHandler.ExecuteAsync(command);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count > 1 && ex.InnerExceptions.All(z => z.Message == ex.InnerException.Message))
                {
                    throw ex.Flatten().InnerException;
                }
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
