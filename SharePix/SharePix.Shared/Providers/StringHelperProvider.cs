using System.Globalization;
using System.Text;

namespace Oishi.Shared.Providers
{
    public static class StringHelperProvider
    {
        public static string RemoveDiacriticsAndSpaces(string text)
        {
            var newString = text.Replace(" ", "");
            newString = newString.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: newString.Length);

            for (int i = 0; i < newString.Length; i++)
            {
                char c = newString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
    }
}
