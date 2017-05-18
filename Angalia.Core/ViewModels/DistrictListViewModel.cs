using System.Collections.ObjectModel;
using Angalia.Core.Models;
using Intersoft.Crosslight.ViewModels;

namespace Angalia.Core.ViewModels
{
    public class DistrictListViewModel : ListViewModelBase<District>
    {
        public DistrictListViewModel()
        {
            this.Title = "District List";
            this.SourceItems = new ObservableCollection<District>
                {
                    new District
                        {
                            Name = " Osu "
                        },
                    new District
                        {
                            Name = " La"
                        },
                    new District
                        {
                            Name = " Ga wai"
                        }
                };
        }
    }
}
