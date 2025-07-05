namespace TechnicalTask.Models;

public record RegisterUserRequest(string FullName, string PhoneNumber, string? Email);
public record LoginRequest(string PhoneNumber);
public record VerifyOtpRequest(string PhoneNumber, string Otp);
public record LoginResponse(string Token);
