using Enoca.Application.Dto.CarrierReport;
using Enoca.Application.Dto.Order;
using Enoca.Application.Result;
using Enoca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Services
{
    public interface IOrderService
    {
        Task<IResult> CreateOrderAsync(CreateOrderDto model);
        Task<IDataResult<List<GetOrderDto>>> GetAllOrderAsync(Expression<Func<Order, bool>> filter = null);
        Task<IDataResult<GetOrderDto>> GetOrderAsync(Expression<Func<Order, bool>> filter);
        Task<IResult> DeleteOrderById(int id);
        Task<IResult> UpdateOrderAsync(UpdateOrderDto model);
        Task<List<CreateCarrierReportDto>> GetAllOrderGroupByDateAndCarrier();
    }
}
