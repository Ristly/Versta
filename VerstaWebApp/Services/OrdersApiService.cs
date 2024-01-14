using System.Text.Json;
using VerstaWebApp.Models;

namespace VerstaWebApp.Services;

public class OrdersApiService : IOrdersApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;

    public OrdersApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiUrl = configuration.GetValue<string>("OrdersApiUrl");
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        var response = await _httpClient.GetAsync(_apiUrl);
        response.EnsureSuccessStatusCode();
        var res = await response.Content.ReadFromJsonAsync<Response<IEnumerable<Order>>>();

        return res.Data;
    }
    public async Task<Order> GetOrderByIdAsync(string id)
    {
        var response = await _httpClient.GetAsync(_apiUrl + "/" + id);
        response.EnsureSuccessStatusCode();
        var res = await response.Content.ReadFromJsonAsync<Response<Order>>();

        return res.Data;
    }
    public async Task<bool> CreateOrderAsync(OrderDTO orderDTO)
    {
        var response = await _httpClient.PostAsync(_apiUrl, JsonContent.Create(orderDTO));
        response.EnsureSuccessStatusCode();


        return true;
    }



}
