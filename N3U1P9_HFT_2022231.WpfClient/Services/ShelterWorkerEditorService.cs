using N3U1P9_HFT_2022231.Models;
using N3U1P9_HFT_2022231.WpfClient.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace N3U1P9_HFT_2022231.WpfClient.Services
{
    public class ShelterWorkerEditorService : IEditorService<ShelterWorker>
    {
        public bool Edit(ShelterWorker worker)
        {
            ShelterWorkerEditorWindow Editor = new ShelterWorkerEditorWindow(worker);

            bool? Result = Editor.ShowDialog();
            if (Result.HasValue && Result.Value) return true;
            return false;
        }
    }
}
