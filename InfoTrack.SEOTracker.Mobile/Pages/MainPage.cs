using Xamarin.Forms;

namespace InfoTrack.SEOTracker.Mobile.Pages
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Children.Add(new LatestPage());
            Children.Add(new AllTimePage());
        }
    }
}