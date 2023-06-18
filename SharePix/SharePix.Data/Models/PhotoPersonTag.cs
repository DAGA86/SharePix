using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Models
{
    public class PhotoPersonTag
    {
        public int PhotoId { get; set; }
        public int PersonId { get; set; }

        public UserAccount Person { get; set; }
        public Photo Photo { get; set; }

    }
}
