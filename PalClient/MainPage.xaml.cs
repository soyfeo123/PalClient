using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PalClient
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public static class UWPPalUtilities
    {
        public static async Task<string> GetPathFromUWPAsset(string assetName)
        {
            StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            string file = Path.Combine(InstallationFolder.Path, assetName);
            if (File.Exists(file))
                return file;
            else
                throw new FileNotFoundException("The file " + assetName + " does not exist.");
        }
    }

    public sealed partial class MainPage : Page
    {
        TabDefinitions allTabs;

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().Title = "Play Roblox";
            DoTabs();
            CustomTitleBar();
        }

        void CustomTitleBar()
        {
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            // Set the title bar colors
            titleBar.BackgroundColor = Colors.Transparent;
            titleBar.ButtonBackgroundColor = Colors.Transparent;

            // Set the inactive title bar colors
            titleBar.InactiveBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

            // Extend the view into the title bar
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
        }

        async void DoTabs()
        {
            string mainTabsPath = await UWPPalUtilities.GetPathFromUWPAsset("Assets/MainTabs.json");
            allTabs = JsonConvert.DeserializeObject<TabDefinitions>(File.ReadAllText(mainTabsPath));
            TabMenu.Items.Clear();
            foreach (TabItem_JSON item in allTabs.tabs)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = item.display;
                TabMenu.Items.Add(listBoxItem);
            }
            TabMenu.SelectionChanged += OnChangeList;
            TabMenu.SelectedIndex = 0;
        }

        private void OnChangeList(object sender, SelectionChangedEventArgs e)
        {
            ApplicationView.GetForCurrentView().Title = (string)((ListBoxItem)TabMenu.Items[TabMenu.SelectedIndex]).Content;
            CurrentPageTitle.Text = (string)((ListBoxItem)TabMenu.Items[TabMenu.SelectedIndex]).Content.ToString();
        }
    }

    public class TabDefinitions
    {
        public TabItem_JSON[] tabs { get; set; }
    }

    public class TabItem_JSON
    {
        public string display { get; set; }
        public string id { get; set; }
    }
}
