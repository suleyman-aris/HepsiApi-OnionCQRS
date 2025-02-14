using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Interface.Repositories;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;
        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enebleTracking = false)
        {
            IQueryable<T> quaryeble = Table;
            if (!enebleTracking) quaryeble = quaryeble.AsNoTracking();
            if (include is not null) quaryeble = include(quaryeble);
            if (predicate is not null) quaryeble = quaryeble.Where(predicate);
            if (orderBy is not null)
                return await orderBy(quaryeble).ToListAsync();

            return await quaryeble.ToListAsync();
        }

        public async Task<List<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enebleTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> quaryeble = Table;
            if (!enebleTracking) quaryeble = quaryeble.AsNoTracking();
            if (include is not null) quaryeble = include(quaryeble);
            if (predicate is not null) quaryeble = quaryeble.Where(predicate);
            if (orderBy is not null)
                return await orderBy(quaryeble).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            return await quaryeble.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enebleTracking = false)
        {
            IQueryable<T> quaryeble = Table;
            if (!enebleTracking) quaryeble = quaryeble.AsNoTracking();
            if (include is not null) quaryeble = include(quaryeble);

            quaryeble.Where(predicate);

            return await quaryeble.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null) Table.Where(predicate);

            return await Table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enebleTracking = false)
        {
            if (!enebleTracking) Table.AsNoTracking();
            return Table.Where(predicate);
        }




    }
}
