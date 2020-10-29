using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Collections.Specialized;
using EncryptedAuctionClient.Lib;
using System.Text.RegularExpressions;
using EncryptedAuctionDatatypes;
using LSHDotNet;

namespace EncryptedAuctionClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string aggregatorUrl;
        private readonly ApiClient apiClient;
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef = this;
        }
        
        public MainWindow()
        {
            aggregatorUrl = ConfigurationManager.AppSettings.Get("aggregatorUrl");
            apiClient = new ApiClient(aggregatorUrl);
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox.Text))
            {
                double minSim = 0.3;
                minSim = MinimumSimilaritySlider.Value;
                int maxResults = 5;
                int.TryParse(MaxResultsTextBox.Text, out maxResults);
                var searchQuery = textBox.Text;
                try
                {
                    var results = await Search(searchQuery, maxResults, minSim);
                    if (results.Count == 0){
                        MessageBox.Show("No result was found for your search query, please try again!");
                        return;
                    }
                    var searchResultWindow = new SearchResultWindow(searchQuery, results);
                    searchResultWindow.Show();
                }
                catch
                {
                    throw;
                }
            }
        }
        private async Task<List<SearchResult>> Search(string searchString, int maxResults, double minSim)
        {
            var hashSeed = await apiClient.GetHashSeed();
            var minHasher = new MinHasher<Guid>(hashSeed);
            var hashedSearchString = minHasher.GetMinHashSignature(searchString);
            var hashedResults = (await apiClient.HashedSearch(new HashedSearchQuery()
            {
                MaxResults = maxResults,
                MinimumSimilarity = minSim,
                SearchTerm = hashedSearchString
            }))?.ToList();
            var groupedResults = hashedResults.GroupBy(r => r.Store);
            var tasks = new List<Task<IEnumerable<ProductBase>>>();
            foreach(var storeResults in groupedResults)
            {
                tasks.Add(apiClient.GetProducts(storeResults.Key, storeResults.Select(r => r.Product.Id).ToList()));
            }
            await Task.WhenAll(tasks);
            foreach(var task in tasks.Where(t => !t.IsFaulted))
            {
                foreach(var product in task.Result)
                {
                    var idx = hashedResults.ToList().FindIndex(h => h.Product.Id == product.Id);
                    hashedResults[idx].Product = product;
                }
            }
            return hashedResults;
        }
    }
}
