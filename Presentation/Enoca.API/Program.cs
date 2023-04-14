
using Enoca.Application;
using Enoca.Application.Validators.Carrier;
using Enoca.Persistence;
using Enoca.Persistence.Attributes;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();


builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
                 .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateCarrierCommandValidator>())
                  .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




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

app.Run();
