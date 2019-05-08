using System;
using System.Drawing;
using System.Text;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10538;
using Ranorex.Core;
using Ranorex;
using System.Collections.Generic;

namespace ADSAutomationPhaseII.TC_10567
{
	public static class Steps
	{
		public static TC10567Repo repo = TC10567Repo.Instance;
		public static List<string> databasesTree = new List<string>() { "Databases", "Keyspaces", "Schema" };
		public static List<string> schemaTree = new List<string>() { "public" };
		public static List<string> tableTree = new List<string>() { "Tables" };
		public static List<string> viewTree = new List<string>() { "Views" };
		public static string TC_10567_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10567"].ToString();
		
		#region "TC1 STEPS"
		
		public static void SelectSchemaScriptGenerator()
		{
			try
			{
				TreeItem dbItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = dbItem.GetItem(Config.ADSDB, false);
				adsdbItem.RightClick();
				
				repo.DataStudio.ToolsMenuInfo.WaitForItemExists(1000);
				repo.DataStudio.ToolsMenu.ClickThis();
				
				repo.DataStudio.SchemaScriptGenMenuInfo.WaitForItemExists(30000);
				repo.DataStudio.SchemaScriptGenMenu.ClickThis();
				
				Reports.ReportLog("SelectSchemaScriptGenerator", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSchemaScriptGenerator : " + ex.Message);
			}
		}
		
		public static void ConfigureGeneralTab()
		{
			try
			{
				ScanForTables();
				ScanForADSTable();
				ClickOnNext();
				Reports.ReportLog("ConfigureGeneralTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureGeneralTab : " + ex.Message);
			}
		}
		
		public static void ConfigureOptionsTab_Preview()
		{
			try
			{
				SelectSaveAsCombo(2);
				SelectSeperatorCombo(2);
				SelectQuotedCombo(1);
				DeselectAllCheckBox();
				SelectRequiredCheckBox();
				ClickOnNext();
				System.Threading.Thread.Sleep(5000);
				ClickOnPrevious();
				ClickOnPrevious();
				ConfigureOptionsTab_SaveFile();
				Reports.ReportLog("ConfigureOptionsTab_Preview", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureOptionsTab_Preview : " + ex.Message);
			}
		}
		
		public static void ConfigureOptionsTab_SaveFile()
		{
			try
			{
				SelectSaveAsCombo(0);
				EnterSaveFilePath();
				ClickOnNext();
				System.Threading.Thread.Sleep(2000);
				ClickOnClose();
				Reports.ReportLog("ConfigureOptionsTab_SaveFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureOptionsTab_SaveFile : " + ex.Message);
			}
		}
		
		public static void ClickOnNext()
		{
			try
			{
				repo.SchemaScriptGenWindow.NextButtonInfo.WaitForItemExists(10000);
				repo.SchemaScriptGenWindow.NextButton.ClickThis();
				Reports.ReportLog("ClickOnNext", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.SchemaScriptGenWindow.SelfInfo.Exists(3000))repo.SchemaScriptGenWindow.Self.Close();
				throw new Exception("Failed : ClickOnNext : " + ex.Message);
			}
		}
		
		public static void ClickOnPrevious()
		{
			try
			{
				repo.SchemaScriptGenWindow.PreviousButtonInfo.WaitForItemExists(10000);
				repo.SchemaScriptGenWindow.PreviousButton.ClickThis();
				Reports.ReportLog("ClickOnPrevious", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnPrevious : " + ex.Message);
			}
		}
		
		public static void ClickOnClose()
		{
			try
			{
				repo.SchemaScriptGenWindow.CloseButtonInfo.WaitForItemExists(10000);
				repo.SchemaScriptGenWindow.CloseButton.ClickThis();
				Reports.ReportLog("ClickOnClose", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnClose : " + ex.Message);
			}
		}
		
		public static void SelectSaveAsCombo(int index)
		{
			try
			{
				repo.SchemaScriptGenWindow.SaveAsComboboxInfo.WaitForItemExists(10000);
				repo.SchemaScriptGenWindow.SaveAsCombobox.SelectedItemIndex = index;
				Reports.ReportLog("SelectSaveAsCombo", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSaveAsCombo : " + ex.Message);
			}
		}
		
		public static void EnterSaveFilePath()
		{
			try
			{
				string serverName = Preconditions.Steps.GetServerFromTCName(Config.TestCaseName);
				string filePath = string.Format("{0}{1}.txt", TC_10567_PATH, serverName);
				Common.DeleteFile(filePath);
				repo.SchemaScriptGenWindow.SaveFilePathTextboxInfo.WaitForItemExists(10000);
				repo.SchemaScriptGenWindow.SaveFilePathTextbox.TextBoxText(filePath);
				Reports.ReportLog("EnterSaveFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterSaveFilePath : " + ex.Message);
			}
		}
		
		public static void SelectSeperatorCombo(int index)
		{
			try
			{
				repo.SchemaScriptGenWindow.SeperatorComboboxInfo.WaitForItemExists(10000);
				repo.SchemaScriptGenWindow.SeperatorCombobox.SelectedItemIndex = index;
				Reports.ReportLog("SelectSeperatorCombo", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSeperatorCombo : " + ex.Message);
			}
		}
		
		public static void SelectQuotedCombo(int index)
		{
			try
			{
				repo.SchemaScriptGenWindow.QuotedComboboxInfo.WaitForItemExists(10000);
				repo.SchemaScriptGenWindow.QuotedCombobox.SelectedItemIndex = index;
				Reports.ReportLog("SelectQuotedCombo", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectQuotedCombo : " + ex.Message);
			}
		}
		
		public static void DeselectAllCheckBox()
		{
			try
			{
				repo.SchemaScriptGenWindow.CheckBoxContainerInfo.WaitForItemExists(10000);
				var collection = repo.SchemaScriptGenWindow.CheckBoxContainer.FindChildren<Ranorex.CheckBox>();
				foreach (var item in collection)
					item.Checked = false;
				
				Reports.ReportLog("DeselectAllCheckBox", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeselectAllCheckBox : " + ex.Message);
			}
		}
		
		public static void SelectRequiredCheckBox()
		{
			try
			{
				List<string> checkboxToCheck = new List<string> {"Generate the CREATE","Generate the DROP","Include INSERT statements for Table data"};
				repo.SchemaScriptGenWindow.CheckBoxContainerInfo.WaitForItemExists(10000);
				var collection = repo.SchemaScriptGenWindow.CheckBoxContainer.FindChildren<Ranorex.CheckBox>();
				foreach (var item in collection)
				{
					if(checkboxToCheck.Contains(item.Text))
						item.Checked = true;
				}
				Reports.ReportLog("SelectRequiredCheckBox", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectRequiredCheckBox : " + ex.Message);
			}
		}
		
		public static void ScanForTables()
		{
			try
			{
				repo.SchemaScriptGenWindow.LeftTableInfo.WaitForItemExists(10000);
				Table table = repo.SchemaScriptGenWindow.LeftTable;
				repo.SchemaScriptGenWindow.UnselectLeft.ClickThis();
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
			catch (Exception ex)
			{
				if(repo.SchemaScriptGenWindow.SelfInfo.Exists(3000))repo.SchemaScriptGenWindow.Self.Close();
				throw new Exception("Failed : ScanForTables :" + ex.Message);
			}
		}
		
		public static void ScanForADSTable()
		{
			try
			{
				repo.SchemaScriptGenWindow.RightTableInfo.WaitForItemExists(10000);
				Table table = repo.SchemaScriptGenWindow.RightTable;
				repo.SchemaScriptGenWindow.UnselectRight.ClickThis();
				foreach (var row in table.Rows)
				{
					if(row.Cells[3].Text.ToLower() == "ads_table" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForADSTable", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.SchemaScriptGenWindow.SelfInfo.Exists(3000))repo.SchemaScriptGenWindow.Self.Close();
				throw new Exception("Failed : ScanForTables :" + ex.Message);
			}
		}
		
		public static void ClickOnTool()
		{
			try
			{
				repo.Application.ToolsInfo.WaitForItemExists(1000);
				repo.Application.Tools.ClickThis();
				Reports.ReportLog("ClickOnTool", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnTool : " + ex.Message);
			}
		}
		
		public static void SelectSchemaScriptGen()
		{
			try
			{
				repo.DataStudio.SchemaScriptGenMenuInfo.WaitForItemExists(1000);
				repo.DataStudio.SchemaScriptGenMenu.ClickThis();
				Reports.ReportLog("SelectSchemaScriptGen", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSchemaScriptGen : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC2 STEPS"
		
		public static void ConfigureGeneralTab_View()
		{
			try
			{
				ScanForViews();
				ScanForADSView();
				ClickOnNext();
				Reports.ReportLog("ConfigureGeneralTab_View", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureGeneralTab_View : " + ex.Message);
			}
		}
		
		public static void SelectSchemaScriptGenerator_View()
		{
			try
			{
				TreeItem dbItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = dbItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem(schemaTree[0]);
				TreeItem viewItem = publicItem.GetItem(viewTree[0]);
				TreeItem adsviewItem = viewItem.GetItem("public.ads_view");
				adsviewItem.RightClick();
				
				repo.DataStudio.ToolsMenuInfo.WaitForItemExists(1000);
				repo.DataStudio.ToolsMenu.ClickThis();
				
				repo.DataStudio.SchemaScriptGenMenuInfo.WaitForItemExists(30000);
				repo.DataStudio.SchemaScriptGenMenu.ClickThis();
				
				Reports.ReportLog("SelectSchemaScriptGenerator_View", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSchemaScriptGenerator_View : " + ex.Message);
			}
		}
		
		public static void ScanForViews()
		{
			try
			{
				repo.SchemaScriptGenWindow.LeftTableInfo.WaitForItemExists(10000);
				Table table = repo.SchemaScriptGenWindow.LeftTable;
				repo.SchemaScriptGenWindow.UnselectLeft.ClickThis();
				foreach (var row in table.Rows)
				{
					if(row.Cells[2].Text.ToLower() == "views" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForViews", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForViews :" + ex.Message);
			}
		}
		
		public static void ScanForADSView()
		{
			try
			{
				repo.SchemaScriptGenWindow.RightTableInfo.WaitForItemExists(10000);
				Table table = repo.SchemaScriptGenWindow.RightTable;
				repo.SchemaScriptGenWindow.UnselectRight.ClickThis();
				foreach (var row in table.Rows)
				{
					if(row.Cells[3].Text.ToLower() == "ads_view" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForADSView", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForADSView :" + ex.Message);
			}
		}
		
		public static void ConfigureOptionsTab_Preview_View()
		{
			try
			{
				SelectSaveAsCombo(2);
				SelectSeperatorCombo(2);
				SelectQuotedCombo(1);
				DeselectAllCheckBox();
				SelectRequiredCheckBox_View();
				ClickOnNext();
				System.Threading.Thread.Sleep(5000);
				ClickOnPrevious();
				ClickOnPrevious();
				ConfigureOptionsTab_SaveFile();
				Reports.ReportLog("ConfigureOptionsTab_Preview_View", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureOptionsTab_Preview_View : " + ex.Message);
			}
		}
		
		public static void ConfigureOptionsTab_SaveFile_View()
		{
			try
			{
				SelectSaveAsCombo(0);
				EnterSaveFilePath();
				ClickOnNext();
				System.Threading.Thread.Sleep(2000);
				ClickOnClose();
				Reports.ReportLog("ConfigureOptionsTab_SaveFile_View", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureOptionsTab_SaveFile_View : " + ex.Message);
			}
		}
		
		public static void SelectRequiredCheckBox_View()
		{
			try
			{
				List<string> checkboxToCheck = new List<string> {"Generate the CREATE","Generate the DROP"};
				repo.SchemaScriptGenWindow.CheckBoxContainerInfo.WaitForItemExists(1000);
				var collection = repo.SchemaScriptGenWindow.CheckBoxContainer.FindChildren<Ranorex.CheckBox>();
				foreach (var item in collection)
				{
					if(checkboxToCheck.Contains(item.Text))
						item.Checked = true;
				}
				Reports.ReportLog("SelectRequiredCheckBox_View", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectRequiredCheckBox_View : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC3 STEPS"
		
		public static void SelectSchemaScriptGenerator_TC3()
		{
			try
			{
				TreeItem dbItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				TreeItem adsdbItem = dbItem.GetItem(Config.ADSDB_CAPS, false);
				adsdbItem.RightClick();
				
				repo.DataStudio.ToolsMenuInfo.WaitForItemExists(1000);
				repo.DataStudio.ToolsMenu.ClickThis();
				
				repo.DataStudio.SchemaScriptGenMenuInfo.WaitForItemExists(30000);
				repo.DataStudio.SchemaScriptGenMenu.ClickThis();
				
				Reports.ReportLog("SelectSchemaScriptGenerator_TC3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSchemaScriptGenerator_TC3 : " + ex.Message);
			}
		}
		
		public static void ConfigureGeneralTab_TC3()
		{
			try
			{
				ScanForProcedures();
				ScanForADSProcedure();
				ClickOnNext();
				Reports.ReportLog("ConfigureGeneralTab_TC3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureGeneralTab_TC3 : " + ex.Message);
			}
		}
		
		public static void ConfigureOptionsTab_Preview_TC3()
		{
			try
			{
				SelectSaveAsCombo(2);
				SelectSeperatorCombo(2);
				SelectQuotedCombo(1);
				DeselectAllCheckBox();
				SelectRequiredCheckBox_View();
				ClickOnNext();
				System.Threading.Thread.Sleep(5000);
				ClickOnPrevious();
				ClickOnPrevious();
				ConfigureOptionsTab_SaveFile();
				Reports.ReportLog("ConfigureOptionsTab_Preview_TC3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureOptionsTab_Preview_TC3 : " + ex.Message);
			}
		}
		
		public static void ScanForProcedures()
		{
			try
			{
				repo.SchemaScriptGenWindow.LeftTableInfo.WaitForItemExists(10000);
				Table table = repo.SchemaScriptGenWindow.LeftTable;
				repo.SchemaScriptGenWindow.UnselectLeft.ClickThis();
				foreach (var row in table.Rows)
				{
					if(row.Cells[2].Text.ToLower() == "procedures" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForProcedures", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForProcedures :" + ex.Message);
			}
		}
		
		public static void ScanForADSProcedure()
		{
			try
			{
				repo.SchemaScriptGenWindow.RightTableInfo.WaitForItemExists(10000);
				Table table = repo.SchemaScriptGenWindow.RightTable;
				repo.SchemaScriptGenWindow.UnselectRight.ClickThis();
				foreach (var row in table.Rows)
				{
					if(row.Cells[3].Text.ToLower() == "ads_procedure" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForADSProcedure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForADSProcedure :" + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC4 STEPS"
		
		public static void ConfigureGeneralTab_TC4()
		{
			try
			{
				ScanForFunctions();
				ScanForADSFunction();
				ClickOnNext();
				Reports.ReportLog("ConfigureGeneralTab_TC4", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureGeneralTab_TC4 : " + ex.Message);
			}
		}
		
		public static void ScanForFunctions()
		{
			try
			{
				repo.SchemaScriptGenWindow.LeftTableInfo.WaitForItemExists(10000);
				Table table = repo.SchemaScriptGenWindow.LeftTable;
				repo.SchemaScriptGenWindow.UnselectLeft.ClickThis();
				foreach (var row in table.Rows)
				{
					if(row.Cells[2].Text.ToLower() == "functions" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForProcedures", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForProcedures :" + ex.Message);
			}
		}
		
		public static void ScanForADSFunction()
		{
			try
			{
				repo.SchemaScriptGenWindow.RightTableInfo.WaitForItemExists(10000);
				Table table = repo.SchemaScriptGenWindow.RightTable;
				repo.SchemaScriptGenWindow.UnselectRight.ClickThis();
				foreach (var row in table.Rows)
				{
					if(row.Cells[3].Text.ToLower() == "ads_function" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForADSProcedure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForADSProcedure :" + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC5 STEPS"
		
		public static void ConfigureGeneralTab_TC5()
		{
			try
			{
				ScanForTriggers();
				ScanForADSTrigger();
				ClickOnNext();
				Reports.ReportLog("ConfigureGeneralTab_TC5", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureGeneralTab_TC5 : " + ex.Message);
			}
		}
		
		public static void ScanForTriggers()
		{
			try
			{
				repo.SchemaScriptGenWindow.LeftTableInfo.WaitForItemExists(10000);
				Table table = repo.SchemaScriptGenWindow.LeftTable;
				repo.SchemaScriptGenWindow.UnselectLeft.ClickThis();
				foreach (var row in table.Rows)
				{
					if(row.Cells[2].Text.ToLower() == "triggers" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForTriggers", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForTriggers :" + ex.Message);
			}
		}
		
		public static void ScanForADSTrigger()
		{
			try
			{
				repo.SchemaScriptGenWindow.RightTableInfo.WaitForItemExists(10000);
				Table table = repo.SchemaScriptGenWindow.RightTable;
				repo.SchemaScriptGenWindow.UnselectRight.ClickThis();
				foreach (var row in table.Rows)
				{
					if(row.Cells[3].Text.ToLower() == "ads_trigger" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForADSTrigger", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForADSTrigger :" + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC6 STEPS"
		public static void ConfigureGeneralTab_TC6()
		{
			try
			{
				ScanForDatabases();
				ScanForADSDB_TC6();
				ClickOnNext_TC6();
				System.Threading.Thread.Sleep(500);
				Reports.ReportLog("ConfigureGeneralTab_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureGeneralTab_TC6 : " + ex.Message);
			}
		}
		
		public static void SelectSchemaScriptGenerator_TC6()
		{
			try
			{
				TreeItem dbItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = dbItem.GetItem(Config.ADSDB, false);
				adsdbItem.RightClick();
				
				repo.DataStudio.ToolsMenuInfo.WaitForItemExists(10000);
				repo.DataStudio.ToolsMenu.ClickThis();
				
				repo.SunAwtWindow.ServerScriptGenMenuInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ServerScriptGenMenu.ClickThis();
				
				Reports.ReportLog("SelectSchemaScriptGenerator_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSchemaScriptGenerator_TC6 : " + ex.Message);
			}
		}
		
		public static void SelectServerScriptGen()
		{
			try
			{
				repo.SunAwtWindowToolsMenu.ServerScriptGenInfo.WaitForItemExists(100000);
				repo.SunAwtWindowToolsMenu.ServerScriptGen.ClickThis();
				Reports.ReportLog("SelectServerScriptGen", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectServerScriptGen : " + ex.Message);
			}
		}
		
		public static void ScanForDatabases()
		{
			try
			{
				repo.ServerScriptGenWindow.LeftTableInfo.WaitForItemExists(10000);
				Table table = repo.ServerScriptGenWindow.LeftTable;
				repo.ServerScriptGenWindow.UnselectLeft.ClickThis();
				UnSelectAll(table);
				foreach (var row in table.Rows)
				{
					if(row.Cells[2].Text.ToLower() == "databases" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForDatabases", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForDatabases :" + ex.Message);
			}
		}
		
		public static void UnSelectAll(Table table)
		{
			try
			{
				foreach (var row in table.Rows)
				{
					if(row.Cells[1].Text == "true") row.Cells[1].ClickThis();
				}
				Reports.ReportLog("UnSelectAll", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnSelectAll :" + ex.Message);
			}
		}
		
		public static void ScanForADSDB_TC6()
		{
			try
			{
				repo.ServerScriptGenWindow.RightTableInfo.WaitForItemExists(10000);
				Table table = repo.ServerScriptGenWindow.RightTable;
				repo.ServerScriptGenWindow.UnselectRight.ClickThis();
				UnSelectAll(table);
				foreach (var row in table.Rows)
				{
					if(row.Cells[2].Text.ToLower() == "ads_db" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForADSTable_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForADSTable_TC6 :" + ex.Message);
			}
		}
		
		public static void ConfigureOptionsTab_Preview_TC6()
		{
			try
			{
				SelectSaveAsCombo_TC6(2);
				SelectSeperatorCombo_TC6(2);
				SelectQuotedCombo_TC6(1);
				DeselectAllCheckBox_TC6();
				SelectRequiredCheckBox_TC6();
				System.Threading.Thread.Sleep(500);
				ClickOnNext_TC6();
				System.Threading.Thread.Sleep(5000);
				ClickOnPrevious_TC6();
				System.Threading.Thread.Sleep(500);
				ClickOnPrevious_TC6();
				System.Threading.Thread.Sleep(500);
				ConfigureOptionsTab_SaveFile_TC6();
				Preconditions.Steps.SelectedServerTreeItem.Select();
				Preconditions.Steps.DisconnectServer();
				Reports.ReportLog("ConfigureOptionsTab_Preview_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureOptionsTab_Preview_TC6 : " + ex.Message);
			}
		}
		
		public static void ConfigureOptionsTab_SaveFile_TC6()
		{
			try
			{
				SelectSaveAsCombo_TC6(0);
				EnterSaveFilePath_TC6();
				System.Threading.Thread.Sleep(500);
				ClickOnNext_TC6();
				System.Threading.Thread.Sleep(2000);
				ClickOnClose_TC6();
				Reports.ReportLog("ConfigureOptionsTab_SaveFile_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureOptionsTab_SaveFile_TC6 : " + ex.Message);
			}
		}
		
		public static void SelectRequiredCheckBox_TC6()
		{
			try
			{
				List<string> checkboxToCheck = new List<string> {"Generate the CREATE","Generate the DROP", "Include blank line between statements"};
				repo.ServerScriptGenWindow.CheckBoxContainerInfo.WaitForItemExists(1000);
				var collection = repo.ServerScriptGenWindow.CheckBoxContainer.FindChildren<Ranorex.CheckBox>();
				foreach (var item in collection)
				{
					if(checkboxToCheck.Contains(item.Text))
						item.Checked = true;
				}
				Reports.ReportLog("SelectRequiredCheckBox_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectRequiredCheckBox_TC6 : " + ex.Message);
			}
		}
		
		public static void ClickOnNext_TC6()
		{
			try
			{
				repo.ServerScriptGenWindow.NextButtonInfo.WaitForItemExists(10000);
				repo.ServerScriptGenWindow.NextButton.ClickThis();
				Reports.ReportLog("ClickOnNext_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnNext_TC6 : " + ex.Message);
			}
		}
		
		public static void ClickOnPrevious_TC6()
		{
			try
			{
				repo.ServerScriptGenWindow.PreviousButtonInfo.WaitForItemExists(10000);
				repo.ServerScriptGenWindow.PreviousButton.ClickThis();
				Reports.ReportLog("ClickOnPrevious_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnPrevious_TC6 : " + ex.Message);
			}
		}
		
		public static void ClickOnClose_TC6()
		{
			try
			{
				repo.ServerScriptGenWindow.Self.Close();
//				repo.ServerScriptGenWindow.CloseButtonInfo.WaitForItemExists(1000);
//				repo.ServerScriptGenWindow.CloseButton.ClickThis();
				Reports.ReportLog("ClickOnClose_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnClose_TC6 : " + ex.Message);
			}
		}
		
		public static void SelectSaveAsCombo_TC6(int index)
		{
			try
			{
				repo.ServerScriptGenWindow.SaveAsComboboxInfo.WaitForItemExists(10000);
				repo.ServerScriptGenWindow.SaveAsCombobox.SelectedItemIndex = index;
				Reports.ReportLog("SelectSaveAsCombo_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSaveAsCombo_TC6 : " + ex.Message);
			}
		}
		
		public static void EnterSaveFilePath_TC6()
		{
			try
			{
				string serverName = Preconditions.Steps.GetServerFromTCName(Config.TestCaseName);
				string filePath = string.Format("{0}{1}.txt", TC_10567_PATH, serverName);
				Common.DeleteFile(filePath);
				repo.ServerScriptGenWindow.SaveFilePathTextboxInfo.WaitForItemExists(10000);
				repo.ServerScriptGenWindow.SaveFilePathTextbox.TextBoxText(filePath);
				Reports.ReportLog("EnterSaveFilePath_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterSaveFilePath_TC6 : " + ex.Message);
			}
		}
		
		public static void SelectSeperatorCombo_TC6(int index)
		{
			try
			{
				repo.ServerScriptGenWindow.SeperatorComboboxInfo.WaitForItemExists(10000);
				repo.ServerScriptGenWindow.SeperatorCombobox.SelectedItemIndex = index;
				Reports.ReportLog("SelectSeperatorCombo_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSeperatorCombo_TC6 : " + ex.Message);
			}
		}
		
		public static void SelectQuotedCombo_TC6(int index)
		{
			try
			{
				repo.ServerScriptGenWindow.QuotedComboboxInfo.WaitForItemExists(10000);
				repo.ServerScriptGenWindow.QuotedCombobox.SelectedItemIndex = index;
				Reports.ReportLog("SelectQuotedCombo_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectQuotedCombo_TC6 : " + ex.Message);
			}
		}
		
		public static void DeselectAllCheckBox_TC6()
		{
			try
			{
				repo.ServerScriptGenWindow.CheckBoxContainerInfo.WaitForItemExists(10000);
				var collection = repo.ServerScriptGenWindow.CheckBoxContainer.FindChildren<Ranorex.CheckBox>();
				foreach (var item in collection)
					item.Checked = false;
				
				Reports.ReportLog("DeselectAllCheckBox_TC6", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeselectAllCheckBox_TC6 : " + ex.Message);
			}
		}
		#endregion
		
		#region "TC7 STEPS"
		public static void ConfigureGeneralTab_TC7()
		{
			try
			{
				ScanForRoles();
				ScanForAnyRole_TC7();
				ClickOnNext_TC6();
				System.Threading.Thread.Sleep(500);
				Reports.ReportLog("ConfigureGeneralTab_TC7", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConfigureGeneralTab_TC7 : " + ex.Message);
			}
		}
		
		public static void SelectSchemaScriptGenerator_TC7()
		{
			try
			{
				TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
				Preconditions.Steps.CloseTab(server.Text);
				Preconditions.Steps.SelectedServerTreeItem = server;
				Preconditions.Steps.SelectedServerName = server.Text;
				server.RightClickThis();
				Preconditions.Steps.ConnectServer();
				
				TreeItem dbItem = server.GetItem("Security");
				TreeItem adsdbItem = dbItem.GetItem("Roles", false);
				adsdbItem.RightClick();
				
				repo.DataStudio.ToolsMenuInfo.WaitForItemExists(1000);
				repo.DataStudio.ToolsMenu.ClickThis();
				
				repo.SunAwtWindow.ServerScriptGenMenuInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ServerScriptGenMenu.ClickThis();
				
				Reports.ReportLog("SelectSchemaScriptGenerator_TC7", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSchemaScriptGenerator_TC7 : " + ex.Message);
			}
		}
		
		public static void ScanForRoles()
		{
			try
			{
				repo.ServerScriptGenWindow.LeftTableInfo.WaitForItemExists(10000);
				Table table = repo.ServerScriptGenWindow.LeftTable;
				repo.ServerScriptGenWindow.UnselectLeft.ClickThis();
				UnSelectAll(table);
				foreach (var row in table.Rows)
				{
					if(row.Cells[2].Text == "Roles" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForRoles", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForRoles :" + ex.Message);
			}
		}
		
		public static void ScanForAnyRole_TC7()
		{
			try
			{
				repo.ServerScriptGenWindow.RightTableInfo.WaitForItemExists(10000);
				Table table = repo.ServerScriptGenWindow.RightTable;
				repo.ServerScriptGenWindow.UnselectRight.ClickThis();
				UnSelectAll(table);
				foreach (var row in table.Rows)
				{
					if(row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForAnyRole_TC7", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForAnyRole_TC7 :" + ex.Message);
			}
		}
		
		#endregion
	}
}
