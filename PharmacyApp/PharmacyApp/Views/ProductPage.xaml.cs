using PharmacyApp.Models;
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
    public partial class ProductPage : ContentPage
    {
        public Product Model { get; private set; }
        public ProductListViewModel ViewModel { get; private set; }
        public ProductPage(Product model, ProductListViewModel viewModel)
        {
          
            
                InitializeComponent();
                Model = model;
                ViewModel = viewModel;
                this.BindingContext = this;
        }
    }
}