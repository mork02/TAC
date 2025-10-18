using ActiveTwitch.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ActiveTwitch
{
    public partial class MainWindow : Window
    {
        private bool _darkMode = false;
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (_, __) =>
            {
                MainFrame.Navigate(new HomePage());
            };
        }

        private void OnSwitchThemeClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var dict = Application.Current.Resources.MergedDictionaries;
                var newTheme = new ResourceDictionary
                {
                    Source = new Uri(_darkMode ? "Themes/Light.xaml" : "Themes/Dark.xaml", UriKind.Relative)
                };

                dict.Clear();
                dict.Add(newTheme);

                _darkMode = !_darkMode;

            } catch ( Exception ex )
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}