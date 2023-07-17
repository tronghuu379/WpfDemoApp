using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfDemoApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public ObservableCollection<Button> MenuButtons { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            MenuButtons = new ObservableCollection<Button>
    {
        new Button { Content = "Button 1" },
        new Button { Content = "Button 2" },
        new Button { Content = "Button 3" }
    };

            DataContext = this;
        }




        //////////////////

        <ListView ItemsSource = "{Binding MenuButtons}" >
    < ListView.ItemTemplate >
        < DataTemplate >
            < Button Content="{Binding Content}"
                    Background="{Binding Background}"
                    Click="Button_Click" />
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>

            //////////////////////////////////

            public class MainViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<ButtonViewModel> MenuButtons { get; set; }

            private ButtonViewModel _selectedButton;
            public ButtonViewModel SelectedButton
            {
                get { return _selectedButton; }
                set
                {
                    if (_selectedButton != value)
                    {
                        if (_selectedButton != null)
                            _selectedButton.IsSelected = false;

                        _selectedButton = value;

                        if (_selectedButton != null)
                            _selectedButton.IsSelected = true;

                        OnPropertyChanged(nameof(SelectedButton));
                    }
                }
            }

            public MainViewModel()
            {
                MenuButtons = new ObservableCollection<ButtonViewModel>
        {
            new ButtonViewModel("Button 1"),
            new ButtonViewModel("Button 2"),
            new ButtonViewModel("Button 3")
        };
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        ///////////////////////
        public class ButtonViewModel : INotifyPropertyChanged
        {
            private string _content;
            public string Content
            {
                get { return _content; }
                set
                {
                    if (_content != value)
                    {
                        _content = value;
                        OnPropertyChanged(nameof(Content));
                    }
                }
            }

            private bool _isSelected;
            public bool IsSelected
            {
                get { return _isSelected; }
                set
                {
                    if (_isSelected != value)
                    {
                        _isSelected = value;
                        OnPropertyChanged(nameof(IsSelected));
                    }
                }
            }

            public ButtonViewModel(string content)
            {
                Content = content;
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        ///////////////////
        ///<ListView ItemsSource="{Binding MenuButtons}"
        SelectedItem="{Binding SelectedButton, Mode=TwoWay}">
    <ListView.ItemTemplate>
        <DataTemplate>
            <Button Content = "{Binding Content}"
                    Background="{Binding IsSelected, Converter={StaticResource SelectedButtonBackgroundConverter}}"
                    Command="{Binding DataContext.SelectButtonCommand, RelativeSource={RelativeSource AncestorType={x:Type Window}}}"
                    CommandParameter="{Binding}" />
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>



    }
}
