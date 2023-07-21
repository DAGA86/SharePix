using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SharePix.Data.Contexts;
using SharePix.Data.Models;
using SharePix.WebApp.Controllers;
using SharePix.WebApp.Models.TextTag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SharePix.Data.Providers
{
    public class TextTagsController : BaseController
    {
        private TextTagProvider _textTagProvider;
        private DatabaseRepository _databaseRepository;


        public TextTagsController(DatabaseContext context, LanguageProvider languageProvider, LocalizationProvider localizationProvider) : base(languageProvider, localizationProvider)
        {
            _textTagProvider = new TextTagProvider(context);
            _databaseRepository = new DatabaseRepository(context);
        }

        [HttpGet]
        public JsonResult GetTags(string term)
        {
            var result = _databaseRepository.Get<Data.Models.TextTag, TextTagViewModel>(x => x.Description.Contains(term), x => new TextTagViewModel { Id = x.Id, Text = x.Description });

            return Json(result.Object);
        }

        //[HttpGet]
        //public IActionResult CreateTag(string tagText)
        //{
        //    Data.Models.TextTag textTag = new TextTag()
        //    {
        //        Description = tagText,
        //    };
        //    _textTagProvider.Create(textTag);
        //    return Json(textTag.Description);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateTag(string tagText)
        {
            // Check if the tag already exists
            var existingTag = _databaseRepository.GetFirstFiltered<TextTag>(x => x.Description == tagText);

            if (existingTag == null)
            {
                // Tag doesn't exist, create a new one in the database
                Data.Models.TextTag textTag = new TextTag()
                {
                    Description = tagText,
                };
                TextTag newTag = _textTagProvider.Create(textTag);

                // Return the new tag's ID and text to the Select2 plugin
                return Json(new { id = newTag.Id, text = newTag.Description });
            }

            // Return the existing tag's ID and text to the Select2 plugin
            return Json(new { id = existingTag.Id, text = existingTag.Description });
        }
    }
}
