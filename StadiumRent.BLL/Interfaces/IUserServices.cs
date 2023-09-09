using StadiumRent.Domain.Entity;
using StadiumRent.Domain.Response;
using StadiumRent.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumRent.BLL.Interfaces
{
    public interface IUserServices
    {
        //BaseResponse<List<Users>> GetAll();
        //Task<IBaseResponse<bool>> DeleteAsync(int id);
        //Task<IBaseResponse<Users>> CreateAsync(Users model);
        //Task<IBaseResponse<Users>> UpdateAsync(int id, Users model);
        Task<IBaseResponse<bool> LogInAsync(int id);
    }
}
