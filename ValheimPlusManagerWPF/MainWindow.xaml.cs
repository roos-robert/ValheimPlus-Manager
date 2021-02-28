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
        private bool ValheimPlusInstalledClient { get; set; } = false;
        private bool ValheimPlusInstalledServer { get; set; } = false;
        private Settings Settings { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            FetchSettings();
        }

        public void FetchSettings()
        {
            try
            {
                // Fetching path settings
                Settings = SettingsDAL.GetSettings();

                // Checking paths and installation status
                UISettingsInit();
            }
            catch (Exception)
            {
                statusLabel.Foreground = Brushes.Red;
                statusLabel.Content = "Error! Settings file not found, reinstall manager.";
            }
        }

        private async void installClientButton_Click(object sender, RoutedEventArgs e)
        {
            installClientUpdateButton.IsEnabled = false;

            ValheimPlusUpdate valheimPlusUpdate = await UpdateManager.CheckForValheimPlusUpdatesAsync(Settings.ValheimPlusGameClientVersion);

            if (valheimPlusUpdate.NewVersion)
            {
                bool success = await UpdateManager.DownloadValheimPlusUpdateAsync(Settings.ValheimPlusGameClientVersion, true);

                if (success)
                {
                    Settings = SettingsDAL.GetSettings();
                    clientInstalledLabel.Content = String.Format("ValheimPlus {0} installed on client", Settings.ValheimPlusGameClientVersion);
                    statusLabel.Foreground = Brushes.Green;
                    statusLabel.Content = "Success! Game client updated to latest version.";
                    installClientUpdateButton.IsEnabled = false;
                }
            }
        }

        private async void checkClientUpdatesButtons_Click(object sender, RoutedEventArgs e)
        {
            ValheimPlusUpdate valheimPlusUpdate = await UpdateManager.CheckForValheimPlusUpdatesAsync(Settings.ValheimPlusGameClientVersion);

            if (valheimPlusUpdate.NewVersion)
            {
                installClientUpdateButton.Content = String.Format("Install update {0}", valheimPlusUpdate.Version);
                installClientUpdateButton.IsEnabled = true;
                statusLabel.Foreground = Brushes.Green;
                statusLabel.Content = String.Format("Update {0} available for game client", valheimPlusUpdate.Version);
            }
            else
            {
                statusLabel.Foreground = Brushes.Red;
                statusLabel.Content = "No new game client updates available";
            }
        }

        private async void installClientUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            installClientUpdateButton.IsEnabled = false;
            installClientUpdateButton.Content = "Installing update ...";

            ValheimPlusUpdate valheimPlusUpdate = await UpdateManager.CheckForValheimPlusUpdatesAsync(Settings.ValheimPlusGameClientVersion);

            if (valheimPlusUpdate.NewVersion)
            {
                bool success = await UpdateManager.DownloadValheimPlusUpdateAsync(Settings.ValheimPlusGameClientVersion, true);

                if (success)
                {
                    Settings = SettingsDAL.GetSettings();
                    clientInstalledLabel.Content = String.Format("ValheimPlus {0} installed on game client", Settings.ValheimPlusServerClientVersion);
                    statusLabel.Foreground = Brushes.Green;
                    statusLabel.Content = "Success! Game client updated to latest version.";
                    installClientUpdateButton.Content = "Update installed!";
                    installClientUpdateButton.IsEnabled = false;
                }
            }
        }

        private void manageClientButton_Click(object sender, RoutedEventArgs e)
        {
            new ConfigurationManagerWindow(true).Show(); // Bool determines if user will manage conf. for server or game client
        }

        private void enableDisableValheimPlusGameClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var modActive = File.Exists(String.Format("{0}winhttp.dll", Settings.ClientInstallationPath));
                if (modActive)
                {
                    System.IO.File.Move(String.Format("{0}winhttp.dll", Settings.ClientInstallationPath), String.Format("{0}winhttp_.dll", Settings.ClientInstallationPath));
                    enableDisableValheimPlusGameClientButton.Content = "Enable ValheimPlus";
                    enableDisableValheimPlusGameClientButton.Style = Application.Current.TryFindResource("MaterialDesignRaisedButton") as Style;

                    statusLabel.Foreground = Brushes.Green;
                    statusLabel.Content = "ValheimPlus disabled on game client!";
                }
                else
                {
                    System.IO.File.Move(String.Format("{0}winhttp_.dll", Settings.ClientInstallationPath), String.Format("{0}winhttp.dll", Settings.ClientInstallationPath));
                    enableDisableValheimPlusGameClientButton.Content = "Disable ValheimPlus";
                    enableDisableValheimPlusGameClientButton.Style = Application.Current.TryFindResource("MaterialDesignOutlinedButton") as Style;

                    statusLabel.Foreground = Brushes.Green;
                    statusLabel.Content = "ValheimPlus enabled on game client!";
                }
            }
            catch (Exception)
            {
                //
            }
        }

        private void setClientPathButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Executeable|valheim.exe"
            };

            if (dialog.ShowDialog() == true)
            {
                var fullPath = dialog.FileName;
                string formattedPath = String.Format("{0}\\", Path.GetDirectoryName(fullPath));
                string uriPath = new Uri(formattedPath).AbsolutePath.ToString();
                uriPath = Uri.UnescapeDataString(uriPath);
                Settings.ClientInstallationPath = uriPath;

                SettingsDAL.UpdateSettings(Settings, true);

                FetchSettings();

                statusLabel.Foreground = Brushes.Green;
                statusLabel.Content = "Path for game client set!";
            }
        }

        private void installServerButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult;

            if (!ValheimPlusInstalledServer)
            {
                messageBoxResult = MessageBox.Show("Are you sure you wish to install ValheimPlus on your server?", "Confirm", MessageBoxButton.YesNo);
            }
            else
            {
                messageBoxResult = MessageBox
                    .Show("Are you sure you wish to reinstall ValheimPlus on your server? This will overwrite your current configurations!", "Confirm");
            }

            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    FileManager.CopyFromTo(Settings.ServerPath, Settings.ServerInstallationPath);
                    ValheimPlusInstalledServer = ValidationManager.CheckInstallationStatus(Settings.ServerInstallationPath);
                    if (ValheimPlusInstalledServer)
                    {
                        serverInstalledLabel.Content = String.Format("ValheimPlus {0} installed on server", Settings.ValheimPlusServerClientVersion);
                        serverInstalledLabel.Foreground = Brushes.Green;
                        installServerButton.Content = "Reinstall ValheimPlus on server";
                        statusLabel.Foreground = Brushes.Green;
                        statusLabel.Content = "Success! Server client has been installed.";
                    }
                }
                catch (Exception)
                {
                    throw new Exception(); // ToDo - handling of errors
                }
            }
        }

        private async void checkServerUpdatesButton_Click(object sender, RoutedEventArgs e)
        {
            ValheimPlusUpdate valheimPlusUpdate = await UpdateManager.CheckForValheimPlusUpdatesAsync(Settings.ValheimPlusServerClientVersion);

            if (valheimPlusUpdate.NewVersion)
            {
                installServerUpdateButton.Content = String.Format("Install update {0}", valheimPlusUpdate.Version);
                installServerUpdateButton.IsEnabled = true;
                statusLabel.Foreground = Brushes.Green;
                statusLabel.Content = String.Format("Update {0} available for server client", valheimPlusUpdate.Version);
            }
            else
            {
                statusLabel.Foreground = Brushes.Red;
                statusLabel.Content = "No new server updates available";
            }
        }

        private async void installServerUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            installServerUpdateButton.IsEnabled = false;
            installServerUpdateButton.Content = "Installing update ...";

            ValheimPlusUpdate valheimPlusUpdate = await UpdateManager.CheckForValheimPlusUpdatesAsync(Settings.ValheimPlusServerClientVersion);

            if (valheimPlusUpdate.NewVersion)
            {
                bool success = await UpdateManager.DownloadValheimPlusUpdateAsync(Settings.ValheimPlusServerClientVersion, false);

                if (success)
                {
                    Settings = SettingsDAL.GetSettings();
                    serverInstalledLabel.Content = String.Format("ValheimPlus {0} installed on server", Settings.ValheimPlusServerClientVersion);
                    statusLabel.Foreground = Brushes.Green;
                    statusLabel.Content = "Success! Server client updated to latest version.";
                    installServerUpdateButton.Content = "Update installed!";
                    installServerUpdateButton.IsEnabled = false;
                }
            }
        }

        private void manageServerButton_Click(object sender, RoutedEventArgs e)
        {
            new ConfigurationManagerWindow(false).Show(); // Bool determines if user will manage conf. for server or game client
        }

        private void setServerPathButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Executeable|valheim_server.exe"
            };

            if (dialog.ShowDialog() == true)
            {
                var fullPath = dialog.FileName;
                string formattedPath = String.Format("{0}\\", Path.GetDirectoryName(fullPath));
                string uriPath = new Uri(formattedPath).AbsolutePath.ToString();
                uriPath = Uri.UnescapeDataString(uriPath);
                Settings.ServerInstallationPath = uriPath;

                SettingsDAL.UpdateSettings(Settings, false);

                FetchSettings();

                statusLabel.Foreground = Brushes.Green;
                statusLabel.Content = "Path for server client set!";
            }
        }

        private void launchGameButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"C:\Program Files (x86)\Steam\steam.exe", "steam://rungameid/892970");
            //Process.Start(String.Format("{0}valheim.exe", Settings.ClientInstallationPath));
        }

        public void UISettingsInit()
        {
            if (ValidationManager.CheckClientInstallationPath(Settings.ClientInstallationPath))
            {
                ValheimPlusInstalledClient = ValidationManager.CheckInstallationStatus(Settings.ClientInstallationPath);

                if (ValheimPlusInstalledClient)
                {
                    clientInstalledLabel.Content = String.Format("ValheimPlus {0} installed on client", Settings.ValheimPlusGameClientVersion);
                    clientInstalledLabel.Foreground = Brushes.Green;
                    installClientButton.Content = "Reinstall ValheimPlus on client";

                    var modActive = File.Exists(String.Format("{0}winhttp.dll", Settings.ClientInstallationPath));
                    if (modActive)
                    {
                        enableDisableValheimPlusGameClientButton.Content = "Disable ValheimPlus";
                        enableDisableValheimPlusGameClientButton.Style = Application.Current.TryFindResource("MaterialDesignOutlinedButton") as Style;
                    }
                    else
                    {
                        enableDisableValheimPlusGameClientButton.Content = "Enable ValheimPlus";
                        enableDisableValheimPlusGameClientButton.Style = Application.Current.TryFindResource("MaterialDesignRaisedButton") as Style;
                    }

                    installClientButton.Visibility = Visibility.Visible;
                    manageClientButton.Visibility = Visibility.Visible;
                    installClientUpdateButton.Visibility = Visibility.Visible;
                    checkClientUpdatesButtons.Visibility = Visibility.Visible;
                    enableDisableValheimPlusGameClientButton.Visibility = Visibility.Visible;
                    setClientPathButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    clientInstalledLabel.Content = "ValheimPlus not installed on client";
                    clientInstalledLabel.Foreground = Brushes.Red;

                    manageClientButton.Visibility = Visibility.Hidden;
                    installClientUpdateButton.Visibility = Visibility.Hidden;
                    checkClientUpdatesButtons.Visibility = Visibility.Hidden;
                    enableDisableValheimPlusGameClientButton.Visibility = Visibility.Hidden;
                    setClientPathButton.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                clientInstalledLabel.Content = "Valheim installation not found, select installation path by locating and choosing 'valheim.exe'";
                clientInstalledLabel.Foreground = Brushes.Red;

                manageClientButton.Visibility = Visibility.Hidden;
                installClientUpdateButton.Visibility = Visibility.Hidden;
                checkClientUpdatesButtons.Visibility = Visibility.Hidden;
                enableDisableValheimPlusGameClientButton.Visibility = Visibility.Hidden;
                installClientButton.Visibility = Visibility.Hidden;
                setClientPathButton.Margin = new Thickness(16, 78, 0, 0);
            }

            if (ValidationManager.CheckServerInstallationPath(Settings.ServerInstallationPath))
            {
                ValheimPlusInstalledServer = ValidationManager.CheckInstallationStatus(Settings.ServerInstallationPath);

                if (ValheimPlusInstalledServer)
                {
                    serverInstalledLabel.Content = String.Format("ValheimPlus {0} installed on server", Settings.ValheimPlusServerClientVersion);
                    serverInstalledLabel.Foreground = Brushes.Green;
                    installServerButton.Content = "Reinstall ValheimPlus on server";

                    installServerButton.Visibility = Visibility.Visible;
                    manageServerButton.Visibility = Visibility.Visible;
                    installServerUpdateButton.Visibility = Visibility.Visible;
                    checkServerUpdatesButton.Visibility = Visibility.Visible;
                    setServerPathButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    serverInstalledLabel.Content = "ValheimPlus not installed on server";
                    serverInstalledLabel.Foreground = Brushes.Red;

                    manageServerButton.Visibility = Visibility.Hidden;
                    installServerUpdateButton.Visibility = Visibility.Hidden;
                    checkServerUpdatesButton.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                serverInstalledLabel.Content = "Valheim installation not found, select installation path by locating and choosing 'valheim__server.exe'";
                serverInstalledLabel.Foreground = Brushes.Red;
                manageServerButton.Visibility = Visibility.Hidden;
                installServerUpdateButton.Visibility = Visibility.Hidden;
                checkServerUpdatesButton.Visibility = Visibility.Hidden;
                installServerButton.Visibility = Visibility.Hidden;
                setServerPathButton.Margin = new Thickness(16, 85, 0, 0);
            }
        }

        // Why two methods? 1. To reduce confusion, 2. In case IronGate adds a dedicated folder for server/client only
        private void backupServerButton_Click(object sender, RoutedEventArgs e)
        {
            FileManager.CopyFromTo(String.Format("C:/Users/{0}/AppData/LocalLow/IronGate", Environment.UserName), String.Format("C:/ValheimServerBackups/{0}", DateTime.Now.ToString("yyyy-MM-dd-HHmm")));
            statusLabel.Foreground = Brushes.Green;
            statusLabel.Content = "Server data backup complete!";
        }

        // Why two methods? 1. To reduce confusion, 2. In case IronGate adds a dedicated folder for server/client only
        private void backupClientButton_Click(object sender, RoutedEventArgs e)
        {
            FileManager.CopyFromTo(String.Format("C:/Users/{0}/AppData/LocalLow/IronGate", Environment.UserName), String.Format("C:/ValheimGameBackups/{0}", DateTime.Now.ToString("yyyy-MM-dd-HHmm")));
            statusLabel.Foreground = Brushes.Green;
            statusLabel.Content = "Game data backup complete!";
        }
    }
}
