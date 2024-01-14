
using Microsoft.EntityFrameworkCore;
using VerstaWebApi.Contexts;
using VerstaWebApi.Models;
using VerstaWebApi.Models.Wrapper;
using VerstaWebApi.Resources;

namespace VerstaWebApi.Services;

public class OrdersService : IOrdersService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _contextAccessor;
    public OrdersService(ApplicationDbContext context, IHttpContextAccessor contextAccessor) 
    { 
        _context = context;
        _contextAccessor = contextAccessor;
    }

    public async Task<Result> CreateOrderAsync(OrderDTO order)
    {    
        try
        {
            var createdOrder = new Order()
            {
                SenderCity = order.SenderCity,
                SenderAddress = order.SenderAddress,
                ReceiverCity = order.ReceiverCity,
                ReceiverAddress = order.ReceiverAddress,
                ReceiveDate = order.ReceiveDate,
                Weight = order.Weight,
            };
            _context.Orders.Add(createdOrder);
            await _context.SaveChangesAsync();
            createdOrder.OrderNumber = createdOrder.Id.ToString();
            await _context.SaveChangesAsync();
            var res = Result.Success(ResponseMessage.OrderCreationSuccess);
            _contextAccessor.HttpContext.Response.StatusCode = res.Status;
            return res;
        }
        catch(DbUpdateException ex)
        {     
#if DEBUG
            var res = Result.Fail(ex.Message, StatusCodes.Status500InternalServerError);
#else
            var res = Result.Fail(ResponseMessage.ServerError, StatusCodes.Status500InternalServerError);
#endif
            _contextAccessor.HttpContext.Response.StatusCode = res.Status;
            return res;
        }
    }

    public async Task<Result<Order>> GetOrderByIdAsync(string id)
    {
        try
        {
            var result = await _context.Orders.FirstOrDefaultAsync(x=>x.Id.ToString()== id);
            
            if(result is null)
                throw new KeyNotFoundException();

            var res = Result<Order>.Success(ResponseMessage.DataRequestSuccess, result);
            _contextAccessor.HttpContext.Response.StatusCode = res.Status;

            return res;
        }
        catch (KeyNotFoundException)
        {
            var res = Result<Order>.Fail(ResponseMessage.OrderNotFound, null, StatusCodes.Status404NotFound);
            _contextAccessor.HttpContext.Response.StatusCode = res.Status;

            return res;
        }
        catch (ArgumentOutOfRangeException)
        {
            var res = Result<Order>.Fail(ResponseMessage.ArgumentOutOfRange, null, StatusCodes.Status400BadRequest);
            _contextAccessor.HttpContext.Response.StatusCode = res.Status;

            return res;
        }
    }

    public async Task<Result<IEnumerable<Order>>> GetOrdersAsync()
    {
        try
        {
            var result = await _context.Orders.ToListAsync();

            var res = Result<IEnumerable<Order>>.Success("Data requested", result);
            _contextAccessor.HttpContext.Response.StatusCode = res.Status;

            return res;
        }   
        catch (ArgumentOutOfRangeException)
        {

            var res = Result<IEnumerable<Order>>.Fail(ResponseMessage.ArgumentOutOfRange, null, StatusCodes.Status400BadRequest);
            _contextAccessor.HttpContext.Response.StatusCode = res.Status;

            return res;
        }
    }
}
