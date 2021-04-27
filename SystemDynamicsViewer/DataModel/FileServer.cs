using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDynamicsViewer.DataModel
{
    public class FileServer
    {
        /// <summary>
        /// Local variables
        /// </summary>
        private string _fileServerPath;
        /// <summary>
        /// Properties
        /// </summary>
        public string FileServerPath
        {
            get => _fileServerPath;
            set => _fileServerPath = value;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileServerPath"></param>
        public FileServer(string fileServerPath = null)
        {
            _fileServerPath = fileServerPath;
        }
    }
}
