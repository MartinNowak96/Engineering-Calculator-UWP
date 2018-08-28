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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Engineering_Math_Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }





        private void Hamberg_Menu_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                selectionFrame.Navigate(typeof(settingsPage));
            }
            else
            {
                switch (args.InvokedItem)
                {
                    case "Polar/Rectangular":
                        selectionFrame.Navigate(typeof(polarToRectangularPage));
                        break;
                    case "555 Timer":
                        selectionFrame.Navigate(typeof(_555Page));
                        break;

                    case "BinaryHexOctal":
                        selectionFrame.Navigate(typeof(binary));
                        break;

                    case "Function Calculator":
                        selectionFrame.Navigate(typeof(functionPage));
                        break;
                }
            }


        }

    }
}
