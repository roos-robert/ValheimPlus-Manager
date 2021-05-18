﻿using MaterialDesignThemes.Wpf;
using System.Windows;
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
        private Settings Settings { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Fetching path settings
            Settings = SettingsDAL.GetSettings();

            managerVersionTextBlock.Text = "Version 0.5.2";

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

        private void otherModsNavigateButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new OtherModsPage());
            DrawerHost.IsLeftDrawerOpen = false;
        }
    }
}
