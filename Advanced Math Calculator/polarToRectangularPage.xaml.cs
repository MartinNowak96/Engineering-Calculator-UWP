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

        }

        private void polarBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculateResult();
            typeTitle11.Text = "R";
            typeTitle12.Text = "θ";
        }

        private void rectangleBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculateResult();
            typeTitle11.Text = "X";
            typeTitle12.Text = "Y";
        }

        private void polarBox2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculateResult();
            typeTitle21.Text = "R";
            typeTitle22.Text = "θ";
        }

        private void rectangleBox2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculateResult();
            typeTitle21.Text = "X";
            typeTitle22.Text = "Y";
        }
        private void polarBox3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculateResult();
            typeTitle31.Text = "R";
            typeTitle32.Text = "θ";
        }

        private void rectangleBox3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculateResult();
            typeTitle31.Text = "X";
            typeTitle32.Text = "Y";
        }

        private void textBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        double rthetaToX(double r, double theta)
        {
            double xvalue = r * (Math.Cos(theta*Math.PI/180));
            return xvalue;
        }
        double rthetaToY(double r, double theta)
        {
            double Yvalue = r * Math.Sin(theta * Math.PI /180);
            return Yvalue;
        }
        double xyToR(double xvalue, double yvalue)
        {
            double rvalue = Math.Pow(Math.Pow(xvalue,2)+Math.Pow(yvalue,2), .5);
            return rvalue;
        }
        double xyToTheta(double xvalue, double yvalue)
        {
            double theta;
            if (xvalue != 0)
            {
                theta = Math.Atan(yvalue / xvalue) * 180 / Math.PI;
            } else
            {
                theta = Math.Atan(yvalue / .000000000000000000001);
            }

            return theta;
        }

        void calculateResult()
        {
            if(input11.Text != "" && input12.Text != "" && input21.Text != "" && input22.Text != "")
            {
                double x1 = Convert.ToDouble(input11.Text);
        double y1 = Convert.ToDouble(input12.Text);
        double x2 = Convert.ToDouble(input21.Text);
        double y2 = Convert.ToDouble(input22.Text);
        double resultX1;
        double resultY1;


                if(operandselection.SelectedIndex == 0)//addition
                {
                    if(inputType1.SelectedIndex == 1)//if input1 is polar
                    {
                        double x3;
                        x3 = rthetaToX(x1, y1);
                        y1 = rthetaToY(x1, y1);
                        x1 = x3;
                    }
                    if (inputType2.SelectedIndex == 1)//if input2 is polar
                    {
                         double x3;
                         x3 = rthetaToX(x2, y2);
                         y2 = rthetaToY(x2, y2);
                        x2 = x3;
                    }
                        resultX1 = x1 + x2;
                        resultY1 = y1 + y2;
                    if (resultBox.SelectedIndex == 1)//if the answer is in polar
                    {
                        double x3;
                        x3= xyToR(resultX1, resultY1);
                        resultY1 = xyToTheta(resultX1, resultY1);
                        resultX1 = x3;
                        RadialGauge.Value =90- resultY1;
                    }
                    resultX.Text = resultX1.ToString();
                    resultY.Text = resultY1.ToString();

                    
                }
                else if(operandselection.SelectedIndex == 1)
                {
                    if (inputType1.SelectedIndex == 1)//if input1 is polar
                    {
                        double x3;
                        x3 = rthetaToX(x1, y1);
                        y1 = rthetaToY(x1, y1);
                        x1 = x3;
                    }
                    if (inputType2.SelectedIndex == 1)//if input2 is polar
                    {
                        double x3;
                        x3 = rthetaToX(x2, y2);
                        y2 = rthetaToY(x2, y2);
                        x2 = x3;
                    }
                    resultX1 = x1 - x2;
                    resultY1 = y1 - y2;
                    if (resultBox.SelectedIndex == 1)//if the answer is in polar
                    {
                        double x3;
                        x3 = xyToR(resultX1, resultY1);
                        resultY1 = xyToTheta(resultX1, resultY1);
                        resultX1 = x3;
                        RadialGauge.Value =90- resultY1;


                    }
                   
                    resultX.Text = resultX1.ToString();
                    resultY.Text = resultY1.ToString();

                }
                else if (operandselection.SelectedIndex == 2)
                {
                    
                }
                else if (operandselection.SelectedIndex == 3)
                {
                    
                }
                    
            }
        }












        private void inputsChange(object sender, TextChangedEventArgs e)
        {
            calculateResult();
        }


        private void DropBoxChange(object sender, SelectionChangedEventArgs e)
        {
            calculateResult();
        }

        private void operandPressed(object sender, TappedRoutedEventArgs e)
        {
            calculateResult();
        }
    }
}
