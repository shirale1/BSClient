using System.Windows.Input;


namespace BSClient.ViewModels;

public class RegisterPageViewModel : ViewModelBase
{

    private string name;
    private int? userId { get; set; }
    private string? user_error;
    private string email;
    private string password;
    private string? password_error;
    private string user_type;
    private bool isBabySiterChecked;
    private bool isParentChecked;
    private bool haveLicense;
    private bool doesntHaveLicense;
    private int age;
    private int experience;
    private int kidsN;
    private bool havePets;
    private bool doesntHavePets;

    private readonly IServiceProvider serviceProvider;
    public Command RegistrationCommand {get;}

    //private BSClientWebAPIProxy proxy;
    //public RegisterViewModel(TasksManagementWebAPIProxy proxy)
    //{
    //    this.proxy = proxy;
    //    RegisterCommand = new Command(OnRegister);
    //    CancelCommand = new Command(OnCancel);
    //    ShowPasswordCommand = new Command(OnShowPassword);
    //    UploadPhotoCommand = new Command(OnUploadPhoto);
    //    PhotoURL = proxy.GetDefaultProfilePhotoUrl();
    //    LocalPhotoPath = "";
    //    IsPassword = true;
    //    UserNameError = "Name is required";
    //    EmailError = "Email is required";
    //    PasswordError = "Password must be at least 4 characters long and contain letters and numbers";
    //}

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
            User_Error = ""; // איפוס שגיאת שם המשתמש
            OnPropertyChanged(nameof(Name));
            // בדיקת תקינות שם המשתמש

            if (!string.IsNullOrEmpty(Name))

            {
                if (char.IsDigit(Name[0]))
                {
                    User_Error = "Username cannot start with a number";
                    OnPropertyChanged(nameof(Name));
                }

            }
        }
    }

    public string User_Error
    {
        get
        {
            return user_error;
        }
        set
        {
            user_error = value;
            OnPropertyChanged(nameof(User_Error));
        }
    }

    public string Email
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public string? Password
    {
        get { return password; }
        set
        {
            password = value;
            Password_Error = "";
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(User_Error));
            if (string.IsNullOrEmpty(password))
            {
                Password_Error = ""; // איפוס השגיאה אם השדה ריק
            }
            else
            {
                if (password != null)
                {
                    bool IsPasswordOk = IsValidPassword(password);
                    if (!IsPasswordOk)
                    {
                        Password_Error = "Password must contain at least one uppercase letter and a number";
                    }
                }
            }
        }
    }

    private bool IsValidPassword(string password)
    {
        bool hasUpperCase = false;
        bool hasDigit = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c))
            {
                hasUpperCase = true;
            }
            if (char.IsDigit(c))
            {
                hasDigit = true;
            }

            if (hasUpperCase && hasDigit)
            {
                break; // אם מצאנו כבר גם אות גדולה וגם ספרה, אפשר לעצור את הלולאה
            }
        }
        return hasUpperCase && hasDigit;

    }

    public string Password_Error
    {
        get { return password_error; }
        set
        {
            password_error = value;
            OnPropertyChanged(nameof(Password_Error));
            //OnPropertyChanged(nameof(CanRegister));
        }
    }

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
    
    public int Age
    {
        get { return age; }
        set
        {
            age = value;
            OnPropertyChanged();
        }
    }
    public int Experience
    {
        get { return experience; }
        set
        {
            experience= value;
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
            kidsN= value;
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

    public ICommand RegisterCommand
    {
        get; private set;
    }


    //public async void Register()
    //{
    //    Models.User user = new Models.User
    //    {

    //        FullName = name,
    //        Email = email,
    //        UserType = user_type,
    //        Password = password,
    // };


   
}

    
