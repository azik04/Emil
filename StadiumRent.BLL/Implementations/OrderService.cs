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

namespace StadiumRent.BLL.Implementations
{
    public class OrderService : IOrderServices
    {
        private readonly IOrderServices _orderService;
        public OrderService (IOrderServices orderService)
        {
            _orderService = orderService;
        }
        public IBaseResponse<List<Orders>> GetAll()
        {
            try
            {
                var orders = _orderService.GetAll().Fir;
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
                    Data = orders
                }
            }

        }
    }
}
