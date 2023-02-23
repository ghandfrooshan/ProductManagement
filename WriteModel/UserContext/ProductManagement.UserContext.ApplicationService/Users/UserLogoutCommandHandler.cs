using Framework.Core.Application;
using Microsoft.AspNetCore.Identity;
using ProductManagement.UserContext.ApplicationService.Contarct.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.UserContext.ApplicationService.Users
{
    public class UserLogoutCommandHandler : ICommandHandler<UserLogoutCommand>
    {

        private readonly SignInManager<IdentityUser> signInManager;


        public UserLogoutCommandHandler(SignInManager<IdentityUser> signInManager)
        {

            this.signInManager = signInManager;

        }
        public async void ExecuteAsync(UserLogoutCommand command)
        {

            signInManager.SignOutAsync();
            



        }
    }
}
