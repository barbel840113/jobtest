using BizCover.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace BizCover.ApplicationCore.Services
{
    public class EfRepostiory<T> : IRepository<T>, IAsyncRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public EfRepostiory(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public T Add(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
            this._dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual T GetById(Guid id)
        {
            return this._dbContext.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await this._dbContext.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> ListAll()
        {
            return this._dbContext.Set<T>().AsEnumerable();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await this._dbContext.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
            this._dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
        }
    }
}
