using Microsoft.AspNetCore.Mvc;
using VerstaWebApi.Models;
using VerstaWebApi.Services;

namespace VerstaWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrdersService _ordersService;
    public OrdersController(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    [HttpOptions]
    public IActionResult Empty()
    {
        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync()
        => new JsonResult(await _ordersService.GetOrdersAsync());



    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderByIdAsync(string id)
        => new JsonResult(await _ordersService.GetOrderByIdAsync(id));


    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync([FromBody] OrderDTO order)
        => new JsonResult(await _ordersService.CreateOrderAsync(order));
}
