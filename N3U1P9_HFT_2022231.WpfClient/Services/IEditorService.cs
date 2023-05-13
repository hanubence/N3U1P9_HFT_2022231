using N3U1P9_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3U1P9_HFT_2022231.WpfClient.Services
{
    public interface IEditorService<T>
    {
        void Edit(T t);
    }
}
