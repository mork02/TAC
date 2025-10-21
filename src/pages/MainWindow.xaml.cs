using ActiveTwitch.Pages;
using ActiveTwitch.src.models;
using ActiveTwitch.src.utils;
using System.Diagnostics;
using System;
using System.IO;
using System.Net.WebSockets;
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
using ActiveTwitch.Models;

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
                LoadConfig();
            };
        }

        private void LoadConfig()
        {
            var data = ConfigManager.Load();
            _darkMode = data.DarkMode;
            ApplyTheme(_darkMode);
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
                src.utils.Debugger.Debug($"[MainWindow::OnSwitchThemeClick]Error: {ex.Message}");
            }
        }
    }
}