using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfDemoApp.Themes
{
    public partial class WindowStyles : ResourceDictionary
    {
        public WindowStyles()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            UIElement element = e.Source as UIElement;
            Window targetWindow = Window.GetWindow(element);
            targetWindow?.Close();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            UIElement element = e.Source as UIElement;
            Window targetWindow = Window.GetWindow(element);
            targetWindow?.DragMove();
        }
    }
}
