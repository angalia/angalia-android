using Intersoft.Crosslight.Forms;

namespace Angalia.Core.Models
{
    public class ReportIncidence : ModelBase
    {
        #region Fields
        
        private string _heading;
        private string _name;
        private string _description;
        private string _submitButton;
        //private byte[] _photo;

        #endregion

        #region Properties

        public string Heading
        {
            get { return _heading; }
            set
            {
                if (_heading != value)
                {
                    _heading = value;
                    OnPropertyChanged("Heading");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string SubmitButton
        {
            get { return _submitButton; }
            set
            {
                if (_submitButton != value)
                {
                    _submitButton = value;
                    OnPropertyChanged("SubmitButton");
                }
            }
        }

        //public byte[] Photo
        //{
        //    get { return _photo; }
        //    set
        //    {
        //        if (_photo != value)
        //        {
        //            _photo = value;
        //            OnPropertyChanged("Photo");
        //        }
        //    }
        //}
        #endregion

        public override void Validate()
        {
            base.Validate();
            this.ClearAllErrors();
            if (string.IsNullOrEmpty(this.Heading))
                this.SetError("Please enter the report heading.", "Heading required");


        }


    }

    [Form(Title = "Report")]
    public class ReportIncidenceMetaData
    {
        #region Fields

        [Section(Header = "Report Incidence")]
        public ReportIncidenceDetailsSection BalanceDetailsSection;

        #endregion
    }

    public class ReportIncidenceDetailsSection
    {
        #region Fields

        [Display(Caption = "Heading")]
        [Editor(EditorType.TextField)]
        [StringInput(Placeholder = "Cholera outbreak in Cape Coast")]
        [Layout(Style = LayoutStyle.RowDetail)]
        public string Heading;

        [Display(Caption = "Name")]
        [Editor(EditorType.TextField)]
        [StringInput(Placeholder = "Caressa Lutterodt")]
        [Layout(Style = LayoutStyle.RowDetail)]
        public string Name;

        [Display(Caption = "Description")]
        [Editor(EditorType.TextField)]
        [StringInput(Placeholder = "There are rumours of cholera outbreak in Cape Coast. This was reported by one of the biggest hospital last week Wednesday during an urgent meeting by the regional directorate.", AutoCorrection = AutoCorrectionType.Yes, AutoResize = true, MinHeight = 3)]
        [Layout(Style = LayoutStyle.RowDetail)]
        public string Description;

        //[Editor(EditorType.Image)]
        //[Image(Height = 83, Width = 80, Placeholder = "item_placeholder.jpg", Frame = "frame.png", FramePadding = 6, FrameShadowHeight = 3)]
        //[ImagePicker(ImageResultMode = ImageResultMode.Both, PickerResultCommand = "FinishImagePickerCommand")]
        //[Layout(Style = LayoutStyle.DetailOnly)]
        //public static byte[] Photo;

        [Editor(EditorType.Button)]
        [Display(Caption = "SUBMIT")]
        [Binding(Path = "SubmitCollectionCommand", SourceType = BindingSourceType.ViewModel)]
        public string SubmitButton;

        #endregion
    }
}
