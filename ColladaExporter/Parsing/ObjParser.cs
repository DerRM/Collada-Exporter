using System;

namespace ColladaExporter.Parsing
{
	public class ObjParser : Parser
	{
		public ObjParser (String path)
		{
			FloatArray floatArray = new FloatArray();
			TrianglesInput input = new TrianglesInput();
			TrianglesP triP = new TrianglesP();
			Source source = new Source();
			source.mFloatArray = floatArray;
			Triangles triangles = new Triangles();
			triangles.mTriangleInputs.Add(input);
			triangles.mTrianglesP = triP;
			Vertices vertices = new Vertices();
			Mesh mesh = new Mesh();
			mesh.mSources.Add(source);
			mesh.mTriangles.Add(triangles);
			mesh.mVertices = vertices;
			Geometry geometry = new Geometry();
			geometry.mMeshes.Add(mesh);
			mGeometryLibrary.mGeometries.Add(geometry);
		}
	}
}

