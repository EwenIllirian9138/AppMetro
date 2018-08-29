using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Librairie;

namespace AppMetroWpf.ViewModel
{
    public class MetroViewModel
    {
        public MetroViewModel()
        {
            Station stationsData = new Station();
            List<ArretAndLineDetails> result = stationsData.Finalstatus();
            DataLoop = new ObservableCollection<ArretAndLineDetails>(result);
        }        

        public ObservableCollection<ArretAndLineDetails> DataLoop
        {
            get;
            set;
        }

    }
}
