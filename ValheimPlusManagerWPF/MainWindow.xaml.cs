using MaterialDesignThemes.Wpf;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media;
using ValheimPlusManager.Data;
using ValheimPlusManager.Models;
using ValheimPlusManager.SupportClasses;

namespace ValheimPlusManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _mainFrame.Navigate(new MainPage());
        }

        private void serverListManagerNavigateButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ServerListManagerPage());
            DrawerHost.IsLeftDrawerOpen = false;
        }

        private void overviewNavigateButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new MainPage());
            DrawerHost.IsLeftDrawerOpen = false;
        }
    }
}
