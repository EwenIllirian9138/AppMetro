using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Librairie;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;

namespace AppMetroWpf.ViewModel
{
    public class MetroViewModel : INotifyPropertyChanged
    {
        Station _stationsData;

        public MetroViewModel()
        {
            //Valeur par défaut
            this.Latitude = 45.185270;
            this.Longitude = 5.727231;
            this.Rayon = 500;
            Request = new RelayCommand(DoRequest);
            _stationsData = new Station();
            DoRequest();
        }

        private void DoRequest()
        {
            List<ArretAndLineDetails> result = _stationsData.FinalstatusDynamique(Latitude, Longitude, Rayon);
            DataLoop = new ObservableCollection<ArretAndLineDetails>(result);
            RaisePropertyChanged("DataLoop");
        }

        public ObservableCollection<ArretAndLineDetails> DataLoop
        {
            get;
            set;
        }
       
        public double Latitude
        {
            get;
            set;
        }

        public double Longitude
        {
            get; 
            set;
        }

        public int Rayon
        {
            get;
            set;
        }

        public ICommand Request
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
