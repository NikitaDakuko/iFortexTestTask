using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<User> GetUser() => Task.FromResult(_context.Users.OrderBy(u => u.Orders.Count).Last());

        public Task<List<User>> GetUsers() => Task.FromResult(_context.Users.Where(u => u.Status == UserStatus.Inactive).ToList());
    }
}
