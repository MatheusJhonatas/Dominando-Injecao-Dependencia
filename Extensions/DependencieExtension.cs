using Microsoft.Data.SqlClient;
using Repositories;
using Repositories.Interfaces;
using Services;
using Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dominando_Injecao_Depencia.Extensions;

public static class DependencieExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        //Add transient é quando queremos que uma nova instancia do objeto seja criada a cada vez que ele for requisitado, exemplo: se eu tiver 5 classes que dependem de uma mesma classe de servico, cada uma dessas classes vai receber uma nova instancia do servico.
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
        services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
    }
    public static void AddServices(this IServiceCollection services)
    {
        //Aqui é um exemplo de utilização do ServiceDescriptor para registrar um serviço com tempo de vida Transient
        services.Add(new ServiceDescriptor(//aqui ele espera 3 parametros
            typeof(IDeliveryFeeService),//tipo do serviço que estamos registrando (Abstração)
            typeof(DeliveryFeeService),//tipo da implementação do serviço (concretização)
            ServiceLifetime.Transient));// tempo de vida do serviço de acordo com um Enum (Transient, Scoped, Singleton)
    }
    public static void AddSqlConnection(this IServiceCollection services, string connectionString)
    {
        //aDD SCOPED é quando queremos que exista uma unica instancia do objeto durante toda a requisicao http, a cada escopo uma nova instancia, exemplo: se eu tiver um servico que faz acesso ao banco de dados, eu posso registrar esse servico como scoped para garantir que durante toda a requisicao http sera usada a mesma conexao com o banco de dados.
        services.AddScoped(c => new SqlConnection(connectionString));
    }
}