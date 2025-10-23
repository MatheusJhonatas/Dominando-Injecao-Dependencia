using Dominando_Injecao_Depencia.Configuration;
using Microsoft.Data.SqlClient;
using Repositories;
using Repositories.Interfaces;
using Services;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
#region AddScoped
//Add scoped é quando queremos que exista uma unica instancia do objeto durante toda a requisicao http, a cada escopo uma nova instancia, exemplo: se eu tiver um servico que faz acesso ao banco de dados, eu posso registrar esse servico como scoped para garantir que durante toda a requisicao http sera usada a mesma conexao com o banco de dados.
builder.Services.AddScoped(c => new SqlConnection("CONN_STRING"));
#endregion
#region AddSingleton
//Add singleton é usado para quando queremos que exista apenas uma unica instancia do objeto durante todo o ciclo de vida da aplicacao. Exemplo: se eu tiver uma classe de configuracao que vai armazenar algumas informacoes que serao usadas por varios servicos, eu posso registrar essa classe como singleton para garantir que todos os servicos usem a mesma instancia dessa classe.
builder.Services.AddSingleton<Configuration>();
#endregion
#region AddTransient
//Add transient é quando queremos que uma nova instancia do objeto seja criada a cada vez que ele for requisitado, exemplo: se eu tiver 5 classes que dependem de uma mesma classe de servico, cada uma dessas classes vai receber uma nova instancia do servico.
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
#endregion
builder.Services.AddControllers();
var app = builder.Build();

app.Run();

