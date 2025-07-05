using TechnicalTask.Models;

namespace TechnicalTask.Services
{
  
    public interface IUserService
    {
        Task<bool> IsPhoneRegisteredAsync(string phone);
        Task<User> RegisterUserAsync(string fullName, string phone, string? email);
    }
}
