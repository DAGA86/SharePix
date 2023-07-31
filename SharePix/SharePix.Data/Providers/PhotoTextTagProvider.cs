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

        public bool TagExists(int tagId)
        {
            return _dbContext.PhotoTextTags.Any(x => x.TagId == tagId);
        }

        public List<PhotoTextTag> GetPhotoTextTagsByPhotoId(int photoId)
        {
            return _dbContext.PhotoTextTags.Where(x => x.PhotoId == photoId).ToList();
        }

        public PhotoTextTag Create(PhotoTextTag photoTextTag)
        {
            PhotoTextTag existingTag = _dbContext.PhotoTextTags.FirstOrDefault(x => x.PhotoId == photoTextTag.PhotoId && x.TagId == photoTextTag.TagId);

            if (existingTag == null)

                _dbContext.PhotoTextTags.Add(photoTextTag);
            _dbContext.SaveChanges();

            return photoTextTag;

        }

        public void Delete(PhotoTextTag photoTextTag)
        {
            _dbContext.PhotoTextTags.Remove(photoTextTag);
            _dbContext.SaveChanges();
        }
    }
}
