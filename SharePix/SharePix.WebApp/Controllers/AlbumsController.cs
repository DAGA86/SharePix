using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using SharePix.Data.Contexts;
using SharePix.Data.Models;
using SharePix.Data.Providers;
using SharePix.Shared.Models;
using SharePix.WebApp.Models.Albums;
using SharePix.WebApp.Models.HomePage;
using SharePix.WebApp.Models.Photos;
using System.Security.Claims;

namespace SharePix.WebApp.Controllers
{
    [Authorize]
    public class AlbumsController : BaseController
    {
        private AlbumProvider _albumProvider;
        private readonly IWebHostEnvironment _env;
        private PhotoProvider _photoProvider;
        private DatabaseRepository _databaseRepository;


        public AlbumsController(DatabaseContext context, IWebHostEnvironment env, LanguageProvider languageProvider, LocalizationProvider localizationProvider) : base(languageProvider, localizationProvider)
        {
            _albumProvider = new AlbumProvider(context);
            _photoProvider = new PhotoProvider(context);
            _databaseRepository = new DatabaseRepository(context);
            _env = env;

        }

        public IActionResult ViewAlbum(int id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Result<List<AlbumPhotoViewModel>> resultPhotos = _databaseRepository.Get<Photo, AlbumPhotoViewModel>(
                x => x.AlbumId == id && x.OwnerId == userId,
                x => new AlbumPhotoViewModel { Date = x.Date, Description = x.Description, Id = x.Id, Location = x.Location, UploadDate = x.UploadDate }
                );

            Result<List<AlbumViewModel>> resultAlbum = _databaseRepository.Get<Album, AlbumViewModel>(
                x => x.Id == id && x.OwnerId == userId,
                x => new AlbumViewModel { Id = x.Id, Name = x.Name, Description = x.Description, CreateDate = x.CreateDate }
                );

            if (resultAlbum.Object != null && resultAlbum.Object.Any())
            {
                AlbumViewModel viewModel = resultAlbum.Object.First();
                viewModel.Photos = resultPhotos.Object;

                if (TempData["SuccessMessage"] != null)
                    ViewData["SuccessMessage"] = TempData["SuccessMessage"];

                return View(viewModel);
                                
            }
            
            return RedirectToAction(nameof(Index), "Home");
        }      


        public IActionResult CreateAlbum()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum(List<IFormFile> files, CreateAlbumViewModel model)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["ErrorMessage"] = Localize("createAlbum.error");
                return View(nameof(CreateAlbum));
            }

            if (ModelState.IsValid)
            {

                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Data.Models.Album album = new Data.Models.Album()
                {
                    Name = model.Name,
                    Description = model.Description,
                    OwnerId = userId,

                };
                album = _albumProvider.Create(album);

                foreach (var file in files)
                {
                    if (file.Length == 0)
                    {
                        continue; // Skip empty files
                    }

                    var tempFilePath = Path.GetTempFileName();

                    try
                    {
                        using (var stream = new FileStream(tempFilePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        if (files != null && files.Count > 0)
                        {
                            // Step 4: Process the image and save it with desired specifications
                            using (var image = Image.Load(tempFilePath))
                            {
                                var height = 1080;
                                if (image.Height > height)
                                {
                                    var ratio = (float)height / image.Height;
                                    var width = (int)(image.Width * ratio);
                                    image.Mutate(x => x.Resize(new ResizeOptions { Size = new Size(width, height) }));
                                }

                                Data.Models.Photo photo = new Data.Models.Photo()
                                {
                                    OwnerId = userId,
                                    AlbumId = album.Id,

                                };
                                var newFileName = $"{_photoProvider.Create(photo).Id}.jpg";

                                string webRootPath = _env.WebRootPath;

                                var newPath = Path.Combine(webRootPath + "\\photos", newFileName);

                                image.Save(newPath);
                            }

                        }
                    }
                    finally
                    {
                        System.IO.File.Delete(tempFilePath); // Delete the temporary file
                    }
                }
            }

            TempData["SuccessMessage"] = Localize("createAlbum.success");
            return RedirectToAction(nameof(Index), "Home");

        }


        public ActionResult EditAlbum(int id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            EditAlbumViewModel model = _albumProvider.GetFirstById(id, x => new EditAlbumViewModel
            {
                Id = id,
                Name = x.Name,
                Description = x.Description,
                PhotoIds = x.PhotoAlbuns.Select(x => x.Id)

            });
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index), "Home");

        }


        [HttpPost]
        public ActionResult EditAlbum(EditAlbumViewModel model)
        {


            if (ModelState.IsValid)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Album album = new Album()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description
                };
                album = _albumProvider.Update(album);

                if (album != null)
                {
                    TempData["SuccessMessage"] = Localize("editAlbum.success");
                    return RedirectToAction(nameof(Index), "Albums");
                }
            }
            ViewData["ErrorMessage"] = Localize("editAlbum.error");
            return View(model);
        }

        public ActionResult Delete(int id)
        { 
            
            if (_albumProvider.Delete(id))
            {
                    TempData["SuccessMessage"] = Localize("deleteAlbum.success");
                    return RedirectToAction(nameof(Index), "Home");
      
            }
            ViewData["ErrorMessage"] = Localize("deleteAlbum.error");
            return RedirectToAction(nameof(EditAlbum), "Photos");

        }

    }
}

