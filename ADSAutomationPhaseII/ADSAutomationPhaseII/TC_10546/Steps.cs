using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.TC_10546.TC1;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10546
{
    public static class Steps
    {
		public static TC10546Repo repo = TC10546Repo.Instance;
		
    	public static string TC1_10546_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10546_Path"].ToString();

		public static void ClickOnTools()
    	{
    		try 
    		{
    			repo.Application.ToolsInfo.WaitForItemExists(2000);
    			repo.Application.Tools.ClickThis();
    			Reports.ReportLog("ClickOnTools", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnTools : " + e.Message);
    		}
    	}

		public static void ClickOnCompareTools()
    	{
    		try 
    		{
    			repo.Datastudio.CompareToolsInfo.WaitForItemExists(2000);
    			repo.Datastudio.CompareTools.ClickThis();
    			Reports.ReportLog("ClickOnCompareTools", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnCompareTools : " + e.Message);
    		}
    	}
		
		public static void ClickOnSchemaSynchronization()
    	{
    		try 
    		{
    			repo.Datastudio.SchemaSynchonizationInfo.WaitForItemExists(2000);
    			repo.Datastudio.SchemaSynchonization.ClickThis();
    			Reports.ReportLog("ClickOnSchemaSynchronization", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnSchemaSynchronization : " + e.Message);
    		}
    	}
		
		public static void ClickOnSourceChooseServer()
    	{
    		try 
    		{
    			repo.SchemaSynchronization.ChooseSourceServerInfo.WaitForItemExists(2000);
    			repo.SchemaSynchronization.ChooseSourceServer.ClickThis();
    			Reports.ReportLog("ClickOnSourceChooseServer", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnSourceChooseServer : " + e.Message);
    		}
    	} 
		
		public static void SelectServer(ref TreeItem item, string serverName)
     	{
     		try 
     		{
     			TreeItem SelectedServer = repo.ChooseServer.SelectServer.Items[0].Items[0].GetItem(serverName.Replace('_',' '), true);
     			item = SelectedServer;
     			if(SelectedServer == null)
				{
					TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(serverName);
	        		Preconditions.Steps.SelectedServerTreeItem = server;
	        		Preconditions.Steps.SelectedServerName = server.Text;
	        		SelectedServer = item = repo.ChooseServer.SelectServer.Items[0].Items[0].GetItem(server.Text);
				}
     		} 
     		catch (Exception e)
     		{
     			throw new Exception("Failed : SelectServer : " + e.Message);
     		}
     	}
     	
     	public static void SelectADSDb(string serverName)
     	{
     		try 
     		{    			
     			TreeItem SelectedServer = null ;
     			SelectServer(ref SelectedServer, serverName);
        		TreeItem adsDB = SelectedServer.GetItem(Configuration.Config.ADSDB, false);
        		adsDB.Select();
     		} 
     		catch (Exception e)
     		{
     			throw new Exception("Failed : SelectADSDb : " + e.Message);
     		}
     	}

		public static void SelectADSDB(string serverName)
		  {
		     try 
		     {
		     	TreeItem SelectedServer = null ;
		     	SelectServer(ref SelectedServer, serverName);
		     	TreeItem adsDB = SelectedServer.GetItem(Configuration.Config.ADSDB.ToUpper(), false);
		        adsDB.Select();
		     } 
		     catch (Exception e)
		     {
		     	throw new Exception("Failed : SelectADSDB : " + e.Message);
		     }
		   } 
		
		public static void ClickOnTargetChooseServer()
    	{
    		try 
    		{
    			repo.SchemaSynchronization.ChooseTargetServerInfo.WaitForItemExists(2000);
    			repo.SchemaSynchronization.ChooseTargetServer.ClickThis();
    			Reports.ReportLog("ClickOnTargetChooseServer", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnTargetChooseServer : " + e.Message);
    		}
    	}
		
		public static void ClickOnOk()
    	{
    		try 
    		{
    			repo.ChooseServer.OkButtonInfo.WaitForItemExists(2000);
    			repo.ChooseServer.OkButton.ClickThis();
    			Reports.ReportLog("ClickOnOk", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnOk : " + e.Message);
    		}
    	}
		
		public static void SetSchema()
     	{
     		try 
     		{
     			repo.SchemaSynchronization.TargetSchemaComboBox.TextBoxText(repo.SchemaSynchronization.SourceSchemaComboBox.TextValue);
     			Reports.ReportLog("SetSchema", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
     		} 
     		catch (Exception e) 
     		{
     		throw new Exception("Failed : SetSchema : " + e.Message);
     		}
     	}
		
		public static void ClickOnUnselectSchemaObjects()
    	{
    		try 
    		{
    			repo.SchemaSynchronization.UnselectSchemaObjectInfo.WaitForItemExists(2000);
    			repo.SchemaSynchronization.UnselectSchemaObject.ClickThis();
    			Reports.ReportLog("ClickOnUnselectSchemaObjects", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnUnselectSchemaObjects : " + e.Message);
    		}
    	}
		
		public static void ScanForTables()
        {    
            try
            {
            	Table table = repo.SchemaSynchronization.SchemaObjectsTable;
                CheckUnselected(table);
                foreach (var row in table.Rows) 
                {
                    if(row.Cells[2].Text.ToLower() == "tables" && row.Cells[1].Text == "false")
                    {
                    	row.Cells[1].ClickThis();
                        break;
                    }                    
                }
                Reports.ReportLog("ScanForTables", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
            } 
            catch (Exception e)
            {
                throw new Exception("Failed : ScanForTables : " + e.Message);
            }
        }
		
		public static void CheckUnselected(Table table)
        {
            try
            {
                foreach (var row in table.Rows) 
                {
                    if(row.Cells[1].Text == "true" || row.Cells[1].Text == "True")
                    {
                    	row.Cells[1].ClickThis();
                        break;
                    }
                }
                Reports.ReportLog("CheckUnselected", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
            } 
            catch (Exception e)
            {
                throw new Exception("Failed : CheckUnselected : " + e.Message);
            }
        }
		
		public static void ClickOnUnselectLeftObjects()
    	{
    		try 
    		{
    			repo.SchemaSynchronization.UnselectLeftObjectsInfo.WaitForItemExists(2000);
    			repo.SchemaSynchronization.UnselectLeftObjects.ClickThis();
    			Reports.ReportLog("ClickOnUnselectLeftObjects", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnUnselectLeftObjects : " + e.Message);
    		}
    	}
		
		public static void ClickOnUnselectRightObjects()
    	{
    		try 
    		{
    			repo.SchemaSynchronization.UnselectRightObjectsInfo.WaitForItemExists(2000);
    			repo.SchemaSynchronization.UnselectRightObjects.ClickThis();
    			Reports.ReportLog("ClickOnUnselectRightObjects", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnUnselectRightObjects : " + e.Message);
    		}
    	}
		
		public static void SelectLeftObjects()
    	{
    		try 
    		{
    			repo.SchemaSynchronization.SelectLeftObjectsInfo.WaitForItemExists(2000);
    			repo.SchemaSynchronization.SelectLeftObjects.ClickThis();
    			Reports.ReportLog("SelectLeftObjects", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : SelectLeftObjects : " + e.Message);
    		}
    	}
		
		public static void SelecRightObjects()
    	{
    		try 
    		{
    			repo.SchemaSynchronization.SelectRightObjectsInfo.WaitForItemExists(2000);
    			repo.SchemaSynchronization.SelectRightObjects.ClickThis();
    			Reports.ReportLog("SelecRightObjects", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : SelecRightObjects : " + e.Message);
    		}
    	}
		
		public static void ClickOnCompare()
    	{
    		try 
    		{
    			repo.SchemaSynchronization.CompareButtonInfo.WaitForItemExists(2000);
    			repo.SchemaSynchronization.CompareButton.ClickThis();
    			Reports.ReportLog("ClickOnCompare", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnCompare : " + e.Message);
    		}
    	}
		
		public static void ClickOnTable()
    	{
    		try 
    		{
    			repo.Application.TableInfo.WaitForItemExists(200000);
    			repo.Application.Table.ClickThis();
    			Reports.ReportLog("ClickOnTable", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnTable : " + e.Message);
    		}
    	}
		
		public static void ClickOnSyncCell()
    	{
    		try 
    		{
    			repo.Application.SyncCheckboxInfo.WaitForItemExists(200000);
    			repo.Application.SyncCheckbox.ClickThis();
    			Reports.ReportLog("ClickOnSyncCell", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnSyncCell : " + e.Message);
    		}
    	}
		
		public static void ClickOnSchemaSynchronize()
    	{
    		try 
    		{
    			repo.Application.SchemaSynchronizeInfo.WaitForItemExists(2000);
    			repo.Application.SchemaSynchronize.ClickThis();
    			Reports.ReportLog("ClickOnSchemaSynchronize", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnSchemaSynchronize : " + e.Message);
    		}
    	}
		
		public static void ValidateAllTabs()
    	{
    		try 
    		{
    			repo.Application.PreviousButtonInfo.WaitForItemExists(20000);
    			repo.Application.PreviousButton.ClickThis();
    			
    			repo.Application.ReviewDependencyTabInfo.WaitForItemExists(20000);
    			if(repo.Application.ReviewDependencyTab.Visible)
    			{
    				Reports.ReportLog("Validation : ReviewDependencyTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    			}
    			else
    			{
    				Reports.ReportLog("Validation : ReviewDependencyTab", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
    			}
    			    			
    			repo.Application.NextButtonInfo.WaitForItemExists(20000);
    			repo.Application.NextButton.ClickThis();
    			    			
    			repo.Application.MapMissingColumnTabInfo.WaitForItemExists(20000);
    			if(repo.Application.MapMissingColumnTab.Visible)
    			{
    				Reports.ReportLog("Validation : MapMissingColumnTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    			}
    			else
    			{
    				Reports.ReportLog("Validation : MapMissingColumnTab", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
    			}
    			
    			repo.Application.ConfigureScriptTabInfo.WaitForItemExists(20000);
    			if(repo.Application.ConfigureScriptTab.Visible)
    			{
    				Reports.ReportLog("Validation : ConfigureScriptTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    			}
    			else
    			{
    				Reports.ReportLog("Validation : ConfigureScriptTab", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
    			}
    			
    			repo.Application.NextButtonInfo.WaitForItemExists(20000);
    			repo.Application.NextButton.ClickThis();
    			
    			repo.Application.OptionsTabInfo.WaitForItemExists(20000);
    			if(repo.Application.OptionsTab.Visible)
    			{
    				Reports.ReportLog("Validation : Options", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    			}
    			else
    			{
    				Reports.ReportLog("Validation : Options", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
    			}
    			
    			repo.Application.NextButtonInfo.WaitForItemExists(20000);
    			repo.Application.NextButton.ClickThis();
    			
    			repo.Application.ReviewTabInfo.WaitForItemExists(20000);
    			if(repo.Application.ReviewTab.Visible)
    			{
    				Reports.ReportLog("Validation : ReviewTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    			}
    			else
    			{
    				Reports.ReportLog("Validation : ReviewTab", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
    			}
    			
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ValidateAllTabs : " + e.Message);
    		}
    	}
		
		public static void ClickOnNextButton()
    	{
    		try 
    		{
    			repo.Application.NextButtonInfo.WaitForItemExists(2000);
    			repo.Application.NextButton.ClickThis();
    			Reports.ReportLog("ClickOnNextButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception e) 
    		{
    			
    			throw new Exception("Failed : ClickOnNextButton : " + e.Message);
    		}
    	}
    }
}
