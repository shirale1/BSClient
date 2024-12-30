using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSClient.Views;
using BSClient.ViewModels;
using BSClient.Models;

namespace BSClient.ViewModels
{
    internal class HomePageBViewModel : ViewModelBase
    {
        public Command (FilterCommand) { get; }
        FilterCommand = new Command(Filter);
       


        private int saveKids;
        public int SaveKids
        {
            get => saveKids;
            set
            {
                saveKids = value;
                OnPropertyChanged("SaveKids");
            }
        }

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
        private bool distance;
        public bool Distance
        {
            get => distance;
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }

        private int payment;
        public int Payment
        {
            get => payment;
            set
            {
                payment = value;
                OnPropertyChanged("Payment");
            }
        }
        public async void FilterCommand()
        {

        }
    }
}

