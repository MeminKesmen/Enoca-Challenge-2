using AutoMapper;
using Enoca.Application.CQRS.Commands.Carrier.CreateCarrier;
using Enoca.Application.CQRS.Commands.Carrier.DeleteCarrier;
using Enoca.Application.CQRS.Commands.Carrier.UpdateCarrier;
using Enoca.Application.CQRS.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using Enoca.Application.CQRS.Commands.CarrierConfiguration.DeleteCarrierConfiguration;
using Enoca.Application.CQRS.Commands.CarrierConfiguration.UpdateCarrierConfiguration;
using Enoca.Application.CQRS.Commands.Order.CreateOrder;
using Enoca.Application.CQRS.Commands.Order.DeleteOrder;
using Enoca.Application.CQRS.Commands.Order.UpdateOrder;
using Enoca.Application.Dto.Carrier;
using Enoca.Application.Dto.CarrierConfiguration;
using Enoca.Application.Dto.CarrierReport;
using Enoca.Application.Dto.Order;
using Enoca.Application.Result;
using Enoca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Carrier
            CreateMap<CreateCarrierCommandRequest, CreateCarrierDto>().ReverseMap();
            CreateMap<CreateCarrierDto, Carrier>().ReverseMap();
            CreateMap<IResult, CreateCarrierCommandResponse>().ReverseMap();

            CreateMap<IResult, DeleteCarrierCommandResponse>().ReverseMap();

            CreateMap<UpdateCarrierCommandRequest, UpdateCarrierDto>().ReverseMap();
            CreateMap<UpdateCarrierDto, Carrier>().ReverseMap();
            CreateMap<IResult, UpdateCarrierCommandResponse>().ReverseMap();

            CreateMap<Carrier, GetCarrierDto>().ReverseMap();

            //Carrier Config
            CreateMap<CreateCarrierConfigurationCommandRequest, CreateCarrierConfigurationDto>().ReverseMap();
            CreateMap<CreateCarrierConfigurationDto, CarrierConfiguration>().ReverseMap();
            CreateMap<IResult, CreateCarrierConfigurationCommandResponse>().ReverseMap();

            CreateMap<IResult, DeleteCarrierConfigurationCommandResponse>().ReverseMap();

            CreateMap<UpdateCarrierConfigurationCommandRequest, UpdateCarrierConfigurationDto>().ReverseMap();
            CreateMap<UpdateCarrierConfigurationDto, CarrierConfiguration>().ReverseMap();
            CreateMap<IResult, UpdateCarrierConfigurationCommandResponse>().ReverseMap();

            CreateMap<CarrierConfiguration, GetCarrierConfigurationDto>().ReverseMap();

            //Order
            CreateMap<CreateOrderCommandRequest, CreateOrderDto>().ReverseMap();
            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<IResult, CreateOrderCommandResponse>().ReverseMap();

            CreateMap<IResult, DeleteOrderCommandResponse>().ReverseMap();

            CreateMap<UpdateOrderCommandRequest, UpdateOrderDto>().ReverseMap();
            CreateMap<UpdateOrderDto, Order>().ReverseMap();
            CreateMap<IResult, UpdateOrderCommandResponse>().ReverseMap();

            CreateMap<Order, GetOrderDto>().ReverseMap();

            //Carrier Report
            CreateMap<CreateCarrierReportDto, CarrierReport>().ReverseMap();
        }
    }
}
