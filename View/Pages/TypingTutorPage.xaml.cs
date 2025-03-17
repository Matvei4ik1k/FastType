using FastType.AppData;
using System.Windows.Controls;

namespace FastType.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для TypingTutorPage.xaml
    /// </summary>
    public partial class TypingTutorPage : Page
    {
        private TypingServise _typingService;
        public TypingTutorPage()
        {
            InitializeComponent();
            _typingService = new TypingServise(KeyboardGrid, TypingTutorTb, TypingTutorTbl);
        }
    }
}
