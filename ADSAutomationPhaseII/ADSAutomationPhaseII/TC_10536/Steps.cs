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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10536
{
	public class Steps
	{
		public static TC10536Repo repo = TC10536Repo.Instance;
		public static string TC3_10536_Path = System.Configuration.ConfigurationManager.AppSettings["TC3_10536_Path"].ToString();
		
		public static void ExplicitSleep()
		{
			System.Threading.Thread.Sleep(300);
		}
		
		public static void ClickOnTools()
		{
			try
			{
				repo.Application.ToolsInfo.WaitForItemExists(20000);
				repo.Application.Tools.ClickThis();
				ExplicitSleep();
				Reports.ReportLog("ClickOnTools ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnTools : " + ex.Message);
			}
		}
		
		public static void SelectCompareTools()
		{
			try
			{
				repo.QueryAnalyzerComboList.CompareToolsInfo.WaitForItemExists(20000);
				repo.QueryAnalyzerComboList.CompareTools.ClickThis();
				ExplicitSleep();
				Reports.ReportLog("SelectCompareTools ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.QueryAnalyzerComboList.SelfInfo.Exists(1000)) repo.QueryAnalyzerComboList.Self.Close();
				throw new Exception("Failed : SelectCompareTools : " + ex.Message);
			}
			
		}
		
		public static void SelectSchemaCompare()
		{
			try
			{
				repo.SunAwtWindow.SchemaCompareInfo.WaitForItemExists(20000);
				repo.SunAwtWindow.SchemaCompare.ClickThis();
				ExplicitSleep();
				Reports.ReportLog("SelectSchemaCompare ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.SunAwtWindow.SelfInfo.Exists(1000)) repo.SunAwtWindow.Self.Close();
				throw new Exception("Failed : SelectSchemaCompare : " + ex.Message);
			}
			
		}
		
		public static void ClickOnLeftChooseServer()
		{
			try
			{
				repo.SchemaCompare.LeftChooseServerInfo.WaitForItemExists(20000);
				repo.SchemaCompare.LeftChooseServer.ClickThis();
				ExplicitSleep();
				Reports.ReportLog("ClickOnLeftChooseServer ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.SchemaCompare.SelfInfo.Exists(1000)) repo.SchemaCompare.Self.Close();
				throw new Exception("Failed : ClickOnLeftChooseServer : " + ex.Message);
			}
			
		}
		
		public static void ClickOkButton()
		{
			try
			{
				repo.ChooseServer.OkButtonInfo.WaitForItemExists(20000);
				repo.ChooseServer.OkButton.ClickThis();
				ExplicitSleep();
				Reports.ReportLog("ClickOkButton ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.ChooseServer.SelfInfo.Exists(1000))  repo.ChooseServer.Self.Close();
				throw new Exception("Failed : ClickOkButton : " + ex.Message);
			}
		}
		
		public static void ClickOnRightChooseServer()
		{
			try
			{
				repo.SchemaCompare.RightChooseServerInfo.WaitForItemExists(20000);
				repo.SchemaCompare.RightChooseServer.ClickThis();
				ExplicitSleep();
				Reports.ReportLog("ClickOnRightChooseServer ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.SchemaCompare.SelfInfo.Exists(1000)) repo.SchemaCompare.Self.Close();
				throw new Exception("Failed : ClickOnRightChooseServer : " + ex.Message);
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
				Reports.ReportLog("SelectServer ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.ChooseServer.SelfInfo.Exists(1000)) repo.ChooseServer.Self.Close();
				if(repo.SchemaCompare.SelfInfo.Exists(1000)) repo.SchemaCompare.Self.Close();
				throw new Exception("Failed : SelectServer : " + ex.Message);
			}
		}
		
		public static void SelectADSDb()
		{
			try
			{
				TreeItem SelectedServer = null ;
				SelectServer(ref SelectedServer);
				TreeItem adsDB = SelectedServer.GetItem(Configuration.Config.ADSDB);
				adsDB.Select();
				Reports.ReportLog("SelectADSDb", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.SchemaCompare.SelfInfo.Exists(1000)) repo.SchemaCompare.Self.Close();
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
				Reports.ReportLog("SelectADSDB ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.SchemaCompare.SelfInfo.Exists(1000)) repo.SchemaCompare.Self.Close();
				throw new Exception("Failed : SelectADSDB : " + ex.Message);
			}
		}
		
		public static void SelectADSDb1()
		{
			try
			{
				TreeItem SelectedServerDb1 = null;
				SelectServer(ref SelectedServerDb1);
				TreeItem adsDB1 = SelectedServerDb1.GetItem(Configuration.Config.ADSDB1);
				ExplicitWait();
				adsDB1.Select();
				Reports.ReportLog("SelectADSDb1 ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.SchemaCompare.SelfInfo.Exists(1000)) repo.SchemaCompare.Self.Close();
				throw new Exception("Failed : SelectADSDb1 : " + ex.Message);
			}
		}
		
		public static void SelectADSDB1()
		{
			try
			{
				TreeItem SelectedServerDb1 = null;
				SelectServer(ref SelectedServerDb1);
				TreeItem adsDB1 = SelectedServerDb1.GetItem(Configuration.Config.ADSDB1.ToUpper());
				adsDB1.Select();
				Reports.ReportLog("SelectADSDB1 ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.SchemaCompare.SelfInfo.Exists(1000)) repo.SchemaCompare.Self.Close();
				throw new Exception("Failed : SelectADSDB1 : " + ex.Message);
			}
		}
		
		public static void SetSchema()
		{
			try
			{
				repo.SchemaCompare.RightObjects.RightDatabaseComboBoxInfo.WaitForItemExists(20000);
				repo.SchemaCompare.RightObjects.RightSchemaCombobox.TextBoxText(repo.SchemaCompare.LeftObjects.LeftSchemaCombobox.TextValue);
				Reports.ReportLog("SetSchema ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetSchema : " + ex.Message);
			}
		}
		
		public static void SetDB()
		{
			try
			{
				repo.SchemaCompare.RightObjects.RightDatabaseComboBoxInfo.WaitForItemExists(20000);
				repo.SchemaCompare.RightObjects.RightDatabaseComboBox.TextBoxText(repo.SchemaCompare.LeftObjects.LeftDatabaseComboBox.TextValue);
				Reports.ReportLog("SetDB ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetDB : " + ex.Message);
			}
		}
		
		public static void ScanForTables()
		{
			try
			{
				Table table = repo.SchemaCompare.LeftObjects.LeftTable;
				CheckUnselected(table);
				foreach (var row in table.Rows)
				{
					if(row.Cells[2].Text.ToLower() == "tables" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
				Reports.ReportLog("ScanForTables ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ScanForTables : " + ex.Message);
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
				Reports.ReportLog("CheckUnselected ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckUnselected : " + ex.Message);
			}
		}
		
		public static void UnselectSchemaObjects()
		{
			try
			{
				repo.SchemaCompare.LeftObjects.UnSelectSchemaObjectsInfo.WaitForItemExists(20000);
				repo.SchemaCompare.LeftObjects.UnSelectSchemaObjects.ClickThis();
				Reports.ReportLog("UnselectSchemaObjects ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnselectSchemaObjects : " + ex.Message);
			}
		}
		
		public static void SelectSchemaTable()
		{
			try
			{
				repo.SchemaCompare.LeftObjects.SelectSchemaObjectsTableInfo.WaitForItemExists(20000);
				repo.SchemaCompare.LeftObjects.SelectSchemaObjectsTable.ClickThis();
				Reports.ReportLog("SelectSchemaTable ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSchemaTable : " + ex.Message);
			}
		}

		public static void UnselectLeftObjects()
		{
			try
			{
				repo.SchemaCompare.LeftObjects.UnSelectSchemaObjectsInfo.WaitForItemExists(20000);
				repo.SchemaCompare.LeftObjects.UnSelectSourceObjects.ClickThis();
				Reports.ReportLog("UnselectLeftObjects ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnselectLeftObjects : " + ex.Message);
			}
		}

		public static void SelectLeftTable()
		{
			try
			{
				repo.SchemaCompare.LeftObjects.SelectLeftObjectsInfo.WaitForItemExists(20000);
				repo.SchemaCompare.LeftObjects.SelectLeftObjects.ClickThis();
				Reports.ReportLog("SelectLeftTable ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectLeftTable : " + ex.Message);
			}
		}

		public static void UnselectRightObjects()
		{
			try
			{
				repo.SchemaCompare.RightObjects.UnselectRightObjectsInfo.WaitForItemExists(20000);
				repo.SchemaCompare.RightObjects.UnselectRightObjects.ClickThis();
				Reports.ReportLog("UnselectRightObjects ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnselectRightObjects : " + ex.Message);
			}
		}

		public static void SelectRightTable()
		{
			try
			{
				repo.SchemaCompare.RightObjects.SelectRightObjectsInfo.WaitForItemExists(20000);
				repo.SchemaCompare.RightObjects.SelectRightObjects.ClickThis();
				Reports.ReportLog("SelectRightTable ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectRightTable : " + ex.Message);
			}
		}

		public static void ClickOnCompareButton()
		{
			try
			{
				repo.SchemaCompare.CompareButtonInfo.WaitForItemExists(20000);
				repo.SchemaCompare.CompareButton.ClickThis();
				Reports.ReportLog("ClickOnCompareButton ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnCompareButton : " + ex.Message);
			}
		}
		
		public static void ClickOnTable()
		{
			try
			{
				if(repo.Application.CompareTableInfo.Exists(20000))
				{
					repo.Application.CompareTable.ClickThis();
					Reports.ReportLog("ClickOnTable ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnTable : " + ex.Message);
			}
		}
		
		public static void ClickOnSpreadSheetIcon()
		{
			try
			{
				if(repo.AquaDataStudio.ViewAsSpreadsheetInfo.Exists(20000))
				{
					repo.AquaDataStudio.ViewAsSpreadsheet.ClickThis();
					Reports.ReportLog("ClickOnSpreadSheetIcon ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSpreadSheetIcon : " + ex.Message);
			}
		}
		
		public static void ClickOnCloseButton()
		{
			try
			{
				if (repo.Downloads.CloseButtonInfo.Exists(20000))
				{
					repo.Downloads.CloseButton.ClickThis();
					Reports.ReportLog("ClickOnCloseButton ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				if(repo.Downloads.SelfInfo.Exists(2000)) repo.Downloads.Self.Close();
				throw new Exception("Failed : ClickOnCloseButton : " + ex.Message);
			}
		}
		
		public static void SelectResultCompare()
		{
			try
			{
				Preconditions.Steps.Sleep();
				Keyboard.Press(Keyboard.ToKey("Ctrl+Shift+K"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.Sleep();
				Reports.ReportLog("SelectResultCompare ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectResultCompare : " + ex.Message);
			}
		}
		
		public static void ClickOnResultTab()
		{
			try
			{
				repo.SelectResultSets.ResultTabInfo.WaitForItemExists(20000);
				repo.SelectResultSets.ResultTab.ClickThis();
				Reports.ReportLog("ClickOnResultTab ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.SelectResultSets.Self.Close();
				throw new Exception("Failed : ClickOnResultTab : " + ex.Message);
			}
		}
		
		public static void ClickOnResultSet1()
		{
			try
			{
				repo.SelectResultSets.ResultSet1Info.WaitForItemExists(20000);
				repo.SelectResultSets.ResultSet1.ClickThis();
				Reports.ReportLog("ClickOnResultSet1 ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.SelectResultSets.Self.Close();
				throw new Exception("Failed : ClickOnResultSet1 : " + ex.Message);
			}
		}
		
		public static void ClickOnResultListSet1()
		{
			try
			{
				repo.SelectResultSets.ResultSetList1Info.WaitForItemExists(20000);
				repo.SelectResultSets.ResultSetList1.ClickThis();
				Reports.ReportLog("ClickOnResultListSet1 ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.SelectResultSets.Self.Close();
				throw new Exception("Failed : ClickOnResultListSet1 : " + ex.Message);
			}
		}
		
		public static void ClickOnResultSet2()
		{
			try
			{
				repo.SelectResultSets.ResultSet2Info.WaitForItemExists(20000);
				repo.SelectResultSets.ResultSet2.ClickThis();
				Reports.ReportLog("ClickOnResultSet2 ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.SelectResultSets.Self.Close();
				throw new Exception("Failed : ClickOnResultSet2 : " + ex.Message);
			}
		}
		
		public static void ClickOnResultListSet2()
		{
			try
			{
				repo.SelectResultSets.ResultSetList2Info.WaitForItemExists(20000);
				repo.SelectResultSets.ResultSetList2.ClickThis();
				Reports.ReportLog("ClickOnResultListSet2 ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnResultListSet2 : " + ex.Message);
			}
		}
		
		public static void ClickOnOkButton()
		{
			try
			{	repo.SelectResultSets.OkButtonInfo.WaitForItemExists(20000);
				repo.SelectResultSets.OkButton.ClickThis();
				Reports.ReportLog("ClickOnOkButton ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOkButton : " + ex.Message);
			}
		}

		public static void ClickOnRefresh()
		{
			try
			{
				repo.Application.RefreshButtonInfo.WaitForItemExists(20000);
				repo.Application.RefreshButton.ClickThis();
				Reports.ReportLog("ClickOnRefresh ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnRefresh : " + ex.Message);
			}
		}
		
		public static void CompareResult()
		{
			try
			{
				string[] compareResult1 = repo.Application.CompareResult1.TextValue.Split(',');
				string row1 = compareResult1[1];
				
				string[] compareResult2 = repo.Application.CompareResult2.TextValue.Split(',');
				string row2 = compareResult2[1];
				
				if (row1 == row2){ Reports.ReportLog("Table rows are equal", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName); }
				else{ Reports.ReportLog("Table rows are not equal", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName); }
				
				//Preconditions.Steps.CloseAllTabs(Preconditions.Steps.SelectedServerName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CompareResult : " + ex.Message);
			}
		}

		public static void Save()
		{
			try
			{
				Preconditions.Steps.Sleep();
				Keyboard.Press(Keyboard.ToKey("Ctrl+S"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.Sleep();
				Reports.ReportLog("Save ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Save : " + ex.Message);
			}
		}

		public static void Browse()
		{
			try
			{
				repo.SaveHTML.BrowseInfo.WaitForItemExists(30000);
				repo.SaveHTML.Browse.ClickThis();
				Reports.ReportLog("Save ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Browse : " + ex.Message);
			}
		}

		public static void EnterFileName()
		{
			try
			{
				string filePath = string.Format("{0}CompareResult", TC3_10536_Path);
				Preconditions.Steps.TextboxText(repo.OpenWindow.FileName, filePath);
				Reports.ReportLog("EnterFileName ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFileName : " + ex.Message);
			}
		}
		
		public static void SaveHtml()
		{
			try
			{
				string filePath = string.Format("{0}CompareResult.html", TC3_10536_Path);
				Commons.Common.DeleteFile(filePath);
				repo.OpenWindow.OpenButtonInfo.WaitForItemExists(20000);
				repo.OpenWindow.OpenButton.ClickThis();
				Reports.ReportLog("SaveHtml ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SaveHtml : " + ex.Message);
			}
		}
		
		public static void ClickOnOk()
		{
			try
			{
				repo.SaveHTML.OkButtonInfo.WaitForItemExists(20000);
				repo.SaveHTML.OkButton.ClickThis();
				Reports.ReportLog("ClickOnOk ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOk : " + ex.Message);
			}
		}
		
		public static void Navigate()
		{
			try
			{
				string filePath = string.Format("{0}CompareResult.html", TC3_10536_Path);
				int processId = Host.Local.OpenBrowser(filePath);
				System.Threading.Thread.Sleep(3000);
				Keyboard.Press(Keyboard.ToKey("Alt+F4"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Reports.ReportLog("Navigate ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			
			catch (Exception ex)
			{
				throw new Exception("Failed : Navigate : " + ex.Message);
			}
		}
		
		public static void ClickOnSpreadSheet()
		{
			try
			{
				repo.ApplicationCompare.ViewAsSpreadsheetInfo.WaitForItemExists(20000);
				repo.ApplicationCompare.ViewAsSpreadsheet.ClickThis();
				repo.Downloads.CloseButtonInfo.WaitForItemExists(20000);
				repo.Downloads.CloseButton.ClickThis();
				Reports.ReportLog("ClickOnSpreadSheet ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSpreadSheet : " + ex.Message);
			}
		}
		
		public static void ResultCompareFilters()
		{
			try
			{
				repo.ApplicationCompare.FilterResultsInfo.WaitForItemExists(20000);
				repo.ApplicationCompare.FilterResults.ClickThis();
				repo.ResultCompareFilters.UnSelectAllButton.ClickThis();
				repo.ResultCompareFilters.SelectAllButtonInfo.WaitForItemExists(2000000);
				repo.ResultCompareFilters.SelectAllButton.ClickThis();
				repo.ResultCompareFilters.ReverseButtonInfo.WaitForItemExists(2000000);
				repo.ResultCompareFilters.ReverseButton.ClickThis();
				repo.ResultCompareFilters.CancelButtonInfo.WaitForItemExists(20000);
				repo.ResultCompareFilters.CancelButton.ClickThis();
				Reports.ReportLog("ResultCompareFilters ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			
			catch (Exception ex)
			{
				throw new Exception("Failed : ResultCompareFilters : " + ex.Message);
			}
		}
		
		public static void ExplicitWait()
		{
			System.Threading.Thread.Sleep(1000);
		}
		
		public static void SelectAquafold()
		{
			try
			{
				TreeItem SelectedServerDb1 = null;
				SelectServer(ref SelectedServerDb1);
				TreeItem aquafold = SelectedServerDb1.GetItem(Configuration.Config.AQUAFOLD);
				ExplicitWait();
				aquafold.Select();
				Reports.ReportLog("SelectAquafold ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectADSDb1 : " + ex.Message);
			}
		}
		
		public static void Vertica_SchemaLeft()
		{
			try
			{
				repo.SchemaCompare.LeftObjects.LeftSchemaCombobox.TextBoxText(Config.ADSDB1);
				Reports.ReportLog("Vertica_SchemaLeft ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Vertica_SchemaLeft : " + ex.Message);
			}
		}
		
		public static void Vertica_SchemaRight()
		{
			try
			{
				repo.SchemaCompare.RightObjects.RightSchemaCombobox.TextBoxText(Config.ADSDB);
				Reports.ReportLog("Vertica_SchemaRight ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Vertica_SchemaRight : " + ex.Message);
			}
		}
	}
}
