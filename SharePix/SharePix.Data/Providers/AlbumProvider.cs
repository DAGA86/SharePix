using Microsoft.EntityFrameworkCore;
using SharePix.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Providers
{
    public class AlbumProvider: DatabaseRepository
    {
        private readonly Contexts.DatabaseContext _dbContext;

        public AlbumProvider(Contexts.DatabaseContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public TViewModel GetFirstById<TViewModel>(int id, Expression<Func<Album, TViewModel>> selectExpression)
        {
            return _dbContext.Albuns.Where(x => x.Id == id).Select(selectExpression).FirstOrDefault();
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
            return updateAlbum;

        }

        public bool Delete(int id)
        {
            Album? albumToDelete = _dbContext.Albuns.FirstOrDefault(x => x.Id == id);
            if (albumToDelete != null)
            {
                _dbContext.Photos.RemoveRange(_dbContext.Photos.Where(x => x.AlbumId == id));
                _dbContext.Albuns.Remove(albumToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
