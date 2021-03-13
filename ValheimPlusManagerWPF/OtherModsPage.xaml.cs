using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
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
using ValheimPlusManager.Data;
using ValheimPlusManager.Models;
using ValheimPlusManager.SupportClasses;

namespace ValheimPlusManager
{
    /// <summary>
    /// Interaction logic for OtherModsPage.xaml
    /// </summary>
    public partial class OtherModsPage : Page
    {
        private bool ValheimPlusInstalledClient { get; set; } = false;
        private bool ValheimPlusInstalledServer { get; set; } = false;
        private Settings Settings { get; set; }

        SnackbarMessageQueue myMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(3000));

        public OtherModsPage()
        {
            InitializeComponent();
            statusSnackBar.MessageQueue = myMessageQueue;
            FetchSettings();
        }

        public void FetchSettings()
        {
            try
            {
                // Fetching path settings
                Settings = SettingsDAL.GetSettings();

                // Fetch current versions and update settings if needed
                bool success = UpdateManager.CheckCurrentVersion(Settings);

                if (success)
                {
                }
            }
            catch (Exception)
            {
                statusLabel.Foreground = Brushes.Red;
                statusLabel.Content = "Error! Settings file not found, reinstall manager.";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                File.Copy(@"Data/OtherMods/AnyPortal.dll", String.Format("{0}BepInEx/plugins/AnyPortal.dll", Settings.ClientInstallationPath), true);
                statusSnackBar.MessageQueue.Enqueue("AnyPortal mod installed!");
            }
            catch (Exception)
            {
                statusSnackBar.MessageQueue.Enqueue("Error! AnyPortal was not installed");
            }
            
        }
    }
}
