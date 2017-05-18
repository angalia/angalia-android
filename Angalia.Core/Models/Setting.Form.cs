using Intersoft.Crosslight.Forms;

namespace Angalia.Core.Models
{
    [Form(Title = "Radius Settings")]
    public class SettingFormMetadata
    {
        #region Sections        

		[Section(Header="Nearby Hospital Radius (metres)")]
		public HospitalInputRangeSection HospitalInputRange;

        [Section(Header = "Nearby Pharmacy Radius (metres)")]
        public PharmacyInputRangeSection PharmacyInputRange;

        #endregion

        #region Input Range Section

        public class HospitalInputRangeSection
		{
			[Editor(EditorType.Label)]
			[Display(Caption="Radius")]
			[Binding(Path = "HospitalRadius", SourceType = BindingSourceType.Model)]
			public string CurrentHospitalRadius;

			[Editor(EditorType.Slider)]
			[Layout(Style = LayoutStyle.DetailOnly)]
			[RangeInput(MaxValue = 1000, MinValue = 0)]
			public int HospitalRadius;
		}

        public class PharmacyInputRangeSection
        {
            [Editor(EditorType.Label)]
            [Display(Caption = "Radius")]
            [Binding(Path = "PharmacyRadius", SourceType = BindingSourceType.Model)]
            public string CurrentPharmacyRadius;

            [Editor(EditorType.Slider)]
            [Layout(Style = LayoutStyle.DetailOnly)]
            [RangeInput(MaxValue = 1000, MinValue = 0)]
            public int PharmacyRadius;
        }

        #endregion

    }
}

