using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace BizCover.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> ListAllAsync();       
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
       
    }
}