using Enoca.Application;
using Enoca.Application.Services;
using Enoca.HangFire.Schedules;
using Enoca.Persistence;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

//var serviceProvider = builder.Services.BuildServiceProvider();
//var _orderService = serviceProvider.GetService<IOrderService>(); 
//var _carrierReportService = serviceProvider.GetService<ICarrierReportService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Hangfire
//var connectionStr = builder.Configuration["HangfireSettings:ConnectionStr"];
builder.Services.AddHangfire(x => x.UseSqlServerStorage(Configuration.ConnectionString));
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard("/job", new DashboardOptions());
//Install-Package Hangfire.Dashboard.Basic.Authentication
//app.UseHangfireDashboard("/job", new DashboardOptions());
//app.UseHangfireDashboard("/job", new DashboardOptions
//{
//    Authorization = new[]
//{
//    new HangfireCustomBasicAuthenticationFilter
//    {
//         User = _configuration.GetSection("HangfireSettings:UserName").Value,
//         Pass = _configuration.GetSection("HangfireSettings:Password").Value
//    }
//    }
//});
app.UseHangfireServer(new BackgroundJobServerOptions());
//“new AutomaticRetryAttribute { Attempts = 3 }” : Tanýmlamasý ile, ilgili method baþarýlý þekilde çalýþtýrýlamaz ise, hata alýnýlmayýncaya kadar 3 defa tekrar edilmektedir.
GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 3 });
RecurringJobs.HourlyCarrierReportOperation();
app.Run();
