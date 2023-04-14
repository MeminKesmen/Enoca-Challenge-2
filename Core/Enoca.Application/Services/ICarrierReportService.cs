using Enoca.Application.Dto.CarrierReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Services
{
    public interface ICarrierReportService
    {
        Task CreateCarrierReportAsync(CreateCarrierReportDto model);
        Task CreateCarrierReportAsync(List<CreateCarrierReportDto> modelList);
    }
}
