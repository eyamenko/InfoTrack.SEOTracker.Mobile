using Autofac;
using InfoTrack.SEOTracker.Mobile.Contracts.ApiClients;
using InfoTrack.SEOTracker.Mobile.ApiClients;
using InfoTrack.SEOTracker.Mobile.ViewModels;

namespace InfoTrack.SEOTracker.Mobile.DependencyResolver
{
    public static class DependencyConfiguration
    {
        private static readonly object _lock = new object();

        private static IContainer _instance;

        private static IContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = Build();
                        }
                    }
                }

                return _instance;
            }
        }

        private static IContainer Build()
        {
            var builder = new ContainerBuilder();

            #region Api Clients

            builder.Register<ISEOTrackerApiClient>(_ => new SEOTrackerApiClient("http://ec2-52-89-146-59.us-west-2.compute.amazonaws.com:5000"));

            #endregion

            #region View Models

            builder.RegisterType<LatestPageViewModel>();
            builder.RegisterType<AllTimePageViewModel>();

            #endregion

            return builder.Build();
        }

        public static T Resolve<T>()
        {
            return Instance.Resolve<T>();
        }
    }
}