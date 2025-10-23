using Microsoft.Data.SqlClient;
using Repositories;
using Repositories.Interfaces;
using Services;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
#region AddScoped
//Add scoped sempre que for durante o ciclo de vida da requisicao a mesma instancia do objeto
builder.Services.AddScoped(c => new SqlConnection("CONN_STRING"));
#endregion
#region AddSingleton
//Add singleton sempre que for durante toda a aplicacao a mesma instancia do objeto

#endregion
#region AddTransient
//Add transient sempre que for cada requisicao uma nova instancia do objeto
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
#endregion
builder.Services.AddControllers();
var app = builder.Build();

app.Run();

