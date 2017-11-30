using PharmacyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PharmacyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    { 
        public LoginPage()
        {
            LoginPageViewModel lpvm = new LoginPageViewModel();
            BindingContext = lpvm;
            InitializeComponent();
        }
    }
}