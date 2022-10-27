using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderServiceGateway;
using OrderServiceGateway.DbContexts;
using OrderServiceGateway.Interfaces;
using OrderServiceGateway.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add DB Connection
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"));
});

// Add Mapping Config.
// Auto Mapper Configurations
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddControllers();

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
