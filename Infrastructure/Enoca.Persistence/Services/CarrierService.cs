using AutoMapper;
using Enoca.Application.Constans;
using Enoca.Application.Dto.Carrier;
using Enoca.Application.Dto.CarrierConfiguration;
using Enoca.Application.Repositories.Carrier;
using Enoca.Application.Repositories.CarrierConfiguration;
using Enoca.Application.Result;
using Enoca.Application.Services;
using Enoca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence.Services
{
    public class CarrierService : ICarrierService
    {
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierWriteRepository _carrierWriteRepository;
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;
        private readonly IMapper _mapper;

        public CarrierService(ICarrierReadRepository carrierReadRepository, ICarrierWriteRepository carrierWriteRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository, IMapper mapper)
        {
            _carrierReadRepository = carrierReadRepository;
            _carrierReadRepository = carrierReadRepository;
            _carrierWriteRepository = carrierWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateCarrierAsync(CreateCarrierDto model)
        {
            var carrier = _mapper.Map<Carrier>(model);
            await _carrierWriteRepository.AddAsync(carrier);
            var result = await _carrierWriteRepository.SaveAsync();
            if (result <= 0)
            {
                return new ErrorResult(Message.CarrierCreatedIsFailed);
            }
            return new SuccessResult(Message.CarrierCreatedIsSuccess);
        }

        public async Task<IResult> CreateCarrierConfigurationAsync(CreateCarrierConfigurationDto model)
        {
            var carrier = await _carrierReadRepository.GetAsync(c => c.Id == model.CarrierId);
            if (carrier == null) { return new ErrorResult(Message.CarrierNotFound); }
            var carrierConfig = _mapper.Map<CarrierConfiguration>(model);
            await _carrierConfigurationWriteRepository.AddAsync(carrierConfig);
            var result = await _carrierConfigurationWriteRepository.SaveAsync();
            if (result <= 0)
            {
                return new ErrorResult(Message.CarrierConfigurationCreatedIsFailed);
            }
            return new SuccessResult(Message.CarrierConfigurationCreatedIsSuccess);
        }

        public async Task<IResult> DeleteCarrierById(int id)
        {
            var carrier = await _carrierReadRepository.GetAsync(c => c.Id == id);
            if (carrier == null) { return new ErrorResult(Message.CarrierNotFound); }
            await _carrierWriteRepository.RemoveAsync(c => c.Id == id);
            var result = await _carrierWriteRepository.SaveAsync();
            if (result <= 0)
            {
                return new ErrorResult(Message.CarrierDeletedIsFailed);
            }
            return new SuccessResult($"{id} Id'li " + Message.CarrierDeletedIsSuccess);
        }

        public async Task<IResult> DeleteCarrierConfigurationById(int id)
        {
            var carrierConfiguration = await _carrierConfigurationReadRepository.GetAsync(c => c.Id == id);
            if (carrierConfiguration == null) { return new ErrorResult(Message.CarrierConfigurationNotFound); }
            await _carrierConfigurationWriteRepository.RemoveAsync(cc => cc.Id == id);
            var result = await _carrierConfigurationWriteRepository.SaveAsync();
            if (result <= 0)
            {
                return new ErrorResult(Message.CarrierConfigurationDeletedIsFailed);
            }
            return new SuccessResult($"{id} Id'li " + Message.CarrierConfigurationDeletedIsSuccess);
        }

        public async Task<IDataResult<List<GetCarrierDto>>> GetAllCarrierAsync(Expression<Func<Carrier, bool>> filter = null)
        {
            var result = await _carrierReadRepository.GetAllAsync(filter);
            if (result == null || result.Count() == 0)
            {
                return new ErrorDataResult<List<GetCarrierDto>>(data: new List<GetCarrierDto>(), message: Message.CarrierNotFound);
            }
            var list = _mapper.Map<List<GetCarrierDto>>(result);
            return new SuccessDataResult<List<GetCarrierDto>>(data: list, message: Message.CarrierFound);
        }

        public async Task<IDataResult<List<GetCarrierConfigurationDto>>> GetAllCarrierConfigurationAsync(Expression<Func<CarrierConfiguration, bool>> filter = null)
        {
            var result = await _carrierConfigurationReadRepository.GetAllAsync(filter);
            if (result == null || result.Count() == 0)
            {
                return new ErrorDataResult<List<GetCarrierConfigurationDto>>(data: new List<GetCarrierConfigurationDto>(), message: Message.CarrierConfigurationNotFound);
            }
            var list = _mapper.Map<List<GetCarrierConfigurationDto>>(result);
            return new SuccessDataResult<List<GetCarrierConfigurationDto>>(data: list, message: Message.CarrierConfigurationFound);
        }

        public async Task<IDataResult<GetCarrierDto>> GetCarrierAsync(Expression<Func<Carrier, bool>> filter)
        {
            var result = await _carrierReadRepository.GetAsync(filter);
            if (result == null)
            {
                return new ErrorDataResult<GetCarrierDto>(Message.CarrierNotFound);
            }
            return new SuccessDataResult<GetCarrierDto>(Message.CarrierFound);
        }

        public async Task<IDataResult<GetCarrierConfigurationDto>> GetCarrierConfigurationAsync(Expression<Func<CarrierConfiguration, bool>> filter)
        {
            var result = await _carrierConfigurationReadRepository.GetAsync(filter);
            if (result == null)
            {
                return new ErrorDataResult<GetCarrierConfigurationDto>(Message.CarrierConfigurationNotFound);
            }
            return new SuccessDataResult<GetCarrierConfigurationDto>(Message.CarrierConfigurationFound);
        }

        public async Task<IResult> UpdateCarrierAsync(UpdateCarrierDto model)
        {
            var carrier = await _carrierReadRepository.GetAsync(c => c.Id == model.Id,false);
            if (carrier == null) { return new ErrorResult(Message.CarrierNotFound); }
            carrier = _mapper.Map<Carrier>(model);
            _carrierWriteRepository.Update(carrier);
            var result = await _carrierWriteRepository.SaveAsync();
            if (result <= 0)
            {
                return new ErrorResult(Message.CarrierUpdatedIsFailed);
            }
            return new SuccessResult(Message.CarrierUpdatedIsSuccess);

        }

        public async Task<IResult> UpdateCarrierConfigurationAsync(UpdateCarrierConfigurationDto model)
        {
            var carrierConfiguration= await _carrierConfigurationReadRepository.GetAsync(c => c.Id == model.Id,false);
            if (carrierConfiguration == null) { return new ErrorResult(Message.CarrierConfigurationNotFound); }
            carrierConfiguration = _mapper.Map<CarrierConfiguration>(model);
            _carrierConfigurationWriteRepository.Update(carrierConfiguration);
            var result = await _carrierConfigurationWriteRepository.SaveAsync();
            if (result <= 0)
            {
                return new ErrorResult(Message.CarrierConfigurationUpdatedIsFailed);
            }
            return new SuccessResult(Message.CarrierConfigurationUpdatedIsSuccess);
        }
    }
}
