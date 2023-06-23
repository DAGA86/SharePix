using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharePix.WebApp.Models.UserAccounts;
using System.Security.Claims;
using SharePix.Data.Providers;
using SharePix.Data.Contexts;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Authorization;


namespace SharePix.WebApp.Controllers
{
    public class UserAccountsController : BaseController
    {
        private UserAccountProvider _userAccountProvider;

        public UserAccountsController(DatabaseContext context, LanguageProvider languageProvider, LocalizationProvider localizationProvider) : base(context, languageProvider, localizationProvider)
        {
            _userAccountProvider = new UserAccountProvider(context);
        }
        // GET: UserAccountsController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                Data.Models.UserAccount dbUserAccount = _userAccountProvider.ValidateCredencials(model.UsernameOrEmail, model.PasswordHash);

                if (dbUserAccount != null)
                {
                    if (dbUserAccount.IsActive == true)
                    {
                        string authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                        // Generate Claims from DbEntity
                        List<Claim> claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Email, dbUserAccount.Email),
                                new Claim(ClaimTypes.NameIdentifier, dbUserAccount.Username.ToString())
                            };

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                                claims, authenticationScheme);

                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(
                                claimsIdentity);

                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            // Refreshing the authentication session should be allowed.
                            //ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8),
                            // The time at which the authentication ticket expires. A 
                            // value set here overrides the ExpireTimeSpan option of 
                            // CookieAuthenticationOptions set with AddCookie.
                            IsPersistent = true,
                            // Whether the authentication session is persisted across 
                            // multiple requests. Required when setting the 
                            // ExpireTimeSpan option of CookieAuthenticationOptions 
                            // set with AddCookie. Also required when setting 
                            // ExpiresUtc.
                            IssuedUtc = DateTimeOffset.UtcNow,
                            // The time at which the authentication ticket was issued.
                            //RedirectUri = "~/Account/Login"
                            // The full path or absolute URI to be used as an http 
                            // redirect response value.
                        };

                        await this.HttpContext.SignInAsync(
                            authenticationScheme,
                            claimsPrincipal,
                            authProperties);

                        return LocalRedirect("~/Home/Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Account inactive");
                        return View(model);
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid credentials!");
            }

            return View(model);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await this.HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectPermanent("~/Home/Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        // POST: UserAccountsController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Data.Models.UserAccount user = new Data.Models.UserAccount()
                {
                    Username = model.Username,
                    Email = model.Email,
                    PasswordHash = model.PasswordHash,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                var result = _userAccountProvider.Create(user);
                if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    ViewData["ErrorMessage"] = Localize(result.ErrorMessage);
                }
                else
                {
                    ViewData["SuccessMessage"] = Localize("register.success");
                    return View(nameof(Login));
                }

            }
            return View();

        }


        public ActionResult ForgotPassword()
        {
            return View();
        }

        private readonly ILogger<HomeController> _logger;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Data.Models.UserAccount user = _userAccountProvider.GetFirstByEmail(model.Email);

                if( user != null)
                {
                    var token = _userAccountProvider.ForgotPassword(user);

                    var passwordResetPassword = Url.Action("ResetPassword", "UserAccounts", new { email = model.Email, token = token }, Request.Scheme);

                    _logger.Log(LogLevel.Warning, passwordResetPassword);

                    return View("~/UserAccounts/ForgotPasswordConfirmation");
                }
                return View("~/UserAccounts/ForgotPasswordConfirmation");
            }
            return View(model);
        }

        public ActionResult SendEmail()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        // GET: UserAccountsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserAccountsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccountsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserAccountsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserAccountsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserAccountsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserAccountsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
