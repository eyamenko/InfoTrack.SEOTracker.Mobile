using System.ComponentModel;
using InfoTrack.SEOTracker.Mobile.Models;
using InfoTrack.SEOTracker.Mobile.Contracts.ApiClients;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace InfoTrack.SEOTracker.Mobile.ViewModels
{
    public class LatestPageViewModel : INotifyPropertyChanged
    {
        private readonly ISEOTrackerApiClient _seoTrackerApiClient;
        private readonly ObservableCollection<SearchPosition> _positions;

        public LatestPageViewModel(ISEOTrackerApiClient seoTrackerApiClient)
        {
            _seoTrackerApiClient = seoTrackerApiClient;
            _positions = new ObservableCollection<SearchPosition>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<SearchPosition> Positions => _positions;

        public ICommand RefreshCommand => new Command(async () =>
        {
            var searchResult = await _seoTrackerApiClient.GetLatestSearchResult();

            Positions.Clear();

            if (searchResult == null)
                return;

            foreach (var position in searchResult.Data)
            {
                Positions.Add(position);
            }
        });
    }
}