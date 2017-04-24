using System.ComponentModel;
using InfoTrack.SEOTracker.Mobile.Contracts.ApiClients;
using InfoTrack.SEOTracker.Mobile.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace InfoTrack.SEOTracker.Mobile.ViewModels
{
    public class AllTimePageViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<SearchResult> _searchResults;
        private readonly ISEOTrackerApiClient _seoTrackerApiClient;

        public AllTimePageViewModel(ISEOTrackerApiClient seoTrackerApiClient)
        {
            _seoTrackerApiClient = seoTrackerApiClient;
            _searchResults = new ObservableCollection<SearchResult>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<SearchResult> SearchResults => _searchResults;

        public async void Refresh()
        {
            var searchResults = await _seoTrackerApiClient.GetSearchResults();

            SearchResults.Clear();

            foreach (var searchResult in searchResults)
            {
                SearchResults.Add(searchResult);
            }
        }
    }
}