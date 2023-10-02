using StadiumRent.BLL.Interfaces;
using StadiumRent.Domain.Entity;
using StadiumRent.Domain.Enum;
using StadiumRent.Domain.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StadiumRent.DAL.Interfaces;

namespace StadiumRent.BLL.Implementations
{
    public class OrderService : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IBaseResponse<List<Orders>> GetAll()
        {
            try
            {
                var orders = _orderRepository.GetAll().ToList();
                if(orders == null)
                {
                    return new BaseResponse<List<Orders>>
                    {
                        Description = "Нфйдено 0 элементов",
                        StatusCode = StatusCode.NotHaveEntity,
                    };
                }
                return new BaseResponse<List<Orders>>
                {
                    Data = orders,
                    StatusCode = StatusCode.OK,
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Orders>>()
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
                var order = _orderRepository.GetAll().SingleOrDefault(x => x.Id == id);
                await _orderRepository.Delete(order);
                return new BaseResponse<bool>
                {
                    Data = true,
                    StatusCode = StatusCode.OK,
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
        public async Task<IBaseResponse<Orders>> CreateAsync(Orders model)
        {
            var orders = new Orders()
            {
                Order = model.Order,
                StadiumId =model.StadiumId,
                UserId = model.UserId,
                Created = DateTime.Now,
            };
            await _orderRepository.CreateAsync(orders);
            return new BaseResponse<Orders>
            {
                Data = orders,
                StatusCode = StatusCode.OK,
            };
        }
        public async Task<IBaseResponse<Orders>> UpdateAsync(int id, Orders model)
        {
            try
            {
                var order = _orderRepository.GetAll().SingleOrDefault(x => x.Id == id);
                if (order == null)
                {
                    return new BaseResponse<Orders>
                    {
                        Description = "Нфйдено 0 элементов",
                        StatusCode = StatusCode.NotHaveEntity,
                    };
                }
                order.Order = model.Order;
                await _orderRepository.CreateAsync(model);
                return new BaseResponse<Orders>
                {
                    Data = order,
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Orders>
                {
                    Description = $"[GetAll] : {ex.Message}",
                    StatusCode = StatusCode.ERROR
                };
            }
        }
    }
}
