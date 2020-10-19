using EncryptedAuctionDatatypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows;
using EncryptedAuctionClient.Lib;
using System.Configuration;
using System.Threading.Tasks;

namespace EncryptedAuctionClient
{
    public class SearchResultsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<OfferViewModel> OfferList { get; set; }
        public Visibility OfferListVisibility { get; set; } = Visibility.Collapsed;
        public String SearchTerm { get; set; }
        public String OfferTerm { get; set; }

        private List<SearchResult> _results;
        public ICommand OfferCommand { get { return new RelayCommand<ProductViewModel>(OnGetOffer); } }
        public ICommand CloseOffersCommand { get { return new RelayCommand<ProductViewModel>(OnCloseOffers); } }
        private async void OnGetOffer(ProductViewModel product)
        {
            await GetOffers(product);
        }
        private void OnCloseOffers(ProductViewModel product)
        {

            OfferListVisibility = Visibility.Collapsed;
            OnPropertyChanged(nameof(OfferListVisibility));
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SearchResultsViewModel(string searchTerm, List<SearchResult> results)
        {
            _results = results;
            CreateData(results);
            OnPropertyChanged(nameof(Products));
            SearchTerm = $"Search results for: \"{searchTerm}\"";
            OnPropertyChanged(nameof(SearchTerm));
        }

        private async Task GetOffers(ProductViewModel product) 
        {
            List<OfferViewModel> offersToGet = new List<OfferViewModel>();
            foreach (var result in _results)
            {
                if(
                        result.Product.Brand == product.Brand
                    && result.Product.Model == product.Model
                    && !offersToGet.Any(o=>o.ProductId == result.Product.Id)
                    )
                {
                    offersToGet.Add(new OfferViewModel()
                    {
                        ProductId = result.Product.Id,
                        StoreApiUrl = result.Store.ApiUrl,
                        StoreName = result.Store.Name
                    });
                }
            }
            var gotOffers = await ApiClient.GetOffers(offersToGet);

            OfferList = gotOffers.OrderBy(o => o.EncryptedPrice).ToList();
            OnPropertyChanged(nameof(OfferList));
            OfferListVisibility = Visibility.Visible;
            OnPropertyChanged(nameof(OfferListVisibility));
            OfferTerm = $"Offers for: \"{product.Brand} {product.Model}\"";
            OnPropertyChanged(nameof(OfferTerm));
        }

        private void CreateData(List<SearchResult> results)
        {
            var productList = new List<ProductViewModel>();
            foreach (var result in results)
            {
                var idx = productList.FindIndex(p => p.Model == result.Product.Model && p.Brand == result.Product.Brand);
                if (idx != -1)
                {
                    if(productList[idx].Similarity < result.Similarity)
                    {
                        productList[idx].Similarity = result.Similarity;
                    }
                    if(!productList[idx].Stores.Any(s=>s.Id == result.Store.Id))
                    {
                        productList[idx].StoreCount += 1;
                        productList[idx].Stores.Add(result.Store);
                    }
                }
                else
                {
                    productList.Add(new ProductViewModel()
                    {
                        Stores = new List<StoreBase>() { result.Store },
                        Model = result.Product.Model,
                        Brand = result.Product.Brand,
                        Description = result.Product.Description,
                        Similarity = result.Similarity,
                        StoreCount = 1
                    });
                }
            }
            Products = new ObservableCollection<ProductViewModel>(productList);
        }
        public ObservableCollection<ProductViewModel> Products { get; private set; }
    }

    public class RelayCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        private Action<T> methodToExecute;
        private Func<bool> canExecuteEvaluator;
        public RelayCommand(Action<T> methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }
        public RelayCommand(Action<T> methodToExecute)
            : this(methodToExecute, null)
        {
        }
        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this.canExecuteEvaluator.Invoke();
                return result;
            }
        }
        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }
        public void Execute(T parameter)
        {
            this.methodToExecute.Invoke(parameter);
        }
    }
}
