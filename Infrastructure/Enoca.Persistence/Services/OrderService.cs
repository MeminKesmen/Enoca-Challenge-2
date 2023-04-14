using AutoMapper;
using Enoca.Application.Constans;
using Enoca.Application.Dto.CarrierReport;
using Enoca.Application.Dto.Order;
using Enoca.Application.Repositories.Carrier;
using Enoca.Application.Repositories.CarrierConfiguration;
using Enoca.Application.Repositories.Order;
using Enoca.Application.Result;
using Enoca.Application.Services;
using Enoca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace Enoca.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierWriteRepository _carrierWriteRepository;
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;
        private readonly IMapper _mapper;

        public OrderService(ICarrierReadRepository carrierReadRepository, ICarrierWriteRepository carrierWriteRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, IMapper mapper)
        {
            _carrierReadRepository = carrierReadRepository;
            _carrierReadRepository = carrierReadRepository;
            _carrierWriteRepository = carrierWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _mapper = mapper;
        }
        public async Task<IResult> CreateOrderAsync(CreateOrderDto model)
        {
            var carrierConfigControl = await _carrierConfigurationReadRepository.Queryable().Where(cc => cc.Carrier.CarrierIsActive).AnyAsync();
            if (!carrierConfigControl) { return new ErrorResult(Message.CarrierConfigurationNotFound); }
            var order = _mapper.Map<Order>(model);

            var carrierConfig = await _carrierConfigurationReadRepository.Queryable()
                .Where(cc => cc.CarrierMinDesi <= model.OrderDesi && cc.CarrierMaxDesi >= model.OrderDesi&&cc.Carrier.CarrierIsActive)
                .OrderBy(cc => cc.CarrierCost).FirstOrDefaultAsync();
            if (carrierConfig != null)
            {
                order.CarrierId = carrierConfig.CarrierId;
                order.OrderCarrierCost = carrierConfig.CarrierCost;
            }
            else
            {
                var minCarrierConfig = _carrierConfigurationReadRepository.Queryable().Where(cc=>cc.Carrier.CarrierIsActive).OrderBy(cc => cc.CarrierMinDesi).FirstOrDefault();
                if (model.OrderDesi < minCarrierConfig.CarrierMinDesi)
                {
                    order.CarrierId = minCarrierConfig.CarrierId;
                    order.OrderCarrierCost = minCarrierConfig.CarrierCost;
                }
                else
                {
                    var maxCarrierConfig = _carrierConfigurationReadRepository.Queryable().Where(cc => cc.Carrier.CarrierIsActive).Include(cc => cc.Carrier).OrderByDescending(cc => cc.CarrierMaxDesi).FirstOrDefault();
                    order.CarrierId = maxCarrierConfig.CarrierId;
                    order.OrderCarrierCost = maxCarrierConfig.CarrierCost + ((order.OrderDesi - maxCarrierConfig.CarrierMaxDesi) * maxCarrierConfig.Carrier.CarrierPlusDesiCost);
                }

            }

            await _orderWriteRepository.AddAsync(order);
            var result = await _orderWriteRepository.SaveAsync();
            if (result <= 0)
            {
                return new ErrorResult(Message.OrderCreatedIsFailed);
            }

            return new SuccessResult(Message.OrderCreatedIsSuccess);
        }

        public async Task<IResult> DeleteOrderById(int id)
        {
            var order = await _orderReadRepository.GetAsync(o => o.Id == id);
            if (order == null) { return new ErrorResult(Message.OrderNotFound); }
            await _orderWriteRepository.RemoveAsync(c => c.Id == id);
            var result = await _orderWriteRepository.SaveAsync();
            if (result <= 0)
            {
                return new ErrorResult(Message.OrderDeletedIsFailed);
            }
            return new SuccessResult($"{id} Id'li " + Message.OrderDeletedIsSuccess);
        }

        public async Task<IDataResult<List<GetOrderDto>>> GetAllOrderAsync(Expression<Func<Order, bool>> filter = null)
        {
            var result = await _orderReadRepository.GetAllAsync(filter);
            
            if (result == null || result.Count() == 0)
            {
                return new ErrorDataResult<List<GetOrderDto>>(data: new List<GetOrderDto>(), message: Message.OrderNotFound);
            }
            var list = _mapper.Map<List<GetOrderDto>>(result);
            return new SuccessDataResult<List<GetOrderDto>>(data: list, message: Message.OrderFound);
        }
        //HangFire
        public async Task<List<CreateCarrierReportDto>> GetAllOrderGroupByDateAndCarrier()
        {
            //var groupedOrders = from order in _orderReadRepository.Table
            //                    group order by new { order.CarrierId, order.OrderDate } into g
            //                    select new CreateCarrierReportDto
            //                    {
            //                        CarrierId = g.Key.CarrierId,
            //                        CarrierCost = g.Sum(o => o.OrderCarrierCost)

            //                    };
            var carrierReportList = _orderReadRepository.Queryable().GroupBy(o => new { o.CarrierId, o.OrderDate.Date })
                        .Select(g => new CreateCarrierReportDto
                        {
                            CarrierId = g.Key.CarrierId,
                            CarrierCost = g.Sum(o => o.OrderCarrierCost),
                            OrderDate = g.Key.Date
                        }).ToList();
            return carrierReportList;
        }

        public async Task<IDataResult<GetOrderDto>> GetOrderAsync(Expression<Func<Order, bool>> filter)
        {
            var result = await _orderReadRepository.GetAsync(filter);
            if (result == null)
            {
                return new ErrorDataResult<GetOrderDto>(data: new GetOrderDto(), message: Message.OrderNotFound);
            }
            return new SuccessDataResult<GetOrderDto>(Message.OrderFound);
        }

        public Task<IResult> UpdateOrderAsync(UpdateOrderDto model)
        {
            throw new NotImplementedException();
        }
    }
}
