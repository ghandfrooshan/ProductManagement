using Framework.Core.Application;

namespace ProductManagement.UserContext.ApplicationService.Contarct.Users
{
    public class UserLoginCommand : Command
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}