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
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10542
{
	public static class Steps
	{
		public static TC10542 repo = TC10542.Instance;
		public static string TC2_10542_Path = System.Configuration.ConfigurationManager.AppSettings["TC2_10542_Path"].ToString();
		public const string CREATEDATABASEQUERY = "create database ads_db";
		public const string CREATETABLEQUERY = "CREATE TABLE ads_table (CustomerID int, CustomerName varchar(255), City varchar(255), PostalCode varchar(255), Country varchar(255), firstname varchar(30), lastname varchar(40))";
		
		public static void CreateDatabaseQuery()
		{
			try
			{
				repo.Application.QATextEditor.Click();
				repo.Application.QATextEditor.PressKeys(CREATEDATABASEQUERY);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
			}
			catch(Exception ex)
			{
				throw new Exception("CreateDatabaseQuery not working. "+ ex.Message);
			}
		}
		
		public static void CreateTableQuery()
		{
			try
			{
				repo.Application.QATextEditor.Click();
				repo.Application.QATextEditor.PressKeys(CREATETABLEQUERY);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				
			}
			catch(Exception ex)
			{
				throw new Exception("CREATETABLEQUERY not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnDiscard()
		{
			try
			{
				if(repo.FileModified.DiscardInfo.Exists(2000))
				{
					repo.FileModified.Discard.ClickThis();
					Reports.ReportLog("ClickOnDiscard", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception e)
			{
				throw new Exception("Failed : ClickOnDiscard : " + e.Message);
			}
		}
		
		public static void ClickOnAutomate()
		{
			try
			{
				repo.Application.AutomateInfo.WaitForItemExists(2000);
				repo.Application.Automate.ClickThis();
				
			}
			catch (Exception)
			{
				
			}
		}
		
		public static void ClickOnGeneralTab()
		{
			try
			{
				repo.ServerScriptGenerator.GeneralTabInfo.WaitForItemExists(2000);
				repo.ServerScriptGenerator.GeneralTab.ClickThis();
				Reports.ReportLog("ClickOnGeneralTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				throw new Exception("Failed : ClickOnGeneralTab : " + e.Message);
			}
		}
		
		public static void ClickOnToggleStatementComment()
		{
			try
			{
				repo.Datastudio.ToggleStatement.ClickThis();
				Reports.ReportLog("ClickOnToggleStatementComment", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception)
			{
				ClickOnAutomate();
				ClickOnToggleStatementComment();
			}
		}
		
		public static void ClickOnToggleDoubleLineComment()
		{
			try
			{
				
				repo.Datastudio.ToggleLineStatement.ClickThis();
				Reports.ReportLog("ClickOnToggleDoubleLineComment", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception)
			{
				ClickOnAutomate();
				ClickOnToggleDoubleLineComment();
			}
		}
		
		public static void ClickOnToggleMinusComment()
		{
			try
			{
				
				repo.Datastudio.ToggleLineComment.ClickThis();
				Reports.ReportLog("ClickOnToggleMinusComment", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception)
			{
				ClickOnAutomate();
				ClickOnToggleMinusComment();
			}
		}
		
		public static void ClickOnToggleBlockComment()
		{
			try
			{
				repo.Datastudio.BlockComment.ClickThis();
				Reports.ReportLog("ClickOnToggleBlockComment", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception)
			{
				ClickOnAutomate();
				ClickOnToggleBlockComment();
			}
		}
		
		public static void ClickOnTools()
		{
			try
			{
				repo.Application.ToolsInfo.WaitForItemExists(2000);
				repo.Application.Tools.Click();
				Reports.ReportLog("ClickOnTools", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnTools : " +ex.Message);
			}
		}
		
		public static void ClickOnSeverScriptGenerator()
		{
			try
			{
				repo.Datastudio.ServerScriptGeneratorInfo.WaitForItemExists(2000);
				repo.Datastudio.ServerScriptGenerator.ClickThis();
				Reports.ReportLog("ClickOnSeverScriptGenerator", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSeverScriptGenerator : " +ex.Message);
			}
		}
		
		public static void ClickOnDeselectObjectType()
		{
			try
			{
				repo.ServerScriptGenerator.DeselectObjectTypesInfo.WaitForItemExists(2000);
				repo.ServerScriptGenerator.DeselectObjectTypes.ClickThis();
				Reports.ReportLog("ClickOnDeselectObjectType", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnDeselectObjectType : " +ex.Message);
			}
		}
		
		public static void ScanForLeftTables()
		{
			try
			{
				Table table = repo.ServerScriptGenerator.SelectObjectTypeTable;
				CheckUnselected(table);
				foreach (var row in table.Rows)
				{
					if(row.Cells[2].Text == "Databases" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
			}
			catch (Exception e)
			{
				throw e;
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
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		public static void ClickOnDeselectObject()
		{
			try
			{
				repo.ServerScriptGenerator.DeselectObjectInfo.WaitForItemExists(2000);
				repo.ServerScriptGenerator.DeselectObject.ClickThis();
				Reports.ReportLog("ClickOnDeselectObject", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnDeselectObject : " +ex.Message);
			}
		}
		
		public static void ScanForRightTables()
		{
			try
			{
				Table table = repo.ServerScriptGenerator.SelectObjectTable;
				CheckUnselected(table);
				foreach (var row in table.Rows)
				{
					if(row.Cells[2].Text.ToLower() == "ads_db" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		public static void ClickOnNextButton()
		{
			try
			{
				repo.ServerScriptGenerator.NextButtonInfo.WaitForItemExists(2000);
				repo.ServerScriptGenerator.NextButton.ClickThis();
				Reports.ReportLog("ClickOnNextButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnNextButton : " +ex.Message);
			}
		}
		
		public static void BrowseFolderLocation()
		{
			try
			{
				System.Threading.Thread.Sleep(500);
				repo.ServerScriptGenerator.BrowseSqlfile.ClickThis();
				repo.FileLocation.Textbox.TextBoxText(TC2_10542_Path + "/" + Preconditions.Steps.SelectedServerName + ".sql");
				repo.FileLocation.SelectButton.ClickThis();
				Reports.ReportLog("BrowseFolderLocation", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : BrowseFolderLocation : " +ex.Message);
			}
			
		}
		
		public static void ClickOnCloseButton()
		{
			try
			{
				repo.ServerScriptGenerator.CloseButtonInfo.WaitForItemExists(2000);
				repo.ServerScriptGenerator.CloseButton.ClickThis();
				Reports.ReportLog("ClickOnCloseButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnCloseButton : " +ex.Message);
			}
		}
		
		public static void ClickOnFile()
		{
			try
			{
				repo.Application.FileMenuInfo.WaitForItemExists(2000);
				repo.Application.FileMenu.ClickThis();
				Reports.ReportLog("ClickOnFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFile : " +ex.Message);
			}
		}
		
		public static void ClickOnOpenMenuItem()
		{
			try
			{
				repo.Datastudio.OpenMenuInfo.WaitForItemExists(200000);
				repo.Datastudio.OpenMenu.ClickThis();
				Reports.ReportLog("ClickOnOpen", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOpen : " +ex.Message);
			}
		}
		
		public static void OpenSqlFile()
		{
			try
			{
				repo.Open.OpenTextboxInfo.WaitForItemExists(2000);
				repo.Open.OpenTextbox.TextBoxText(TC2_10542_Path + "/" + Preconditions.Steps.SelectedServerName + ".sql");
				Reports.ReportLog("OpenSqlFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenSqlFile : " +ex.Message);
			}
		}
		
		public static void ClickOpen()
		{
			try
			{
				repo.Open.OpenButtonInfo.WaitForItemExists(2000);
				repo.Open.OpenButton.ClickThis();
				Reports.ReportLog("ClickOpen", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Failed : ClickOpen : " +ex.Message);
			}
		}
		
		public static void SelectServer()
		{
			try
			{
				string servername = Preconditions.Steps.GetServerFromTCName(Config.TestCaseName);
				TreeItem item = repo.ChooseServer.SelectServer.GetItem(servername);
				item.ClickThis();
				Reports.ReportLog("SelectServer", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Failed : SelectServer : " +ex.Message);
			}
		}
		
		public static void ClickOpenQueryAnalyser()
		{
			try
			{
				repo.ChooseServer.OpenQueryAnalyserInfo.WaitForItemExists(2000);
				repo.ChooseServer.OpenQueryAnalyser.ClickThis();
				Reports.ReportLog("ClickOpenQueryAnalyser", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Failed : ClickOpenQueryAnalyser : " +ex.Message);
			}
		}
		
		public static void ClickOnShowTextButton()
		{
			try
			{
				repo.Application.ShowTextInfo.WaitForItemExists(2000);
				repo.Application.ShowText.ClickThis();
				Reports.ReportLog("ClickOnShowTextButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnShowTextButton : " +ex.Message);
			}
		}
		
		public static void ClickOnShowTextHistoryButton()
		{
			try
			{
				repo.Application.ShowTextHistoryInfo.WaitForItemExists(2000);
				repo.Application.ShowTextHistory.ClickThis();
				Reports.ReportLog("ClickOnShowTextHistoryButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnShowTextHistoryButton : " +ex.Message);
			}
		}
		
		public static void ClickOnShowGridButton()
		{
			try
			{
				repo.Application.ShowGridInfo.WaitForItemExists(2000);
				repo.Application.ShowGrid.ClickThis();
				Reports.ReportLog("ClickOnShowGridButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnShowGridButton : " +ex.Message);
			}
		}
		
		public static void ClickOnPivotGridButton()
		{
			try
			{
				repo.Application.PivotGridInfo.WaitForItemExists(2000);
				repo.Application.PivotGrid.ClickThis();
				Reports.ReportLog("ClickOnPivotGridButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnPivotGridButton : " +ex.Message);
			}
		}
		
		public static void ClickOnFormButton()
		{
			try
			{
				repo.Application.FormInfo.WaitForItemExists(2000);
				repo.Application.Form.ClickThis();
				Reports.ReportLog("ClickOnFormButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFormButton : " +ex.Message);
			}
		}
		
		public static void ClickOnExecutionPlanButton()
		{
			try
			{
				repo.Application.ExecutionPlanInfo.WaitForItemExists(2000);
				repo.Application.ExecutionPlan.ClickThis();
				Reports.ReportLog("ClickOnExecutionPlanButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnExecutionPlanButton : " +ex.Message);
			}
		}
		
		public static void ClickOnClientStatisticsButton()
		{
			try
			{
				repo.Application.ClientStatisticsInfo.WaitForItemExists(2000);
				repo.Application.ClientStatistics.ClickThis();
				Reports.ReportLog("ClickOnClientStatisticsButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnClientStatisticsButton : " +ex.Message);
			}
		}
		
		public static void ClickOnTextTab()
		{
			try
			{
				if(repo.Application.TextTabInfo.Exists(2000))
				{
					repo.Application.TextTab.ClickThis();
					Reports.ReportLog("ClickOnTextTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnTextTab : " +ex.Message);
			}
		}
		
		public static void ClickOnTextHistoryTab()
		{
			try
			{
				if(repo.Application.TextHistoryTabInfo.Exists(2000))
				{
					repo.Application.TextHistoryTab.ClickThis();
					Reports.ReportLog("ClickOnTextHistoryTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnTextHistoryTab : " +ex.Message);
			}
		}
		
		public static void ClickOnShowGridTab()
		{
			try
			{
				if(repo.Application.GridTabInfo.Exists(2000))
				{
					repo.Application.GridTab.ClickThis();
					Reports.ReportLog("ClickOnShowGridTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnShowGridTab : " +ex.Message);
			}
		}
		
		public static void ClickOnPivotGridTab()
		{
			try
			{
				if(repo.Application.PivotGridTabInfo.Exists(2000))
				{
					repo.Application.PivotGridTab.ClickThis();
					Reports.ReportLog("ClickOnPivotGridTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnPivotGridTab : " +ex.Message);
			}
		}
		
		public static void ClickOnFormTab()
		{
			try
			{
				if(repo.Application.FormTabInfo.Exists(2000))
				{
					repo.Application.FormTab.ClickThis();
					Reports.ReportLog("ClickOnFormTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFormTab : " +ex.Message);
			}
		}
		
		public static void ClickOnExecutionPlanTab()
		{
			try
			{
				if(repo.Application.ExecutionPlanTabInfo.Exists(2000))
				{
					repo.Application.ExecutionPlanTab.ClickThis();
					Reports.ReportLog("ClickOnExecutionPlanTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnExecutionPlanTab : " +ex.Message);
			}
		}
		
		public static void ClickOnClientStatisticsTab()
		{
			try
			{
				if(repo.Application.ClientStatisticsTabInfo.Exists(2000))
				{
					repo.Application.ClientStatisticsTab.ClickThis();
					Reports.ReportLog("ClickOnClientStatisticsTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnClientStatisticsTab : " +ex.Message);
			}
		}
	}
}
