using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;


namespace ADSAutomationPhaseII.TC_10549
{
    public class Steps
    {
    	public static TC10549 repo = TC10549.Instance; 
    	public static string TC1_10549_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10549_Path"].ToString();
    	
    	public static void ClickOnTools()
    	{
    		try 
    		{
    			repo.Application.ToolsInfo.WaitForItemExists(30000);
    			repo.Application.Tools.ClickThis();
    			Reports.ReportLog("ClickOnTools", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		}
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : ClickOnTools : " + ex.Message);   			
    		}
    	}  		
    		    	
    	public static void ClickOnObjectSearch()
    	{
    		try 
    		{
    			repo.DataStudio.ObjectSearchInfo.WaitForItemExists(30000);
    			repo.DataStudio.ObjectSearch.ClickThis();
    			Reports.ReportLog("ClickOnObjectSearch", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		}
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : ClickOnObjectSearch : " + ex.Message);
    		}
    	}
    	
    	public static void SelectAquaFold()
		  {
		     try 
		     {
		     	TreeItem SelectedServer = null ;
     			SelectServer(ref SelectedServer);
        		TreeItem aquafold = SelectedServer.GetItem(Config.AQUAFOLD);
        		aquafold.Select();
		        Reports.ReportLog("SelectAquaFold", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
		     } 
		     catch(Exception ex)
		     {
		     	if(repo.ChooseServer.SelfInfo.Exists(1000))repo.ChooseServer.Self.Close();
		     	throw new Exception("Failed : SelectAquaFold : " + ex.Message);	
		     }
    	}
    	
    	public static void SelectADSDb()
		  {
		     try 
		     {
		     	TreeItem SelectedServer = null ;
     			SelectServer(ref SelectedServer);
        		TreeItem adsDB = SelectedServer.GetItem(Config.ADSDB);
        		adsDB.Select();
		        Reports.ReportLog("SelectADSDb", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
		     } 
		     catch(Exception ex)
		     {
		     	if(repo.ChooseServer.SelfInfo.Exists(1000))repo.ChooseServer.Self.Close();
		     	throw new Exception("Failed : SelectADSDb : " + ex.Message);	
		     }
    	}
    	
    	public static void SelectADSDB()
		  {
		     try 
		     {
		     	TreeItem SelectedServer = null ;
		     	SelectServer(ref SelectedServer);
		     	TreeItem adsDB = SelectedServer.GetItem(Configuration.Config.ADSDB.ToUpper());
		        adsDB.Select();
		        Reports.ReportLog("SelectADSDB", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
		     } 
		     catch(Exception ex)
		     {
		     	if(repo.ChooseServer.SelfInfo.Exists(1000))repo.ChooseServer.Self.Close();
		     	throw new Exception("Failed : SelectADSDB : " + ex.Message);	
		     }
    	}
    	
    	public static void SelectServer(ref TreeItem item)
     	{
     		try 
     		{
     			TreeItem SelectedServer = repo.ChooseServer.ServerList.Items[0].Items[0].GetItem(Preconditions.Steps.SelectedServerName);
     			item = SelectedServer;
     			if(SelectedServer == null)
				{
					TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Configuration.Config.TestCaseName);
	        		SelectedServer = item = repo.ChooseServer.ServerList.Items[0].Items[0].GetItem(server.Text);
				}
     			ExplicitWait();
     			Reports.ReportLog("SelectServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
     		} 
     		catch(Exception ex)
     		{
     			if(repo.ChooseServer.SelfInfo.Exists(1000))repo.ChooseServer.Self.Close();
     			throw new Exception("Failed : SelectServer : " + ex.Message);
     		}
     	}
    	
    	public static void ClickOk()
    	{
    		try 
    		{
    			repo.ChooseServer.OkButtonInfo.WaitForExists(new Duration(20000));
    			repo.ChooseServer.OkButton.ClickThis();
    			Reports.ReportLog("ClickOk", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : ClickOk : " + ex.Message);    			
    		}
    	}
    	
    	public static void UnSelectDatabase()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.UnselectDatabaseInfo.WaitForExists(new Duration(20000));
    			repo.ObjectSearchWindow.UnselectDatabase.ClickThis();
    			Reports.ReportLog("UnSelectDatabase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : UnSelectDatabase : " + ex.Message);
    		}
    	}
    	
    	public static void UnSelectSchema()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.UnselectSchemaInfo.WaitForExists(new Duration(20000));
    			repo.ObjectSearchWindow.UnselectSchema.ClickThis();
    			Reports.ReportLog("UnSelectSchema", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : UnSelectSchema : " + ex.Message);
    		}
    	}
    	
    	public static void UnSelectObject()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.UnselectObjectInfo.WaitForExists(new Duration(20000));
    			repo.ObjectSearchWindow.UnselectObject.ClickThis();
    			Reports.ReportLog("UnSelectObject", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : UnSelectObject : " + ex.Message);
    		}
    	}
    	
