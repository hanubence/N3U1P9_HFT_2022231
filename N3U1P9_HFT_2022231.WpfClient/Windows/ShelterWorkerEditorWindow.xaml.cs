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
using N3U1P9_HFT_2022231.Models;
using N3U1P9_HFT_2022231.WpfClient.ViewModels;

namespace N3U1P9_HFT_2022231.WpfClient.Windows
{
    /// <summary>
    /// Interaction logic for ShelterWorkerEditorWindow.xaml
    /// </summary>
    public partial class ShelterWorkerEditorWindow : Window
    {
        public ShelterWorkerEditorWindow(ShelterWorker worker)
        {
            InitializeComponent();
            var ViewModel = new EditorViewModel<ShelterWorker>();
            ViewModel.Setup(worker);
            this.DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
