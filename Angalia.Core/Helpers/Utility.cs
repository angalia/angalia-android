using Intersoft.Crosslight;

namespace Angalia.Core.Helpers
{
    public static class Utility
    {
        #region Fields

        private static OSKind? _operatingSystem;

        #endregion

        #region Methods

        public static OSKind GetOperatingSystem()
        {
            if (_operatingSystem == null)
            {
                IApplicationContext applicationContext = ServiceProvider.GetService<IApplicationService>().GetContext();
                if (applicationContext != null)
                    _operatingSystem = applicationContext.Platform.OperatingSystem;
            }

            return _operatingSystem.Value;
        }

        #endregion
    }
}