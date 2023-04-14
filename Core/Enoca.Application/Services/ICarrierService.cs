using Enoca.Application.Dto.Carrier;
using Enoca.Application.Dto.CarrierConfiguration;
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
    public interface ICarrierService
    {
        Task<IResult> CreateCarrierAsync(CreateCarrierDto model);
        Task<IDataResult<List<GetCarrierDto>>> GetAllCarrierAsync(Expression<Func<Carrier, bool>> filter=null);
        Task<IDataResult<GetCarrierDto>> GetCarrierAsync(Expression<Func<Carrier,bool>> filter);
        Task<IResult> DeleteCarrierById(int id);
        Task<IResult> UpdateCarrierAsync(UpdateCarrierDto model);

        Task<IResult> CreateCarrierConfigurationAsync(CreateCarrierConfigurationDto model);
        Task<IDataResult<List<GetCarrierConfigurationDto>>> GetAllCarrierConfigurationAsync(Expression<Func<CarrierConfiguration, bool>> filter=null);
        Task<IDataResult<GetCarrierConfigurationDto>> GetCarrierConfigurationAsync(Expression<Func<CarrierConfiguration, bool>> filter);
        Task<IResult> DeleteCarrierConfigurationById(int id);
        Task<IResult> UpdateCarrierConfigurationAsync(UpdateCarrierConfigurationDto model);

    }
}
