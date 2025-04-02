using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastType.AppData
{
    public class TypingServise
    {
        //Создаем поля для хранения и использования переменных для внутренней логики класса.

        private Stopwatch _stopwatch;

        //Поля для хранения и использования в рамках класса.
        private Grid _keyboardGrid;
        private TextBox _typingTextBox;
        private TextBlock _typintTextBlock;
        private TextBlock _speedtextBlock;
        private ProgressBar _progressBar;
        //Создаем свойство для получения и присваивания расчетов
        public double TypeSpeed { get; private set; }

        //Создаем конструктор класса для приема элементов управления из интерфейса (TypingTutorPage.xaml)
        public TypingServise(Grid keyboardGrid, TextBox typingTextBox, TextBlock typintTextBlock, TextBlock speedtextBlock, ProgressBar progressBar)
        {
            _stopwatch = new Stopwatch();
            _keyboardGrid = keyboardGrid;
            _typingTextBox = typingTextBox;
            _typintTextBlock = typintTextBlock;
            _speedtextBlock = speedtextBlock;
            _typingTextBox.PreviewKeyDown += _typingTextBox_PreviewKeyDown;
            _typingTextBox.PreviewKeyUp += _typingTextBox_PreviewKeyUp;
            _typingTextBox.TextChanged += _typingTextBox_TextChanged;
            _progressBar = progressBar;
        }

        private void _typingTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_typingTextBox.Text.Length >= 1 && !_stopwatch.IsRunning)
            {
                _stopwatch.Start();
            }

            if (_typingTextBox.Text == _typintTextBlock.Text)
            {
                _stopwatch.Stop();
            }

            if (_typingTextBox.Text.Length >= 2)
            {
                _speedtextBlock.Text = CalculateSpeed();
            }
            UpdateProgress();
        }

        private void _typingTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            var button = FindButtonByKey(e.Key);
            if (button != null)
            {
                button.BorderThickness = new Thickness(0);
            }
        }

        private void _typingTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var button = FindButtonByKey(e.Key);
            if (button != null)
            {
                button.BorderThickness = new Thickness(2.0, 2.0, 2.0, 4.0);
            }
        }

        private Button FindButtonByKey(Key key)
        {
            foreach (var stackPanel in _keyboardGrid.Children.OfType<StackPanel>())
            {
                foreach (var button in stackPanel.Children.OfType<Button>())
                {
                    if (button.Tag.ToString() == key.ToString())
                    {
                        return button;
                    }
                }
            }
            return null;
        }

        private string CalculateSpeed()
        {

            TypeSpeed = _typingTextBox.Text.Length / _stopwatch.Elapsed.TotalMinutes;
            return $"{TypeSpeed:F0} СВМ";
        }
        private void UpdateProgress()
        {
            double rezult = _typingTextBox.Text.Length * 100.0 / _typintTextBlock.Text.Length;

            _progressBar.Value = Math.Floor(rezult);
        }
    }
}
