using PharmacyApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PharmacyApp.ViewModels
{
    public class MenuViewModel
    {

        public ICommand GoHomeCommand { get; set; }
        public ICommand GoUserProfileCommand { get; set; }
        public ICommand GoRegisterCommand { get; set; }
        public ICommand GoLoginCommand { get; set; }

        public MenuViewModel()
        {
            
            GoHomeCommand = new Command(GoHome);
            GoUserProfileCommand = new Command(GoSecond);
            GoRegisterCommand = new Command(Register);
            GoLoginCommand = new Command(Login);
        }


        void GoHome(object obj)
        {
            App.NavigationPage.Navigation.PopToRootAsync();
            App.MenuIsPresented = false;
        }

        void GoSecond(object obj)
        {
            App.NavigationPage.Navigation.PushAsync(new ProductListPage());
            App.MenuIsPresented = false;
        }

        void Register()
        {
            App.NavigationPage.Navigation.PushAsync(new RegistrationPage());
            App.MenuIsPresented = false;
        }

        void Login()
        {
            App.NavigationPage.Navigation.PushAsync(new LoginPage());
            App.MenuIsPresented = false;
        }
    }
}
        