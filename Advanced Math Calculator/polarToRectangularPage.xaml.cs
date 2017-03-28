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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Advanced_Math_Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class polarToRectangularPage : Page
    {
        public polarToRectangularPage()
        {
            this.InitializeComponent();
        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void inputType1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           //if (typeTitle11.Text == "X")
           // { 
            //    typeTitle11.Text = "R";
             //   typeTitle12.Text = "Theta";
                
           // }
           // else
           // {
           //     typeTitle11.Text = "X";
           //     typeTitle12.Text = "Y";
           // }
        }

        private void polarBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            typeTitle11.Text = "X";
            typeTitle12.Text = "Y";
        }

        private void rectangleBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            typeTitle11.Text = "R";
            typeTitle12.Text = "Theta";
        }
    }
}
