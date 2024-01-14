using Microsoft.AspNetCore.Mvc;
using VerstaWebApp.Models;
using VerstaWebApp.Services;

namespace VerstaWebApp.Controllers;

public class OrdersController : Controller
{
    private readonly IOrdersApiService _ordersApiService;

    public OrdersController(IOrdersApiService ordersApiService)
    {
        _ordersApiService = ordersApiService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> AllAsync()
        => View("OrdersAll", await _ordersApiService.GetOrdersAsync());


    [HttpGet]
    public async Task<IActionResult> CreateAsync()
        => View("Create", new OrderDTO());


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] OrderDTO orderDTO)
    {
        if(!ModelState.IsValid)
            return View();
        
        if(await _ordersApiService.CreateOrderAsync(orderDTO))
        {
            return RedirectToAction("All");
        }
        else
        { 
            return BadRequest();
        }
    }

    public async Task<IActionResult> GetByIdAsync(string id)
        => View("Order", await _ordersApiService.GetOrderByIdAsync(id));
}
