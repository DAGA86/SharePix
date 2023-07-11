using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharePix.Data.Contexts;
using SharePix.Data.Providers;
using SharePix.WebApp.Models.Photos;
using System.Security.Claims;

namespace SharePix.WebApp.Controllers
{
    [Authorize]
    public class PhotosController : BaseController
    {
        private DatabaseRepository _databaseRepository;
        private PhotoProvider _photoProvider;
        private readonly IWebHostEnvironment _env;
        private UserAccountProvider _userAccountProvider;


        public PhotosController(DatabaseContext context, IWebHostEnvironment env, LanguageProvider languageProvider, LocalizationProvider localizationProvider) : base(languageProvider, localizationProvider)
        {
            _databaseRepository = new DatabaseRepository(context);
            _photoProvider = new PhotoProvider(context);
            _userAccountProvider = new UserAccountProvider(context);
            _env = env;
        }

        public ActionResult Index()
        {
            return View();
        }


      
        public ActionResult UploadPhoto()
        {
            UploadPhotoViewModel model = new UploadPhotoViewModel();
          
            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(List<IFormFile> files, UploadPhotoViewModel model)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("No files uploaded.");
            }

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

                            if (ModelState.IsValid)
                            {
                                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                                Data.Models.Photo photo = new Data.Models.Photo()
                                {
                                    OwnerId = userId,
                                    Location = model.Location,
                                    Description = model.Description,
                                    Date = model.Date,
                                };
                                var newFileName = $"{_photoProvider.Create(photo).Id}.jpg";

                                string webRootPath = _env.WebRootPath;

                                var newPath = Path.Combine(webRootPath + "\\photos", newFileName);

                                image.Save(newPath);
                            }
                        }
                    }
                }
                finally
                {
                    System.IO.File.Delete(tempFilePath); // Delete the temporary file
                }
            }

            return Ok("Photos uploaded successfully.");

        }

        public ActionResult ViewOnePhoto()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
