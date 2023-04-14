using Enoca.Application.Dto.CarrierReport;
using Enoca.Application.Repositories.Order;
using Enoca.Application.Services;

namespace Enoca.HangFire.RecurringJobs
{
    public class CarrierReport
    {
        private readonly IOrderService _orderService;
        private readonly ICarrierReportService _carrierReportService;
        public CarrierReport(IOrderService orderService, ICarrierReportService carrierReportService)
        {
            _orderService = orderService;
            _carrierReportService = carrierReportService;
        }

        public async Task Process()
        {
            //kayıt kontrol
            var reportList = await _orderService.GetAllOrderGroupByDateAndCarrier();
            if (reportList != null || reportList.Count > 0)
            {
                await _carrierReportService.CreateCarrierReportAsync(reportList);
            }

        }
    }
}
