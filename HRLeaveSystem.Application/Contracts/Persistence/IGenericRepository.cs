using HRLeaveSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveSystem.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task CreateAsync(T entity);
        
    }


}
