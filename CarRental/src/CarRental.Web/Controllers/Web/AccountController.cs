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
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;

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

        private static LoginDbContext context = new LoginDbContext();
        private static LoginService service = new LoginService(context);
        



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


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {

            //User user = new User();
            //_userManager.GetRolesAsync(user);//IsInRole(user.Id, "Admin")
            //string[] roles = Roles.GetRolesForUser(user.UserName);

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

                        //var Roles = new LoginDbContext().Roles.ToList();
                        await _userManager.AddToRoleAsync(user, UserStatus.Regular);


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


        public IActionResult Admin()
        {
            return View();
        }

        
        [HttpGet]
        [Authorize(Roles = UserStatus.Master + "," + UserStatus.SuperAdmin)]
        public IActionResult Master()
        {
            IList<User> Users = service.GetAll();
            IList<string> UserRoles = service.GetUserRoles();
            IList<string> Roles = service.GetAllRoles();

            Master model = new Master(Users, UserRoles, Roles);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = UserStatus.Master + "," + UserStatus.SuperAdmin)]
        public IActionResult MasterSearch([FromBody]string query)
        {
            IList<User> Users = service.SearchUsers(query);
            IList<string> UserRoles = service.GetUserRoles();
            IList<string> Roles = service.GetAllRoles();

            Master model = new Master(Users, UserRoles, Roles);

            return PartialView("MasterPartial", model);
        }






        [HttpGet]
        public IActionResult AccountSettings()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {          
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User changed their password successfully.");
                    return RedirectToAction(nameof(AccountSettings), "Account");
                }
                AddErrors(result);
                return View(model);
            }
            return RedirectToAction(nameof(AccountSettings), "Account");
        }

        [HttpGet]
        public IActionResult AddPhoneNumber()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoneNumber(AddPhoneNumber model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                bool result = service.ChangePhoneNumber(user.Id, model.PhoneNumber);
                if (result)
                {
                    return RedirectToAction(nameof(AccountSettings), "Account");
                }
                return View(model);
            }
            return RedirectToAction(nameof(AccountSettings), "Account");
        }

        public async Task<string> GetPhoneNumber()
        {
            User user = await GetCurrentUserAsync();
            return user.PhoneNumber;
        }

        
        public void ChangeUserStatus(string id, string value)
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

        private async Task<User> GetCurrentUserAsync()
        {
            return await _userManager.FindByIdAsync(HttpContext.User.GetUserId());
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
