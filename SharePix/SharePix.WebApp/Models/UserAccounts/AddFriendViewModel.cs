using SharePix.WebApp.Models.Albums;
using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.UserAccounts
{
    public class AddFriendViewModel
    {
        public string Email { get; set; }

        public List<RequestFriendsViewModel>? RequestFriends { get; set; }
        public List<FriendsViewModel>? Friends { get; set; }

}

    public class RequestFriendsViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }

    }

    public class FriendsViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }

    }
}
