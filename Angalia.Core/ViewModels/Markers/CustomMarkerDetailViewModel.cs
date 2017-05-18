using Angalia.Core.Models;
using Angalia.Core.ViewModels.Base;
using Intersoft.Crosslight;

namespace Angalia.Core.ViewModels.Markers
{
    public class CustomMarkerDetailViewModel : SampleViewModelBase
    {
        #region Constructors

        public CustomMarkerDetailViewModel()
        {
        }

        #endregion

        #region Fields

        private MarkerPlacemark _marker;

        #endregion

        #region Properties

        public MarkerPlacemark Marker
        {
            get { return _marker; }
            set
            {
                if (_marker != value)
                {
                    _marker = value;
                    OnPropertyChanged("Marker");
                }
            }
        }

        #endregion

        #region Methods

        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);

            this.Marker = parameter.Data as MarkerPlacemark;
            this.Title = this.Marker.Name;
        }

        #endregion
    }
}