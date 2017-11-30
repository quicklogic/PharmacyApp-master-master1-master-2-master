using PharmacyApp.Models;
using PharmacyApp.Models;
using PharmacyApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PharmacyApp.ViewModels
{
    public class ProductListViewModel : INotifyPropertyChanged
    {
        bool initialized = false;   
        Product selectedProduct;  
        private bool isBusy;    
        private bool filtersVisible;
        private bool searchVisible;
        private bool pickerEnable;
 
       
        public ObservableCollection<Product> Products { get; set; }
        PharmacyService pharmacyService = new PharmacyService();
        public event PropertyChangedEventHandler PropertyChanged;

        
        public ICommand BackCommand { protected set; get; }
        public ICommand SearchCommand { get; set; }
        public ICommand CategoryFilter { get; set; }
        public ICommand CategoryCommand { get; set; }
        public ICommand FiltersCommand { get; set; }
        public INavigation Navigation { get; set; }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }


        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public ProductListViewModel()
        {
            SearchCommand = new Command(Search);
            Products = new ObservableCollection<Product>();
            IsBusy = false;
            FiltersVisible = false;
            PickerEnable = false;
            SearchVisible = false;
            BackCommand = new Command(Back);
            FiltersCommand = new Command(Filters);
            CategoryCommand = new Command(Category);
        }

        void Category()
        {
            if (PickerEnable != true)
            {
                PickerEnable = true;
            }
            else PickerEnable = false;
        }
        void Filters()
        {
            if (FiltersVisible != true)
            {
                FiltersVisible = true;
            }
            else FiltersVisible = false;
        }
        void Search()
        {

            if (SearchVisible != true)
            {
                SearchVisible = true;
            }
            else
            {
                SearchVisible = false;
                FiltersVisible = false;
            }
        }
        public bool SearchVisible
        {
            set
            {
                if (searchVisible != value)
                {
                    searchVisible = value;
                    OnPropertyChanged("SearchVisible");
                }
            }
            get
            {
                return searchVisible;
            }
        }

        public bool FiltersVisible
        {
            set
            {
                if (filtersVisible != value)
                {
                    filtersVisible = value;
                    OnPropertyChanged("FiltersVisible");
                }
            }
            get
            {
                return filtersVisible;
            }
        }

        public bool PickerEnable
        {
            set
            {
                if (pickerEnable != value)
                {
                    pickerEnable = value;
                    OnPropertyChanged("PickerEnable");
                }
            }
            get
            {
                return pickerEnable;
            }
        }
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (selectedProduct != value)
                {
                    Product tempProduct = new Product()
                    {
                        ID = value.ID,
                        Name = value.Name,
                        Category = value.Category,
                        Price = value.Price,
                        Type = value.Type,
                        Description = value.Description
                    };
                    selectedProduct = null;
                    OnPropertyChanged("SelectedProduct");
                    Navigation.PushAsync(new ProductPage(tempProduct, this));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        
        private void Back()
        {
            Navigation.PopAsync();
        }

       

        public async Task GetProducts()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Product> products = await pharmacyService.Get();

            
            Products.Clear();
            while (Products.Any())
                Products.RemoveAt(Products.Count - 1);

            
            foreach (Product p in products)
                Products.Add(p);
            IsBusy = false;
            initialized = true;
        }
 
    }

    }
