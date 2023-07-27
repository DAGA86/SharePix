using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Models
{
    public enum FriendStatus
    {
        Requested = 1,
        Approved = 2
    }

    public class Friend
    {
        public int UserAccountId { get; set; }
        public int FriendAccountId { get; set; }
        public FriendStatus Status { get; set; }

        public UserAccount UserAccount { get; set; }
        public UserAccount FriendAccount { get; set; }
    }
}
