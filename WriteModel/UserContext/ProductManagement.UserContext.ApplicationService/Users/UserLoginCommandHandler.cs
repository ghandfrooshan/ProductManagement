using Framework.Core.Application;
using Microsoft.AspNetCore.Identity;
using ProductManagement.UserContext.ApplicationService.Contarct.Users;
using System.Reflection;

namespace ProductManagement.UserContext.ApplicationService.Users
{
    public class UserLoginCommandHandler : ICommandHandler<UserLoginCommand>
    {
       
        private readonly SignInManager<IdentityUser> signInManager;
       

        public UserLoginCommandHandler(SignInManager<IdentityUser> signInManager)
        {
            
           this.signInManager = signInManager;
           
        }
        public async void ExecuteAsync(UserLoginCommand command)
        {
           
            var result = signInManager.PasswordSignInAsync(command.Email, command.Password, true, false).Result;
            
            if (!result.Succeeded) { throw new Exception("Login is faild!"); }


        }
    }
}