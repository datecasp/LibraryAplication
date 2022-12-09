using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using LibraryApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly LibraryApplicationDbContext Db;

        protected readonly DbSet<TEntity> DbSet;

        protected Repository(LibraryApplicationDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public Task Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            var result = await DbSet.FindAsync(id);

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public Task Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //TODO
        }

    }
}
