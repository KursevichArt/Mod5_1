using System;
using System.Globalization;
using System.Windows;

namespace Mod5_5
{
    public partial class MainWindow : Window
    {
        private string _currentInput = string.Empty;
        private double _firstNumber = 0;
        private string _operation = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            _currentInput += button.Content.ToString();
            Display.Text = _currentInput;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;

            // Проверяем, может ли быть преобразовано текущее значение
            if (double.TryParse(_currentInput, NumberStyles.Float, CultureInfo.InvariantCulture, out _firstNumber))
            {
                _operation = button.Content.ToString();
                _currentInput = string.Empty;
            }
            else
            {
                Display.Text = "Error"; // Отображаем ошибку, если ввод некорректен
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double secondNumber;
            if (double.TryParse(_currentInput, NumberStyles.Float, CultureInfo.InvariantCulture, out secondNumber))
            {
                double result = 0;

                switch (_operation)
                {
                    case "+":
                        result = _firstNumber + secondNumber;
                        break;
                    case "-":
                        result = _firstNumber - secondNumber;
                        break;
                    case "*":
                        result = _firstNumber * secondNumber;
                        break;
                    case "÷": // Изменяем здесь на "÷"
                        if (secondNumber != 0)
                        {
                            result = _firstNumber / secondNumber;
                        }
                        else
                        {
                            Display.Text = "Error"; // Деление на 0
                            return;
                        }
                        break;
                    default:
                        Display.Text = "Error"; // На случай, если операция некорректна
                        return;
                }

                Display.Text = result.ToString(CultureInfo.InvariantCulture);
                _currentInput = result.ToString(CultureInfo.InvariantCulture);
                _firstNumber = result; // Сохраняем результат для дальнейших операций
                _operation = string.Empty; // Сбрасываем операцию
            }
            else
            {
                Display.Text = "Error"; // Отображаем ошибку, если ввод некорректен
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _currentInput = string.Empty;
            _firstNumber = 0;
            _operation = string.Empty;
            Display.Text = string.Empty;
        }
    }
}