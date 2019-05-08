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
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10568
{

	public class Steps
	{
		public static TC10568 repo = TC10568.Instance; 
    	public static string TC1_10568_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10568_Path"].ToString();
    	
    	public static void ExpandDatabases()
    	{
    		try 
    		{
    			TreeItem dbTreeItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Databases");
    			Reports.ReportLog("ExpandDatabases", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    			
    			EditTableData(dbTreeItem, "ads_db", "public", "public.ads_table");
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ExpandDatabases : " + e.Message);
    		}
    	}
    	
    	public static void ExpandDatabases_Select()
    	{
    		try 
    		{
    			TreeItem dbTreeItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Databases");
    			Reports.ReportLog("ExpandDatabases", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    			
    			SelectDatabase(dbTreeItem, "ads_db", "public", "public.ads_table");
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ExpandDatabases_Select : " + e.Message);
    		}
    	}
    	
    	public static void EditTableData(TreeItem dbTreeItem,string db, string schema, string table)
    	{
    		try 
    		{
    			TreeItem item = dbTreeItem.GetItem(db);
    			TreeItem item1 = item.GetItem(schema);
    			TreeItem item2 = item1.GetItem("Tables");
    			TreeItem item3 = item2.GetItem(table);
    			item3.RightClickThis();
    			repo.Datastudio.EditTableInfo.WaitForItemExists(2000);
    			repo.Datastudio.EditTable.ClickThis();
    			Reports.ReportLog("EditTableData", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : EditTableData : " + e.Message);
    		}
    	}
    	
    	public static void SelectDatabase(TreeItem dbTreeItem, string db, string schema, string table)
    	{
    		try 
    		{
    			TreeItem item = dbTreeItem.GetItem(db);
    			TreeItem item1 = item.GetItem(schema);
    			TreeItem item2 = item1.GetItem("Tables");
    			TreeItem item3 = item2.GetItem(table);
    			item3.RightClickThis();
    			Preconditions.Steps.QueryAnalyser();
    			System.Threading.Thread.Sleep(2000);
    			Preconditions.Steps.WriteSelectTable();
    			System.Threading.Thread.Sleep(2000);
    			Keyboard.Press(Keyboard.ToKey("Ctrl+Alt+Enter"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
    			Reports.ReportLog("SelectDatabase", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			throw new Exception("Failed : SelectDatabase : " + e.Message);
    		}
    	}
    	
    	public static void VerifyTabledataTab()
    	{
    		try 
    		{
    			repo.AmazonRedshift.TableDataInfo.WaitForItemExists(2000);
    			if(repo.AmazonRedshift.TableData.Visible)
    			{
    				repo.AmazonRedshift.TableData.ClickThis();
    				Reports.ReportLog("TabledataTab is visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    			}
    			else
    			{
    				Reports.ReportLog("TabledataTab is not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
    			}
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : VerifyTabledataTab : " + e.Message);
    		}
    	}
    	
    	public static void VerifyPrimaryKeyTab()
    	{
    		try 
    		{
    			repo.AmazonRedshift.PrimaryKeyInfo.WaitForItemExists(2000);
    			if(repo.AmazonRedshift.PrimaryKey.Visible)
    			{
    				repo.AmazonRedshift.PrimaryKey.ClickThis();
    				Reports.ReportLog("PrimaryKeyTab is visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    			}
    			else
    			{
    				Reports.ReportLog("PrimaryKeyTab is not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
    			}
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : VerifyPrimaryKeyTab : " + e.Message);
    		}
    	}
    	
    	public static void VerifySqlPreviewTab()
    	{
    		try 
    		{
    			repo.AmazonRedshift.PreviewSQLInfo.WaitForItemExists(2000);
    			if(repo.AmazonRedshift.PreviewSQL.Visible)
    			{
    				repo.AmazonRedshift.PreviewSQL.ClickThis();
    				Reports.ReportLog("PreviewSQL is visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    			}
    			else
    			{
    				Reports.ReportLog("Preview is not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
    			}
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : VerifySqlPreviewTab : " + e.Message);
    		}
    	}
    	
    	public static void VerifyMessagesTab()
    	{
    		try 
    		{
    			repo.AmazonRedshift.MessagesInfo.WaitForItemExists(2000);
    			if(repo.AmazonRedshift.Messages.Visible)
    			{
    				repo.AmazonRedshift.Messages.ClickThis();
    				Reports.ReportLog("Messages is visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    			}
    			else
    			{
    				Reports.ReportLog("Messages is not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
    			}
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : VerifyMessagesTab : " + e.Message);
    		}
    	}
    	
    	public static void ClickOnClose()
    	{
    		try 
    		{
    			repo.AmazonRedshift.CloseInfo.WaitForItemExists(2000);
    			repo.AmazonRedshift.Close.ClickThis();
    			Reports.ReportLog("ClickOnClose", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnClose : " + e.Message);
    		}
    	}
	}
}
