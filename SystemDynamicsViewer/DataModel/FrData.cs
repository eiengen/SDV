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
    public class FrData:INotifyPropertyChanged
    {
        private List<double> _frequencyArray = new List<double>();
        private List<double> _magnitudeArray = new List<double>();
        private List<double> _phaseArray = new List<double>();
        private string _systemId;
        private string _systemConfiguration;
        private string _projectId;
        private string _bodeInput;
        private string _bodeOutput;
        private string _bodeExcitation;
        private double _frequencyStart;
        private double _frequencyStop;
        private double _excitationAmplitude;

        [Browsable(false)]
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

        [Browsable(false)]
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
        [Browsable(false)]
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
        [DisplayName("Input")]
        public string BodeInput
        {
            get => _bodeInput;
            set
            {
                if (value == _bodeInput) return;
                _bodeInput = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Output")]
        public string BodeOutput
        {
            get => _bodeOutput;
            set
            {
                if (value == _bodeOutput) return;
                _bodeOutput = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Excitation")]
        public string BodeExcitation
        {
            get => _bodeExcitation;
            set
            {
                if (value == _bodeExcitation) return;
                _bodeExcitation = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("F Start")]
        public double FrequencyStart
        {
            get => _frequencyStart;
            set
            {
                if (value.Equals(_frequencyStart)) return;
                _frequencyStart = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("F Stop")]
        public double FrequencyStop
        {
            get => _frequencyStop;
            set
            {
                if (value.Equals(_frequencyStop)) return;
                _frequencyStop = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Ex. Amp.")]
        public double ExcitationAmplitude
        {
            get => _excitationAmplitude;
            set
            {
                if (value.Equals(_excitationAmplitude)) return;
                _excitationAmplitude = value;
                OnPropertyChanged();
            }
        }

        public string SystemId
        {
            get => _systemId;
            set
            {
                if (value == _systemId) return;
                _systemId = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Configuration")]
        public string SystemConfiguration
        {
            get => _systemConfiguration;
            set
            {
                if (value == _systemConfiguration) return;
                _systemConfiguration = value;
                OnPropertyChanged();
            }
        }

        public string ProjectId
        {
            get => _projectId;
            set
            {
                if (value == _projectId) return;
                _projectId = value;
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
