using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfoTrack.SEOTracker.Mobile.Models;

namespace InfoTrack.SEOTracker.Mobile.Contracts.ApiClients
{
    public interface ISEOTrackerApiClient
    {
        Task<IEnumerable<SearchResult>> GetSearchResults();
        Task<SearchResult> GetLatestSearchResult();
    }
}