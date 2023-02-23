using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.App.Models;
using ProductManagement.UserContext.ApplicationService.Contarct.Users;
using ProductManagement.UserContext.ApplicationService.Users;
using ProductManagement.UserContext.Facade.Contract.Users;
using ProductManagement.UserContext.Facade.Users;

namespace ProductManagement.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserCommandfacade userCommandfacade;

        public AccountController(IUserCommandfacade userCommandfacade )
        {
            this.userCommandfacade = userCommandfacade;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        public ActionResult Login()
        {
  


            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserLoginCommand command, string returnUrl = "/" )
        { 

            userCommandfacade.LoginUser(command);
            return Redirect(returnUrl);


        }


        [HttpGet]
        public IActionResult Register()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserCreateCommand command)
        {
            userCommandfacade.CreateUser(command);
            var loginCommad = new UserLoginCommand() { Email = command.Email, Password = command.Password };
            userCommandfacade.LoginUser(loginCommad);
            return RedirectToAction("Index", "Product");
        }


        public ActionResult Logout( )
        {
            var command = new UserLogoutCommand();
            userCommandfacade.LogoutUser(command);
            return RedirectToAction("Login", "Account");
        }

    }
}
