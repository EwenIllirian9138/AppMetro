using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Librairie;
using System.Windows;

namespace AppMetroWpf.ViewModel
{
    public class MetroViewModel
    {
        public MetroViewModel()
        {
            Latitude = " " ;
            Longitude = " ";
            Rayon = " ";
            Station stationsData = new Station();
            List<ArretAndLineDetails> result = stationsData.FinalstatusDynamique(Latitude,Longitude,Rayon);
            DataLoop = new ObservableCollection<ArretAndLineDetails>(result);
        }        

        public ObservableCollection<ArretAndLineDetails> DataLoop
        {
            get;
            set;
        }
        public void Button1(object sender, RoutedEventArgs e)
        {
            String latitude = Latitude;
            String longitude = Longitude;
            String rayon = Rayon;
        }
        public String Latitude
        {
            get;
            set;
        }
        public String Longitude
        {
            get;
            set;
        }
        public String Rayon
        {
            get;
            set;
        }
    }
}
