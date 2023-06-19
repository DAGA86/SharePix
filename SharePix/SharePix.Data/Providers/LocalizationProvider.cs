using SharePix.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Providers
{
    public interface ILocalizationProvider
    {
        Translation? GetTranslation(string translationKey, int languageId);
    }

    public class LocalizationProvider : ILocalizationProvider
    {
        private readonly Contexts.DatabaseContext _dbContext;

        public LocalizationProvider(Contexts.DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Translation? GetTranslation(string translationKey, int languageId)
        {
            return _dbContext.Translations.FirstOrDefault(x =>
                    x.Key.Trim().ToLower() == translationKey.Trim().ToLower()
                    && x.LanguageId == languageId);
        }
    }
}
