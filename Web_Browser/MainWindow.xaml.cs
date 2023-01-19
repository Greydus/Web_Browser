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

        private void goBtn_OnClick(object sender, RoutedEventArgs e)
        {
            webBrowser.Navigate(uriAddrBox.Text);
        }

        private void refreshBtn_OnClick(object sender, RoutedEventArgs e)
        {
            webBrowser.Refresh();
        }

        private void bckBtn_OnClick(object sender, RoutedEventArgs e)
        {
            webBrowser.GoBack();
        }

        private void fwdBtn_OnClick(object sender, RoutedEventArgs e)
        {
            webBrowser.GoForward();
        }

        private void webBrowser_OnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            uriAddrBox.Text = e.Uri.AbsoluteUri;
        }

        private void mainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            webBrowser.Navigate(uriAddrBox.Text);
        }
    }
}
