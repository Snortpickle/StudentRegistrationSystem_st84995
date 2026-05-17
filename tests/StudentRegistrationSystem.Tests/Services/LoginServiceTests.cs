using StudentRegistrationSystem.Services;
using Xunit;

namespace StudentRegistrationSystem.Tests.Services;

public class LoginServiceTests
{
    [Fact]
    public void Login_Combinations_FromTask()
    {
        Assert.Equal(false, LoginService.Login(null, null));
        Assert.Equal(false, LoginService.Login(null, "admin"));
        Assert.Equal(false, LoginService.Login("admin", null));
        Assert.Equal(false, LoginService.Login("Admin", "Admin"));
        Assert.Equal(false, LoginService.Login("Admin", "admin"));
        Assert.Equal(false, LoginService.Login("admin", "Admin"));
        Assert.Equal(true, LoginService.Login("admin", "admin"));
    }
}
