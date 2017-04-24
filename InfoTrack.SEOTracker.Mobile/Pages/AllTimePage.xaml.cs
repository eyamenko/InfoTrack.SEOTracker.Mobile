using Xamarin.Forms;
using InfoTrack.SEOTracker.Mobile.ViewModels;
using InfoTrack.SEOTracker.Mobile.DependencyResolver;
using OxyPlot;
using OxyPlot.Series;
using InfoTrack.SEOTracker.Mobile.Models;
using System.Linq;
using OxyPlot.Axes;
using System;

namespace InfoTrack.SEOTracker.Mobile.Pages
{
    public partial class AllTimePage : ContentPage
    {
        private readonly AllTimePageViewModel _model;

        public AllTimePage()
        {
            InitializeComponent();

            _model = DependencyConfiguration.Resolve<AllTimePageViewModel>();

            ChartView.Model = GetModel();

            _model.SearchResults.CollectionChanged += CollectionChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ChartView.IsVisible = false;
            IndicatorView.IsVisible = true;
            IndicatorView.IsRunning = true;

            _model.Refresh();
        }

        private PlotModel GetModel()
        {
            var model = new PlotModel();

            var series = new LineSeries()
            {
                ItemsSource = _model.SearchResults,
                Mapping = GetDataPoint,
                Color = OxyColors.Blue
            };

            model.Series.Add(series);

            model.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "yy/M/d"
            });

            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                MajorStep = 1
            });

            return model;
        }

        private DataPoint GetDataPoint(object obj)
        {
            var searchResult = obj as SearchResult;

            if (searchResult == null)
                return default(DataPoint);

            var first = searchResult.Data.FirstOrDefault();
            var x = DateTimeAxis.ToDouble(searchResult.Timestamp);
            var y = first == null ? 0 : first.Index;

            return new DataPoint(x, y);
        }

        private void CollectionChanged(object sender, EventArgs e)
        {
            IndicatorView.IsRunning = false;
            IndicatorView.IsVisible = false;
            ChartView.IsVisible = true;

            ChartView.Model.InvalidatePlot(true);
        }
    }
}