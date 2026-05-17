using System.Windows;
using StudentRegistrationSystem.Common;
using StudentRegistrationSystem.Services;

namespace StudentRegistrationSystem.ViewModels;

public sealed class LoginViewModel : ViewModelBase
{
    private string? _login;
    public string? Login
    {
        get => _login;
        set => SetProperty(ref _login, value);
    }

    private string? _password;
    public string? Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public RelayCommand TryLoginCommand { get; }

    public LoginViewModel()
    {
        TryLoginCommand = new RelayCommand(TryLogin);
    }

    private void TryLogin()
    {
        if (LoginService.Login(Login, Password))
        {
            // Success: close login window and open main window
            var loginWindow = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.GetType().Name == "LoginWindow");

            var main = new Views.MainWindow();
            main.Show();

            loginWindow?.Close();
            return;
        }

        MessageBox.Show("Invalid username or password. Try: admin / admin", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
    }
}
