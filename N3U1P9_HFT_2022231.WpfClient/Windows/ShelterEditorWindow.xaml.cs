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
    /// Interaction logic for ShelterEditorWindow.xaml
    /// </summary>
    public partial class ShelterEditorWindow : Window
    {
        public ShelterEditorWindow(Shelter shelter)
        {
            InitializeComponent();
            var ViewModel = new EditorViewModel<Shelter>();
            ViewModel.Setup(shelter);
            this.DataContext = ViewModel;
        }
    }
}
