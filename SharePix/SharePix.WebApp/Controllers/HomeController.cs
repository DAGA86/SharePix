using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SharePix.Data.Providers;
using SharePix.WebApp.Models;
using SharePix.WebApp.Models.HomePage;
using SharePix.WebApp.Models.Photos;
using System.Diagnostics;

namespace SharePix.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(LanguageProvider languageProvider, LocalizationProvider localizationProvider) : base(languageProvider, localizationProvider)
        {

        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Index()
        {
            PhotosViewModel photosViewModel = new PhotosViewModel();

            UploadPhotoViewModel[] uploadPhotoViewModel = null;
            
            if(uploadPhotoViewModel != null)
            {
                photosViewModel.UploadPhoto = uploadPhotoViewModel;
            }

            return View(photosViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}