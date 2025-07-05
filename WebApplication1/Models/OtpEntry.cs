namespace TechnicalTask.Models
{
    public class OTPEntry
    {
        public string PhoneNumber { get; set; } = null!;
        public string OTP { get; set; } = null!;
        public DateTime Expiry { get; set; }
    }

}
