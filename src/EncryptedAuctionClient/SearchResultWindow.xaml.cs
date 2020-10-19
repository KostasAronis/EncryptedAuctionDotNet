using EncryptedAuctionDatatypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EncryptedAuctionClient
{
    /// <summary>
    /// Interaction logic for SearchResultWindow.xaml
    /// </summary>
    public partial class SearchResultWindow : Window
    {
        private List<SearchResult> _results;

        public SearchResultWindow(string searchTerm, List<SearchResult> results)
        {
            _results = results;
            var vm = new SearchResultsViewModel(searchTerm, results);
            this.DataContext = vm;
            InitializeComponent();
        }
    }
}
