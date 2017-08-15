using Histogram_MVVM.ViewModels;
using System.Windows;

namespace Histogram_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new AppViewModel();
        }
    }
}
