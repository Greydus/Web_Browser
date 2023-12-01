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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoButtonOnClick(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(UrlTextBox.Text);
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

        private void WebBrowserOnNavigated(object sender, NavigationEventArgs e)
        {
            BackButton.IsEnabled = WebBrowser.CanGoBack;
            ForwardButton.IsEnabled = WebBrowser.CanGoForward;
            UrlTextBox.IsEnabled = true;
            UrlTextBox.Text = e.Uri.AbsoluteUri;
            SearchTextBox.IsEnabled = true;
            GoButton.IsEnabled = true;
            SearchButton.IsEnabled = true;
            RefreshButton.IsEnabled = true;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(Properties.Settings.Default.HomePage);
        }

        private void SearchButtonOnClick(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(Properties.Settings.Default.SearchEngine + HttpUtility.UrlEncode(SearchTextBox.Text));
        }

        private void WebBrowserOnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            BackButton.IsEnabled = false;
            ForwardButton.IsEnabled = false;
            UrlTextBox.IsEnabled = false;
            SearchTextBox.IsEnabled = false;
            GoButton.IsEnabled = false;
            SearchButton.IsEnabled = false;
            RefreshButton.IsEnabled = false;
        }

        private void SettingsButtonOnClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow(this);
            settingsWindow.ShowDialog();
        }
    }
}
