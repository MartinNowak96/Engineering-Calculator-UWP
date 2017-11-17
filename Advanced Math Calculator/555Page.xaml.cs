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
    public sealed partial class _555Page : Page
    {
        public _555Page()
        {
            this.InitializeComponent();
        }

        private void R1_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (R1.Text.Length != 0 && R2.Text.Length != 0 && cap.Text.Length != 0)
            {
                try
                {
                    double Resistor1 = Convert.ToDouble(R1.Text);
                    double Resistor2 = Convert.ToDouble(R2.Text);
                    double capacitor = Convert.ToDouble(cap.Text);
                    double periodVar;
                    double timeOff;
                    double timeOn;
                    Resistor1 = Resistor1 * Math.Pow(10, findExponent(R1Unit));
                    Resistor2 = Resistor2 * Math.Pow(10, findExponent(R2Unit));
                    capacitor = capacitor * Math.Pow(10, findExponent(capUnit));

                    periodVar = Convert.ToDouble(0.693 * capacitor * (Resistor1 + (2 * Resistor2)));
                    timeOff = Convert.ToDouble(Math.Log(2) * Resistor2 * capacitor);
                    timeOn = periodVar - timeOff;
                    duty.Text = Convert.ToString(Math.Round(timeOn/ periodVar, 4) * 100) + "%";


                    frequency.Text = findFreq(1 / periodVar);
                    period.Text = findTime(periodVar);
                    timeoff.Text = findTime(timeOff);
                    timeon.Text = findTime(timeOn);

                    double duty1 = Math.Round(timeOn / periodVar, 4);

                    top1.Width = new GridLength(duty1, GridUnitType.Star);
                    top2.Width = new GridLength(duty1, GridUnitType.Star);
                    top3.Width = new GridLength(duty1, GridUnitType.Star);


                    bottom1.Width = new GridLength((1-duty1), GridUnitType.Star);
                    bottom2.Width = new GridLength((1 - duty1), GridUnitType.Star);
                    bottom3.Width = new GridLength((1 - duty1), GridUnitType.Star);
                }
                catch { }
               }
            

        }

        public string findFreq(double freq)
        {
            string frequencyString = "";

            if (freq > 1)
            {
                frequencyString = Convert.ToString(freq) + "Hz";
            }
            if(freq > 1000)
            {
                frequencyString = Convert.ToString(freq /1000) + "KHz";
            }
            if (freq > 1000000)
            {
                frequencyString = Convert.ToString(freq / 1000000) + "MHz";
            }
            if (freq < 1)
            {
                frequencyString = Convert.ToString(freq * 1000) + "mHz";

            }


            return frequencyString;
        }

        public string findTime(double time)
        {
            string Time = "";

            if (time > 1)
            {
                Time = Convert.ToString(time) + "s";
            }
            if (time < 1)
            {
                Time = Convert.ToString(time * 1000) + "ms";
            }
            if (time < 0.00001)
            {
                Time = Convert.ToString(time * 1000000) + "us";

            }
            if (time < 0.00000001)
            {
                Time = Convert.ToString(time * 1000000000) + "ns";

            }

            return Time;
        }


        public int findExponent(ComboBox unit)
        {

            switch(unit.SelectedIndex){

                case 0:
                    return 6;

                case 1:
                    return 3;
                case 2:
                    return 0;
                case 3:
                    return -3;

                case 4:
                    return -6;
                case 5:
                    return -9;
            }
            


            return 10;
        }
    }
}
