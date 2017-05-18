using System.Collections.ObjectModel;
using Angalia.Core.Models;
using Intersoft.Crosslight.ViewModels;

namespace Angalia.Core.ViewModels
{
    public class RegionListViewModel : ListViewModelBase<Region>
    {
        public RegionListViewModel()
        {
            this.Title = "Regional List";
            this.SourceItems = new ObservableCollection<Region>
            {
                new Region
                    {
                        Name = " Central"
                    },
                new Region
                    {
                        Name = " Eastern"
                    },
                new Region
                    {
                        Name = " Western"
                    }
            };
        }
    }
}