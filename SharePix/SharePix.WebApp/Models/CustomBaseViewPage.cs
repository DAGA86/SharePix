using SharePix.Data.Providers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

public abstract class CustomBaseViewPage<TModel> : Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>
{
    [RazorInject]
    public LanguageProvider LanguageProvider { get; set; }

    [RazorInject]
    public LocalizationProvider LocalizationProvider { get; set; }

    public delegate HtmlString Localizer(string translationKey, params object[] args);

    private Localizer _localizer;

    public Localizer Localize
    {
        get
        {
            if (_localizer == null)
            {
                var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

                var language = LanguageProvider.GetLanguageByCulture(currentCulture);
                if (language != null)
                {
                    _localizer = (translationKey, args) =>
                    {
                        var stringResource = LocalizationProvider.GetTranslation(translationKey, language.Id);

                        if (stringResource == null || string.IsNullOrEmpty(stringResource.Value))
                        {
                            return new HtmlString(translationKey);
                        }

                        return new HtmlString((args == null || args.Length == 0)
                            ? stringResource.Value
                            : string.Format(stringResource.Value, args));
                    };
                }
            }
            return _localizer;
        }
    }
}

public abstract class CustomBaseViewPage : CustomBaseViewPage<dynamic>
{ }