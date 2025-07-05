using Microsoft.EntityFrameworkCore;
using TechnicalTask.Data;
using TechnicalTask.Models;

namespace TechnicalTask.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) => _context = context;

        public async Task<bool> IsPhoneRegisteredAsync(string phone)
        {
            return await _context.Users.AnyAsync(u => u.PhoneNumber == phone);
        }

        public async Task<User> RegisterUserAsync(string fullName, string phone, string? email)
        {
            var user = new User { FullName = fullName, PhoneNumber = phone, Email = email };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
