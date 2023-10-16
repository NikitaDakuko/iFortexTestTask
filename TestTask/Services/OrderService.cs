using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Order> GetOrder() => Task.FromResult(_context.Orders.OrderBy(o => o.Price * o.Quantity).Last());

        public Task<List<Order>> GetOrders() => Task.FromResult(_context.Orders.Where(o => o.Quantity > 10).ToList());
    }
}
