using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SystemDynamicsViewer.Annotations;

namespace SystemDynamicsViewer.DataModel
{
    public class FrMatFileData:INotifyPropertyChanged
    {
        private List<double> _timeArray;
        private List<double> _frequencyArray;
        private List<double> _magnitudeArray;
        private List<double> _phaseArray;

        public List<double> TimeArray
        {
            get => _timeArray;
            set
            {
                if (Equals(value, _timeArray)) return;
                _timeArray = value;
                OnPropertyChanged();
            }
        }

        public List<double> FrequencyArray
        {
            get => _frequencyArray;
            set
            {
                if (Equals(value, _frequencyArray)) return;
                _frequencyArray = value;
                OnPropertyChanged();
            }
        }

        public List<double> MagnitudeArray
        {
            get => _magnitudeArray;
            set
            {
                if (Equals(value, _magnitudeArray)) return;
                _magnitudeArray = value;
                OnPropertyChanged();
            }
        }

        public List<double> PhaseArray
        {
            get => _phaseArray;
            set
            {
                if (Equals(value, _phaseArray)) return;
                _phaseArray = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
