using System.Collections.ObjectModel;
using Angalia.Core.Models;
using Intersoft.Crosslight.ViewModels;

namespace Angalia.Core.ViewModels
{
    public class DiseaseListViewModel : ListViewModelBase<Disease>
    {
        public DiseaseListViewModel()
        {
            this.Title = "Disease List";
            this.SourceItems = new ObservableCollection<Disease>
                {
                    new Disease
                        {
                            Name = " Measles"
                        },
                    new Disease
                        {
                            Name = " Cholera"
                        }
                };
        }
    }
}
