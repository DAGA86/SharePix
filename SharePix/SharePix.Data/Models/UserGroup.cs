using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Models
{
    public class UserGroup
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }

        public Group Group { get; set; }
        public UserAccount User { get; set; }
    }
}
