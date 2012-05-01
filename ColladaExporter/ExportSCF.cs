using System;

namespace ColladaExporter
{
	public class ExportSCF
	{
		private ColladaParser mParser;
		private GeometryLibrary mGeometryLibrary;
		
		public ExportSCF (String path)
		{
			mParser = new ColladaParser(path);
			
			if (mParser.IsFinished)
			{
				mGeometryLibrary = mParser.GeometryLibrary;
			}
			
			WriteSCF.OpenFile("/Users/christophersierigk/Desktop/Test.scf");
			WriteSCFData();
			WriteSCF.CloseFile();
		}
		
		private void WriteSCFData()
		{
			SCFSpecification.SCF SCFFile = new SCFSpecification.SCF();
			
			WriteSCFMainChunk(SCFFile);
			
			Geometry geometry = mGeometryLibrary.mGeometries[0];
			Mesh mesh = geometry.mMeshes[0];
			
			for (int i = 0; i < mesh.mTriangles.Count; i++)
			{
				Console.WriteLine("TriangleGroup " + i);
				SCFFile.mHeader.mGeometryChunk.mTotalNoOfTriangles += mesh.mTriangles[i].mCount;
			}
			
			SCFFile.mHeader.mGeometryChunk.mNoOfTriangleGroups = (uint) mesh.mTriangles.Count;
			
			WriteSCFGeometryChunk(SCFFile);
			
			WriteSCFArrayData(mesh);
			
			for (int i = 0; i < SCFFile.mHeader.mGeometryChunk.mNoOfTriangleGroups; i++)
			{
				WriteSCFTrianglesData(mesh.mTriangles[i]);
			}
		}
		
		private void WriteSCFMainChunk(SCFSpecification.SCF scf)
		{
			SCFSpecification.SCFMainChunk main = scf.mHeader.mMainChunk;
			
			WriteSCF.Write(main.mMagicNumber);
			WriteSCF.Write(main.mVersion);
			WriteSCF.Write(main.mChunkId);
			WriteSCF.Write(main.mNoOfSubChunks);
		}
		
		private void WriteSCFGeometryChunk(SCFSpecification.SCF scf)
		{
			SCFSpecification.SCFGeometryChunk geometry = scf.mHeader.mGeometryChunk;
			
			WriteSCF.Write(geometry.mChunkId);
			WriteSCF.Write(geometry.mNoOfTriangleGroups);
			WriteSCF.Write(geometry.mTotalNoOfTriangles);
			WriteSCF.Write(geometry.mDataOffset);
		}
		
		private void WriteSCFArrayData(Mesh mesh)
		{
			for (int i = 0; i < mesh.mSources.Count; i++)
			{
				if (i != 2)
				{
					Console.WriteLine(mesh.mSources[i].mSourceId + " Entered");
					WriteSCF.Write(mesh.mSources[i].mFloatArray.mCount);
					
					for (int j = 0; j < mesh.mSources[i].mFloatArray.mCount; j++)
					{
						WriteSCF.Write(mesh.mSources[i].mFloatArray.mFloats[j]);
					}
				}
			}
		}
		
		private void WriteSCFTrianglesData(Triangles triangles)
		{
			WriteSCF.Write(triangles.mCount);
			
			int increment = 3 * triangles.mTriangleInputs.Count;
			int increment1 = triangles.mTriangleInputs.Count;
			
			for (int i = 0; i < triangles.mTrianglesP.mIndices.Count; i += increment)
			{
				WriteSCF.Write(triangles.mTrianglesP.mIndices[i + (0 * increment1)]);
				WriteSCF.Write(triangles.mTrianglesP.mIndices[i + (1 * increment1)]);
				WriteSCF.Write(triangles.mTrianglesP.mIndices[i + (2 * increment1)]);
				
				if (triangles.mTriangleInputs.Count > 1)
				{
					WriteSCF.Write(triangles.mTrianglesP.mIndices[i + 1 + (0 * increment1)]);
					WriteSCF.Write(triangles.mTrianglesP.mIndices[i + 1 + (1 * increment1)]);
					WriteSCF.Write(triangles.mTrianglesP.mIndices[i + 1 + (2 * increment1)]);
				}
			}
		}
	}
}

