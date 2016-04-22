using CarRental.DataAccess;
using CarRental.DataAccess.Entities;
using CarRental.Services;
using CarRental.Web.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Security;
using CarRental.ServicesContracts;
using System.Threading.Tasks;

namespace CarRental.Web.Controllers.Web
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;

        //public object FormsAuthentication { get; private set; }
        private static LoginService service = new LoginService(new LoginDbContext());



        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }


        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Account model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                /*if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    return View("Lockout");
                }*/
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /*[HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Account user)
        {
            if (ModelState.IsValid)
            {
                string message = new LoginService(new LoginDbContext()).VerifyAccount(user.UserName, user.Password);
                if (message.Equals("Success"))
                {
                    //FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else if (message.Equals(UserStatus.Admin))
                {
                    //FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Admin", "Account");
                }
                else if (message.Equals(UserStatus.Master))
                {      
                   
                    //FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Master", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }*/



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }


        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                if (service.isEmailTaken(model.Email))
                {
                    ModelState.AddModelError("", "Email is already taken");
                }
                else
                {
                    var user = new User
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.PhoneNumber
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                        // Send an email with this link
                        //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                        //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                        //    "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation(3, "User created a new account with password.");
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /*[HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                //new LoginService(new LoginDbContext())
                string message = new LoginService(new LoginDbContext()).AddUser(register.FirstName, register.LastName,
                    register.PhoneNumber, register.Email, register.UserName, register.Password);
                if (message.Equals("Success"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", message);
                }
            }
            return View(register);
        }*/

        public IActionResult Admin()
        {
            return View();
        }

        

        public IActionResult Master()
        {
            //LoginService service = new LoginService(new LoginDbContext());
            //IList<User> list = service.GetAll();
            return View(/*service.GetAll()*/);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword change)
        {
            /*if (ModelState.IsValid)
            {
                if (service.ChangePassword(change.CurrentPassword,change.NewPassword))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect password");
                }
            }*/
            return View();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return service.GetAll();
        }
        
        public void ChangeUserStatus(int id, string value)
        {
            service.ChangeStatus(id, value);
            
        }


        public void RemoveUser(string id)
        {
            var result = _userManager.DeleteAsync(service.GetById(id));
        }

        public IEnumerable<User> SearchUsers(string SearchQuery)
        {
            IEnumerable<User> list = service.SearchUsers(SearchQuery);
            return list;
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }



        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }


        /*[AllowAnonymous]
        public async Task<JsonResult> EmailAlreadyExistsAsync(string Email)
        {
            var result =
                //await _userManager.FindByNameAsync(Email) ??
                await _userManager.FindByEmailAsync(Email);
            return Json(result == null);
        }*/


    }
}
