using Models;

namespace Repositories.Interfaces;

public interface IPromoCodeRepository
{
    Task<PromoCode?> GetPromoCodeAsync(string code);
}