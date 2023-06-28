using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SharePix.Data.Contexts;
using SharePix.Data.Providers;

namespace SharePix.WebApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly LanguageProvider _languageProvider;
        private readonly LocalizationProvider _localizationProvider;

        public BaseController(LanguageProvider languageProvider, LocalizationProvider localizationProvider)
        {
            _languageProvider = languageProvider;
            _localizationProvider = localizationProvider;
        }

        public string Localize(string translationKey, params object[] args)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            var language = _languageProvider.GetLanguageByCulture(currentCulture);
            if (language != null)
            {
                var stringResource = _localizationProvider.GetTranslation(translationKey, language.Id);
                if (stringResource == null || string.IsNullOrEmpty(stringResource.Value))
                {
                    return translationKey;
                }

                return (args == null || args.Length == 0)
                    ? stringResource.Value
                    : string.Format(stringResource.Value, args);
            }

            return translationKey;
        }

        public void TranslatedInvalidModelState(ModelStateDictionary modelState)
        {
            foreach (var entry in modelState)
            {
                var error = entry.Value.Errors.FirstOrDefault();
                if (!string.IsNullOrEmpty(error?.ErrorMessage))
                {
                    var translatedErrorMessage = Localize(error.ErrorMessage);

                    if (translatedErrorMessage != null)
                    {
                        var translatedError = new ModelError(translatedErrorMessage);
                        entry.Value.Errors.Clear();
                        entry.Value.Errors.Add(translatedError);
                    }
                }
            }
        }
    }
}
