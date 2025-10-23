using Dominando_Injecao_Depencia.Configuration;
using Dominando_Injecao_Depencia.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Configuration>();
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSqlConnection(connStr);
builder.Services.AddControllers();
var app = builder.Build();

app.Run();

