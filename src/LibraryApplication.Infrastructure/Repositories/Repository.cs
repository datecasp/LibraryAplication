using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using LibraryApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<TEntity> Add(TEntity entity)
        {
            DbSet.AddAsync(entity);
            Db.SaveChanges();
            return entity;
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            var libro = await DbSet.FindAsync(id);

            if (libro == null)
            {
                return null;
            }

            return libro;
        }

        public async Task<bool> Update(TEntity entity)
        {
            if (EntityExists(entity)) 
            {
                DbSet.Update(entity);
                await SaveChanges();
                return true;
            }
            else { return false; }
        }

        public async Task Remove(TEntity entity)
        {
            if (EntityExists(entity))
            {
                DbSet.Remove(entity);
            }
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        private bool EntityExists(TEntity entity) 
        {
            return DbSet.Any(e => e.Id == entity.Id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
