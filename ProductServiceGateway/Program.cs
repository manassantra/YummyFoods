using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductServiceGateway;
using ProductServiceGateway.DbContexts;
using ProductServiceGateway.Interfaces;
using ProductServiceGateway.Services;

var builder = WebApplication.CreateBuilder(args);

// Add All services to the container.
// Connect DB
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"));
});

// Auto Mapper Configurations
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

/*builder.Services.AddAuthentication()*/

/*builder.Services.AddAuthorization();*/

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
