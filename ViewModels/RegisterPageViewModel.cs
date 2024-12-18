using BSClient.Services;
using System.Windows.Input;
using BSClient.Models;


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
        UserType = "1";

    }
    

    private bool isBabySiterChecked;
    private bool isParentChecked;
    private int kidsN;
    private bool havePets;
    private DateTime birthDate;


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
            ValidateUserName();
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

    private void ValidateUserName()
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
    #region Usertype

    private string userType;
    public string UserType
    {
        get
        {
            return userType;
        }
        set
        {
            userType = value;
            if (value == "1")
            {
                IsBabySiterChecked = true;
                IsParentChecked = false;
            }
            else
            {
                IsBabySiterChecked = false;
                IsParentChecked = true;
            }
                
            OnPropertyChanged(nameof(UserType));
        }
    }

    public bool IsBabySiterChecked
    {
        get { return isBabySiterChecked; }
        set
        {
            isBabySiterChecked = value;
            
            OnPropertyChanged(nameof(IsBabySiterChecked));
        }
    }
    public bool IsParentChecked
    {
        get { return isParentChecked; }
        set
        {
            isParentChecked = value;
            
            OnPropertyChanged(nameof(IsParentChecked));
        }
    }
    #endregion
    #region birthDate
    public DateTime BirthDate
    {
        get => birthDate;
        set
        {
            birthDate = value;
            OnPropertyChanged("BirthDate");
        }
    }
  
    public DateTime MaxDate
    {
        get { return DateTime.Now.AddYears(-15); }
    }
    #endregion birthDate

    #region experience
    private int experience;

    public int Experience
    {
        get => experience;
        set
        {
            experience = value;
            ValidateExperience();
            OnPropertyChanged("Experience");
        }
    }
    private string experienceError;
    public string ExperienceError
    {
        get => experienceError;
        set
        {
            experienceError = value;
            OnPropertyChanged("experienceError");
        }
    }

    private bool showExperienceError;
    public bool ShowExperienceError
    {
        get => showExperienceError;
        set
        {
            showExperienceError = value;
            OnPropertyChanged("ShowExperienceError");
        }
    }
    private void ValidateExperience()
    {
        //this.ShowExperienceError = Experience == 0;
    }
    #endregion experience
    #region license

    private bool haveLicense;
    public bool HaveLicense
    {
        get => haveLicense;
        set
        {
            haveLicense = value;
            OnPropertyChanged("HaveLicense;");
        }
    }
    #endregion license
    #region kids

    private int kids;
    public int Kids
    {
        get => kids;
        set
        {
            kids = value;
            ValidateKids();
            OnPropertyChanged("Kids");
        }
    }
    private string kidsError;
    public string KidsError
    {
        get => kidsError;
        set
        {
            kidsError = value;
            OnPropertyChanged("kidsError");
        }
    }
    private bool showKidsError;

    public bool ShowKidsError
    {
        get => showKidsError
;
        set
        {
            showKidsError=value;
            OnPropertyChanged("ShowKidsError;");
        }
    }
    
    private void ValidateKids()
    {
        //this.ShowKidsError = Kids == 0;
    }
    #endregion kids
    #region pets
    private bool pets;
    public bool Pets
    {
        get => pets;
        set
        {
            pets = value;
            OnPropertyChanged("Pets");
        }
    }
    #endregion pets
    #region  Address
    private string address;
    public string Address
    {
        get => address;
        set
        {
            address = value;
            ValidateAddress();
            OnPropertyChanged("Address");
        }
    }
    private string addressError;
    public string AddressError
    {
        get => addressError;
        set
        {
            addressError = value;
            OnPropertyChanged("AddressError");
        }
    }
    private bool showAddressError;

    public bool ShowAddressError
    {
        get => showAddressError;
        set
        {
            showAddressError = value;
            OnPropertyChanged(" ShowAddressError");
        }
    }
    private void ValidateAddress()
    {
        this.ShowAddressError = string.IsNullOrEmpty(Address);
    }
    #endregion address
    public async void OnRegister()
    {
        ValidateUserName();
        ValidateEmail();
        ValidatePassword();

        if (!ShowUserNameError  && !ShowEmailError && !ShowPasswordError && !showAddressError&& !showKidsError )
        {

            if (IsParentChecked)
            {
                Parent? p = new Parent()
                {
                    UserName = UserName,
                    Email = Email,
                    Password = Password,
                    Address = Address,
                    UserType = UserType,
                    KidsN = Kids,
                    Pets = Pets
                };
                InServerCall = true;
                p = await proxy.RegisterParent(p);
                InServerCall = false;
                if (p != null)
                {
                   ((App)(Application.Current)).MainPage.Navigation.PopAsync();
                }
                else
                {

                    //If the registration failed, display an error message
                    string errorMsg = "Registration failed. Please try again.";
                    await Application.Current.MainPage.DisplayAlert("Registration", errorMsg, "ok");
                }
            }
            else
            {
                Babysiter? b = new Babysiter()
                {
                    UserName = UserName,
                    Email = Email,
                    Password = Password,
                    Address = Address,
                    UserType = UserType,
                    License = HaveLicense,
                    ExperienceY = Experience,
                    BirthDate = DateOnly.FromDateTime(BirthDate)
                };
                InServerCall = true;
                b = await proxy.RegisterBabysiter(b);
                InServerCall = false;
                if (b != null)
                {
                    ((App)(Application.Current)).MainPage.Navigation.PopAsync();
                }
                else
                {

                    //If the registration failed, display an error message
                    string errorMsg = "Registration failed. Please try again.";
                    await Application.Current.MainPage.DisplayAlert("Registration", errorMsg, "ok");
                }
            }

            
            
        }

    }
}


    
