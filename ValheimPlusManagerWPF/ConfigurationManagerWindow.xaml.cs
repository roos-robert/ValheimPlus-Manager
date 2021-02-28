using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using ValheimPlusManager.Models;
using ValheimPlusManager.SupportClasses;

namespace ValheimPlusManager
{
    /// <summary>
    /// Interaction logic for ConfigurationManagerWindow.xaml
    /// </summary>
    public partial class ConfigurationManagerWindow : Window
    {
        private ValheimPlusConf ValheimPlusConf { get; set; }

        private bool ManageClient { get; set; }

        public ConfigurationManagerWindow(bool manageClient)
        {
            InitializeComponent();
            this.ManageClient = manageClient;

            if (manageClient)
            {
                ValheimPlusConf = ConfigManager.ReadConfigFile(true);
                DataContext = ValheimPlusConf;
            }
            else
            {
                ValheimPlusConf = ConfigManager.ReadConfigFile(false);
                DataContext = ValheimPlusConf;
            }
        }

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            bool success = ConfigManager.WriteConfigFile(ValheimPlusConf, ManageClient);

            if (success)
            {
                statusLabel.Content = String.Format("Changes saved!");
                statusLabel.Foreground = Brushes.Green;
            }
            else
            {
                statusLabel.Content = String.Format("Error, changes not saved!");
                statusLabel.Foreground = Brushes.Red;
            }

            // Timer to show status for set time (3)
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += HideStatusLabel;
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Start();
        }

        private void HideStatusLabel(object sender, EventArgs e)
        {
            statusLabel.Visibility = Visibility.Hidden;
        }

        private void IntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void FloatValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+(\\.[0-9]?)?");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
