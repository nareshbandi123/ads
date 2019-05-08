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
using ADSAutomationPhaseII.TC_10542;

namespace ADSAutomationPhaseII.TC_10543
{
	[TestModule("E0972D8D-057C-4834-B671-A70A015F3324", ModuleType.UserCode, 1)]
	public static class Steps
	{
		public static TC10543 repo = TC10543.Instance;
		public static TC10542 repo10542 = TC10542.Instance;
		public static string TC1_10543_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10543_Path"].ToString();
		public const string SELECTDATABASEQUERY = "SELECT * FROM ads_table WHERE firstname='\\&name'";
		public const string SELECTTABLE = "select * from ";

		public static void ClickOnQuery()
		{
			try
			{
				repo.Application.QueryTabInfo.WaitForItemExists(20000);
				repo.Application.QueryTab.ClickThis();
				Reports.ReportLog("ClickOnQuery", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnQuery : " + e.Message);
			}
		}
		
		public static void ClickOnDisconnect()
		{
			try
			{
				repo.Datastudio.DisconnectInfo.WaitForItemExists(20000);
				repo.Datastudio.Disconnect.ClickThis();
				Reports.ReportLog("ClickOnDisconnect", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnDisconnect : " + e.Message);
			}
		}
		
		public static void ClickOnDisconnectYesButton()
		{
			try
			{
				repo.Disconnect.YesButtonInfo.WaitForItemExists(2000);
				repo.Disconnect.YesButton.ClickThis();
				Reports.ReportLog("ClickOnDisconnectYesButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnDisconnectYesButton : " + e.Message);
			}
		}
		
		public static void ClickOnReconnect()
		{
			try
			{
				repo.Datastudio.ReconnectInfo.WaitForItemExists(200000);
				repo.Datastudio.Reconnect.ClickThis();
				Reports.ReportLog("ClickOnReconnect", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnReconnect : " + e.Message);
			}
		}
		
		public static void ClickOnReconnectYesButton()
		{
			try
			{
				repo.Reconnect.YesButtonInfo.WaitForItemExists(20000);
				repo.Reconnect.YesButton.ClickThis();
				Reports.ReportLog("ClickOnReconnectYesButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnReconnectYesButton : " + e.Message);
			}
		}
		
		public static void ClickOnChangeServer()
		{
			try
			{
				repo.Datastudio.ChangeServerInfo.WaitForItemExists(2000);
				repo.Datastudio.ChangeServer.ClickThis();
				Reports.ReportLog("ClickOnChangeServer", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnChangeServer : " + e.Message);
			}
		}
		
		public static void SelectCassandra()
		{
			try
			{
				repo.ChooseServer.CassandraInfo.WaitForItemExists(2000);
				repo.ChooseServer.Cassandra.ClickThis();
				Reports.ReportLog("SelectCassandra", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : SelectCassandra : " + e.Message);
			}
		}
		
		public static void ClickOnOk()
		{
			try
			{
				repo.ChooseServer.OkButtonInfo.WaitForItemExists(20000);
				repo.ChooseServer.OkButton.ClickThis();
				System.Threading.Thread.Sleep(2000);
				Reports.ReportLog("ClickOnOk", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnOk : " + e.Message);
			}
		}
		
		public static void ClickOnFileMenu()
		{
			try
			{
				repo.Application.FileMenuInfo.WaitForItemExists(20000);
				repo.Application.FileMenu.ClickThis();
				Reports.ReportLog("ClickOnFileMenu", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnFileMenu : " + e.Message);
			}
		}
		
		public static void ClickOnOptions()
		{
			try
			{
				repo.Datastudio.OptionsInfo.WaitForItemExists(20000);
				repo.Datastudio.Options.ClickThis();
				Reports.ReportLog("ClickOnOptions", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnOptions : " + e.Message);
			}
		}
		
		public static void ClickOnQueryAnalyser()
		{
			try
			{
				repo.Options.QueryAnalyserInfo.WaitForItemExists(20000);
				repo.Options.QueryAnalyser.ClickThis();
				repo.Options.QueryAnalyser.Expand();
				Reports.ReportLog("ClickOnQueryAnalyser", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnQueryAnalyser : " + e.Message);
			}
		}
		
		public static void ClickOnSQLEditor()
		{
			try
			{
				repo.Options.SQLEditorInfo.WaitForItemExists(20000);
				repo.Options.SQLEditor.ClickThis();
				repo.Options.SQLEditor.Expand();
				Reports.ReportLog("ClickOnSQLEditor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnSQLEditor : " + e.Message);
			}
		}
		
		public static void ClickOnAmazonRedshift()
		{
			try
			{
				repo.Options.AmazonRedshiftInfo.WaitForItemExists(20000);
				repo.Options.AmazonRedshift.ClickThis();
				Reports.ReportLog("ClickOnAmazonRedshift", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnAmazonRedshift : " + e.Message);
			}
		}
		
		public static void SelectServer()
		{
			try
			{
				string servername = Preconditions.Steps.GetServerFromTCName(Config.TestCaseName);
				TreeItem item = Extension.GetItem(repo.Options.QueryAnalyser, servername);
				item.ClickThis();
				Reports.ReportLog("SelectServer", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Failed : SelectServer : " +ex.Message);
			}
		}
		
		public static void ScanForTables()
		{
			try
			{
				repo.Options.OptionsTableInfo.WaitForItemExists(20000);
				Table table = repo.Options.OptionsTable;
				foreach (var row in table.Rows)
				{
					if(row.Cells[0].Text == "Parameterized Script" && row.Cells[1].Text == "false")
					{
						row.Cells[1].ClickThis();
						break;
					}
				}
			}
			catch (Exception e)
			{
				throw new Exception("ScanForTables " +e.Message);
			}
		}
		
		public static void ClickOnAutoCompletion()
		{
			try
			{
				repo.Options.AutoCompletionInfo.WaitForItemExists(20000);
				repo.Options.AutoCompletion.ClickThis();
				Reports.ReportLog("ClickOnAutoCompletion", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnAutoCompletion : " + e.Message);
			}
		}
		
		public static void ClickOnOptionsOk()
		{
			try
			{
				repo.Options.OkButtonInfo.WaitForItemExists(20000);
				repo.Options.OkButton.ClickThis();
				Reports.ReportLog("ClickOnOptionsOk", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnOptionsOk : " + e.Message);
			}
		}
		
		public static void SelectDatabaseQuery()
		{
			try
			{
				repo10542.Application.QATextEditorInfo.WaitForItemExists(20000);
				repo10542.Application.QATextEditor.Click();
				repo10542.Application.QATextEditor.PressKeys(SELECTDATABASEQUERY);
				Keyboard.Press(Keyboard.ToKey("Ctrl+E"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
			}
			catch(Exception ex)
			{
				throw new Exception("SelectDatabaseQuery not working. "+ ex.Message);
			}
		}
		
		public static void ScanForMaxResultTables(string item)
		{
			try
			{
				repo.Options.OptionsTableInfo.WaitForItemExists(20000);
				Table table = repo.Options.OptionsTable;
				foreach (var row in table.Rows)
				{
					if(row.Cells[0].Text == "Max Results")
					{
						if(string.IsNullOrEmpty(row.Cells[1].Text))
						{
							repo.Options.MaxText.ClickThis();
							repo.Options.MaxText.PressKeys(item);
							break;
						}
					}
				}
			}
			catch (Exception e)
			{
				throw new Exception("ScanForMaxResultTables : "+e.Message);
			}
		}
		
		public static void ScanForMaxResultEmpty()
		{
			try
			{
				repo.Options.EditOptionsTableInfo.WaitForItemExists(20000);
				Table table = repo.Options.EditOptionsTable;
				foreach (var row in table.Rows)
				{
					if(row.Cells[0].Text == "Max Results")
					{
						row.Cells[1].DoubleClickThis();
						Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
						Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
						break;
					}
				}
			}
			catch (Exception e)
			{
				throw new Exception("Failed : ScanForMaxResultEmpty : " + e.Message);
			}
		}
		
		public static void ValidateRows()
		{
			try
			{
				repo.Application.ResultTextInfo.WaitForItemExists(2000);
				string Result = repo.Application.ResultText.TextValue;
				
				if(Result.Contains("2"))
				{
					Reports.ReportLog("Validation : ValidateRows", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation failed : ValidateRows", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ValidateRows : " + e.Message);
			}
		}
		
		public static void ValidateSQLEditorTable()
		{
			try
			{
				repo.Options.SQLEditorTableInfo.WaitForItemExists(20000);
				if(repo.Options.SQLEditorTable.Rows.Count == 9)
				{
					Reports.ReportLog("Validation : ValidateSQLEditorTable", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation failed : ValidateSQLEditorTable", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ValidateSQLEditorTable : " + e.Message);
			}
		}
		
		public static void ClickOnAutoComplete()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+Shift+U"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Reports.ReportLog("ClickOnAutoComplete", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnAutoComplete : " + e.Message);
			}
		}
		
		public static void ClickOnAutoCommit()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+Shift+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Reports.ReportLog("ClickOnAutoCommit", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnAutoCommit : " + e.Message);
			}
		}
		
		public static void SelectTableQuery()
		{
			try
			{
				repo10542.Application.QATextEditorInfo.WaitForItemExists(20000);
				repo10542.Application.QATextEditor.PressKeys(SELECTTABLE);
				System.Threading.Thread.Sleep(2000);
			}
			catch(Exception ex)
			{
				throw new Exception("CreateDatabaseQuery not working. "+ ex.Message);
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
		
		public static void EditQuery()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Reports.ReportLog("EditQuery", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : EditQuery : " + e.Message);
			}
		}
		
		public static void ClickOnEditorOk()
		{
			try
			{
				if(repo.EditoOptionsChanged.OkButtonInfo.Exists(new Duration(5000)))
				{
					repo.EditoOptionsChanged.OkButton.ClickThis();
					Reports.ReportLog("ClickOnEditorOk", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception e)
			{
				throw new Exception("Failed : ClickOnEditorOk : " + e.Message);
			}
		}
		
		public static void ClickOnExecute()
		{
			try
			{
				repo.Parameters.ExecuteInfo.WaitForItemExists(20000);
				repo.Parameters.Execute.ClickThis();
				Reports.ReportLog("ClickOnExecute", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception e)
			{
				
				throw new Exception("Failed : ClickOnExecute : " + e.Message);
			}
		}
	}
}
