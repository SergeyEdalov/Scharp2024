﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Calculator calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            calculator.Result += Calculator_Result;
        }

        private void Calculator_Result(object? sender, CalculatorArgs e)
        {
            Answer.Content = e.answer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool parse = int.TryParse(InputText.Text, out int value);
            string name = (e.Source as FrameworkElement).Name;
            if (String.IsNullOrEmpty(InputText.Text))
            {
                Application.Current.Shutdown();
            }
            if (!parse)
            {
                MessageBox.Show("Неверно введены данные!");
                InputText.Text = string.Empty;
            }
            switch (name)
            {
                case "Add":
                    calculator.Add(value);
                    break;
                case "Sub":
                    calculator.Sub(value);
                    break;
                case "Mult":
                    calculator.Mult(value);
                    break;
                case "Div":
                    calculator.Div(value);
                    break;
                case "Cancel":
                    calculator.Cancel();
                    break;
                case "Exit":
                    calculator.Result -= Calculator_Result;
                    Application.Current.Shutdown();
                    break;
                default:
                    MessageBox.Show("Ошибка нажатия кнопки!");
                    InputText.Text = string.Empty;
                    break;
            }
        }
        private void InputText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = InputText.Text;

            if (str.Length > 0)
            {
                char last = str[str.Length - 1];
                if (last < '0' || last > '9') { str = str.Remove(str.Length - 1); }
                InputText.Text = str;
            }
        }
    }
}