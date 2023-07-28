using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using SharePix.Data.Contexts;
using SharePix.Data.Models;
using SharePix.Data.Providers;
using SharePix.Shared.Models;
using SharePix.WebApp.Models.Albums;
using SharePix.WebApp.Models.Photos;
using SharePix.WebApp.Models.UserAccounts;
using System.Collections.Generic;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SharePix.WebApp.Controllers
{
    [Authorize]
    public class PhotosController : BaseController
    {
        private DatabaseRepository _databaseRepository;
        private PhotoProvider _photoProvider;
        private PhotoTextTagProvider _photoTextTagProvider;
        private readonly IWebHostEnvironment _env;
        private UserAccountProvider _userAccountProvider;


        public PhotosController(DatabaseContext context, IWebHostEnvironment env, LanguageProvider languageProvider, LocalizationProvider localizationProvider) : base(languageProvider, localizationProvider)
        {
            _databaseRepository = new DatabaseRepository(context);
            _photoProvider = new PhotoProvider(context);
            _userAccountProvider = new UserAccountProvider(context);
            _photoTextTagProvider = new PhotoTextTagProvider(context);
            _env = env;
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
                ViewData["ErrorMessage"] = Localize("uploadPhoto.error");
                return View(nameof(UploadPhoto));
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
                            var height = 1080; //pixeis
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

                                var createPhoto = _photoProvider.Create(photo);

                                var newFileName = $"{createPhoto.Id}.jpg";

                                string webRootPath = _env.WebRootPath;

                                var newPath = Path.Combine(webRootPath + "\\photos", newFileName);

                                image.Save(newPath);


                                if (model.textTagIds != null && model.textTagIds.Any())
                                {
                                    foreach (var tagId in model.textTagIds)
                                    {
                                        PhotoTextTag? photoTextTag = new PhotoTextTag() { PhotoId = createPhoto.Id, TagId = tagId };

                                        photoTextTag = _photoTextTagProvider.Create(photoTextTag);

                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    System.IO.File.Delete(tempFilePath); // Delete the temporary file
                }
            }

            TempData["SuccessMessage"] = Localize("uploadPhoto.success");
            return RedirectToAction(nameof(Index), "Home");

        }


        public ActionResult EditPhoto(int id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Result<List<PhotoTextTag>> result = _databaseRepository.Get<PhotoTextTag, PhotoTextTag>(x => x.PhotoId == id);
            Result<List<TextTag>> resultTextTag = _databaseRepository.Get<TextTag, TextTag>(x => result.Object.Select(y => y.TagId).Contains(x.Id));

            ViewBag.TextTags = new MultiSelectList(resultTextTag.Object, "Id", "Description", resultTextTag.Object);

            EditPhotoViewModel model = _photoProvider.GetFirstById(id, x => new EditPhotoViewModel
            {
                Id = id,
                Date = x.Date,
                Location = x.Location,
                Description = x.Description,
                AlbumId = x.AlbumId,
                textTagIds = x.TextTags.Select(x => x.TagId)
            });

            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index), "Home");

        }

        [HttpPost]
        public ActionResult EditPhoto(EditPhotoViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Photo photo = new Photo()
                {
                    Id = model.Id,
                    Date = model.Date,
                    Location = model.Location,
                    Description = model.Description
                };
                photo = _photoProvider.Update(photo);

                if (model.textTagIds != null && model.textTagIds.Any())
                {
                    var existingTags = _photoTextTagProvider.GetPhotoTextTagsByPhotoId(model.Id);
                    var existingTagIds = existingTags.Select(x => x.TagId);

                    // Check for tags to remove
                    var tagsToRemove = existingTags.Where(x => !model.textTagIds.Contains(x.TagId)).ToList();
                    foreach (var tagToRemove in tagsToRemove)
                    {
                        _photoTextTagProvider.Delete(tagToRemove);
                    }

                    foreach (var tagId in model.textTagIds)
                    {
                        PhotoTextTag? photoTextTag = new PhotoTextTag() { PhotoId = model.Id, TagId = tagId };
                        photoTextTag = _photoTextTagProvider.Create(photoTextTag);
                    }
                }

                else
                {
                    // If no tags were selected, remove all existing tags for the photo
                    var existingTags = _photoTextTagProvider.GetPhotoTextTagsByPhotoId(model.Id);
                    foreach (var tag in existingTags)
                    {
                        _photoTextTagProvider.Delete(tag);
                    }
                }

                if (photo != null)
                {
                    TempData["SuccessMessage"] = Localize("editPhoto.success");
                    if (photo.AlbumId != null)
                    {
                        return RedirectToAction(nameof(Index), "Albums", new { id = photo.AlbumId });
                    }

                    return RedirectToAction(nameof(Index), "Home");
                }
            }
            ViewData["ErrorMessage"] = Localize("editPhoto.error");
            return View(model);
        }

        public IActionResult Delete(int id, int? albumId = null)
        {
            if (_photoProvider.Delete(id))
            {
                TempData["SuccessMessage"] = Localize("deletePhoto.success");
                if (albumId != null)
                {
                    return RedirectToAction(nameof(Index), "Albums", new { id = albumId });
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            ViewData["ErrorMessage"] = Localize("deletePhoto.error");
            return RedirectToAction(nameof(EditPhoto), "Photos");

        }

    }
}
