using Microsoft.Win32;
using BSClient.Views;
using System.Windows.Input;

namespace BSClient.ViewModels;

//public class LoginPageViewModel : ContentPage
//{
//    private BSClientWebAPIProxy proxy;
//    private IServiceProvider serviceProvider;
//    public LoginViewModel(BSClientWebAPIProxy, IServiceProvider serviceProvider)
//    {
//        this.serviceProvider = serviceProvider;
//        this.proxy = proxy;
//        LoginCommand = new Command(OnLogin);
//        RegisterCommand = new Command(OnRegister);
//        username = "";
//        password = "";
//        InServerCall = false;
//        errorMsg = "";
//    }
//    private string username;
//    private string password;

//    public string UserName
//    {
//        get => username;
//        set
//        {
//            if (username != value)
//            {
//                username = value;
//                OnPropertyChanged(nameof(Email));
//            }
//        }
//    }
//    public string Password
//    {
//        get => password;
//        set
//        {
//            if (password != value)
//            {
//                password = value;
//                OnPropertyChanged(nameof(Password));
//            }
//        }
//    }
//    private string errorMsg;
//    public string ErrorMsg
//    {
//        get => errorMsg;
//        set
//        {
//            if (errorMsg != value)
//            {
//                errorMsg = value;
//                OnPropertyChanged(nameof(ErrorMsg));
//            }
//        }
//    }
//    public ICommand LoginCommand { get; }
//    public ICommand RegisterCommand { get; }



//    private async void OnLogin()
//    {
//        //Choose the way you want to blobk the page while indicating a server call
//        InServerCall = true;
//        ErrorMsg = "";
//        //Call the server to login
//        LoginInfo loginInfo = new LoginInfo { UserName = UserName, Password = Password };
//        AppUser? u = await this.proxy.LoginAsync(loginInfo);

//        InServerCall = false;

//        //Set the application logged in user to be whatever user returned (null or real user)
//        ((App)Application.Current).LoggedInUser = u;
//        if (u == null)
//        {
//            ErrorMsg = "Invalid email or password";
//        }
//        else
//        {
//            ErrorMsg = "";
//            //Navigate to the main page
//            AppShell shell = serviceProvider.GetService<AppShell>();
//            TaskViewModel tasksViewModel = serviceProvider.GetService<TasksViewModel>();
//            tasksViewModel.Refresh(); //Refresh data and user in the tasksview model as it is a singleton
//            ((App)Application.Current).MainPage = shell;
//            Shell.Current.FlyoutIsPresented = false; //close the flyout
//            Shell.Current.GoToAsync("Tasks"); //Navigate to the Tasks tab page
//        }
//    }
//    private void OnRegister()
//    {
//        ErrorMsg = "";
//        UserName = "";
//        Password = "";
//        // Navigate to the Register View page
//        ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<Register>());
//    }




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
                // can add more logic here like password validation etc.
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
