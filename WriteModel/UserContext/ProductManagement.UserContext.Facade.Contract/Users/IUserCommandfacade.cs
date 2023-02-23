using ProductManagement.UserContext.ApplicationService.Contarct.Users;

namespace ProductManagement.UserContext.Facade.Contract.Users
{
    public interface IUserCommandfacade
    {
        void CreateUser(UserCreateCommand command);
        void LoginUser(UserLoginCommand command);
        void LogoutUser(UserLogoutCommand command);
    }
}