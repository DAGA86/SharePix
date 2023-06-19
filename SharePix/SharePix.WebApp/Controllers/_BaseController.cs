using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using SharePix.Data.Contexts;
using SharePix.Data.Providers;

namespace SharePix.WebApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly DatabaseContext _context;

        private readonly LanguageProvider _languageProvider;
        private readonly LocalizationProvider _localizationProvider;

        public BaseController(DatabaseContext context, LanguageProvider languageProvider, LocalizationProvider localizationProvider)
        {
            _context = context;
            _languageProvider = languageProvider;
            _localizationProvider = localizationProvider;
        }

        public HtmlString Localize(string translationKey, params object[] args)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            var language = _languageProvider.GetLanguageByCulture(currentCulture);
            if (language != null)
            {
                var stringResource = _localizationProvider.GetTranslation(translationKey, language.Id);
                if (stringResource == null || string.IsNullOrEmpty(stringResource.Value))
                {
                    return new HtmlString(translationKey);
                }

                return new HtmlString((args == null || args.Length == 0)
                    ? stringResource.Value
                    : string.Format(stringResource.Value, args));
            }

            return new HtmlString(translationKey);
        }
    }
}
