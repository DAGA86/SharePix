using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Crypto;
using SharePix.Data.Contexts;
using SharePix.Data.Models;
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


        public List<T> GetAllFiltered<T>(Expression<Func<T, bool>> filterExpression) where T : class
        {
            return _context.Set<T>().Where(filterExpression).ToList();
        }

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
