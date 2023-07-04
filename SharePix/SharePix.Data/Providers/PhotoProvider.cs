using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Options;
using SharePix.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SharePix.Data.Providers
{
    public class PhotoProvider : DatabaseRepository
    {
        private Contexts.DatabaseContext _dbContext;

        public PhotoProvider(Contexts.DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Photo Create(Photo item)
        {
            item.UploadDate = DateTime.Now;
            _dbContext.Photos.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public Photo Update(Photo photo)
        {
            Models.Photo? updatePhoto = _dbContext.Photos.FirstOrDefault(x => x.Id == photo.Id);
            if (updatePhoto != null)
            {
                updatePhoto.Date = photo.Date;
                updatePhoto.Location = photo.Location;
                updatePhoto.Description = photo.Description;

                _dbContext.SaveChanges();
            }
            return photo;

        }
    }
}