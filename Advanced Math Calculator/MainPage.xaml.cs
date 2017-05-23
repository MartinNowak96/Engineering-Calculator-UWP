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

namespace Advanced_Math_Calculator
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

        private void HambergurButton_Click(object sender, RoutedEventArgs e)
        {
            Hamberg_Menu.IsPaneOpen = !Hamberg_Menu.IsPaneOpen;
        }


        private void IconListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FunctionCalc1.IsSelected)
            {
                selectionFrame.Navigate(typeof(functionPage));
                pageTitle.Text = "Function Calculator";
            }
            else if (settings.IsSelected)
            {
                selectionFrame.Navigate(typeof(settingsPage));
                pageTitle.Text = "Settings";
            }
            else if (polarRectangular.IsSelected)
            {
                selectionFrame.Navigate(typeof(polarToRectangularPage));
                pageTitle.Text = "Polar/Rectangular";
            }
            else if (BinaryHexOctal.IsSelected)
            {
                selectionFrame.Navigate(typeof(binary));
                pageTitle.Text = "Binary/Octal/Hex";
            }

        }
    }
}
