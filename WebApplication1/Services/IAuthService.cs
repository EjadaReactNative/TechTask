namespace TechnicalTask.Services
{
    
    public interface IAuthService
    {
        string GenerateOTP(int length = 6);
        void StoreOTP(string phone, string otp);
        bool ValidateOTP(string phone, string otp);
        string GenerateFakeJwtToken(string phone);
    }
}
