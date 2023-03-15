using OwnaTechnical.Application.Services;
using OwnaTechnical.Domain.Interfaces;
using OwnaTechnical.Domain.Orders;
using OwnaTechnical.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services
	.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<OrderService>();

var app = builder.Build();

// Usually this is removed from Production, but I left it in to give a summary of the API
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
