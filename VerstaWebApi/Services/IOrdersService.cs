using VerstaWebApi.Models;
using VerstaWebApi.Models.Wrapper;

namespace VerstaWebApi.Services;

public interface IOrdersService
{
    public Task<Result> CreateOrderAsync(OrderDTO order);
    public Task<Result<IEnumerable<Order>>> GetOrdersAsync();
    public Task<Result<Order>> GetOrderByIdAsync(string id);
    
}
