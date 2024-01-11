
using Microsoft.EntityFrameworkCore;
using VerstaWebApi.Contexts;
using VerstaWebApi.Models;
using VerstaWebApi.Models.Wrapper;

namespace VerstaWebApi.Services;

public class OrdersService : IOrdersService
{
    private readonly ApplicationDbContext _context;
    public OrdersService(ApplicationDbContext context) 
    { 
        _context = context;
    }

    public async Task<Result> CreateOrderAsync(Order order)
    {    
        try
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            order.OrderNumber = order.Id.ToString();
            await _context.SaveChangesAsync();
            return Result.Success("Order created");
        }
        catch(DbUpdateException ex)
        {
#if DEBUG
            return Result.Fail(ex.Message, StatusCodes.Status500InternalServerError);
#else
            return Result.Fail("Server error", StatusCodes.Status500InternalServerError);
#endif
        }
    }

    public async Task<Result<Order>> GetOrderByIdAsync(string id)
    {
        try
        {
            var result = await _context.Orders.FirstOrDefaultAsync(x=>x.Id.ToString()== id);
            
            if(result is null)
                throw new KeyNotFoundException();

            return Result<Order>.Success("Order created", result);
        }
        catch (KeyNotFoundException)
        {
            return Result<Order>.Fail($"Order №{id} not found", null, StatusCodes.Status404NotFound);
        }
        catch (ArgumentOutOfRangeException)
        {
            return Result<Order>.Fail("Wrong format of an argument",null, StatusCodes.Status400BadRequest);

        }
    }

    public async Task<Result<IEnumerable<Order>>> GetOrdersAsync()
    {
        try
        {
            var result = await _context.Orders.ToListAsync();

            return Result<IEnumerable<Order>>.Success("Order created", result);
        }   
        catch (ArgumentOutOfRangeException)
        {
            return Result<IEnumerable<Order>>.Fail("Wrong format of an argument", null, StatusCodes.Status400BadRequest);

        }
    }
}
