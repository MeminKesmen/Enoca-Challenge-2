using AutoMapper;
using Enoca.Application.Dto.CarrierReport;
using Enoca.Application.Repositories.CarrierReport;
using Enoca.Application.Services;
using Enoca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence.Services
{
    public class CarrierResportService : ICarrierReportService
    {
        private ICarrierReportWriteRepository _carrierReportWriteRepository;
        private IMapper _mapper;
        public CarrierResportService(ICarrierReportWriteRepository carrierReportWriteRepository, IMapper mapper)
        {
            _carrierReportWriteRepository = carrierReportWriteRepository;
            _mapper = mapper;
        }

        public async Task CreateCarrierReportAsync(CreateCarrierReportDto model)
        {
            var carrierReport = _mapper.Map<CarrierReport>(model);
            await _carrierReportWriteRepository.AddAsync(carrierReport);
            await _carrierReportWriteRepository.SaveAsync();
        }
        public async Task CreateCarrierReportAsync(List<CreateCarrierReportDto> modelList)
        {
            var carrierReport = _mapper.Map<List<CarrierReport>>(modelList);
            await _carrierReportWriteRepository.AddRangeAsync(carrierReport);
            await _carrierReportWriteRepository.SaveAsync();
        }
    }
}
