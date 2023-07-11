using SharePix.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Providers
{
    public class AlbumProvider: DatabaseRepository
    {
        private Contexts.DatabaseContext _dbContext;

        public AlbumProvider(Contexts.DatabaseContext dbContext) : base(dbContext) //? base
        {
            _dbContext = dbContext;
        }

        public Album Create(Album item)
        {
            item.CreateDate = DateTime.Now;
            _dbContext.Albuns.Add(item);
            _dbContext.SaveChanges();

            return item;
        }

        public Album Update(Album album)
        {
            Models.Album? updateAlbum = _dbContext.Albuns.FirstOrDefault(x => x.Id == album.Id);
            if (updateAlbum != null)
            {
                updateAlbum.Name = album.Name;
                updateAlbum.Description = album.Description;
       
                _dbContext.SaveChanges();
            }
            return album;

        }

    }
}
