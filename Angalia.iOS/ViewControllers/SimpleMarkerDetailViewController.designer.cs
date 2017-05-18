// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MapSamples.iOS
{
	[Register ("SimpleMarkerDetailViewController")]
	partial class SimpleMarkerDetailViewController
	{
		[Outlet]
		UIKit.UILabel AddressText { get; set; }

		[Outlet]
		UIKit.UIImageView BuildingImage { get; set; }

		[Outlet]
		UIKit.UILabel PhoneText { get; set; }

		[Outlet]
		UIKit.UILabel TitleText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BuildingImage != null) {
				BuildingImage.Dispose ();
				BuildingImage = null;
			}

			if (TitleText != null) {
				TitleText.Dispose ();
				TitleText = null;
			}

			if (PhoneText != null) {
				PhoneText.Dispose ();
				PhoneText = null;
			}

			if (AddressText != null) {
				AddressText.Dispose ();
				AddressText = null;
			}
		}
	}
}
