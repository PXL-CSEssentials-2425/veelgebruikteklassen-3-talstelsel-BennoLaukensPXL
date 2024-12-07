using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3Telstelsel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Key_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                convertButton_Click(sender, e);
            }
            else if (!(e.Key >= Key.A && e.Key <= Key.F) && !(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = true;
            }
        }
        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            int dec = 0;
            int powTimes = hexaDecimalValueTextBox.Text.Length - 1;
            for (int i = 0; i <= hexaDecimalValueTextBox.Text.Length-1; i++)
            {
                int pow = int.Parse(Math.Pow(16, powTimes).ToString());
                char c = hexaDecimalValueTextBox.Text[i];
                switch (c.ToString().ToUpper())
                {
                    case "A":
                        num = 10;
                        break;
                    case "B":
                        num = 11;
                        break;
                    case "C":
                        num = 12;
                        break;
                    case "D":
                        num = 13;
                        break;
                    case "E":
                        num = 14;
                        break;
                    case "F":
                        num = 15;
                        break;
                    default:
                        int.TryParse(c.ToString(), out num);
                        break;
                }
                dec += num * pow;
                powTimes--;
            }
            
            decimalValueTextBox.Text = dec.ToString();
        }

        private void againButton_Click(object sender, RoutedEventArgs e)
        {
            decimalValueTextBox.Clear();
            hexaDecimalValueTextBox.Clear();
            hexaDecimalValueTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
