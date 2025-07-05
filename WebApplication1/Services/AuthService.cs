namespace TechnicalTask.Services
{
    
    using System.Collections.Concurrent;
    using TechnicalTask.Models;

    public class AuthService : IAuthService
    {
        private static readonly ConcurrentDictionary<string, OTPEntry> _otpStore = new();

        public string GenerateOTP(int length = 6)
        {
            var random = new Random();
            string otp = "";
            for (int i = 0; i < length; i++)
                otp += random.Next(0, 10).ToString();
            return otp;
        }

        public void StoreOTP(string phone, string otp)
        {
            var expiry = DateTime.UtcNow.AddMinutes(5);
            var entry = new OTPEntry { PhoneNumber = phone, OTP = otp, Expiry = expiry };
            _otpStore[phone] = entry;
        }

        public bool ValidateOTP(string phone, string otp)
        {
            if (_otpStore.TryGetValue(phone, out var entry))
            {
                if (entry.Expiry < DateTime.UtcNow)
                {
                    _otpStore.TryRemove(phone, out _);
                    return false; // expired
                }
                if (entry.OTP == otp)
                {
                    _otpStore.TryRemove(phone, out _);
                    return true;
                }
            }
            return false;
        }

        public string GenerateFakeJwtToken(string phone)
        {
            // Generating dummy token by using the phone number and current time as timestamp
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{phone}:{DateTime.UtcNow}"));
        }
    }
}
