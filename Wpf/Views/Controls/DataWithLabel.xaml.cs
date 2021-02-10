using System.Windows;
using System.Windows.Controls;

namespace Wpf.Views.Controls
{
    public partial class DataWithLabel : UserControl
    {
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(DataWithLabel));
        public string Label
        {
            get => (string) GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }
        
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register(nameof(Data), typeof(string), typeof(DataWithLabel));
        public string Data
        {
            get => (string) GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
        
        public DataWithLabel()
        {
            InitializeComponent();
            // DataContext = this;
        }
    }
}