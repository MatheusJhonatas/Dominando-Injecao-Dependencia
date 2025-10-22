using Models;

namespace Repositories.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(string customerId);
}