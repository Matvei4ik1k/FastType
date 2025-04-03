using System.Windows;

namespace FastType
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TypingTutorBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFraime.Navigate();
        }

        private void RatingBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
