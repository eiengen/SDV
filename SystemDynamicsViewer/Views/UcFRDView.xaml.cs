using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SystemDynamicsViewer.DataModel;
using SystemDynamicsViewer.ViewModels;
using SystemDynamicsViewer.Views;


namespace SystemDynamicsViewer.Views
{
    /// <summary>
    /// Interaction logic for UcFRDView.xaml
    /// </summary>
    public partial class UcFrdView : UserControl
    {
        private FrViewModel _frViewModel = new FrViewModel();

        public FrViewModel FrViewModel => _frViewModel;

        public UcFrdView()
        {
            InitializeComponent();

            SelectData.FrViewModel = _frViewModel;
            // File server path
            SelectData.CmbDrive.ItemsSource = Directory.GetDirectories(_frViewModel.FrdData.TestFileServer.FileServerPath);

            DataGridSelectedFrData.ItemsSource = _frViewModel.FrdData.FrdCollection;
        }
        /// <summary>
        /// Custom view of datagrid column headers
        /// </summary>
        private void DataGridSelectedFrData_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (!(e.PropertyDescriptor is PropertyDescriptor propertyDescriptor)) return;
            e.Cancel = propertyDescriptor.Attributes.Contains(new BrowsableAttribute(false));

            e.Column.Header = propertyDescriptor.DisplayName;
        }
    }
}
