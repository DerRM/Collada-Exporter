using System;
using System.Xml;
using System.IO;

namespace ColladaExporter
{
	public class ColladaParser
	{
		public const String LIBRARY_GEOMETRIES = "library_geometries";
		
		private String parseOutput;
		
		public ColladaParser (String path)
		{	
			parseOutput = "";
			
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(path);
			
			XmlElement RootElement = xmlDoc.DocumentElement;
			
			for (int i = 0; i < RootElement.ChildNodes.Count; i++) 
			{
				XmlNode ChildNode = RootElement.ChildNodes[i];
				String Name = ChildNode.Name.ToString();
				parseOutput += Name + "\n";
				Parse(ChildNode);
			}
		}
		
		public String GetParseOutput()
		{
			return parseOutput;
		}
		
		private void Parse(XmlNode Node)
		{
			if (Node == null)
			{
				return;
			}
			
			for (int j = 0; j < Node.ChildNodes.Count; j++)
			{
				XmlNode ChildNode = Node.ChildNodes[j];
				parseOutput += "\t" + ChildNode.Name + "\n";
				Parse(ChildNode);
			}
		}
	}
}

