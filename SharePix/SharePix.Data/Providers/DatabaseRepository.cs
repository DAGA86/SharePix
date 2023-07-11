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

        private IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>>? filterExpression,
            Expression<Func<TEntity, object>>[]? sortExpressions,
            int? limit = null,
            int? skip = null)
            where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filterExpression != null)
                query = query.Where(filterExpression);

            if (sortExpressions != null && sortExpressions.Length > 0)
            {
                foreach (var sortExpression in sortExpressions)
                {
                    query = ApplySort(query, sortExpression);
                }
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (limit.HasValue)
            {
                query = query.Take(limit.Value);
            }

            return query;
        }

        public Result<List<TViewModel>> Get2<TEntity, TViewModel>(
            Expression<Func<TEntity, TViewModel>> projection,
            Expression<Func<TEntity, bool>>? filterExpression,
            Expression<Func<TEntity, object>>[]? sortExpressions,
            int? limit = null,
            int? skip = null)
            where TEntity : class
        {
            Result<List<TViewModel>> result = new Result<List<TViewModel>>();
            try
            {
                result.Object = GetQueryable(filterExpression, sortExpressions, limit, skip).Select(projection).ToList();
            }
            catch (Exception exception)
            {
                result.ErrorMessage = $"{nameof(Get)} - {exception.InnerException}";
            }
            return result;
        }

        public Result<List<TEntity>> Get2<TEntity>(
            Expression<Func<TEntity, bool>>? filterExpression,
            Expression<Func<TEntity, object>>[]? sortExpressions,
            int? limit = null,
            int? skip = null)
            where TEntity : class
        {

            Result<List<TEntity>> result = new Result<List<TEntity>>();
            try
            {
                result.Object = GetQueryable(filterExpression, sortExpressions, limit, skip).ToList();
            }
            catch (Exception exception)
            {
                result.ErrorMessage = $"{nameof(Get)} - {exception.InnerException}";
            }
            return result;
        }

        private IQueryable<TEntity> ApplySort<TEntity>(IQueryable<TEntity> query, Expression<Func<TEntity, object>> sortExpression)
        {
            if (sortExpression.Body is MemberExpression memberExpression)
            {
                var parameter = sortExpression.Parameters[0];
                var keySelector = Expression.Lambda(memberExpression, parameter);

                var orderByExpression = Expression.Call(
                    typeof(Queryable),
                    "OrderBy",
                    new[] { typeof(TEntity), memberExpression.Type },
                    query.Expression,
                    Expression.Quote(keySelector)
                );

                return query.Provider.CreateQuery<TEntity>(orderByExpression);
            }

            return query;
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

        public Result<List<TEntity>> Get<TEntity>(
            Expression<Func<TEntity, bool>>? filterExpression,
            Expression<Func<TEntity, TEntity>>? projection)
            where TEntity : class
        {
            Result<List<TEntity>> result = new Result<List<TEntity>>();
            try
            {
                IQueryable<TEntity> query = _context.Set<TEntity>();
                if (filterExpression != null)
                {
                    query = query.Where(filterExpression);
                }
                if (projection != null)
                {
                    query = query.Select(projection);
                }
                result.Object = query.ToList();
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
            return _context.Set<T>().FirstOrDefault(filterExpression);
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
