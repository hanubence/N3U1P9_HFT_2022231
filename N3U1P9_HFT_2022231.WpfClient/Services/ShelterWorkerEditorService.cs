using N3U1P9_HFT_2022231.Models;
using N3U1P9_HFT_2022231.WpfClient.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3U1P9_HFT_2022231.WpfClient.Services
{
    public class ShelterWorkerEditorService : IEditorService<ShelterWorker>
    {
        public void Edit(ShelterWorker worker)
        {
            new ShelterWorkerEditorWindow(worker).ShowDialog();
        }
    }
}
