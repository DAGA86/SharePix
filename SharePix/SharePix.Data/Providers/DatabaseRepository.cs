using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Crypto;
using SharePix.Data.Contexts;
using SharePix.Data.Models;
using SharePix.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Providers
{
    public class DatabaseRepository
    {
        private readonly DatabaseContext _context;

        public DatabaseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Result<List<TViewModel>> Get<TEntity, TViewModel>(
            Expression<Func<TEntity, bool>>? filterExpression,
            Expression<Func<TEntity, TViewModel>>? projection)
            where TEntity : class
        {
            Result<List<TViewModel>> result = new Result<List<TViewModel>>();
            try
            {
                IQueryable<TEntity> query = _context.Set<TEntity>();
                if (filterExpression != null) 
                {
                    query = query.Where(filterExpression);
                }
                if (projection != null)
                {
                    result.Object = query.Select(projection).ToList();
                }
                else
                {
                    result.Object = query.Cast<TViewModel>().ToList();
                }
            }
            catch (Exception exception)
            {
                result.ErrorMessage = $"{nameof(Get)} - {exception.Message}";
            }
            return result;
        }


        public List<T> GetAllFiltered<T>(Expression<Func<T, bool>> filterExpression) where T : class
        {
            return _context.Set<T>().Where(filterExpression).ToList();
        }

        //change bool to int
        public T GetFirstFiltered<T>(Expression<Func<T, bool>> filterExpression) where T : class
        {
            return _context.Set<T>().FirstOrDefault();
        }

        public void DeleteFiltered<T>(Expression<Func<T, bool>> filterExpression) where T : class
        {
            var entities = _context.Set<T>().Where(filterExpression);

            _context.Set<T>().RemoveRange(entities);

            _context.SaveChanges();
        }

        public void EditFiltered<T>(Expression<Func<T, bool>> filterExpression, Action<T> editAction) where T : class
        {
            var entities = _context.Set<T>().Where(filterExpression);

            foreach (var entity in entities)
            {
                editAction(entity);
            }

            _context.SaveChanges();
        }


    }
}
