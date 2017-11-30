using PharmacyApp.Models;
using PharmacyApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PharmacyApp.ViewModels
{
    class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand RegisterCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public INavigation Navigation;
        UserInfo usr;

        public bool passLogVisible;
        public bool tableVisible;

        public string Login
        {
            get { return usr.Login; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    usr.Login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public string Password
        {

            get { return usr.Password; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    usr.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string FirstName
        {
            get { return usr.FirstName; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    usr.FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string SecondName
        {
            get { return usr.SecondName; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    usr.SecondName = value;
                    OnPropertyChanged("SecondName");
                }
            }
        }

        public string Patronomyc
        {
            get { return usr.Patronomyc; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    usr.Patronomyc = value;
                    OnPropertyChanged("Patronomyc");
                }
            }
        }

        public string Address
        {
            get { return usr.Address; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    usr.Address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public string BornDate
        {
            get { return usr.BornDate; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    usr.BornDate = value;
                    OnPropertyChanged("BornDate");
                }
            }
        }

        public string Number
        {
            get { return usr.Number; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    usr.Number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        public string Mail
        {
            get { return usr.Mail; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    usr.Mail = value;
                    OnPropertyChanged("Mail");
                }
            }
        }



        public bool PassLogVisible
        {
            get { return passLogVisible; }
            set
            {
                passLogVisible = value;
                OnPropertyChanged("PassLogVisible");
            }
        }

        public bool TableVisible
        {
            get { return tableVisible; }
            set
            {
                tableVisible = value;
                OnPropertyChanged("TableVisible");
            }
        }

        public RegistrationViewModel()
        {
            usr = new UserInfo();
            TableVisible = false;
            PassLogVisible = true;
            RegisterCommand = new Command(Registration);
            NextCommand = new Command(Next);
           
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void Next()
        {
            if(!String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password))
            {
                if (PassLogVisible != false)
                    PassLogVisible = false;

                if (TableVisible != true)
                    TableVisible = true;
            }
        }
        
        public async void Registration()
        {
            if (IsNullOrWhiteSpaceExtension.AllIsNullOrWhiteSpace(false, FirstName, SecondName, Address, BornDate, Mail, Number))
            {
                PharmacyService service = new PharmacyService();
                var user = await service.Add(usr);
                if (user == null)
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
                        App.NavigationPage.Navigation.PopToRootAsync();
                        App.NavigationPage.Navigation.PushAsync(new LoginPage());
                    });
                }
            }
        }
    }
}
