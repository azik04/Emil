using StadiumRent.DAL.Interfaces;
using StadiumRent.Domain.Entity;
using StadiumRent.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumRent.BLL.Interfaces
{
    public interface IStadiumServices
    {
        BaseResponse<List<Stadium>> GetAll();
        Task<IBaseResponse<bool>> DeleteAsync(int id);
        Task<IBaseResponse<Stadium>> CreateAsync(Stadium model);
        Task<IBaseResponse<Stadium>> UpdateAsync(int id, Stadium model);
    }
}
