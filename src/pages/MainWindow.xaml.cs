using ActiveTwitch.Pages;
using ActiveTwitch.src.models;
using System.IO;
using System.Text;
using System.Text.Json;
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
        private readonly string configPath = "src/data/config.json";

        public MainWindow()
        {
            InitializeComponent();
            

            Loaded += (_, __) =>
            {
                MainFrame.Navigate(new HomePage());

                var config = LoadConfig();
                _darkMode = config.DarkMode;
                ApplyTheme(_darkMode);
            };
        }

        private Config LoadConfig()
        {
            try
            {
                if (File.Exists(configPath))
                {
                    var json = File.ReadAllText(configPath, Encoding.UTF8);
                    var config = JsonSerializer.Deserialize<Config>(json);
                    if (config != null) return config;
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"[MainWindow::LoadConfig]Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }

        private void ApplyTheme(bool darkMode)
        {
            var themeName = darkMode ? "Dark" : "Light";
            var themeUri = new Uri($"src/pages/themes/{themeName}.xaml", UriKind.Relative);

            var dicts = Application.Current.Resources.MergedDictionaries;
            dicts.Clear();
            dicts.Add(new ResourceDictionary { Source = themeUri });
        }

        private void OnSwitchThemeClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _darkMode = !_darkMode;
                ApplyTheme(_darkMode);

            } catch ( Exception ex )
            {
                MessageBox.Show($"[MainWindow::OnSwitchThemeClick]Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}