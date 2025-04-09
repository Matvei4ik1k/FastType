using FastType.View.Pages;
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
            MainFraime.Navigate(new AuthorizationPage());
        }

        private void TypingTutorBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFraime.Navigate(new TypingTutorPage());
        }

        private void RatingBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFraime.Navigate(new RatingPage());
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFraime.Navigate(new ProfilePage());
        }
    }
}
