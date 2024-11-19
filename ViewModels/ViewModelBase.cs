using System.ComponentModel;

namespace BSClient.ViewModels;

         public class ViewModelBase : INotifyPropertyChanged
         {
             public event PropertyChangedEventHandler PropertyChanged;

             protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
             {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
             }

  
         }
