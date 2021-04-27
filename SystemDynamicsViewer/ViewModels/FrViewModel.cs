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
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace SystemDynamicsViewer.ViewModels
{
    public class FrViewModel:INotifyPropertyChanged
    {
        private FrdDataModel _frdData = new FrdDataModel();

        /// <summary>
        /// Properties of the View Model
        /// </summary>
        ///
        private OxyPlot.Series.LineSeries _frequencyCurve = new OxyPlot.Series.LineSeries()
        {
            Title = "Frequency test example",
            StrokeThickness = 3
        };

        public FrdDataModel FrdData
        {
            get => _frdData;
            set
            {
                if (Equals(value, _frdData)) return;
                _frdData = value;
                OnPropertyChanged();
            }
        }

        public LineSeries FrequencyCurve
        {
            get => _frequencyCurve;
            set
            {
                if (Equals(value, _frequencyCurve)) return;
                _frequencyCurve = value;
                OnPropertyChanged();
            }
        }

        public PlotModel FrPlotModel { get; private set; }
        public object SelectedData { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FrViewModel()
        {
            var frPlotModel = new PlotModel
            {
                Title = "Frequency response example"
            };

            _frequencyCurve.Points.Add(new DataPoint(0.1, 0));
            _frequencyCurve.Points.Add(new DataPoint(1, 0.5));
            _frequencyCurve.Points.Add(new DataPoint(10, 5));
            _frequencyCurve.Points.Add(new DataPoint(15, 10));
            _frequencyCurve.Points.Add(new DataPoint(20, 5));
            _frequencyCurve.Points.Add(new DataPoint(25, 0));
            _frequencyCurve.Points.Add(new DataPoint(30, -5));
            _frequencyCurve.Points.Add(new DataPoint(35, -10));
            _frequencyCurve.Points.Add(new DataPoint(40, -20));
            _frequencyCurve.Points.Add(new DataPoint(50, -40));

            frPlotModel.Axes.Add(new OxyPlot.Axes.LogarithmicAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Frequency [Hz]",
                Base = 10,
                UseSuperExponentialFormat = true,
                MajorGridlineStyle = LineStyle.Dash,
                TickStyle = TickStyle.Outside,
                AbsoluteMinimum = 0.1,
                AbsoluteMaximum = 1000,
                MinimumRange = 0.1,
                MaximumRange = 1000,
                IntervalLength = 10
            });
            frPlotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Magnitude [dB]",
                MajorGridlineStyle = LineStyle.Dash,
                TickStyle = TickStyle.Outside
            });

            frPlotModel.Series.Add(_frequencyCurve);

            this.FrPlotModel = frPlotModel;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
