﻿using Framework.Core.Application;
using Framework.Core.DependencyInjection;
using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class TransactionalCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
    {
        private readonly ICommandHandler<TCommand> commandHandler;
        private readonly IDiContainer diContainer;
        public TransactionalCommandHandler(ICommandHandler<TCommand> commandHandler, IDiContainer diContainer)
        {
            this.commandHandler = commandHandler;
            this.diContainer = diContainer;
        }
        public void ExecuteAsync(TCommand command)
        {
            var unitOfWork = diContainer.Resolve<IUnitOfWork>();
            try
            {
                commandHandler.ExecuteAsync(command);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                throw ex;
            }
        }
    }
}
