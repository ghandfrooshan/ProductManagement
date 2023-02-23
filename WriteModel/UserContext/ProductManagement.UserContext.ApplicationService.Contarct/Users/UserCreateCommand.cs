using Framework.Core.Application;

namespace ProductManagement.UserContext.ApplicationService.Contarct.Users
{
    public class UserCreateCommand :Command
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}