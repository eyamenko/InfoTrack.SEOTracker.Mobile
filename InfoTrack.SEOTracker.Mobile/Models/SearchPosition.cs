namespace InfoTrack.SEOTracker.Mobile.Models
{
    public class SearchPosition
    {
        public int Index { get; set; }
        public string Url { get; set; }

        public string Formatted => $"{Index}. {Url}";
    }
}