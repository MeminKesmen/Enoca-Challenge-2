using Enoca.Application.Services;
using Enoca.HangFire.RecurringJobs;
using Hangfire;

namespace Enoca.HangFire.Schedules
{
    public static class RecurringJobs
    {
        [Obsolete]
        public static void HourlyCarrierReportOperation()
        {
            
            /*  RemoveIfExists yöntemini çağırarak var olan yinelenen bir işi kaldırabilirsiniz. 
                Böyle tekrar eden bir iş olmadığında bir istisna oluşturmaz */
            //database manuel oluşturmadan hata veriyor.İçi boş bir database oluştur.
            RecurringJob.RemoveIfExists(nameof(CarrierReport));
            RecurringJob.AddOrUpdate<CarrierReport>(nameof(CarrierReport),
                job => job.Process(), Cron.Hourly, TimeZoneInfo.Local);
        }
    }
}
