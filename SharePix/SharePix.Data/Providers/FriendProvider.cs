using SharePix.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Providers
{
    public class FriendProvider : DatabaseRepository
    {
        private Contexts.DatabaseContext _dbContext;

        public FriendProvider(Contexts.DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public Friend Create(Friend friend)
        {
            friend.Status = FriendStatus.Requested;
            _dbContext.Friends.Add(friend);
            _dbContext.SaveChanges();

            return friend;
        }

        public bool Delete(int id)
        {
            Friend? friendToDelete = _dbContext.Friends.FirstOrDefault(x => x.UserAccountId == id);
            if (friendToDelete != null)
            {
                _dbContext.Friends.Remove(friendToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
