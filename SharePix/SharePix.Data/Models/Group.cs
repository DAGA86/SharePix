using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Models
{
    public class Group
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int OwnerId { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }
        public UserAccount Owner { get; set; }

    }
}
