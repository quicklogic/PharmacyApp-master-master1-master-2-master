using PharmacyApp.Models;
using PharmacyApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PharmacyApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand EnterCommand { get; set; }
        INavigation Navigation { get; set; }

        User user;

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public string Login
        {
            get { return user.login; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    user.login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public string Password
        {

            get { return user.password; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    user.password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public LoginPageViewModel()
        {
            user = new User();
            EnterCommand = new Command(Enter);
        }

        private async void Enter()
        {
            if (!String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password))
            { 

                PharmacyService service = new PharmacyService();

                var user1 = await service.Login(user);
                if(user1 == null)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        App.NavigationPage.Navigation.PopToRootAsync();
                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        App.NavigationPage.Navigation.PushAsync(new WelcomePage());
                    });
                   
                }

                

            }
        }
    }
}
