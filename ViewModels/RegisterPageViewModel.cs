using BSClient.Services;
using System.Windows.Input;


namespace BSClient.ViewModels;

public class RegisterPageViewModel : ViewModelBase
{

    private readonly IServiceProvider serviceProvider;
    public Command RegisterCommand { get; }

    private BSWebAPIProxy proxy;
    public RegisterPageViewModel(BSWebAPIProxy proxy)
    {
        this.proxy = proxy;
        RegisterCommand = new Command(OnRegister);
        ShowPasswordCommand = new Command(OnShowPassword);
        IsPassword = true;
        BirthDate = DateTime.Now.AddYears(-17);
        UserNameError = "UserName is required";
        EmailError = "Email is required";
        PasswordError = "Password must be at least 4 characters long and contain letters and numbers";

    }
    private string user_type;
    private bool isBabySiterChecked;
    private bool isParentChecked;
    private bool haveLicense;
    private bool doesntHaveLicense;
    private DateTime birthDate;
    private int experience;
    private int kidsN;
    private bool havePets;
    private bool doesntHavePets;


    //Defiine properties for each field in the registration form including error messages and validation logic
    #region UserName
    private bool showUserNameError;

    public bool ShowUserNameError
    {
        get => showUserNameError;
        set
        {
            showUserNameError = value;
            OnPropertyChanged("ShowUserNameError");
        }
    }

    private string userName;

    public string UserName
    {
        get => userName;
        set
        {
            userName = value;
            ValidateName();
            OnPropertyChanged("UserName");
        }
    }

    private string userNameError;
    public string UserNameError
    {
        get => userNameError;
        set
        {
            userNameError = value;
            OnPropertyChanged("UserNameError");
        }
    }

    private void ValidateName()
    {
        this.ShowUserNameError = string.IsNullOrEmpty(UserName);
    }
    #endregion
    #region Email
    private bool showEmailError;

    public bool ShowEmailError
    {
        get => showEmailError;
        set
        {
            showEmailError = value;
            OnPropertyChanged("ShowEmailError");
        }
    }

    private string email;

    public string Email
    {
        get => email;
        set
        {
            email = value;
            ValidateEmail();
            OnPropertyChanged("Email");
        }
    }

    private string emailError;

    public string EmailError
    {
        get => emailError;
        set
        {
            emailError = value;
            OnPropertyChanged("EmailError");
        }
    }

    private void ValidateEmail()
    {
        this.ShowEmailError = string.IsNullOrEmpty(Email);
        if (!ShowEmailError)
        {
            //check if email is in the correct format using regular expression
            if (!System.Text.RegularExpressions.Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                EmailError = "Email is not valid";
                ShowEmailError = true;
            }
            else
            {
                EmailError = "";
                ShowEmailError = false;
            }
        }
        else
        {
            EmailError = "Email is required";
        }
    }
    #endregion
    #region Password
    private bool showPasswordError;

    public bool ShowPasswordError
    {
        get => showPasswordError;
        set
        {
            showPasswordError = value;
            OnPropertyChanged("ShowPasswordError");
        }
    }

    private string password;

    public string Password
    {
        get => password;
        set
        {
            password = value;
            ValidatePassword();
            OnPropertyChanged("Password");
        }
    }

    private string passwordError;

    public string PasswordError
    {
        get => passwordError;
        set
        {
            passwordError = value;
            OnPropertyChanged("PasswordError");
        }
    }

    private void ValidatePassword()
    {
        //Password must include characters and numbers and be longer than 4 characters
        if (string.IsNullOrEmpty(password) ||
            password.Length < 4 ||
            !password.Any(char.IsDigit) ||
            !password.Any(char.IsLetter))
        {
            this.ShowPasswordError = true;
        }
        else
            this.ShowPasswordError = false;
    }

    //This property will indicate if the password entry is a password
    private bool isPassword = true;
    public bool IsPassword
    {
        get => isPassword;
        set
        {
            isPassword = value;
            OnPropertyChanged("IsPassword");
        }
    }
    //This command will trigger on pressing the password eye icon
    public Command ShowPasswordCommand { get; }
    //This method will be called when the password eye icon is pressed
    public void OnShowPassword()
    {
        //Toggle the password visibility
        IsPassword = !IsPassword;
    }
    #endregion
    public string User_Type
    {
        get
        {
            return user_type;
        }
        set
        {
            user_type = value;
            OnPropertyChanged(nameof(User_Type));
        }
    }
    public bool IsBabySiterChecked
    {
        get { return isBabySiterChecked; }
        set
        {
            isBabySiterChecked = value;
            if (IsBabySiterChecked)
            {
                User_Type = "1"; // עדכון ל-1 עבור בייביסיטר
                IsParentChecked = false; // Uncheck the Buyer radio button
            }
            OnPropertyChanged(nameof(IsBabySiterChecked));
        }
    }
    public bool IsParentChecked
    {
        get { return isParentChecked; }
        set
        {
            isParentChecked = value;
            if (IsParentChecked)
            {
                User_Type = "2"; // עדכון ל-2 עבור הורה
                IsBabySiterChecked = false; // Uncheck the Buyer radio button
            }
            OnPropertyChanged(nameof(IsParentChecked));
        }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        set
        {
            birthDate = value;
            OnPropertyChanged();
        }
    }
    public DateTime MaxDate
    {
        get { return DateTime.Now.AddYears(-15); }
    }


    public int Experience
    {
        get { return experience; }
        set
        {
            experience = value;
            OnPropertyChanged();
        }
    }
    public bool HaveLicense
    {
        get { return haveLicense; }
        set
        {
            doesntHaveLicense = true;
            haveLicense = value;
            OnPropertyChanged();
        }
    }
    public bool DoesntHaveLicense
    {
        get { return doesntHaveLicense; }
        set
        {
            doesntHaveLicense = value;
            haveLicense = false;
            OnPropertyChanged();
        }
    }
    public int KidsN
    {
        get { return kidsN; }
        set
        {
            kidsN = value;
            OnPropertyChanged();
        }
    }
    public bool HavePets
    {
        get { return havePets; }
        set
        {
            havePets = value;
            OnPropertyChanged();
        }
    }
    public bool DoesntHavePets
    {
        get { return doesntHavePets; }
        set
        {
            doesntHavePets = value;
            OnPropertyChanged();
        }
    }




    public async void OnRegister()
    {



    }
}


    