    	public static void SelectDatabase()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.SelectDatabaseInfo.WaitForExists(new Duration(20000));
    			repo.ObjectSearchWindow.SelectDatabase.ClickThis();
    			Reports.ReportLog("SelectDatabase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : SelectDatabase : " + ex.Message);
    		}
    	}
    	
    	public static void SelectSchema()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.SelectSchemaInfo.WaitForExists(new Duration(20000));
    			repo.ObjectSearchWindow.SelectSchema.ClickThis();
    			Reports.ReportLog("SelectSchema", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : SelectSchema : " + ex.Message);
    		}
    	}
    	
    	public static void SelectObjectType()
    	{
    		try 
    		{ 
	        	foreach (var row in repo.ObjectSearchWindow.SelectObjectType.Rows) 
	        	{
	        		if(row.Cells[2].Text == "Tables")
	        		{
	        			row.Cells[1].ClickThis();
	        			break;
	        		}
	        	}
	        	Reports.ReportLog("SelectObjectType", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
        	}
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : SelectObjectType : " + ex.Message);
    		}
    	}
    	   	
    	public static void SelectColumnName()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.ColumnNameInfo.WaitForExists(new Duration(20000));
    			repo.ObjectSearchWindow.ColumnName.ClickThis();
    			Reports.ReportLog("SelectColumnName", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : SelectColumnName : " + ex.Message);
    		}
    	}
    	
    	public static void SelectViewSource()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.ViewSourceInfo.WaitForExists(new Duration(20000));
    			repo.ObjectSearchWindow.ViewSource.ClickThis();
    			Reports.ReportLog("SelectViewSource", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : SelectViewSource : " + ex.Message);
    		}
    	}
    	
    	public static void SearchText(string text)
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.SearchTextInfo.WaitForExists(new Duration(10000));
    			if(!repo.ObjectSearchWindow.SearchText.TextValue.IsEmpty())
    			{
	    			Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
    			}
    			repo.ObjectSearchWindow.SearchText.PressKeys(text);
    			Reports.ReportLog("SearchText", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : SearchText : " + ex.Message);
    		}
    	}
    	
    	public static void SearchButton()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.SearchButtonInfo.WaitForExists(new Duration(20000));
    			repo.ObjectSearchWindow.SearchButton.ClickThis();
    			Reports.ReportLog("SearchButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : SearchButton : " + ex.Message);
    		}
    	}
    	
    	public static void ValidateTable(int num)
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.ObjectSearchResultTableInfo.WaitForItemExists(30000);
    			if(repo.ObjectSearchWindow.ObjectSearchResultTable.Rows.Count > num)
    			{
    				string message = string.Format("Validate Search : {0} records found", repo.ObjectSearchWindow.ObjectSearchResultTable.Rows.Count); 
    				Validate.Exists(repo.ObjectSearchWindow.ObjectSearchResultTableInfo, message);
    			}
    			Reports.ReportLog("ValidateTable", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : ValidateTable : " + ex.Message);
    		}
    	}
    	
    	public static void AppendButton()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.AppendButtonInfo.WaitForItemExists(30000);
    			repo.ObjectSearchWindow.AppendButton.ClickThis();
    			Reports.ReportLog("AppendButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : AppendButton : " + ex.Message);
    		}
    	}

		public static void ObjectName()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.ObjectNameInfo.WaitForExists(new Duration(20000));
    			repo.ObjectSearchWindow.ObjectName.ClickThis();
    			Reports.ReportLog("ObjectName", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : ObjectName : " + ex.Message);
    		}
    	}
		
		public static void QuickFilter()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.QuickFilterInfo.WaitForExists(new Duration(20000));
    			repo.ObjectSearchWindow.QuickFilter.PressKeys("id");
    			Reports.ReportLog("QuickFilter", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : QuickFilter : " + ex.Message);
    		}
    	}
		
		public static void Close()
    	{
    		try 
    		{
    			repo.ObjectSearchWindow.CloseInfo.WaitForItemExists(20000);
    			repo.ObjectSearchWindow.Close.ClickThis();
    			Reports.ReportLog("Close", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : Close : " + ex.Message);
    		}
    	}
		
		public static void UnSelectViews()
		{
			try 
			{
				repo.ObjectSearchWindow.UnSelectViewsInfo.WaitForExists(new Duration(20000));
				repo.ObjectSearchWindow.UnSelectViews.ClickThis();
				Reports.ReportLog("UnSelectViews", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex) 
			{
				throw new Exception("Failed : UnSelectViews : " + ex.Message);				
			}
		}
		
		public static void ExplicitWait()
		{
			System.Threading.Thread.Sleep(1000);
		}
    }
}
