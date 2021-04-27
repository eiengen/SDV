using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SystemDynamicsViewer.Annotations;
using SystemDynamicsViewer.DataModel;

namespace SystemDynamicsViewer.ViewModels
{
    public class SelectedDataViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<TestDataFile> _testDataFiles;
        private TestDataFile _testDataFile = new TestDataFile();

        /// <summary>
        /// Properties of the View Model
        /// </summary>
        public string DataFileName;

        public string DataFileName1
        {
            get => DataFileName;
            set
            {
                if (value == DataFileName) return;
                DataFileName = value;
                OnPropertyChanged();
            }
        }

        public string MeasurementType1
        {
            get => MeasurementType;
            set
            {
                if (value == MeasurementType) return;
                MeasurementType = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TestDataFile> TestDataFiles1
        {
            get => TestDataFiles;
            set
            {
                if (Equals(value, TestDataFiles)) return;
                TestDataFiles = value;
                OnPropertyChanged();
            }
        }

        public TestDataFile CurrentFile1
        {
            get => CurrentFile;
            set
            {
                if (Equals(value, CurrentFile)) return;
                CurrentFile = value;
                OnPropertyChanged();
            }
        }

        public string MeasurementType;
        public ObservableCollection<TestDataFile> TestDataFiles;
        public TestDataFile CurrentFile;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
