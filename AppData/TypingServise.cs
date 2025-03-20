using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastType.AppData
{
    public class TypingServise
    {
        //Поля для хранения и использования в рамках класса.
        private Grid _keyboardGrid;
        private TextBox _typingTextBox;
        private TextBlock _typintTextBlock;

        //Создаем конструктор класса для приема элементов управления из интерфейса (TypingTutorPage.xaml)
        public TypingServise(Grid keyboardGrid, TextBox typingTextBox, TextBlock typintTextBlock)
        {
            _keyboardGrid = keyboardGrid;
            _typingTextBox = typingTextBox;
            _typintTextBlock = typintTextBlock;
            _typingTextBox.PreviewKeyDown += _typingTextBox_PreviewKeyDown;
            _typingTextBox.PreviewKeyUp += _typingTextBox_PreviewKeyUp;
        }

        private void _typingTextBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var button = FindButtonByKey(e.Key);
            if (button != null)
            {
                button.BorderThickness = new Thickness(0);
            }
        }

        private void _typingTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
    }
}
