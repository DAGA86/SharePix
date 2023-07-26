using Microsoft.EntityFrameworkCore;
using SharePix.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Providers
{
    public class PhotoTextTagProvider
    {
        private Contexts.DatabaseContext _dbContext;

        public PhotoTextTagProvider(Contexts.DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PhotoTextTag Create(PhotoTextTag tag)
        {
            _dbContext.PhotoTextTags.Add(tag);
            _dbContext.SaveChanges();

            return tag;
        }
    }
}
