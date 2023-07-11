using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SharePix.Data.Contexts;
using SharePix.Data.Models;
using SharePix.Data.Providers;
using SharePix.Shared.Models;
using SharePix.WebApp.Models;
using SharePix.WebApp.Models.HomePage;
using SharePix.WebApp.Models.Photos;
using System.Diagnostics;

namespace SharePix.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private DatabaseRepository _databaseRepository;

        public HomeController(DatabaseContext context, LanguageProvider languageProvider, LocalizationProvider localizationProvider) : base(languageProvider, localizationProvider)
        {
            _databaseRepository = new DatabaseRepository(context);

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
            //IEnumerable<PhotoViewModel> photosViewModel = _databaseRepository.Get<Photo, PhotoViewModel>==
            Result<List<PhotoViewModel>> result = _databaseRepository.Get<Photo, PhotoViewModel>(
                null, 
                x => new PhotoViewModel { 
                    Id = x.Id, Location = x.Location, Date = x.Date, Description = x.Description, AlbumId = x.AlbumId }
                );

            return View(result.Object);
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