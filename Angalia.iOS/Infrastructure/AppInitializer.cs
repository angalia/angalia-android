using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using Intersoft.Crosslight.UI.iOS;
using MapSamples.Infrastructure;

namespace MapSamples.iOS.Infrastructure
{
    public sealed class AppInitializer : IApplicationInitializer
    {
        #region Methods

        public IApplicationService GetApplicationService(IApplicationContext context)
        {
            return new CrosslightAppAppService(context);
        }

        public void InitializeApplication(IApplicationHost appHost)
        {
        }

        public void InitializeComponents(IApplicationHost appHost)
        {
        }

        public void InitializeServices(IApplicationHost appHost)
        {
            UIApplicationDelegate.PreserveAssembly(typeof(ServiceInitializer).Assembly);
        }

        #endregion
    }
}