using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Models
{
    public class TextTag
    {
        public int Id { get; set; }
        [StringLength(32)]
        public string Description { get; set; }

        public ICollection<PhotoTextTag> PhotoTextTags { get; set; }
    }
}
