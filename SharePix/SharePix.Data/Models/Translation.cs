using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Models
{
    public class Translation
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int? LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
