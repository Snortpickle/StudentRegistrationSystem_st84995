namespace StudentRegistrationSystem.Services;

/// <summary>
/// Simple login (required for unit test).
/// Username: admin
/// Password: admin
/// </summary>
public static class LoginService
{
    public static bool Login(string? login, string? password)
        => login == "admin" && password == "admin";
}
