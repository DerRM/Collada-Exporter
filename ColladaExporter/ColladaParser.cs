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
					ParseGeometryLibrary_GeometryMeshSource(MeshNode.ChildNodes[i], CurrentMesh);
				}
				
				if (MeshNode.ChildNodes[i].Name.Equals("vertices"))
				{
					ParseGeometryLibrary_GeometryMeshVertices(MeshNode.ChildNodes[i], CurrentMesh);
				}
				
				if (MeshNode.ChildNodes[i].Name.Equals("triangles"))
				{
					ParseGeometryLibrary_GeometryMeshTriangles(MeshNode.ChildNodes[i], CurrentMesh);
				}
			}
			
			CurrentGeometry.mMeshes.Add(CurrentMesh);
		}
		
		public void ParseGeometryLibrary_GeometryMeshSource(XmlNode SourceNode, Mesh CurrentMesh)
		{
			Console.WriteLine("Entered SourceNode");
			
			Source CurrentSource = new Source();
			
			for (int i = 0; i < SourceNode.ChildNodes.Count; i++)
			{
				if (SourceNode.ChildNodes[i].Name.Equals("float_array"))
				{
					
				}
				
				if (SourceNode.ChildNodes[i].Name.Equals("technique_common"))
				{
					
				}
			}
			
			CurrentMesh.mSources.Add(CurrentSource);
		}
		
		public void ParseGeometryLibrary_GeometryMeshVertices(XmlNode VerticeNode, Mesh CurrentMesh)
		{
			Console.WriteLine("Entered VerticesNode");
			
			Vertices CurrentVertices = new Vertices();
			
			for (int i = 0; i < VerticeNode.ChildNodes.Count; i++)
			{
				if (VerticeNode.ChildNodes[i].Name.Equals("input"))
				{
					
				}
			}
			
			CurrentMesh.mVertices = CurrentVertices;
		}
		
		public void ParseGeometryLibrary_GeometryMeshTriangles(XmlNode TrianglesNode, Mesh CurrentMesh)
		{
			Console.WriteLine("Entered TrianglesNode");
			
			Triangles CurrentTriangles = new Triangles();
			
			for (int i = 0; i < TrianglesNode.ChildNodes.Count; i++)
			{
				if (TrianglesNode.ChildNodes[i].Equals("input"))
				{
					
				}
				
				if (TrianglesNode.ChildNodes[i].Equals("p"))
				{
				}
			}
			
			CurrentMesh.mTriangles.Add(CurrentTriangles);
		}
	}
}

