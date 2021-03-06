using MaterialDesignThemes.Wpf;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
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

        SnackbarMessageQueue myMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(3000));

        public ConfigurationManagerWindow(bool manageClient)
        {
            InitializeComponent();
            this.ManageClient = manageClient;
            statusSnackBar.MessageQueue = myMessageQueue;

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
                statusSnackBar.MessageQueue.Enqueue("Changes saved!");
            }
            else
            {
                statusSnackBar.MessageQueue.Enqueue("Error, changes not saved!");
            }
        }

        private void IntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^-0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void FloatValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[-0-9]+(\\.[0-9]?)?");
            //e.Handled = regex.IsMatch(e.Text);
            Regex regex = new Regex("[^-0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
