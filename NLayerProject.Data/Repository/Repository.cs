using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Repositories;

namespace NLayerProject.Data.Repository
{
    public class Repository <TEntity>:IRepository<TEntity> where TEntity:class
    {
        public readonly DbContext _context;
        public readonly DbSet<TEntity> _DbSet;


        public Repository(DbContext context)
        {
            _context = context;
            _DbSet = context.Set<TEntity>();

        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await _DbSet.FindAsync(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _DbSet.SingleOrDefaultAsync(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _DbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _DbSet.AddRangeAsync(entities);
        }

        public void Remove(TEntity entity)
        {
            _DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
           _DbSet.RemoveRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            //Çok sütünlu tablolarda bu kodu eklemek lazım.
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}