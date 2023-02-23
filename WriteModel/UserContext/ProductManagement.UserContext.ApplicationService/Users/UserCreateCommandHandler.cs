using Framework.Core.Application;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using ProductManagement.UserContext.ApplicationService.Contarct.Users;
using System.Security.Policy;
using System.Text.Encodings.Web;
using System.Text;
using System.Windows.Input;

namespace ProductManagement.UserContext.ApplicationService.Users
{
    public class UserCreateCommandHandler : ICommandHandler<UserCreateCommand>
    {
        private readonly UserManager<IdentityUser> userManager;
       

        public UserCreateCommandHandler(UserManager <IdentityUser> userManager
           
            )
        {
            this.userManager = userManager;
         
        }
        public  void ExecuteAsync(UserCreateCommand command)
        {

            var user = new IdentityUser { Email = command.Email,UserName=command.Email };
            

            var result = userManager.CreateAsync(user, command.Password).Result;
            if (!result.Succeeded) { throw new Exception(result.Errors.ToString()); }

        }


           
       
    }
}