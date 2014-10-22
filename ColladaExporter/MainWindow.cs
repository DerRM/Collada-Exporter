using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace ColladaExporter
{
	public partial class MainWindow : MonoMac.AppKit.NSWindow
	{
		#region Constructors
		
		// Called when created from unmanaged code
		public MainWindow (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindow (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}
		
		#endregion
		
		partial void openSelectFileDialog (MonoMac.Foundation.NSObject sender)
		{
			NSOpenPanel panel = NSOpenPanel.OpenPanel;
			panel.AllowsMultipleSelection = false;
			panel.CanChooseDirectories = false;
			int result = panel.RunModal();
			
			if (result == 1)
			{
				txt_input.StringValue = panel.Url.Path;
			}
		}
		
		partial void openSaveFileDialog (MonoMac.Foundation.NSObject sender)
		{
			
		}
		
		partial void exportFile (MonoMac.AppKit.NSButton sender)
		{
			
			var scfExport = new ExportSCF(txt_input.StringValue, txt_output.StringValue);
			NSTextView txt = (NSTextView) txt_fld_output.DocumentView;
			//txt.TextStorage.Append(new NSAttributedString(parser.GetParseOutput()));
			txt.TextStorage.Append(new NSAttributedString(scfExport.DebugOutput));
		}
	}
}

