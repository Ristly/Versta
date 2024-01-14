using Microsoft.Extensions.Primitives;
using VerstaWebApp.Models;

namespace VerstaWebApp.Services
{
    public interface IOrdersApiService
    {
        Task<bool> CreateOrderAsync(OrderDTO orderDTO);
        Task<Order> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetOrdersAsync();
    }
}