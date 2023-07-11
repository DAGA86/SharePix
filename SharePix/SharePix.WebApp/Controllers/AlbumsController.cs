using Microsoft.AspNetCore.Mvc;
using SharePix.Data.Contexts;
using SharePix.Data.Providers;
using SharePix.WebApp.Models.Albums;
using System.Security.Claims;

namespace SharePix.WebApp.Controllers
{
    public class AlbumsController : BaseController
    {
        private AlbumProvider _albumProvider;
        private readonly IWebHostEnvironment _env;
        private PhotoProvider _photoProvider;


        public AlbumsController(DatabaseContext context, IWebHostEnvironment env, LanguageProvider languageProvider, LocalizationProvider localizationProvider) : base(languageProvider, localizationProvider)
        {
            _albumProvider = new AlbumProvider(context);
            _photoProvider = new PhotoProvider(context);
            _env = env;

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(List<IFormFile> files, CreateAlbumViewModel model)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("No files uploaded.");
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
                                    Description = model.Description,
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

            return Ok("Photos uploaded successfully.");

        }

        }
    }

