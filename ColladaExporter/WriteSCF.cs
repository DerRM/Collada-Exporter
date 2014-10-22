using System;
using System.IO;

namespace ColladaExporter
{
	public class WriteSCF
	{
		public static BinaryWriter mBinaryWriter;
		public static FileStream mFileStream;
		
		public static void OpenFile(String fileName)
		{
			mFileStream = File.Create(fileName);
			mBinaryWriter = new BinaryWriter(mFileStream);
		}
		
		public static void Write(Byte buffer)
		{
			mBinaryWriter.Write(buffer);
		}
		
		public static void Write(Single buffer)
		{
			mBinaryWriter.Write(buffer);
		}
		
		public static void Write(int buffer)
		{
			mBinaryWriter.Write(buffer);
		}
		
		public static void Write(uint buffer)
		{
			mBinaryWriter.Write(buffer);
		}
		
		public static void Write(ushort buffer)
		{
			mBinaryWriter.Write(buffer);
		}
		
		public static void Write(char[] buffer)
		{
			mBinaryWriter.Write(buffer);
		}
		
		public static void Write(String buffer)
		{
			mBinaryWriter.Write(buffer.ToCharArray());
			mBinaryWriter.Write('\0');
		}
		
		public static void CloseFile()
		{
			mBinaryWriter.Close();
			mFileStream.Close();
		}
	}
}

