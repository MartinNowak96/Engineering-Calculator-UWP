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
    public sealed partial class binary : Page
    {
        public binary()
        {
            this.InitializeComponent();
        }

        private void swapButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int inputIndex = inputType1.SelectedIndex;
            int outputIndex = outputType1.SelectedIndex;
            //swapping the inputs
            inputType1.SelectedIndex = outputIndex;
            outputType1.SelectedIndex = inputIndex;

            calculate();

        }

        //decimal to binary dont work
        void calculate()
        {
            string input = inputBox.Text.ToUpper();
            double total = 0;
            double midInput = 1;
            double midInput1=0;



            if (inputBox.Text != "")
            {
                //if decimal is result
                if (outputType1.SelectedIndex == 1)
                {
                    for (int i = 0; input.Length != 0; i++)
                    {
                        midInput = Convert.ToDouble(input.Substring(input.Length - 1, 1));
                        int base1 = 0;
                        if (inputType1.SelectedIndex == 0)//binary
                            base1 = 2;
                        else if (inputType1.SelectedIndex == 1)//dec
                            base1 = 10;
                        else if (inputType1.SelectedIndex == 2)//hex
                            base1 = 16;
                        else if (inputType1.SelectedIndex == 3)//octal
                            base1 = 8;

                        midInput = Math.Pow(base1, i) * midInput;
                        total = total + midInput;
                        input = input.Substring(0, input.Length - 1);
                    }
                    outputBox.Text = total.ToString();

                }
                //if binary is result
                else if (outputType1.SelectedIndex == 0)
                {
                    //if input is binary
                    if(inputType1.SelectedIndex == 0){
                        outputBox.Text = inputBox.Text;   
                    }
                    //if input is hex
                    else if (inputType1.SelectedIndex == 2)
                    {
                        string resultBinary = "";
                        while (input != "")
                        {
                            string input1 = input.Substring(input.Length - 1, 1);
                            input = input.Substring(0, input.Length - 1);

                            switch (input1)
                            {
                                case "0":
                                    resultBinary = "0000" + resultBinary;
                                    break;
                                case "1":
                                    resultBinary = "0001" + resultBinary;
                                    break;
                                case "2":
                                    resultBinary = "0010" + resultBinary;
                                    break;
                                case "3":
                                    resultBinary = "0011" + resultBinary;
                                    break;
                                case "4":
                                    resultBinary = "0100" + resultBinary;
                                    break;
                                case "5":
                                    resultBinary = "0101" + resultBinary;
                                    break;
                                case "6":
                                    resultBinary = "0110" + resultBinary;
                                    break;
                                case "7":
                                    resultBinary = "0111" + resultBinary;
                                    break;
                                case "8":
                                    resultBinary = "1000" + resultBinary;
                                    break;
                                case "9":
                                    resultBinary = "1001" + resultBinary;
                                    break;
                                case "A":
                                    resultBinary = "1010" + resultBinary;
                                    break;
                                case "B":
                                    resultBinary = "1011" + resultBinary;
                                    break;
                                case "C":
                                    resultBinary = "1100" + resultBinary;
                                    break;
                                case "D":
                                    resultBinary = "1101" + resultBinary;
                                    break;
                                case "E":
                                    resultBinary = "1110" + resultBinary;
                                    break;
                                case "F":
                                    resultBinary = "1111" + resultBinary;
                                    break;
                            }
                            outputBox.Text = resultBinary;

                        }
                    }
                    //if input is octal
                    else if (inputType1.SelectedIndex == 3)
                    {
                        string resultBinary = "";
                        while (input != "")
                        {
                            string input1 = input.Substring(input.Length - 1, 1);
                            input = input.Substring(0, input.Length - 1);

                            switch(input1){
                                case "0":
                                    resultBinary = "000" + resultBinary;
                                    break;
                                case "1":
                                    resultBinary = "001" + resultBinary;
                                    break;
                                case "2":
                                    resultBinary = "010" + resultBinary;
                                    break;
                                case "3":
                                    resultBinary = "011" + resultBinary;
                                    break;
                                case "4":
                                    resultBinary = "100" + resultBinary;
                                    break;
                                case "5":
                                    resultBinary = "101" + resultBinary;
                                    break;
                                case "6":
                                    resultBinary = "110" + resultBinary;
                                    break;
                                case "7":
                                    resultBinary = "111" + resultBinary;
                                    break;
                            }
                            outputBox.Text = resultBinary;

                        }
                    }
                    //if input is decimal
                    else if (inputType1.SelectedIndex == 1)
                    {
                        for (int i = 0; midInput != 0; i++)
                        {
                            if (i == 0)
                            {
                                midInput = Convert.ToDouble(input) / 2;
                                midInput1 = Math.Round(Convert.ToDouble(input) / 2);
                            }
                            else
                            {
                                midInput = Convert.ToDouble(midInput1) / 2;
                                midInput1 = Math.Round(Convert.ToDouble(midInput1) / 2);
                                
                            }
                            int num = 0;
                            if (midInput == midInput1)//means 0
                            {
                                num = 0;
                            }
                            else
                            {
                                num = 1;
                            }
                            total = total + (num * Math.Pow(10, i));
                            
                        }//end for
                        outputBox.Text = total.ToString(###################,#0);
                    }
                }
                //if octal is result
                else if (outputType1.SelectedIndex == 3)
                {
                    //if input is octal
                    if (inputType1.SelectedIndex == 3)
                    {
                        outputBox.Text = inputBox.Text;
                    }
                    //if input is binary
                    if (inputType1.SelectedIndex == 0)
                    {

                    }
                }
                //if HEX is result
                else if (outputType1.SelectedIndex == 2)
                {
                    //if input is Hex
                    if (inputType1.SelectedIndex == 2)
                    {
                        outputBox.Text = inputBox.Text;
                    }
                    //if input is binary
                    else if(inputType1.SelectedIndex == 0){
                        string resultHEX = "";
                        while (input != "")
                        {
                            if (input.Length >= 4)
                            {

                                string inputFour = input.Substring(input.Length - 4, 4); //gets the last 4 bits
                                switch (inputFour)
                                {
                                    case "0000":
                                        resultHEX = "0" + resultHEX;
                                        break;
                                    case "0001":
                                        resultHEX = "1" + resultHEX;
                                        break;
                                    case "0010":
                                        resultHEX = "2" + resultHEX;
                                        break;
                                    case "0011":
                                        resultHEX = "3" + resultHEX;
                                        break;
                                    case "0100":
                                        resultHEX = "4" + resultHEX;
                                        break;
                                    case "0101":
                                        resultHEX = "5" + resultHEX;
                                        break;
                                    case "0110":
                                        resultHEX = "6" + resultHEX;
                                        break;
                                    case "0111":
                                        resultHEX = "7" + resultHEX;
                                        break;
                                    case "1000":
                                        resultHEX = "8" + resultHEX;
                                        break;
                                    case "1001":
                                        resultHEX = "9" + resultHEX;
                                        break;
                                    case "1010":
                                        resultHEX = "A" + resultHEX;
                                        break;
                                    case "1011":
                                        resultHEX = "B" + resultHEX;
                                        break;
                                    case "1100":
                                        resultHEX = "C" + resultHEX;
                                        break;
                                    case "1101":
                                        resultHEX = "D" + resultHEX;
                                        break;
                                    case "1110":
                                        resultHEX = "E" + resultHEX;
                                        break;
                                    case "1111":
                                        resultHEX = "F" + resultHEX;
                                        break;
                                }
                                input = input.Substring(0, input.Length - 4);//removes last 4 bits
                            }
                            else if (input != "")
                            {
                                while (input.Length < 4)
                                {
                                    input = "0" + input;
                                }
                            }
                        }
                        outputBox.Text = resultHEX;
                    }
                }



            }
        }

        private void inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculate();
            if(inputBox.Text == ""){
                outputBox.Text = "";
            }
        }

        //input boxes changed
        private void inputBinary_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculate();
        }
        private void inputDecimal_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculate();
        }
        private void inputHex_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculate();
        }
        private void inputOctal_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculate();
        }
        //output boxes changed
        private void outputBinary_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculate();
        }
        private void outputDecimal_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculate();
        }
        private void outputHex_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculate();
        }
        private void outputOctal_Tapped(object sender, TappedRoutedEventArgs e)
        {
            calculate();
        }
        
        private void inputBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {//char by char
            
                   int position = inputBox.SelectionStart;
                   string input = inputBox.Text;
                   string inputReplace = input;
            while (input != "")
            {
                if (inputType1.SelectedIndex == 1) {//decimal mask
                    if (input.Length == 1)//if there is only 1 char in inputReplace
                    {
                        if (!input.Any(char.IsDigit))//is it not a digit
                        {
                            inputReplace = inputReplace.Replace(input, "");//replace it with nothing

                            inputBox.Text = inputReplace;//set the output
                            inputBox.SelectionStart = position - 1;//set the position
                            break;
                        }
                        input = "";
                        break;
                    }
                    if (!input.Substring(0, 1).Any(char.IsDigit))// if its not a digit
                    {
                        inputReplace = inputReplace.Replace(input.Substring(0, 1), "");//replace the bad char with nothing
                        inputBox.Text = inputReplace;
                        inputBox.SelectionStart = position - 1;
                    }
                    if (input.Length != 1)
                    {
                        input = input.Substring(1, input.Length - 1);//removes first char to check the next***
                    }

                }
                else if (inputType1.SelectedIndex == 0)
                {//binary mask
                    if (input.Length == 1)//if there is only 1 char in inputReplace
                    {
                        if (input != "1" && input != "0")//is it not a 1 or 0
                        {
                            inputReplace = inputReplace.Replace(input, "");//replace it with nothing

                            inputBox.Text = inputReplace;//set the output
                            inputBox.SelectionStart = position - 1;//set the position
                            break;
                        }
                        input = "";
                        break;
                    }
                    if (input.Substring(0, 1) !="1" && input.Substring(0, 1) != "0")// if its not a 1 or 0
                    {
                        inputReplace = inputReplace.Replace(input.Substring(0, 1), "");//replace the bad char with nothing
                        inputBox.Text = inputReplace;
                        inputBox.SelectionStart = position - 1;
                    }
                    if (input.Length != 1)
                    {
                        input = input.Substring(1, input.Length - 1);//removes first char to check the next***
                    }

                }
                else if (inputType1.SelectedIndex == 3)
                {//octal mask
                    if (input.Length == 1)//if there is only 1 char in inputReplace
                    {
                        if (input != "1" && input != "0" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7")//is it not a 1 or 0
                        {
                            inputReplace = inputReplace.Replace(input, "");//replace it with nothing

                            inputBox.Text = inputReplace;//set the output
                            inputBox.SelectionStart = position - 1;//set the position
                            break;
                        }
                        input = "";
                        break;
                    }
                    if (input.Substring(0, 1) != "1" && input.Substring(0, 1) != "0" && input.Substring(0, 1) != "2" && input.Substring(0, 1) != "3" && input.Substring(0, 1) != "4" && input.Substring(0, 1) != "5" && input.Substring(0, 1) != "6" && input.Substring(0, 1) != "7")// if its not a 1 or 0
                    {
                        inputReplace = inputReplace.Replace(input.Substring(0, 1), "");//replace the bad char with nothing
                        inputBox.Text = inputReplace;
                        inputBox.SelectionStart = position - 1;
                    }
                    if (input.Length != 1)
                    {
                        input = input.Substring(1, input.Length - 1);//removes first char to check the next***
                    }

                }
                else if (inputType1.SelectedIndex == 2)
                {//Hex mask
                    
                    input = input.ToUpper();
                    inputReplace = input.ToUpper();


                    if (input.Length == 1)//if there is only 1 char in inputReplace
                    {
                        if (input != "A" && input != "B" && input != "C" && input != "D" && input != "E" && input != "F" && !input.Any(char.IsDigit))// if its not num or ABCDEF
                        {
                            inputReplace = inputReplace.Replace(input, "");//replace it with nothing

                            inputBox.Text = inputReplace;//set the output
                            inputBox.SelectionStart = position - 1;//set the position
                            break;
                        }
                        input = "";
                        break;
                    }
                    if (input.Substring(0, 1) != "A" && input.Substring(0, 1) != "B" && input.Substring(0, 1) != "C" && input.Substring(0, 1) != "D" && input.Substring(0, 1) != "E" && input.Substring(0, 1) != "F" && !input.Substring(0, 1).Any(char.IsDigit))// if its not num or ABCDEF
                    {
                        inputReplace = inputReplace.Replace(input.Substring(0, 1), "");//replace the bad char with nothing
                        inputBox.Text = inputReplace;
                        inputBox.SelectionStart = position - 1;
                    }
                    if (input.Length != 1)
                    {
                        input = input.Substring(1, input.Length - 1);//removes first char to check the next***
                    }

                }
            }
        }
               
    }
}
