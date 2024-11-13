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

    private readonly IServiceProvider serviceProvider;

    // ����� ������� ������ �������� ����� ������ �� ��������� ������



    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
            User_Error = ""; // ����� ����� �� ������
            OnPropertyChanged(nameof(Name));
            // ����� ������ �� ������

            if (!string.IsNullOrEmpty(Name))

            {
                if (char.IsDigit(Name[0]))
                {
                    User_Error = "!!�� ������ �� ���� ������ �����!!";
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
                Password_Error = ""; // ����� ������ �� ���� ���
            }
            else
            {
                if (password != null)
                {
                    bool IsPasswordOk = IsValidPassword(password);
                    if (!IsPasswordOk)
                    {
                        Password_Error = "!!����� ����� ����� ����� ��� ����� ��� �����!!";
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
                break; // �� ����� ��� �� ��� ����� ��� ����, ���� ����� �� ������
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
                User_Type = "1"; // ����� �-1 ���� ���������
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
                User_Type = "2"; // ����� �-2 ���� ����
                IsBabySiterChecked = false; // Uncheck the Buyer radio button
            }
            OnPropertyChanged(nameof(IsParentChecked));
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
    //    };


    //    // check
    //    int? res = await this.api_service.Register(user);
    //    // �� ������ ������
    //    if (res != null)
    //    {
    //        // ����� ��� ������
    //        if (User_Type == "2") // �� ������ ��� ����
    //        {


    //            var Pare = serviceProvider.GetRequiredService<SellerRegistrationPage>();
    //            var sellerRegistrationViewModel = serviceProvider.GetRequiredService<SellerRegistrationPageViewModel>();

    //            // ����� �-ViewModel �� �-SellerId �����
    //            sellerRegistrationViewModel.Initialize((int)res);

    //            // ����� �-ViewModel �-BindingContext �� ���
    //            sellerRegistrationPage.BindingContext = sellerRegistrationViewModel;
    //            await App.Current.MainPage.Navigation.PushAsync(sellerRegistrationPage);

    //        }
    //        else if (User_Type == "3") // �� ������ ��� ����
    //        {
    //            // ���� ��� BusinessesPage
    //            var BusinessesPage = serviceProvider.GetRequiredService<BusinessesPage>();
    //            await App.Current.MainPage.Navigation.PushAsync(BusinessesPage);
    //        }
    //    }
    //    else
    //    {
    //        // ����� ����� ������� ����� (����� ����� ������, ����)
    //        await Application.Current.MainPage.DisplayAlert("�����", "������ �����, ��� ���.", "�����");
    //    }
    //}
}

    
