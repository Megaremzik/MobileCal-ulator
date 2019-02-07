using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileCalculator
{
    public partial class MainPage : ContentPage
    {
        string mode = "eq";
        char lastOperator = '=';
        public MainPage()
        {
            InitializeComponent();
        }
        private void ButOperator_clicked(object sender, EventArgs e)
        {
            var currentOperator = (Button)sender;
            switch (mode)
            {
                case "eq":
                    result.Text = numbers.Text;
                    result.Text += currentOperator.Text;
                    mode = "operator";
                    break;
                case "operator":
                    result.Text.Remove(result.Text.Length - 1);
                    result.Text += currentOperator.Text;
                    break;
                case "number":
                    if (lastOperator != '=') numbers.Text = Calculate(result.Text).ToString();
                    result.Text = numbers.Text;
                    result.Text += currentOperator.Text;
                    mode = "operator";
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            lastOperator = Convert.ToChar(currentOperator.Text);
        }
        private void ButNumber_clicked(object sender, EventArgs e)
        {
            var currentNumber = (Button)sender;
            switch (mode)
            {
                case "eq":
                    numbers.Text = currentNumber.Text;
                    mode = "number";
                    break;
                case "operator":
                    numbers.Text = currentNumber.Text;
                    mode = "number";
                    break;
                case "number":
                    numbers.Text += currentNumber.Text;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
        private void ButClear_clicked(object sender, EventArgs e)
        {
            numbers.Text = "0";
            result.Text = "";
        }
        private void ButEq_clicked(object sender, EventArgs e)
        {
            var equalButton = (Button)sender;
            switch (mode)
            {
                case "operator":
                    result.Text.Remove(result.Text.Length - 1);
                    mode = "eq";
                    break;
                case "number":
                    result.Text += numbers.Text;
                    numbers.Text = Calculate(result.Text).ToString();
                    mode = "eq";
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            lastOperator = '=';
        }
        private double Calculate(string str)
        {
            var numbers = str.Split(lastOperator);
            double result = 0;
            switch (lastOperator)
            {
                case '+':
                    result = double.Parse(numbers[0]) + double.Parse(numbers[1]);
                    break;
                case '-':
                    result = double.Parse(numbers[0]) - double.Parse(numbers[1]);
                    break;
                case '*':
                    result = double.Parse(numbers[0]) * double.Parse(numbers[1]);
                    break;
                case '/':
                    if (double.Parse(numbers[1]) != 0) result = double.Parse(numbers[0]) + double.Parse(numbers[1]);
                    else result = 0;
                    break;
            }
            return result;
        }
    }
}
