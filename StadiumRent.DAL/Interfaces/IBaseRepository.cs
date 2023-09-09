using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumRent.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> CreateAsync(T Entity);
        IQueryable<T> GetAll();

        Task<T> Update(T Entity);
        Task<bool> Delete(T entity);
    }
}
