using Repositories;
using Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddControllers();
var app = builder.Build();

app.Run();

