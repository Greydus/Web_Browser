﻿using System;
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
using System.Windows.Shapes;

namespace Web_Browser
{
    /// <summary>
    /// Lógica de interacción para SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            HomePage.Text = Properties.Settings.Default.HomePage;
            SearchEngine.Text = Properties.Settings.Default.SearchEngine;
        }

        private void SaveButtonOnClick(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.HomePage = HomePage.Text;
            Properties.Settings.Default.SearchEngine = SearchEngine.Text;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}