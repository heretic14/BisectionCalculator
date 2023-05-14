using System;
using System.Collections.Generic;
using System.Linq;
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

namespace BisectionCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBox textBox;

        public MainWindow()
        {
            InitializeComponent();
            textBox = F;
        }

        private void X1_Click(object sender, RoutedEventArgs e)
        {
            textBox = X1;
        }

        private void X2_Click(object sender, RoutedEventArgs e)
        {
            textBox = X2;
        }

        private void F_Click(object sender, RoutedEventArgs e)
        {
            textBox = F;
        }

        private void EPS_Click(object sender, RoutedEventArgs e)
        {
            textBox = EPS;
        }

        private void B9_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "9";
        }

        private void B8_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "8";
        }

        private void B7_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "7";
        }

        private void B6_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "6";
        }

        private void B5_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "5";
        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "4";
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "3";
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "2";
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "1";
        }

        private void B0_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "0";
        }

        private void Bplus_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "+";
        }

        private void Bminus_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "-";
        }

        private void Bmult_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "*";
        }

        private void Bdiv_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "/";
        }

        private void Bdot_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += ".";
        }

        private void Bsin_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "Sin()";
        }

        private void Bcos_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "Cos()";
        }

        private void Btan_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "Tan()";
        }

        private void Bln_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "Log10()";
        }

        private void Blog_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "Log()";
        }

        private void Be_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "Exp()";
        }

        private void Babs_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "Abs()";
        }

        private void Bsqrt_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "Sqrt()";
        }

        private void Bpow_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "Pow(,)";
        }

        private void Bleft_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += "(";
        }

        private void Bright_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText += ")";
        }
    }
}
