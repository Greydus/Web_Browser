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
        WebBrowser webBrowser;

        public MainWindow()
        {
            webBrowser = new WebBrowser();

            webBrowser.Navigated += WebBrowser_Navigated;
            webBrowser.Navigating += WebBrowser_Navigating;

            InitializeComponent();
        }

        private void GoButtonOnClick(object sender, RoutedEventArgs e)
        {
            webBrowser.Navigate(UrlTextBox.Text);
        }

        private void RefreshButtonOnClick(object sender, RoutedEventArgs e)
        {
            webBrowser.Refresh();
        }

        private void BackButtonOnClick(object sender, RoutedEventArgs e)
        {
            webBrowser.GoBack();
        }

        private void ForwardButtonOnClick(object sender, RoutedEventArgs e)
        {
            webBrowser.GoForward();
        }

        private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            BackButton.IsEnabled = webBrowser.CanGoBack;
            ForwardButton.IsEnabled = webBrowser.CanGoForward;
            UrlTextBox.IsEnabled = true;
            UrlTextBox.Text = e.Uri.AbsoluteUri;
            SearchTextBox.IsEnabled = true;
            GoButton.IsEnabled = true;
            SearchButton.IsEnabled = true;
            RefreshButton.IsEnabled = true;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            tabControl.Items.Add(webBrowser);
            webBrowser.Navigate(Properties.Settings.Default.HomePage);
        }

        private void SearchButtonOnClick(object sender, RoutedEventArgs e)
        {
            webBrowser.Navigate(Properties.Settings.Default.SearchEngine + HttpUtility.UrlEncode(SearchTextBox.Text));
        }

        private void WebBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
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

        private void AddTabButtonOnClick(object sender, RoutedEventArgs e)
        {
            tabControl.Items.Add(webBrowser);
        }
    }
}
