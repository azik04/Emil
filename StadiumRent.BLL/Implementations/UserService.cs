using StadiumRent.Domain.Enum;
using StadiumRent.BLL.Interfaces;
using StadiumRent.DAL.Interfaces;
using StadiumRent.Domain.Entity;
using StadiumRent.Domain.Enum;
using StadiumRent.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace StadiumRent.BLL.Implementations
{
    public class UserService : IUserServices
    {
        private readonly IUserServices _userService;
        public UserService(IUserServices userService)
        {
            _userService = userService;
        }


        public  BaseResponse<List<Users>> GetAll()
        {
            try
            {
                var user = _userService.GetAll();
                if (user == null)
                {
                    return new BaseResponse<List<Users>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.NotHaveEntity
                    };
                }
                return new BaseResponse<List<Users>>()
                {
                    Data = user.Data,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Users>>()
                {
                    Description = $"[GetAll] : {ex.Message}",
                    StatusCode = StatusCode.ERROR
                };
            }
        }
        public async Task<IBaseResponse<Users>> CreateAsync(Users model)
        {
            try
            {
                var users = new Users()
                {
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    Password = model.Password,
                };
                await _userService.CreateAsync(model);
                return new BaseResponse<Users>()
                {
                    Description = "User has been created",
                    StatusCode = StatusCode.NotHaveEntity
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<Users>()
                {
                    Description = $"[GetAll] : {ex.Message}",
                    StatusCode = StatusCode.ERROR
                };
            }
        }
        public  async Task<IBaseResponse<Users>> UpdateAsync(int id, Users model)
        {
            try
            {
                var users = _userService.GetAll().SingleOrDefault(x => x.id == id);
                if (users == null)
                {
                    return new BaseResponse<Users>()
                    {
                        Description = "User is not found",
                        StatusCode = StatusCode.NotHaveEntity
                    };
                    users......
                    await _userService.UpdateAsync(model);
                    return new BaseResponse<Users>()
                    {
                        Data = users.Data,
                        StatusCode = StatusCode.OK
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<Users>()
                {
                    Description = $"[GetAll] : {ex.Message}",
                    StatusCode = StatusCode.ERROR
                };
            }
        }
        public async Task<IBaseResponse<bool>> DeleteAsync(int id)
        {
            try
            {            
                var users = _userService.GetAll().SingleOrDefault(x => x.id == id);
                if (users == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "User is not found",
                        StatusCode = StatusCode.NotHaveEntity,
                    };
                }
                await _userService.DeleteAsync(id);
                return new BaseResponse<bool>()
                {
                    Data = users.Data,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[GetAll] : {ex.Message}",
                    StatusCode = StatusCode.ERROR
                };
            }


        }
    }
}
    

