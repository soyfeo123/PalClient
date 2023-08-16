using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.Storage;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PalClient
{
    public sealed partial class LaunchRobloxTab : UserControl
    {
        public LaunchRobloxTab()
        {
            this.InitializeComponent();
            DoStuff();
            
        }

        async void DoStuff()
        {
            string robloxVerPath = "";
            PBtn.IsEnabled = false;
            try
            {
                robloxVerPath = await GetCurrentRobloxVersion();
                string ver = robloxVerPath;
                Console.Write(ver);
                Info.Text = "Version: " + ver + "\nLauncher: RobloxPlayerBeta.exe";
                PBtn.IsEnabled = true;
            }
            catch (DirectoryNotFoundException ex)
            {
                Info.Text = "Roblox is not installed.";
            }
            catch (Exception ex)
            {
                Info.Text = "An unexpected error occured. (" + ex.Message + ")";
            }
        }

        async Task<string> GetCurrentRobloxVersion()
        {
            string localAD = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            localAD = localAD.Substring(0, localAD.Length - 7);
            localAD = Path.Combine(localAD, "Local");
            PBtn.Content = Path.Combine(localAD, "Roblox");
            string robloxDirectory = "";

            //if(Directory.Exists(Path.Combine(localAD, "Roblox")))
            //{
            //    throw new DirectoryNotFoundException("Roblox is not installed.");
            //}
            robloxDirectory = Path.Combine(localAD, "Roblox", "Versions");
            StorageFolder versFolder = await StorageFolder.GetFolderFromPathAsync(robloxDirectory);
            StorageFolder[] allVersions = (StorageFolder[])await versFolder.GetFoldersAsync();
            foreach(StorageFolder version in allVersions)
            {
                if(File.Exists(Path.Combine(version.Path, "RobloxPlayerBeta.exe")))
                {
                    robloxDirectory = version.Path;
                    break;
                }
            }
            return robloxDirectory;
        }
    }
}
