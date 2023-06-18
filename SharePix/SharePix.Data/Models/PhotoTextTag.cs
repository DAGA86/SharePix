using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Models
{
    public class PhotoTextTag
    {
        public int PhotoId { get; set; }
        public int TagId { get; set; }

        public Photo Photo { get; set; }
        public TextTag Tag { get; set; }
    }
}
