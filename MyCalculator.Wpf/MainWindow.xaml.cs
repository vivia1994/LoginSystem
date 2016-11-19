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

namespace MyCalculator.Wpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void _addButton_Click(object sender, RoutedEventArgs e)
        {
            int first = int.Parse(this._firstTextBox.Text);
            int second = int.Parse(this._secondTextBox.Text); Calculator calculator = new Calculator();
            int sum = calculator.Add(first, second);
            this._sumTextBlock.Text = sum.ToString();
        }
    }
}
