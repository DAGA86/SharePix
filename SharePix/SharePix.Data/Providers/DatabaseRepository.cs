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

        // Método Get genérico que retorna uma lista de ViewModel (TViewModel) com base na entidade TEntity.
        // Permite filtrar e projetar os resultados usando expressões opcionais.
        public Result<List<TViewModel>> Get<TEntity, TViewModel>(
            Expression<Func<TEntity, bool>>? filterExpression = null,
            Expression<Func<TEntity, TViewModel>>? projection = null)
            where TEntity : class
        {
            // Cria uma instância de Result<List<TViewModel>> para armazenar o resultado.
            Result<List<TViewModel>> result = new Result<List<TViewModel>>();

            try
            {
                // Obtém um IQueryable<TEntity> baseado no tipo TEntity do contexto (_context).
                IQueryable<TEntity> query = _context.Set<TEntity>();

                // Se foi fornecida uma expressão de filtro, adiciona o filtro à consulta.
                if (filterExpression != null)
                {
                    query = query.Where(filterExpression);
                }

                // Verifica se foi fornecida uma expressão de projeção.
                if (projection != null)
                {
                    // Se sim, aplica a projeção e atribui os resultados ao objeto "Object" do resultado.
                    result.Object = query.Select(projection).ToList();
                }
                else
                {
                    // Se não foi fornecida uma expressão de projeção, utiliza a conversão direta (Cast) para TViewModel
                    // e atribui os resultados ao objeto "Object" do resultado.
                    result.Object = query.Cast<TViewModel>().ToList();
                }
            }
            catch (Exception exception)
            {
                // Em caso de exceção, define a mensagem de erro no resultado.
                result.ErrorMessage = $"{nameof(Get)} - {exception.Message}";
            }

            // Retorna o resultado, que contém a lista de ViewModels ou uma mensagem de erro, se houver.
            return result;
        }



        // Método Get genérico que recebe uma expressão de filtro opcional e uma expressão de projeção opcional.
        public Result<List<TEntity>> Get<TEntity>(
            Expression<Func<TEntity, bool>>? filterExpression = null,
            Expression<Func<TEntity, TEntity>>? projection = null)
            where TEntity : class
        {
            // Cria uma instância de Result<List<TEntity>> para armazenar o resultado.
            Result<List<TEntity>> result = new Result<List<TEntity>>();

            try
            {
                // Obtém um IQueryable<TEntity> baseado no tipo TEntity do contexto (_context).
                IQueryable<TEntity> query = _context.Set<TEntity>();

                // Se foi fornecida uma expressão de filtro, adiciona o filtro à consulta.
                if (filterExpression != null)
                {
                    query = query.Where(filterExpression);
                }

                // Se foi fornecida uma expressão de projeção, adiciona a projeção à consulta.
                if (projection != null)
                {
                    query = query.Select(projection);
                }

                // Executa a consulta e atribui os resultados ao objeto "Object" do resultado.
                result.Object = query.ToList();
            }
            catch (Exception exception)
            {
                // Em caso de exceção, define a mensagem de erro no resultado.
                result.ErrorMessage = $"{nameof(Get)} - {exception.Message}";
            }

            // Retorna o resultado, que contém a lista de entidades ou uma mensagem de erro, se houver.
            return result;
        }



        public T GetFirstFiltered<T>(Expression<Func<T, bool>> filterExpression) where T : class
        {
            return _context.Set<T>().FirstOrDefault(filterExpression);
        }


    }
}
