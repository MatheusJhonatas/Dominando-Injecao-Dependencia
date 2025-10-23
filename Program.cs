using Dominando_Injecao_Depencia.Configuration;
using Dominando_Injecao_Depencia.Extensions;
using Microsoft.Data.SqlClient;
using Repositories;
using Repositories.Interfaces;
using Services;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSqlConnection("CONN_STRING");
builder.Services.AddControllers();
var app = builder.Build();

app.Run();

