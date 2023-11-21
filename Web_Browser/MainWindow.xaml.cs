using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Web_Browser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string HomePage;
        readonly string SearchEngine;

        public MainWindow()
        {
            HomePage = "https://wiby.me/";
            SearchEngine = "https://wiby.me/?q=";

            InitializeComponent();
        }

        private void GoButtonOnClick(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(UrlAddress.Text);
        }

        private void RefreshButtonOnClick(object sender, RoutedEventArgs e)
        {
            WebBrowser.Refresh();
        }

        private void BackButtonOnClick(object sender, RoutedEventArgs e)
        {
            WebBrowser.GoBack();
        }

        private void ForwardButtonOnClick(object sender, RoutedEventArgs e)
        {
            WebBrowser.GoForward();
        }

        private void WebBrowserOnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            UrlAddress.Text = e.Uri.AbsoluteUri;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(HomePage);
        }

        private void SearchButtonOnClick(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(SearchEngine + HttpUtility.UrlEncode(SearchQuery.Text));
        }
    }
}
