using Framework.Core.Application;
using Framework.Facade;
using ProductManagement.UserContext.ApplicationService.Contarct.Users;
using ProductManagement.UserContext.Facade.Contract.Users;

namespace ProductManagement.UserContext.Facade.Users
{
    public class UserCommandfacade : FacadeCommandBase, IUserCommandfacade
    {
        public UserCommandfacade(ICommandBus commandBus) : base(commandBus)
        {
        }
        
        public void CreateUser(UserCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void LoginUser(UserLoginCommand command)
        {
            CommandBus.Dispatch(command);
        }
        public void LogoutUser(UserLogoutCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}