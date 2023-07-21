﻿using Microsoft.AspNetCore.Authorization;
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
using System.Linq.Expressions;
using System.Security.Claims;

namespace SharePix.WebApp.Controllers
{
    [Authorize]
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
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Result<List<Photo>> resultPhotos = _databaseRepository.Get<Photo, Photo>(
                x => x.AlbumId == null && x.OwnerId == userId);

            Result<List<Album>> resultAlbums = _databaseRepository.Get<Album, Album>(
                x => x.OwnerId == userId);

            foreach (var album in resultAlbums.Object)
            {
                resultPhotos.Object.Add(_databaseRepository.GetFirstFiltered<Photo>(x => x.AlbumId == album.Id));
            }
            resultPhotos.Object = resultPhotos.Object.OrderByDescending(x => x.UploadDate).ToList();
            List<HomePageViewModel> list = new List<HomePageViewModel>();
            foreach (var photo in resultPhotos.Object)
            {
                list.Add(new HomePageViewModel()
                {
                    Id = photo.Id,
                    Date = photo.Date,
                    Description = photo.Description,
                    Location = photo.Location,
                    AlbumName = photo.Album?.Name,
                    AlbumId = photo.AlbumId,
                });
            }
            if (TempData["SuccessMessage"] != null)
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];



            return View(list);
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