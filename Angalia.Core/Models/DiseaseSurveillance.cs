using Angalia.Core.ViewModels;
using Intersoft.Crosslight.Forms;

namespace Angalia.Core.Models
{
    public class DiseaseSurveillance : ModelBase
    {
        #region Fields

        private Region _primeAccount;
        private string _amount;
        private string _narration;
        private string _dest;

        #endregion

        #region Properties

        
        public string Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }
        

        public string Narration
        {
            get { return _narration; }
            set
            {
                if (_narration != value)
                {
                    _narration = value;
                    OnPropertyChanged("Narration");
                }
            }
        }
        public string Dest
        {
            get { return _dest; }
            set
            {
                if (_dest != value)
                {
                    _dest = value;
                    OnPropertyChanged("Dest");
                }
            }
        }
        #endregion

        public override void Validate()
        {
            base.Validate();
            this.ClearAllErrors();
            

        }


    }

    [Form(Title = "Disease Surveillance")]
    public class DiseaseSsurveillanceFormMetadata
    {
        #region Fields

        [Section(Header = "Select Region")]
        public RegionDetailsSection RegionDetailsSection;

        [Section(Header = "Select District")]
        public DistrictDetailsSection DistrictDetailsSection;


        [Section(Header = "Select Disease")]
        public DiseaseDetailsSection DiseaseDetailsSection;


        [Section(Header = "")]
        public SubmitDetailsSection SubmitDetailsSection;
        #endregion
    }

    public class RegionDetailsSection
    {
        #region Fields

        [Editor(EditorType.Picker)]
        [SelectedItemBinding(Path = "Region")]
        [Binding(Path = "Region.Name")]
        [SelectionInput(SelectionMode.Single, DisplayMemberPath = "Name", ValueMemberPath = "Name", ListSourceType = typeof(RegionListViewModel))]
        [Layout(Style = LayoutStyle.DetailOnly)]
        public Region Region;
        #endregion
    }

    public class DistrictDetailsSection
    {
        #region Fields        

        [Editor(EditorType.Picker)]
        [SelectedItemBinding(Path = "District")]
        [Binding(Path = "District.Name")]
        [SelectionInput(SelectionMode.Single, DisplayMemberPath = "Name", ValueMemberPath = "Name", ListSourceType = typeof(DistrictListViewModel))]
        [Layout(Style = LayoutStyle.DetailOnly)]
        public District District;
        
        #endregion
    }

    public class DiseaseDetailsSection
    {
        #region Fields

        [Editor(EditorType.Picker)]
        [SelectedItemBinding(Path = "Disease")]
        [Binding(Path = "Disease.Name")]
        [SelectionInput(SelectionMode.Single, DisplayMemberPath = "Name", ValueMemberPath = "Name", ListSourceType = typeof(DiseaseListViewModel))]
        [Layout(Style = LayoutStyle.DetailOnly)]
        public Disease Disease;

        #endregion
    }

    public class SubmitDetailsSection
    {
        #region Fields

        [Editor(EditorType.Button)]
        [Display(Caption = "SUBMIT")]
        [Binding(Path = "SubmitCollectionCommand", SourceType = BindingSourceType.ViewModel)]
        [Button(Parameter = "Hello FormBuilder!")]
        public string Narration;

        #endregion
    }

}