using System.Windows.Controls;

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
        }

        private void _typingTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _typingTextBox.Clear();
            _typingTextBox.Text = e.Key.ToString();
        }
    }
}
