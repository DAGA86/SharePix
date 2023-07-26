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

      
        public async Task<IActionResult> CreateTag(string newTextTag)
        {
            // Check if the tag already exists
            var existingTag = _databaseRepository.GetFirstFiltered<TextTag>(x => x.Description == newTextTag);

            if (existingTag == null)
            {
                // Tag doesn't exist, create a new one in the database
                Data.Models.TextTag newTag = new TextTag()
                {
                    Description = newTextTag,
                };
                newTag = _textTagProvider.Create(newTag);

                // Return the new tag's ID and text to the Select2 plugin
                return Json(new { id = newTag.Id, text = newTag.Description });
            }

            // Return the existing tag's ID and text to the Select2 plugin
            return Json(new { id = existingTag.Id, text = existingTag.Description });
        }
    }
}
