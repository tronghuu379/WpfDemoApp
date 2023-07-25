using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfDemoApp.Themes
{
    public partial class WindowStyles : ResourceDictionary
    {
        public WindowStyles()
        {
            InitializeComponent();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (App.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                App.Current.MainWindow.WindowState = WindowState.Normal;
                button.Content = "";
            }
            else
            {
                App.Current.MainWindow.WindowState = WindowState.Maximized;
                button.Content = "";
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            UIElement element = e.Source as UIElement;
            Window targetWindow = Window.GetWindow(element);
            targetWindow?.Close();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.ClickCount == 2)
                {

                }
            }

            UIElement element = e.Source as UIElement;
            Window targetWindow = Window.GetWindow(element);
            targetWindow?.DragMove();
        }

        private void AdjustWindowSize()
        {
            minimizeButton.Content = "";
        }
    }
}
