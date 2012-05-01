using System;
using System.Collections.Generic;

namespace ColladaExporter
{
	public class SCFSpecification
	{
		public class SCFMainChunk
		{
			public SCFMainChunk()
			{
				mVersion = 1;
				mMagicNumber = 809911123; // SCF0
				mNoOfSubChunks = 1; // only geometry chunk for now
				mChunkId = 0;
			}
			
			public uint mVersion;
			public uint mMagicNumber;
			public uint mNoOfSubChunks;
			public uint mChunkId;
		}
		
		public class SCFGeometryChunk
		{
			public SCFGeometryChunk()
			{
				mChunkId = 1;
				mNoOfTriangleGroups = 0;
				mTotalNoOfTriangles = 0;
				mDataOffset = 0;
			}
			
			public uint mChunkId;
			public uint mNoOfTriangleGroups;
			public uint mTotalNoOfTriangles;
			public uint mDataOffset;
		}
		
		public class SCFHeader
		{
			public SCFHeader()
			{
				mMainChunk = new SCFMainChunk();
				mGeometryChunk = new SCFGeometryChunk();
			}
			
			public SCFMainChunk mMainChunk;
			public SCFGeometryChunk mGeometryChunk;
		}
		
		public class SCF
		{
			public SCF()
			{
				mHeader = new SCFHeader();
			}
			
			public SCFHeader mHeader;
		}
	}
	
	public class GeometryLibrary
	{
		public GeometryLibrary() 
		{
			mGeometries = new List<Geometry>();
		}
		
		public List<Geometry> mGeometries;
	}
	
	public class Geometry
	{
		public Geometry()
		{
			mMeshes = new List<Mesh>();
		}
		
		public List<Mesh> mMeshes;
	}
	
	public class Mesh
	{
		public Mesh()
		{
			mSources = new List<Source>();
			mTriangles = new List<Triangles>();
			mVertices = new Vertices();
		}
		
		public List<Source> mSources;
		public List<Triangles> mTriangles;
		public Vertices mVertices;
	}
	
	public class Source
	{
		public Source()
		{
			mSourceId = "";
			mFloatArray = new FloatArray();
			mTechniqueCommon = new TechniqueCommon();
		}
		
		public String mSourceId;
		public FloatArray mFloatArray;
		public TechniqueCommon mTechniqueCommon;
	}
	
	public class Vertices
	{
		public Vertices()
		{
			mVerticesId = "";
			mInputSemantic = "";
			mInputSource = "";
		}
		
		public String mVerticesId;
		public String mInputSemantic;
		public String mInputSource;
	}
	
	public class Triangles
	{
		public Triangles()
		{
			mCount = 0;
			mMaterial = "";
			mTriangleInputs = new List<TrianglesInput>();
			mTrianglesP = new TrianglesP();
		}
		
		public uint mCount;
		public String mMaterial;
		public List<TrianglesInput> mTriangleInputs;
		public TrianglesP mTrianglesP;
	}
	
	public class FloatArray
	{
		public FloatArray()
		{
			mCount = 0;
			mFloatArrayId = "";
			mFloats = new List<float>();
		}
		
		public uint mCount;
		public String mFloatArrayId;
		public List<float> mFloats;
	}
	
	public class TechniqueCommon
	{
		public TechniqueCommon()
		{
			mAccessor = new Accessor();
		}
		
		public Accessor mAccessor;
	}
	
	public class TrianglesInput
	{
		public TrianglesInput()
		{
			mOffset = 0;
			mSemantic = "";
			mSource = "";
		}
		
		public uint mOffset;
		public String mSemantic;
		public String mSource;
	}
	
	public class TrianglesP
	{
		public TrianglesP()
		{
			mIndices = new List<uint>();
		}
		
		public List<uint> mIndices;
	}
	
	public class Accessor
	{
		public Accessor()
		{
			mCount = 0;
			mStride = 0;
			mSource = "";
			mParams = new List<Param>();
		}
		
		public uint mCount;
		public uint mStride;
		public String mSource;
		public List<Param> mParams;
	}
	
	public class Param
	{
		public Param()
		{
			mName = "";
			mType = "";
		}
		
		public String mName;
		public String mType;
	}
}

