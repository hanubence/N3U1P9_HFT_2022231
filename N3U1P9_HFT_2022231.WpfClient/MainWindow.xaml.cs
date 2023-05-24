using N3U1P9_HFT_2022231.WpfClient.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace N3U1P9_HFT_2022231.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowViewModel();
            this.DataContext = vm;
        }

        private void WorkerList_GotFocus(object sender, RoutedEventArgs e)
        {
            vm.SelectedAnimal = null;
        }

        private void AnimalList_GotFocus(object sender, RoutedEventArgs e)
        {
            vm.SelectedWorker = null;
        }
    }
}
