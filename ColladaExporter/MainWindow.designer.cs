// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace ColladaExporter
{
	[Register ("MainWindow")]
	partial class MainWindow
	{
		[Outlet]
		MonoMac.AppKit.NSTextField txt_input { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField txt_output { get; set; }

		[Outlet]
		MonoMac.AppKit.NSScrollView txt_fld_output { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton btn_input { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton btn_output { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton btn_export { get; set; }

		[Action ("openSelectFileDialog:")]
		partial void openSelectFileDialog (MonoMac.Foundation.NSObject sender);

		[Action ("openSaveFileDialog:")]
		partial void openSaveFileDialog (MonoMac.Foundation.NSObject sender);

		[Action ("exportFile:")]
		partial void exportFile (MonoMac.AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (txt_input != null) {
				txt_input.Dispose ();
				txt_input = null;
			}

			if (txt_output != null) {
				txt_output.Dispose ();
				txt_output = null;
			}

			if (txt_fld_output != null) {
				txt_fld_output.Dispose ();
				txt_fld_output = null;
			}

			if (btn_input != null) {
				btn_input.Dispose ();
				btn_input = null;
			}

			if (btn_output != null) {
				btn_output.Dispose ();
				btn_output = null;
			}

			if (btn_export != null) {
				btn_export.Dispose ();
				btn_export = null;
			}
		}
	}

	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
