using System;

namespace ColladaExporter.Parsing
{
	public class Parser
	{
		protected GeometryLibrary mGeometryLibrary = new GeometryLibrary();
		protected bool isFinished = false;
		
		public GeometryLibrary GeometryLibrary
		{
			get { return mGeometryLibrary; }
		}
		
		public bool IsFinished
		{
			get { return isFinished; }
		}

		public Parser ()
		{
		}
	}
}

