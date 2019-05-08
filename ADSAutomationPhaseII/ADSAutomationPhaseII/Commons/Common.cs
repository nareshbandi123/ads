using System;
using System.IO;
using ADSAutomationPhaseII.Extensions;
using System.Configuration;

namespace ADSAutomationPhaseII.Commons
{
	public static class Common
	{	
		public static int ApplicationOpenWaitTime = 180000;
		
		public static void CreateFile(string filename)
        {
        	try 
        	{
	        	if(!System.IO.File.Exists(filename))
	        		System.IO.File.Create(filename);
        	} 
        	catch (Exception ex)
        	{
        		throw new Exception("Delete File Failed : "+ ex.Message);
        	}
        }
		
		public static void DeleteFile(string filename)
        {
        	try 
        	{
	        	if(System.IO.File.Exists(filename))
	        		System.IO.File.Delete(filename);
        	} 
        	catch (Exception ex)
        	{
        		throw new Exception("Delete File Failed : "+ ex.Message);
        	}
        }
		
		public static void DeleteFolder(string folderToDeletePath)
        {
        	try 
        	{
        		if(Directory.Exists(folderToDeletePath))
	        		Directory.Delete(folderToDeletePath, true);
        	} 
        	catch (Exception ex)
        	{
        		throw new Exception("Delete Folder Failed : " + ex.Message);
        	}
        }
	}
}


