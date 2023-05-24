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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _lastNumber;
        private SelectedOperation _selectedOperation;
        private double _result;
        public MainWindow()
        {
            InitializeComponent();
            ACButton.Click += ACButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
        }

        public void EqualsToButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber = 0;
            if (double.TryParse(resultLable.Content.ToString(), out newNumber))
            {
                switch (_selectedOperation)
                {
                    case SelectedOperation.Division:
                        _result = SimpleMath.Division(_lastNumber, newNumber);
                        break;
                    case SelectedOperation.Multiplication:
                        _result = SimpleMath.Multiplication(_lastNumber, newNumber);
                        break;
                    case SelectedOperation.Substraction:
                        _result = SimpleMath.Substraction(_lastNumber, newNumber);
                        break;
                    case SelectedOperation.Addition:
                        _result = SimpleMath.Add(_lastNumber, newNumber);
                        break;
                }
                resultLable.Content = _result.ToString();
            }
        }

        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            resultLable.Content = "0";
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLable.Content.ToString(), out _lastNumber))
            {
                _lastNumber = _lastNumber * (-1);
                resultLable.Content = _lastNumber.ToString();
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLable.Content.ToString(), out _lastNumber))
            {
                _lastNumber = _lastNumber / 100;
                resultLable.Content = _lastNumber.ToString();
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedNumber = int.Parse((sender as Button).Content.ToString());
            if (resultLable.Content.ToString().Equals("0"))
                resultLable.Content = $"{selectedNumber}";
            else
                resultLable.Content = $"{resultLable.Content}{selectedNumber}";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLable.Content.ToString(), out _lastNumber))
            {
                resultLable.Content = "0";
            }
            if (sender == divisionButton)
                _selectedOperation = SelectedOperation.Division;
            else if (sender == multiplyButton)
                _selectedOperation = SelectedOperation.Multiplication;
            else if (sender == substractionButton)
                _selectedOperation = SelectedOperation.Substraction;
            else if (sender == additionButton)
                _selectedOperation = SelectedOperation.Addition;
        }

        private void decimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLable.Content.ToString().Contains("."))
                resultLable.Content = $"{resultLable.Content}.";
        }
    }
    public enum SelectedOperation
    {
        Division,
        Multiplication,
        Substraction,
        Addition
    }
    public class SimpleMath
    {
        public static double Add(double firstnumber, double secondnumber)
        {
            return firstnumber + secondnumber;
        }
        public static double Substraction(double firstnumber, double secondnumber)
        {
            return firstnumber - secondnumber;
        }
        public static double Multiplication(double firstnumber, double secondnumber)
        {
            return firstnumber * secondnumber;
        }
        public static double Division(double firstnumber, double secondnumber)
        {
            if (secondnumber == 0)
                MessageBox.Show("Divide by zero is not supported", "Error message", MessageBoxButton.OK, MessageBoxImage.Error);
            return 0;

            return firstnumber / secondnumber;
        }
    }
}
