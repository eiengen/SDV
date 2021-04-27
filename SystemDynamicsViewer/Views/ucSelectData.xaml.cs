using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Path = System.IO.Path;

namespace SystemDynamicsViewer.Views
{
    /// <summary>
    /// Interaction logic for ucSelectData.xaml
    /// </summary>
    public partial class UcSelectData : UserControl
    {
        /// <summary>
        /// Properties
        /// </summary>
        private FrViewModel _frViewModel = null;

        public FrViewModel FrViewModel
        {
            get => _frViewModel;
            set => _frViewModel = value;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public UcSelectData()
        {
            InitializeComponent();
        }
        
        private void BtnGetData_Click(object sender, RoutedEventArgs e)
        {
            if (this.CmbDrive.SelectedValue == null)
                return;

            // Clear data
            this.FrViewModel.FrdData.SearchedTestFiles.Clear();

            // Mouse waiting symbol while searching for files
            Mouse.OverrideCursor = Cursors.AppStarting;

            //create the object of directory info
            this.FrViewModel.FrdData.BuildDataModelFileServer(this.CmbDrive.SelectedValue.ToString(), TxtSearch.Text.Trim());

            Mouse.OverrideCursor = null;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void BtnSelectData_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridSearchData.SelectedItems.Count == 0) return;
            
            foreach (var testItem in DataGridSearchData.SelectedItems)
            {
                if (this.FrViewModel.FrdData.SelectedFrdFiles.Contains((TestDataFile) testItem))
                {
                    continue;
                }

                this.FrViewModel.FrdData.SearchedTestFiles[FrViewModel.FrdData.SearchedTestFiles.IndexOf((TestDataFile) testItem)].Selected = true;
                this.FrViewModel.FrdData.SelectedFrdFiles.Add((TestDataFile) testItem);
            }
        }

        private void BtnClearSelectedData_Click(object sender, RoutedEventArgs e)
        {
            this.FrViewModel.FrdData.SelectedFrdFiles.Clear();
            foreach (var testItem in this.FrViewModel.FrdData.SearchedTestFiles)
            {
                testItem.Selected = false;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataGridSearchData.ItemsSource = this.FrViewModel.FrdData.SearchedTestFiles;
            this.DataGridSelectedData.ItemsSource = this.FrViewModel.FrdData.SelectedFrdFiles;
        }

        private void DataGridSearchData_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (!(e.PropertyDescriptor is PropertyDescriptor propertyDescriptor)) return;
            e.Cancel = propertyDescriptor.Attributes.Contains(new BrowsableAttribute(false));

            e.Column.Header = propertyDescriptor.DisplayName;
        }

        private void DataGridSelectedData_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (!(e.PropertyDescriptor is PropertyDescriptor propertyDescriptor)) return;
            e.Cancel = propertyDescriptor.Attributes.Contains(new BrowsableAttribute(false));

            e.Column.Header = propertyDescriptor.DisplayName;
        }

        private void DataGridSelectedData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.FrViewModel.SelectedData = DataGridSelectedData.SelectedIndex;
            this.FrViewModel.FrdData.FrdCollection.Clear();
            // INSERTS EXAMPLE DATA, TO BE REPLACED WITH DATABASE INFORMATION
            this.FrViewModel.FrdData.FrdCollection.Add(new FrData
            {
                BodeExcitation = "Cmd Rate",
                BodeInput = "Cmd Rate",
                BodeOutput = "Gyro Rate",
                ExcitationAmplitude = 5.0,
                FrequencyStart = 1.0,
                FrequencyStop = 150,
                SystemId = "EUT1",
                SystemConfiguration = "Fixed",
                ProjectId = "P-1000"
            });

            this.FrViewModel.FrPlotModel.InvalidatePlot(false);
        }

        private void DataGridSearchData_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void DataGridSearchData_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            int selectedIndex = DataGridSearchData.SelectedIndex;
            
            this.FrViewModel.FrdData.SearchedTestFiles[selectedIndex].Selected = true;

            // Check duplicate selected data
            if (this.FrViewModel.FrdData.SelectedFrdFiles.Contains(
                this.FrViewModel.FrdData.SearchedTestFiles[selectedIndex]))
            {
                if (this.FrViewModel.FrdData.SearchedTestFiles[selectedIndex].Selected == true)
                {
                    this.FrViewModel.FrdData.SearchedTestFiles[selectedIndex].Selected = false;
                    // Remove data from selected data list
                    this.FrViewModel.FrdData.SelectedFrdFiles.Remove(
                        this.FrViewModel.FrdData.SearchedTestFiles[selectedIndex]);
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.FrViewModel.FrdData.SelectedFrdFiles.Add(this.FrViewModel.FrdData.SearchedTestFiles[selectedIndex]);
            }
        }

        private void tbFilterName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
