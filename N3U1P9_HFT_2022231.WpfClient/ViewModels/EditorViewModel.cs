using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace N3U1P9_HFT_2022231.WpfClient.ViewModels
{
    public class EditorViewModel<T>
    {
        public T Actual { get; set; }
        public ICommand CloseEditorCommand { get; set; }
        public void Setup(T actual) { Actual = actual; }
        public EditorViewModel()
        {

        }
    }
}
