using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Repository
{
    public interface IRepository
    {
        public interface IRepository<TEntity, TKey, TDataContext> where TEntity : class where TDataContext : DbContext
        {
            Task AddAsync(TEntity entity);

            Task UpdateAsync(TEntity entity);

            Task DeleteAsync(TKey key);

            IQueryable<TEntity> GetAll();

            Task<TEntity> GetByIdAsync(TKey key);
        }
    }
}
