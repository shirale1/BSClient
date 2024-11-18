using Microsoft.Win32;
using BSClient.Views;
using System.Windows.Input;

namespace BSClient.ViewModels;

public class LoginPageViewModel : ContentPage
{

    private IServiceProvider serviceProvider;
    public ICommand LoginCommand { get; set; }
    public ICommand GoToRegisterCommand { get; set; }
    private string email;
    public string Email
    {
        get => email;
        set
        {
            if (email != value)
            {
                email = value;
                OnPropertyChanged(nameof(Email));
                // can add more logic here like email validation etc.
                // can add error message property and set it here
            }
        }
    }
    private string password;
    public string Password
    {
        get => password;
        set
        {
            if (password != value)
            {
                password = value;
                OnPropertyChanged(nameof(Password));
                // can add more logic here like email validation etc.
                // can add error message property and set it here
            }
        }
    }
    public LoginPageViewModel(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        GoToRegisterCommand = new Command(GoToRegister);
    }

    public void GoToRegister()
    {
        ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<Register>());
    }
}
