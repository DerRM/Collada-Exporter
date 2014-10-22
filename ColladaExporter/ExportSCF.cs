using System;
using System.IO;
using ColladaExporter.Parsing;

namespace ColladaExporter
{
	public class ExportSCF
	{
		private Parser mParser;
		private GeometryLibrary mGeometryLibrary;
		private String debugOutput;

		public String DebugOutput
		{
			get { return debugOutput; }
		}

		public ExportSCF (String path, String dest)
		{
			string e = Path.GetExtension(path).ToLower();
			debugOutput = "";

			switch(e) {
			case ".dae":
				mParser = new ColladaParser(path);
				break;
			case ".obj":
				mParser = new ObjParser(path);
				break;
			default:
				debugOutput += "I don't know what that is\n";
				return;
				//break;
			}

			if (mParser.IsFinished)
			{
				mGeometryLibrary = mParser.GeometryLibrary;
			}

			if (dest.Equals(""))
			{
				WriteSCF.OpenFile("/Users/derrm/Desktop/Test.scf");
			}
			else
			{
				WriteSCF.OpenFile(dest);
			}

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
				debugOutput += "TriangleGroup " + i + "\n";
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
					debugOutput += mesh.mSources[i].mSourceId + " Entered\n";
					WriteSCF.Write(mesh.mSources[i].mFloatArray.mCount);
					
					for (int j = 0; j < mesh.mSources[i].mFloatArray.mCount; j++)
					{
						WriteSCF.Write(mesh.mSources[i].mFloatArray.mFloats[j]);
					}
				}

				if (i == 2) 
				{
					debugOutput += mesh.mSources[i].mSourceId + " Entered\n";
					WriteSCF.Write(mesh.mSources[i].mFloatArray.mCount / 3);

					for (int j = 0; j < mesh.mSources[i].mFloatArray.mCount; j += 3)
					{
						WriteSCF.Write(mesh.mSources[i].mFloatArray.mFloats[j]);
						WriteSCF.Write(mesh.mSources[i].mFloatArray.mFloats[j + 1]);
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
				WriteSCF.Write((ushort)triangles.mTrianglesP.mIndices[i + (0 * increment1)]);
				WriteSCF.Write((ushort)triangles.mTrianglesP.mIndices[i + (1 * increment1)]);
				WriteSCF.Write((ushort)triangles.mTrianglesP.mIndices[i + (2 * increment1)]);
				
				if (triangles.mTriangleInputs.Count > 1)
				{
					WriteSCF.Write((ushort)triangles.mTrianglesP.mIndices[i + 1 + (0 * increment1)]);
					WriteSCF.Write((ushort)triangles.mTrianglesP.mIndices[i + 1 + (1 * increment1)]);
					WriteSCF.Write((ushort)triangles.mTrianglesP.mIndices[i + 1 + (2 * increment1)]);
				}

				if (triangles.mTriangleInputs.Count > 2)
				{
					WriteSCF.Write((ushort)triangles.mTrianglesP.mIndices[i + 2 + (0 * increment1)]);
					WriteSCF.Write((ushort)triangles.mTrianglesP.mIndices[i + 2 + (1 * increment1)]);
					WriteSCF.Write((ushort)triangles.mTrianglesP.mIndices[i + 2 + (2 * increment1)]);
				}
			}
		}
	}
}

