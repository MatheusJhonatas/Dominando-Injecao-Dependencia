namespace Services.Interfaces;

public interface IDeliveryFeeService
{
    Task<decimal> GetDeliverFeeAsync(string zipCode);
}