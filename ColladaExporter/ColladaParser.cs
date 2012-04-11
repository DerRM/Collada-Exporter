using System;
using System.Xml;
using System.IO;

namespace ColladaExporter
{
	public class ColladaParser
	{
		public const String LIBRARY_GEOMETRIES = "library_geometries";
		
		private GeometryLibrary mGeometryLibrary = new GeometryLibrary();
		
		public ColladaParser(String path)
		{	
			
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load("/Users/christophersierigk/Downloads/Astro/astroBoy_walk_Max.DAE");
			
			XmlElement RootElement = xmlDoc.DocumentElement;
			
			for (int i = 0; i < RootElement.ChildNodes.Count; i++)
			{
				XmlNode ChildNode = RootElement.ChildNodes[i];
				String ChildName = ChildNode.Name.ToString();
				
				if (ChildName.Equals(LIBRARY_GEOMETRIES))
				{
					ParseGeometryLibrary(ChildNode);
				}
			}
		}
		
		public void ParseGeometryLibrary(XmlNode GeomNode)
		{
			Console.WriteLine("Entered GeometryLibraryNode");
			
			for (int i = 0; i < GeomNode.ChildNodes.Count; i++) {
				
				if (GeomNode.ChildNodes[i].Name.Equals("geometry"))
				{
					ParseGeometryLibrary_Geometry(GeomNode.ChildNodes[i]);
				}
			}
		}
		
		public void ParseGeometryLibrary_Geometry(XmlNode GeomNode)
		{
			Console.WriteLine("Entered GeometryNode");
			
			Geometry CurrentGeometry = new Geometry();
			
			for (int i = 0; i < GeomNode.ChildNodes.Count; i++)
			{
				if (GeomNode.ChildNodes[i].Name.Equals("mesh"))
				{
					ParseGeometryLibrary_GeometryMesh(GeomNode.ChildNodes[i], CurrentGeometry);
				}
			}
			
			mGeometryLibrary.mGeometries.Add(CurrentGeometry);
		}
		
		public void ParseGeometryLibrary_GeometryMesh(XmlNode MeshNode, Geometry CurrentGeometry)
		{
			Console.WriteLine("Entered MeshNode");
			
			Mesh CurrentMesh = new Mesh();
			
			for (int i = 0; i < MeshNode.ChildNodes.Count; i++)
			{
				if (MeshNode.ChildNodes[i].Name.Equals("source"))
				{
					
				}
				
				if (MeshNode.ChildNodes[i].Name.Equals("vertices"))
				{
					
				}
				
				if (MeshNode.ChildNodes[i].Name.Equals("triangles"))
				{
					
				}
			}
			
			CurrentGeometry.mMeshes.Add(CurrentMesh);
		}
	}
}

