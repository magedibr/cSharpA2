using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AM_A2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1200, 700);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView appView = ApplicationView.GetForCurrentView();
appView.Title = "Calculator";
            ContentFrame.Navigate(typeof(ApplicationInfo));
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

         //   ContentFrame.Navigate(typeof(ApplicationInfo));

            var item = args.SelectedItemContainer;
            
            if (item != null)
            {
                switch (item.Tag.ToString())
                {
                   case "CalcP":
                        NavView.IsPaneVisible = true;
                        ContentFrame.Navigate(typeof(Calculator));
                        break;

                    case "AppIPage":
                        NavView.IsPaneVisible = true;

                        ContentFrame.Navigate(typeof(ApplicationInfo));
                        break;
                    case "DevIPage":
                        NavView.IsPaneVisible = true;

                        ContentFrame.Navigate(typeof(Dev));
                        break;

                }

            }





        }
    }
}
