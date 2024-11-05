
using BSClient.ViewModels;
namespace BSClient.Views;

public partial class Register : ContentPage
{
	public Register(RegisterPageViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}
//using BSClient.ViewModels;

//namespace BSClient.Views
//{
//    public partial class Register : ContentPage
//    {
//        public Register()
//        {
//            InitializeComponent();
//            BindingContext = new RegisterPageViewModel(); // יצירת ViewModel וקשירתו לדף
//        }
//    }
//}