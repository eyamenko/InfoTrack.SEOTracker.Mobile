using Xamarin.Forms;
using InfoTrack.SEOTracker.Mobile.DependencyResolver;
using InfoTrack.SEOTracker.Mobile.ViewModels;

namespace InfoTrack.SEOTracker.Mobile.Pages
{
    public partial class LatestPage : ContentPage
    {
        public LatestPage()
        {
            InitializeComponent();

            var model = DependencyConfiguration.Resolve<LatestPageViewModel>();

            BindingContext = model;

            PositionListView.BeginRefresh();

            model.Positions.CollectionChanged += (sender, e) => PositionListView.EndRefresh();
        }
    }
}