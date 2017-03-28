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
    public sealed partial class functionPage : Page
    {
        public functionPage()
        {
            this.InitializeComponent();
        }
        private void equation_TextChanged(object sender, TextChangedEventArgs e)
        {
            int position = equation.SelectionStart;
            string formula = equation.Text;
            if (parenthesis_assist.IsOn == true)
            {//parenassit
                if (position - 1 > 0)
                {
                    if (formula.Substring(position - 1) == "^")
                    {
                        formula = formula.Replace("^", "^()");
                        equation.Text = formula;
                        equation.SelectionStart = position + 1;
                    }
                    if (formula.Substring(position - 1) == "(")
                    {
                        formula = formula.Replace("(", "()");
                        equation.Text = formula;
                        equation.SelectionStart = position;
                    }
                    if (formula.Substring(position - 1) == "/")
                    {
                        formula = formula.Replace("/", "/()");
                        equation.Text = formula;
                        equation.SelectionStart = position + 1;
                    }
                }
            }//parenAssist 
        }

        string piconvert(string formula)
        {
            string stringpi = "3.141592653589793238462643";
            string pifunction = formula;

            while (formula.Contains("π"))
            {
                string pipart;

                if (formula.IndexOf("π") != 0 && formula.IndexOf("π") != formula.Length - 1)//if pi isnt the begining or end (middle)
                {
                    pifunction = formula.Substring(formula.LastIndexOf("π") - 1, formula.Length - formula.LastIndexOf("π") + 1);
                    formula = formula.Substring(0, formula.LastIndexOf("π") - 1);
                }
                else if (formula.IndexOf("π") == 0)//if pi is the first char
                {
                    pifunction = pifunction.Substring(pifunction.LastIndexOf("π"), pifunction.Length - pifunction.LastIndexOf("π"));
                    formula = "π_";
                }
                else if (formula.IndexOf("π") == formula.Length - 1)//if pi is the last char
                {
                    pifunction = pifunction.Substring(pifunction.LastIndexOf("π") - 1, pifunction.Length - pifunction.LastIndexOf("π") + 1);
                    formula = formula.Substring(0, formula.LastIndexOf("π") - 1);
                }


                if (formula.IndexOf("π") != 0)//if pi isnt at the beginging
                {
                    pipart = pifunction.Substring(pifunction.IndexOf("π") - 1, 2);//first part of _pi
                    pipart = pipart.Replace("π", "");
                    if (pipart.Contains(")") || pipart.Any(char.IsDigit) || pipart.Contains("x"))//if a number or ) or x is in front of pi put a *
                    {
                        pifunction = pifunction.Replace("π", "*π");
                    }
                }
                if (pifunction.IndexOf("π") != pifunction.Length - 1)//if pi isnt at the end
                {
                    pipart = pifunction.Substring(pifunction.IndexOf("π"), 2);
                    pipart = pipart.Replace("π", "");
                    if (pipart.Contains("(") || pipart.Any(char.IsDigit) || pipart.Contains("x"))//if a number or ( or x is behind of pi put a *
                    {
                        pifunction = pifunction.Replace("π", "π*");
                    }
                }



                pifunction = pifunction.Replace("π", stringpi);
                if (formula.IndexOf("π") != 0 && formula.IndexOf("π") != formula.Length - 1)//if pi isnt the begining or end (middle)
                {
                    formula = formula + pifunction;
                }
                else if (formula.IndexOf("π") == 0)
                {
                    formula = pifunction;
                }
                else if (pifunction.IndexOf("π") == formula.Length - 1)
                {
                    formula = formula + pifunction;
                }

            }//ends while

            return formula;
        }//ends pi function
        string evaluateExponant(string partMD, double xvalue)
        {
            string expoBase = partMD.Substring(0, partMD.IndexOf("^"));
            if (!partMD.Substring(partMD.IndexOf("^") + 1, partMD.Length - partMD.IndexOf("^") - 1).Contains("/"))
            {


                string exponant = partMD.Substring(partMD.IndexOf("^") + 1, partMD.Length - partMD.IndexOf("^") - 1);
                double expoBaseDouble = breakUpX(expoBase, xvalue);
                double exponantDouble = breakUpX(exponant, xvalue);

                partMD = Math.Pow(expoBaseDouble, exponantDouble).ToString();
            }

            return partMD;
        }
        double evaluateASMD(string formula1, double xValue, int numOfBits)
        {
            int[] OperandAS = new int[numOfBits];
            int[] OperandMD = new int[numOfBits];
            string[] partsAS = new string[numOfBits];
            string partMD = "0";
            double[] partsFinal = new double[numOfBits];
            double[] result = new double[numOfBits];
            double finalresult = 0;
            double[] valueAS = new double[numOfBits];
            int numOfAS = 0;

            for (numOfAS = 0; formula1.IndexOf("+") > -1 || formula1.IndexOf("-") > -1; numOfAS++)// breaks up the pluses and minus into operand and parts array
            {

                if (formula1.Contains("+") && formula1.IndexOf("+") < formula1.IndexOf("-") || formula1.IndexOf("-") == -1)//checks if its a plus or minus comes first
                {
                    if (formula1.Contains("+"))
                    {
                        OperandAS[numOfAS] = 0;//0 for additon 
                        partsAS[numOfAS] = formula1.Substring(0, formula1.IndexOf("+"));//took the first term of the eqaution to the array
                        formula1 = formula1.Substring(formula1.IndexOf("+") + 1, formula1.Length - formula1.IndexOf("+") - 1);//removes the first term from the equation
                    }
                }
                else if (formula1.IndexOf("-") < formula1.IndexOf("+") || formula1.IndexOf("+") == -1)//checks if its a plus or minus comes first
                {
                    if (formula1.IndexOf("-") == 0)//if negative comes first
                    {
                        string formulaWONeg = formula1.Substring(1, formula1.Length - 1);//take off negative
                        if (formulaWONeg.IndexOf("-") < formulaWONeg.IndexOf("+") && formulaWONeg.IndexOf("-") != -1 || formula1.IndexOf("+") == -1)//if next is a -
                        {
                            if (formulaWONeg.IndexOf("-") > formulaWONeg.IndexOf("/") && formulaWONeg.IndexOf("-") > formulaWONeg.IndexOf("*"))//if a / or * comes before the next -
                            {
                                //maybe breaks thes up into 2
                            }
                            partsAS[numOfAS] = formula1.Substring(0, formula1.Substring(1, formula1.Length - 1).IndexOf("-") + 1);
                            if (formula1.Substring(1, formula1.Length - 1).Contains("-"))
                            {
                                formula1 = formula1.Substring(1, formula1.Length - 1);
                                formula1 = formula1.Substring(formula1.IndexOf("-"), formula1.Length - formula1.IndexOf("-"));
                            }
                            else
                            {
                                partsAS[numOfAS] = formula1;
                                formula1 = "";
                            }
                        }
                        else if ((formulaWONeg.IndexOf("+") < formulaWONeg.IndexOf("-") && formulaWONeg.IndexOf("+") != -1) || formulaWONeg.IndexOf("-") == -1)//if next is a +
                        {
                            partsAS[numOfAS] = formula1.Substring(0, formula1.IndexOf("+"));
                            formula1 = formula1.Substring(1, formula1.Length - 1);
                            formula1 = formula1.Substring(formula1.IndexOf("+") + 1, formula1.Length - formula1.IndexOf("+") - 1);
                        }

                    }//end if negative came first
                    else
                    {
                        OperandAS[numOfAS] = 1;//1 for subtration
                        partsAS[numOfAS] = formula1.Substring(0, formula1.IndexOf("-"));//took the first term of the eqaution to the array
                        formula1 = formula1.Substring(formula1.IndexOf("-") + 1, formula1.Length - formula1.IndexOf("-") - 1);//removes the first term from the equation
                    }
                }

            }//end for loop
            partsAS[numOfAS] = formula1; // when there only is one term left
            formula1 = "";

            for (int i = 0; i != numOfAS + 1; i++)
            {
                int j = 0;
                bool containsMD = false;
                for (j = 0; partsAS[i] != ""; j++)//while there is * or / (should break up the terms completely and solve them)
                {
                    containsMD = false;
                    if (partsAS[i].Contains("*") || partsAS[i].Contains("/"))
                    {

                        if (partsAS[i].IndexOf("*") < partsAS[i].IndexOf("/") && partsAS[i].Contains("*") || partsAS[i].IndexOf("/") == -1) //if * comes first
                        {
                            containsMD = true;
                            OperandMD[j] = 0;
                            partMD = partsAS[i].Substring(0, partsAS[i].IndexOf("*")); //sets partMD to the first 

                            if (partMD.Contains("^"))
                            {
                                partMD = evaluateExponant(partMD, xValue);
                            }
                            partsAS[i] = partsAS[i].Substring(partsAS[i].IndexOf("*") + 1, partsAS[i].Length - partsAS[i].IndexOf("*") - 1);
                        }
                        else if (partsAS[i].IndexOf("/") < partsAS[i].IndexOf("*") || partsAS[i].IndexOf("*") == -1 && partsAS[i].Contains("/")) //if / comes first
                        {
                            containsMD = true;
                            OperandMD[j] = 1;
                            partMD = partsAS[i].Substring(0, partsAS[i].IndexOf("/")); //sets partMD to the first
                            if (partMD.Contains("^"))
                            {
                                partMD = evaluateExponant(partMD, xValue);
                            }
                            partsAS[i] = partsAS[i].Substring(partsAS[i].IndexOf("/") + 1, partsAS[i].Length - partsAS[i].IndexOf("/") - 1);
                        }
                    }
                    if (partsAS[i].IndexOf("*") == -1 && partsAS[i].IndexOf("/") == -1 && containsMD == false)//if there is none
                    {
                        partMD = partsAS[i];
                        if (partMD.Contains("^"))
                        {
                            partMD = evaluateExponant(partMD, xValue);
                        }
                        partsAS[i] = "";
                    }
                    partsFinal[j] = breakUpX(partMD, xValue);

                    if (j == 0)
                    {
                        valueAS[i] = partsFinal[j];
                    }
                    else
                    {
                        if (OperandMD[j - 1] == 0)
                            valueAS[i] = valueAS[i] * partsFinal[j];
                        if (OperandMD[j - 1] == 1)
                            valueAS[i] = valueAS[i] / partsFinal[j];
                    }

                }//ends inner for loop
                if (i == 0)
                {
                    finalresult = valueAS[i];
                }
                else
                {
                    if (OperandAS[i - 1] == 0)
                        finalresult = finalresult + valueAS[i];
                    if (OperandAS[i - 1] == 1)
                        finalresult = finalresult - valueAS[i];
                }
            }//ends outter loop of partsAS

            return finalresult;
        }//end evaluating ASMD
        double breakUpX(string part, double xValue)
        {
            double result;
            string stringnum;
            double num;

            if (part.IndexOf("x") != -1) //if it has an X remove it
            {
                stringnum = part.Replace("x", "");

                if (stringnum == "")//if it removed x and now there is nothing then it must only be an x
                {
                    result = xValue;
                }
                else if (part.IndexOf("x") == part.Length - 1 || part.IndexOf("x") == 0)//if x is last or first
                {//if removed x = does not = "" then multiply x that number it was next to 
                    num = Convert.ToDouble(stringnum);
                    result = xValue * num;
                }
                else//if x is in the middle
                {
                    string[] xfactors = part.Split('x');
                    result = Convert.ToDouble(xfactors[0]) * xValue * Convert.ToDouble(xfactors[1]);
                }
            }
            else//if it does not contain an x it must just be a number
            {
                result = Convert.ToDouble(part);
            }
            return result;
        }//end breakup x

        private void go_Click(object sender, RoutedEventArgs e)
        {
            int numOfBits = 100;//sets the size of all the arrays
            double x = Convert.ToDouble(xvalue.Text);
            string formula = equation.Text;
            double finalresult;
            formula.Replace(" ", string.Empty);//removes spaces

            formula = piconvert(formula);



            bool parenError = false;
            if (formula.Contains("(") || formula.Contains(")"))//finds the error in parenthisi 
            {
                Stack<char> paren = new Stack<char>();
                string parenfor = formula;
                while (parenfor != "")
                {
                    if (parenfor.Substring(0, 1) == "(")
                        paren.Push('(');
                    if (paren.Count != 0)
                    {
                        if (parenfor.Substring(0, 1) == ")")
                            paren.Pop();
                    }
                    else if (parenfor.Substring(0, 1) == ")")
                    {
                        parenError = true;
                        break;
                    }
                    parenfor = parenfor.Substring(1, parenfor.Length - 1);
                }
            }


            if (formula.IndexOf("+/") != -1 || formula.IndexOf("-/") != -1 || formula.IndexOf("+*") != -1 || formula.IndexOf("-*") != -1 || formula.IndexOf("*/") != -1)
            {
                output.Text = "ERROR";
            }
            else if (parenError)
            {
                output.Text = "ERROR - Check Parenthesis";
            }
            else
            {
                if (formula.Contains("("))
                {
                    string multiplyParen = formula;
                    while (multiplyParen.Contains("("))
                    {
                        if (multiplyParen.IndexOf("(") == 0)
                        {
                            multiplyParen = multiplyParen.Substring(1, multiplyParen.Length - 1);
                            continue;
                        }
                        if (multiplyParen.Substring(multiplyParen.IndexOf("(") - 1, 1).Any(char.IsDigit) || multiplyParen.Substring(multiplyParen.IndexOf("(") - 1, 1).Contains("x"))
                        {
                            formula = formula.Replace(multiplyParen.Substring(multiplyParen.IndexOf("(") - 1, 2), multiplyParen.Substring(multiplyParen.IndexOf("(") - 1, 1) + "*(");
                        }
                        multiplyParen = multiplyParen.Substring(multiplyParen.IndexOf("(") + 1, multiplyParen.Length - 1 - multiplyParen.IndexOf("("));
                    }

                    while (formula.Contains("("))
                    {
                        string firstPar = formula.Substring(formula.IndexOf("(") + 1, formula.Length - formula.IndexOf("(") - 1); //takes from the first ( to the end of the string
                        if (firstPar.IndexOf("(") > firstPar.IndexOf(")") || firstPar.IndexOf("(") == -1) //the first ( should be gone so this checks for if another ( comes before the )
                        {
                            string par1 = firstPar.Substring(0, firstPar.IndexOf(")")); // This should just be an equation with MDAS
                            string eval = evaluateASMD(par1, x, numOfBits).ToString();
                            formula = formula.Replace("(" + par1 + ")", eval);
                        }
                        else
                        {
                            while (firstPar.IndexOf("(") < firstPar.IndexOf(")") && firstPar.IndexOf("(") != -1)
                            {
                                firstPar = firstPar.Substring(firstPar.IndexOf("(") + 1, firstPar.Length - firstPar.IndexOf("(") - 1);// moves in on the parenthisies

                            }
                            string par1 = firstPar.Substring(0, firstPar.IndexOf(")")); // This should just be an equation with MDAS
                            string eval = evaluateASMD(par1, x, numOfBits).ToString();
                            formula = formula.Replace("(" + par1 + ")", eval);
                        }

                    }
                }

                finalresult = evaluateASMD(formula, x, numOfBits);


                if (DegreesRadians.IsOn == false)
                {
                    finalresult = (finalresult * 180) / Math.PI;
                }

                string result1 = finalresult.ToString();
                output.Text = result1;
            }//ends  first else
        }//ends click
        private void DegreesRadians_Toggled(object sender, RoutedEventArgs e)
        {
            // if (DegreesRadians.IsOn == false)
            // {

            //  double output1 = (Convert.ToDouble(equation.Text) * 180) / Math.PI;
            //    output.Text = output1.ToString();
            // }
            // else
            // {
            //double num = Convert.ToDouble(equation.Text);
            //double output1 = (num * Math.PI) / 180;
            //output.Text = output1.ToString();
            // }
        }

        private void xvalue_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            string x = xvalue.Text;
            string xnum = xvalue.Text;
            int position = xvalue.SelectionStart;
            while (xnum != "")
            {
                if (xnum.Length == 1)//if there is only 1 char in x
                {
                    if (!xnum.Any(char.IsDigit) && xnum != ".")//is it not a digit or a decimal
                    {
                        x = x.Replace(xnum, "");//replace it with nothing

                        xvalue.Text = x;//set the output
                        xvalue.SelectionStart = position - 1;//set the position
                        break;
                    }
                    xnum = "";
                    break;
                }
                if (!xnum.Substring(0, 1).Any(char.IsDigit) && xnum.Substring(0, 1) != ".")// if its not a digit or a decimal 
                {
                    x = x.Replace(xnum.Substring(0, 1), "");//replace the bad char with nothing
                    xvalue.Text = x;
                    xvalue.SelectionStart = position - 1;
                }
                if (xnum.Length != 1)
                {
                    xnum = xnum.Substring(1, xnum.Length - 1);//removes first char to check the next
                }

            }//end while


        }

        private void equation_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            int position = equation.SelectionStart;
            string formula = equation.Text.ToLower();


            equation.Text = equation.Text.ToLower();
            equation.SelectionStart = position;
            if (formula.Contains("pi"))
            {
                formula = formula.Replace("pi", "π");
                equation.Text = formula;
                equation.SelectionStart = position;//-1 because pi is two chars
            }
        }

    }
}
