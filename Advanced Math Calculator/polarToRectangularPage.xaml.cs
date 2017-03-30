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

        private void textBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }



        //drop box change
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


        //conversions
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
                        x3 = xyToR(resultX1, resultY1);
                        resultY1 = xyToTheta(resultX1, resultY1);
                        resultX1 = x3;

                        if (resultY1 >= 0)
                        {
                            resultY1 = -resultY1;
                            while (resultY1 < 0)
                            {
                                resultY1 = resultY1 + 360;
                            }
                            RadialGauge.Value = resultY1;
                        }
                        else
                        {

                            resultY1 = -resultY1;
                            while (resultY1 < 0)
                            {
                                resultY1 = resultY1 + 360;
                            }

                            RadialGauge.Value = resultY1;
                        }


                        resultX.Text = resultX1.ToString();
                        resultY.Text = resultY1.ToString();

                    }
                    else
                    {

                        resultX.Text = resultX1.ToString();
                        resultY.Text = resultY1.ToString();

                        double x5;
                        x5 = xyToR(resultX1, resultY1);
                        resultY1 = xyToTheta(resultX1, resultY1);
                        resultX1 = x5;
                        if (resultY1 >= 0)
                        {
                            double y1Theta = -resultY1;
                            while (y1Theta < 0)
                            {
                                y1Theta = y1Theta + 360;
                            }
                            RadialGauge.Value = y1Theta;
                        }
                        else
                        {

                            double y1Theta = -resultY1;
                            while (y1Theta < 0)
                            {
                                y1Theta = y1Theta + 360;
                            }

                            RadialGauge.Value = y1Theta;
                        }

                    }

                }//addition
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
                        RadialGauge.Value = 90 - resultY1;
                        resultX.Text = resultX1.ToString();
                        resultY.Text = resultY1.ToString();

                    }
                    else
                    {

                        resultX.Text = resultX1.ToString();
                        resultY.Text = resultY1.ToString();

                        double x5;
                        x5 = xyToR(resultX1, resultY1);
                        resultY1 = xyToTheta(resultX1, resultY1);
                        resultX1 = x5;
                        RadialGauge.Value = 90 - resultY1;
                    }

                }//subtraction
                else if (operandselection.SelectedIndex == 2)//division
                {
                    double xone = Convert.ToDouble(input11.Text);
                    double yone = Convert.ToDouble(input12.Text);
                    double xtwo = Convert.ToDouble(input21.Text);
                    double ytwo = Convert.ToDouble(input22.Text);
                    double x1result;
                    double y1result;

                    if (inputType1.SelectedIndex == 0)//if its rectangular convert it to polar
                    {
                        double xone2 = xyToR(xone, yone);
                        yone = xyToTheta(xone, yone);
                        xone = xone2;
                    }
                    if (inputType2.SelectedIndex == 0)//if its rectangular convert it to polar
                    {
                        double xtwo2 = xyToR(xtwo, ytwo);
                        ytwo = xyToTheta(xtwo, ytwo);
                        xtwo = xtwo2;
                    }
                    x1result = xone / xtwo;//polar
                    y1result = yone - ytwo;
                    if (resultBox.SelectedIndex == 1)//if the answer is in polar
                    {
                        resultX.Text = x1result.ToString();
                        resultY.Text = y1result.ToString();


                       
                        if (y1result>= 0)
                        {
                            y1result = -y1result;
                            while (y1result < 0)
                            {
                                y1result= y1result + 360;
                            }
                            RadialGauge.Value = y1result; 
                        }
                        else
                        {

                            y1result = -y1result;
                            while (y1result < 0)
                            {
                                y1result = y1result + 360;
                            }
                            
                            RadialGauge.Value = y1result;
                        }
                       

                    }
                    else//if the answer is in rectangular, change polar into rectangle
                    {
                        double x3;
                        if (y1result >= 0)
                        {
                            double y1Theta = -y1result;
                            while (y1Theta < 0)
                            {
                                y1Theta = y1Theta + 360;
                            }
                            RadialGauge.Value = y1Theta;
                        }
                        else
                        {

                            double y1Theta = -y1result;
                            while (y1Theta < 0)
                            {
                                y1Theta = y1Theta + 360;
                            }

                            RadialGauge.Value = y1Theta;
                        }


                        x3 = rthetaToX(x1result, y1result);
                        y1result = rthetaToY(x1result, y1result);
                        resultX1 = x3;
                        
                        resultX.Text = resultX1.ToString();
                        resultY.Text = y1result.ToString();

                    }
                }//division
                else if (operandselection.SelectedIndex == 3)
                {
                    
                }
                    
            }//multiplication
        }//calculations



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

        //text changing only allow numbers
        private void input11_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            string x = input11.Text;
            string xnum = input11.Text;
            int position = input11.SelectionStart;
            while (xnum != "")
            {
                if (xnum.Length == 1)//if there is only 1 char in x
                {
                    if (!xnum.Any(char.IsDigit) && xnum != ".")//is it not a digit or a decimal
                    {
                        x = x.Replace(xnum, "");//replace it with nothing

                        input11.Text = x;//set the output
                        input11.SelectionStart = position - 1;//set the position
                        break;
                    }
                    xnum = "";
                    break;
                }
                if (!xnum.Substring(0, 1).Any(char.IsDigit) && xnum.Substring(0, 1) != ".")// if its not a digit or a decimal 
                {
                    x = x.Replace(xnum.Substring(0, 1), "");//replace the bad char with nothing
                    input11.Text = x;
                    input11.SelectionStart = position - 1;
                }
                if (xnum.Length != 1)
                {
                    xnum = xnum.Substring(1, xnum.Length - 1);//removes first char to check the next
                }

            }//end while
        }
        private void input12_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            string x = input12.Text;
            string xnum = input12.Text;
            int position = input12.SelectionStart;
            while (xnum != "")
            {
                if (xnum.Length == 1)//if there is only 1 char in x
                {
                    if (!xnum.Any(char.IsDigit) && xnum != ".")//is it not a digit or a decimal
                    {
                        x = x.Replace(xnum, "");//replace it with nothing

                        input12.Text = x;//set the output
                        input12.SelectionStart = position - 1;//set the position
                        break;
                    }
                    xnum = "";
                    break;
                }
                if (!xnum.Substring(0, 1).Any(char.IsDigit) && xnum.Substring(0, 1) != ".")// if its not a digit or a decimal 
                {
                    x = x.Replace(xnum.Substring(0, 1), "");//replace the bad char with nothing
                    input12.Text = x;
                    input12.SelectionStart = position - 1;
                }
                if (xnum.Length != 1)
                {
                    xnum = xnum.Substring(1, xnum.Length - 1);//removes first char to check the next
                }

            }//end while
        }
        private void input21_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            string x = input21.Text;
            string xnum = input21.Text;
            int position = input21.SelectionStart;
            while (xnum != "")
            {
                if (xnum.Length == 1)//if there is only 1 char in x
                {
                    if (!xnum.Any(char.IsDigit) && xnum != ".")//is it not a digit or a decimal
                    {
                        x = x.Replace(xnum, "");//replace it with nothing

                        input21.Text = x;//set the output
                        input21.SelectionStart = position - 1;//set the position
                        break;
                    }
                    xnum = "";
                    break;
                }
                if (!xnum.Substring(0, 1).Any(char.IsDigit) && xnum.Substring(0, 1) != ".")// if its not a digit or a decimal 
                {
                    x = x.Replace(xnum.Substring(0, 1), "");//replace the bad char with nothing
                    input21.Text = x;
                    input21.SelectionStart = position - 1;
                }
                if (xnum.Length != 1)
                {
                    xnum = xnum.Substring(1, xnum.Length - 1);//removes first char to check the next
                }

            }//end while
        }
        private void input22_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            string x = input22.Text;
            string xnum = input22.Text;
            int position = input22.SelectionStart;
            while (xnum != "")
            {
                if (xnum.Length == 1)//if there is only 1 char in x
                {
                    if (!xnum.Any(char.IsDigit) && xnum != ".")//is it not a digit or a decimal
                    {
                        x = x.Replace(xnum, "");//replace it with nothing

                        input22.Text = x;//set the output
                        input22.SelectionStart = position - 1;//set the position
                        break;
                    }
                    xnum = "";
                    break;
                }
                if (!xnum.Substring(0, 1).Any(char.IsDigit) && xnum.Substring(0, 1) != ".")// if its not a digit or a decimal 
                {
                    x = x.Replace(xnum.Substring(0, 1), "");//replace the bad char with nothing
                    input22.Text = x;
                    input22.SelectionStart = position - 1;
                }
                if (xnum.Length != 1)
                {
                    xnum = xnum.Substring(1, xnum.Length - 1);//removes first char to check the next
                }

            }//end while
        }
    }
}
