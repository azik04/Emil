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
    public class StadiumService : IStadiumServices
      
    {
        private readonly IStadiumRepository _stadiumRepository;
        public StadiumService(IStadiumRepository stadiumRepository)
        {
            _stadiumRepository = stadiumRepository;
        }

        public BaseResponse<List<Stadium>> GetAll()
        {
            try
            {
                var stadium = _stadiumRepository.GetAll();
                if(!stadium.Any()) 
                {
                    return new BaseResponse<List<Stadium>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.NotHaveEntity, 
                    };
                }
                return new BaseResponse<List<Stadium>>()
                {
                    Data = stadium.ToList(),
                    StatusCode = StatusCode.OK,
                };


            }
            catch (Exception ex) 
            {
                return new BaseResponse<List<Stadium>>()
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
                var car =  _stadiumRepository.GetAll().SingleOrDefault( x => x.id == id);
                
                if (car == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Car not found",
                        StatusCode = StatusCode.NotHaveEntity,
                        Data = false
                    };
                }

                await _stadiumRepository.Delete(car);
              

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.NotHaveEntity
                };
            }
        }
        public async Task<IBaseResponse<Stadium>> CreateAsync(Stadium model) 
        {
            try
            {
                var stadium = new Stadium()
                {
                    name = model.name,
                    Adress = model.Adress,
                    DateCreat = DateTime.Now,
                };
                await _stadiumRepository.CreateAsync(stadium);
                return  new BaseResponse<Stadium>()
                {
                    StatusCode = StatusCode.OK,
                    Data = stadium
                };
            }

            catch (Exception ex)
            {
                return new BaseResponse<Stadium>()
                {
                    Description = $"[GetAll] : {ex.Message}",
                    StatusCode = StatusCode.ERROR
                };
            }
        }
        public async Task<IBaseResponse<Stadium>> UpdateAsync(int id, Stadium model)
        {
            try
            {
                var stadium = _stadiumRepository.GetAll().SingleOrDefault(x => x.id == id);

                if (stadium == null)
                {

                    return new BaseResponse<Stadium>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.NotHaveEntity,
                    };
                }
                stadium.Adress = model.Adress;
                stadium.name = model.name;
                await _stadiumRepository.Update(stadium);
                return new BaseResponse<Stadium>()
                {
                    Data = stadium,
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Stadium>()
                {
                    Description = $"[GetAll] : {ex.Message}",
                    StatusCode = StatusCode.ERROR
                };
            }
        }

    }
    }


