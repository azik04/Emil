using StadiumRent.Domain.Entity;
using StadiumRent.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumRent.BLL.Interfaces
{
    public interface IOrderServices
    {
        Task<IBaseResponse<Orders>> CreateAsync(Orders model);
        IBaseResponse<List<Orders>> GetAll();
        Task<IBaseResponse<bool>> DeleteAsync(int id);
        Task<IBaseResponse<Orders>> UpdateAsync(int id, Orders model);
    }
}
