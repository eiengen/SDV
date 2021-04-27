using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SystemDynamicsViewer.Annotations;
using Accord.IO;

namespace SystemDynamicsViewer.DataModel
{
    public class FrdDataModel:INotifyPropertyChanged
    {
        private ObservableCollection<TestDataFile> _searchedTestFiles = new ObservableCollection<TestDataFile>();
        private ObservableCollection<TestDataFile> _selectedFrdFiles = new ObservableCollection<TestDataFile>();

        private ObservableCollection<FrData> _frdCollection = new ObservableCollection<FrData>();

        private ObservableCollection<FrMatFileData> _matDataCollection = new ObservableCollection<FrMatFileData>();
        // Replace argument in FileServer(string arg) with the file server path holding the test data. 
        private string fileServerPath;
        private FileServer _testFileServer = new FileServer(fileServerPath);

        /// <summary>
        /// Properties
        /// </summary>
        public ObservableCollection<FrMatFileData> MatDataCollection
        {
            get => _matDataCollection;
            set
            {
                if (Equals(value, _matDataCollection)) return;
                _matDataCollection = value;
                OnPropertyChanged();
            }
        }

        public FileServer TestFileServer
        {
            get => _testFileServer;
            set
            {
                if (Equals(value, _testFileServer)) return;
                _testFileServer = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TestDataFile> SearchedTestFiles
        {
            get => _searchedTestFiles;
            set
            {
                if (Equals(value, _searchedTestFiles)) return;
                _searchedTestFiles = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<TestDataFile> SelectedFrdFiles
        {
            get => _selectedFrdFiles;
            set
            {
                if (Equals(value, _selectedFrdFiles)) return;
                _selectedFrdFiles = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<FrData> FrdCollection
        {
            get => _frdCollection;
            set
            {
                if (Equals(value, _frdCollection)) return;
                _frdCollection = value;
                OnPropertyChanged();
            }
        }

        private void ResetCollections()
        {
            SearchedTestFiles.Clear();
            SelectedFrdFiles.Clear();
            FrdCollection.Clear();
        }

        /// <summary>
        /// Function building the data information from the given file server path, filtered by the txtSearch string.
        /// </summary>
        /// <param name="fileServerPath"></param>
        /// <param name="txtSearch"></param>
        public void BuildDataModelFileServer(String fileServerPath, string txtSearch)
        {
            ResetCollections();

            var df = new DirectoryInfo(fileServerPath);

            foreach (var fi in df.GetFiles())
            {
                this.SearchedTestFiles.Add(new TestDataFile()
                {
                    Name = fi.Name,
                    FullName = fi.FullName,
                    Size = fi.Length,
                    Type = fi.Extension,
                    CreateDate = fi.CreationTime
                });
            }

            //retrieves the file information from the defined file server
            foreach (var dir in df.GetDirectories())
            {
               if (!string.IsNullOrEmpty(txtSearch))
               {
                   foreach (var fi in dir.GetFiles(txtSearch))
                   {
                       this.SearchedTestFiles.Add(new TestDataFile()
                       {
                           Name = fi.Name,
                           FullName = fi.FullName,
                           Size = fi.Length,
                           Type = fi.Extension,
                           CreateDate = fi.LastWriteTime
                       });
                   }
               }
               else
               {
                   // search the file and available in the directory
                   foreach (var fi in dir.GetFiles())
                   {
                       this.SearchedTestFiles.Add(new TestDataFile()
                       {
                           Name = fi.Name,
                           FullName = fi.FullName,
                           Size = fi.Length,
                           Type = fi.Extension,
                           CreateDate = fi.LastWriteTime
                       });
                   }
               }

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
