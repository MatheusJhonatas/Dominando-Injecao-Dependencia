using Repositories;
using Repositories.Interfaces;
using Services;
using Services.Interfaces;

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
        services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
    }
}