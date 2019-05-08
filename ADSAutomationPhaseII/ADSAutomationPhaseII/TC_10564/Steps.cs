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

using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using System.Windows.Forms;

namespace ADSAutomationPhaseII.TC_10564
{
	
	public static class Steps
	{
		
		public static TC10564Repo repo = TC10564Repo.Instance;
		public static PreconditionRepo preRepo = PreconditionRepo.Instance;
		public static string MSEXCEL_PATH = System.Configuration.ConfigurationManager.AppSettings["MSEXCEL_PATH"].ToString();
		public static string TC_10556_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10556"].ToString();
		
		
		#region "step1"
		
		public static void ConnectServer()
		{
			try
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(30000);
				TreeItem amazonServer = preRepo.ServersList.LocalDBServersTreeItem.GetItem(ServerList.AmazonRedshift);
				Preconditions.Steps.SelectedServerTreeItem = amazonServer;
				Preconditions.Steps.SelectedServerName = ServerList.AmazonRedshift;
				amazonServer.Select();
				System.Threading.Thread.Sleep(2000);
				amazonServer.RightClickThis();
				Preconditions.Steps.ConnectServer();
				Preconditions.Steps.QueryAnalyser();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConnectServer : " + ex.Message);
			}
			
		}
		
		public static void ClickonOpenScript()
		{
			try
			{
				repo.QueyWindow.OpenScriptInfo.WaitForItemExists(1000);
				repo.QueyWindow.OpenScript.ClickThis();
				Reports.ReportLog("New Query popup window displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonOpenScript : " + ex.Message);
			}
			
		}
		
		public static void CancelOpenWindow()
		{
			try
			{
				repo.OpenWindow.CancelInfo.WaitForItemExists(1000);
				repo.OpenWindow.Cancel.ClickThis();
				Reports.ReportLog("CancelOpenWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CancelOpenWindow : " + ex.Message);
			}
			
		}
		
		public static void ClickonSaveQuery()
		{
			try
			{
				repo.QueyWindow.SaveQueryInfo.WaitForItemExists(1000);
				repo.QueyWindow.SaveQuery.ClickThis();
				Reports.ReportLog("Open popup window displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);

			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonSaveQuery : " + ex.Message);
			}
			
		}
		
		public static void CancelSaveWindow()
		{
			try
			{
				repo.SaveWindow.CancelInfo.WaitForItemExists(1000);
				repo.SaveWindow.Cancel.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CancelSaveWindow : " + ex.Message);
			}
			
		}
		
		public static void ClickonSaveQueryAs()
		{
			try
			{
				repo.QueyWindow.SaveQueryAs.ClickThis();
				Reports.ReportLog("Save popup window displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonSaveQueryAs : " + ex.Message);
			}
			
		}
		
		public static void Clickonsaveresult()
		{
			try
			{
				repo.QueyWindow.SaveResultInfo.WaitForItemExists(1000);
				repo.QueyWindow.SaveResult.ClickThis();
				Reports.ReportLog("Save Results window displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : Clickonsaveresult : " + ex.Message);
			}
			
		}
		
		public static void ClickonPrint()
		{
			try
			{
				repo.QueyWindow.PrintInfo.WaitForItemExists(1000);
				repo.QueyWindow.Print.ClickThis();
				Reports.ReportLog("Select  Tab to print window displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonPrint : " + ex.Message);
			}
			
		}
		
		public static void CancelPrintWindow()
		{
			try
			{
				repo.PrintWindow.CancelInfo.WaitForItemExists(1000);
				repo.PrintWindow.Cancel.ClickThis();
				Reports.ReportLog("CancelPrintWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CancelPrintWindow : " + ex.Message);
				
			}
			
		}
		
		public static void ClickonSelectBlock()
		{
			try
			{
				repo.QueyWindow.SelectBlockInfo.WaitForItemExists(1000);
				repo.QueyWindow.SelectBlock.ClickThis();
				Reports.ReportLog("ClickonSelectBlock", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonSelectBlock : " + ex.Message);
				
			}
			
		}
		
		public static void EntertheText()
		{
			try
			{
				repo.QueyWindow.TextWindowInfo.WaitForItemExists(500);
				repo.QueyWindow.TextWindow.PressKeys("Select");
				Reports.ReportLog("EntertheText", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
			
		}
		
		public static void ClickonCut()
		{
			try
			{
				repo.QueyWindow.CutInfo.WaitForItemExists(1000);
				repo.QueyWindow.Cut.ClickThis();
				Reports.ReportLog("TEXT in the query analyser window  erased", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonCut : " + ex.Message);
			}
			
		}
		
		public static void ClickonCopy()
		{
			try
			{
				repo.QueyWindow.CopyInfo.WaitForItemExists(1000);
				Reports.ReportLog("TEXT in the  query analyser window should be copied", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.QueyWindow.Copy.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonCopy : " + ex.Message);
			}
			
		}
		
		public static void ClickonPaste()
		{
			try
			{
				repo.QueyWindow.PasteInfo.WaitForItemExists(1000);
				Reports.ReportLog("TEXT in the  query analyser window should be Pasted", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.QueyWindow.Paste.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonPaste : " + ex.Message);
			}
			
		}
		
		public static void ClickonUndo()
		{
			try
			{
				repo.QueyWindow.UndoInfo.WaitForItemExists(1000);
				Reports.ReportLog("Last action  performed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.QueyWindow.Undo.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonUndo : " + ex.Message);
			}
			
		}
		
		public static void ClickonRedo()
		{
			try
			{
				repo.QueyWindow.RedoInfo.WaitForItemExists(1000);
				Reports.ReportLog("Find Search engine highlighted to use the option", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.QueyWindow.Redo.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonRedo : " + ex.Message);
			}
			
		}
		
		public static void ClickonFind()
		{
			try
			{
				repo.QueyWindow.Find.ClickThis();
				Reports.ReportLog("Replace search engine highlighted with replace, replace all, Exclude  options", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonFind : " + ex.Message);
			}
			
		}
		
		public static void Find()
		{
			try
			{
				repo.QueyWindow.SearchText.PressKeys("Select");
				Reports.ReportLog("Find", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : Find : " + ex.Message);
			}
			
		}
		
		public static void ClickOnReplace()
		{
			try
			{
				repo.QueyWindow.ReplaceInfo.WaitForItemExists(1000);
				repo.QueyWindow.Replace.ClickThis();
				Reports.ReportLog("ClickOnReplace", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnReplace : " + ex.Message);
			}
			
		}
		
		public static void Replace()
		{
			try
			{
				repo.QueyWindow.SearchText.PressKeys("Select");
				repo.QueyWindow.ReplaceButton.ClickThis();
				Reports.ReportLog("Replace", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : Replace : " + ex.Message);
			}
			
		}
		
		public static void CloseFindWindow()
		{
			try
			{
				repo.QueyWindow.CloseButtonInfo.WaitForItemExists(1000);
				repo.QueyWindow.CloseButton.Click();
				Reports.ReportLog("CloseFindWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseFindWindow : " + ex.Message);
			}
			
		}
		
		public static void ClickonLowerCase()
		{
			try
			{
				repo.QueyWindow.LowerCaseInfo.WaitForItemExists(1000);
				repo.QueyWindow.LowerCase.ClickThis();
				Reports.ReportLog("Selected text change to lowercase text", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);

			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonLowerCase : " + ex.Message);
			}
			
		}
		
		public static void ClickonUpperCase()
		{
			try
			{
				repo.QueyWindow.UpperCaseInfo.WaitForItemExists(1000);
				repo.QueyWindow.UpperCase.ClickThis();
				Reports.ReportLog("Selected text change to Uppercase text", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonUpperCase : " + ex.Message);
			}
			
		}
		
		public static void ClickonParse()
		{
			try
			{
				repo.QueyWindow.ParseInfo.WaitForItemExists(1000);
				repo.QueyWindow.Parse.ClickThis();
				Reports.ReportLog("Script parsed message displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonParse : " + ex.Message);
			}
			
		}
		
		public static void ClickonExecute()
		{
			try
			{
				repo.QueyWindow.Execute.ClickThis();
				Reports.ReportLog("Query executed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonExecute : " + ex.Message);
			}
			
		}
		
		public static void ClickonExecuteCurrent()
		{
			try
			{
				repo.QueyWindow.UpperCaseInfo.WaitForItemExists(1000);
				repo.QueyWindow.UpperCase.ClickThis();
				Reports.ReportLog("Selected Query should be executed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonExecuteCurrent : " + ex.Message);
			}
			
		}
		
		public static void ClickonExecuteEdit()
		{
			try
			{
				repo.QueyWindow.ExecuteEditInfo.WaitForItemExists(1000);
				repo.QueyWindow.ExecuteEdit.ClickThis();
				Reports.ReportLog("Execute Edit popup window displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonExecuteEdit : " + ex.Message);
			}
			
		}
		
		public static void ClickOk()
		{
			try
			{
				repo.TableWindow1.OkInfo.WaitForItemExists(1000);
				repo.TableWindow1.Ok.ClickThis();
				Reports.ReportLog("ClickOk", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOk : " + ex.Message);
			}
			
		}
		
		public static void ClickonExecuteExplain()
		{
			try
			{
				repo.QueyWindow.ExecuteExplainInfo.WaitForItemExists(1000);
				repo.QueyWindow.ExecuteExplain.ClickThis();
				Reports.ReportLog("Execution explain message displayed in detail", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);

			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonExecuteExplain : " + ex.Message);
			}
			
		}
		
		public static void ClickStop()
		{
			try
			{
				repo.QueyWindow.StopButtonInfo.WaitForItemExists(1000);
				repo.QueyWindow.StopButton.ClickThis();
				Reports.ReportLog("Execution stopped", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickStop : " + ex.Message);
			}
			
		}
		
		public static void ClickonAutoCommit()
		{
			try
			{
				repo.QueyWindow.AutoCommitInfo.WaitForItemExists(1000);
				repo.QueyWindow.AutoCommit.ClickThis();
				Reports.ReportLog("Autocommit set to ON displayed in the results pane window", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonAutoCommit : " + ex.Message);
			}
			
		}
		
		public static void ClickonCommit()
		{
			try
			{
				repo.QueyWindow.Commit.ClickThis();
				Reports.ReportLog("Commit succesful displayed in the results pane window", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonCommit : " + ex.Message);
			}
			
		}
		
		public static void ClickonRollback()
		{
			try
			{
				repo.QueyWindow.RollBack.ClickThis();
				Reports.ReportLog("Rollback succesful displayed in the results pane window", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonRollback : " + ex.Message);
			}
			
		}
		
		public static void Clickonreconnect()
		{
			try
			{
				repo.QueyWindow.Reconnect.ClickThis();
				Reports.ReportLog("Reconnect popup window Displayed with message", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : Clickonreconnect : " + ex.Message);
			}
			
		}
		
		public static void CloseReconnectWindow()
		{
			try
			{
				if(repo.ReConnectWindow.SelfInfo.Exists())
					repo.ReConnectWindow.Close.ClickThis();
				Reports.ReportLog("CloseReconnectWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseReconnectWindow : " + ex.Message);
			}
			
		}
		
		public static void CloseReconnection()
		{
			try
			{
				if(repo.ReConnect.SelfInfo.Exists())
				   repo.ReConnect.NOButton.ClickThis();
				Reports.ReportLog("Disconnect window  displayed with the message", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseReconnection : " + ex.Message);
			}
			
		}
		
		public static void ClickonDisconnect()
		{
			try
			{
				repo.QueyWindow.DisconnectInfo.WaitForItemExists(10000);
				repo.QueyWindow.Disconnect.ClickThis();
				Reports.ReportLog("Disconnect window  displayed with the message", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonDisconnect : " + ex.Message);
			}
			
		}
		
		public static void ClickNoButton()
		{
			try
			{
				if(repo.DisconnectWindow.SelfInfo.Exists())
					repo.DisconnectWindow.ClickNo.ClickThis();
					Reports.ReportLog("ClickNoButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickNoButton : " + ex.Message);
			}
		}
		
		public static void ClickonChangeserverconnection()
		{
			try
			{
				repo.QueyWindow.ChangeServer.ClickThis();
				Reports.ReportLog("Choose server or database popup window displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonChangeserverconnection : " + ex.Message);
			}
			
		}
		
		public static void CloseServerWindow()
		{
			try
			{
				repo.ServerConnectionWindow.CancelInfo.WaitForItemExists(1000);
				repo.ServerConnectionWindow.Cancel.ClickThis();
				Reports.ReportLog("CloseServerWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseServerWindow : " + ex.Message);
			}
			
		}
		
		public static void ClickonAutocomplete()
		{
			try
			{
				repo.QueyWindow.AutoComplete.ClickThis();
				Reports.ReportLog("Auto complete ON displayed in the results pane window", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonAutocomplete : " + ex.Message);
			}
			
		}

		public static void ClickonAutocompleteAll()
		{
			try
			{
				repo.QueyWindow.AutoCompleteAll.ClickThis();
				Reports.ReportLog("Auto complete on all schemas ON displayed in the results pane window", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonAutocompleteAll : " + ex.Message);
			}
			
		}
		
		public static void ClickonRefreshSchema()
		{
			try
			{
				repo.QueyWindow.RefreshSchema.ClickThis();
				Reports.ReportLog("Auto complete Schema refreshed displayed in the results pane window", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonRefreshSchema : " + ex.Message);
			}
			
		}
		
		public static void ClickonParametesrized()
		{
			try
			{
				repo.QueyWindow.ParameterizeInfo.WaitForItemExists(1000);
				repo.QueyWindow.Parameterize.ClickThis();
				Reports.ReportLog("ClickonParametesrized", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonParametesrized : " + ex.Message);
			}
			
		}
		
		#endregion
		
		
		public static void ClickonFile()
		{
			try
			{
				repo.Application.FileInfo.WaitForItemExists(25000);
				repo.Application.File.ClickThis();
				Reports.ReportLog("ClickonFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonFile : " + ex.Message);
			}
			
		}
		
		public static void VerifyFileOptions()
		{
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				List<string> fileNames = new List<string>(){ "New", "Open", "Open Recent", "New in current window", "Open in current window",
					"Save", "Save As", "Save all", "Save Results", "Print", "Mount Directory", "Unmount Directory", "New window",
					"Set Window Title", "Proxy settings", "Options", "Close window", "Exit" };
				
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyFileOptions : " + ex.Message);
			}
			
		}
		
		public static void ClickonEdit()
		{
			try
			{
				repo.Application.EditInfo.WaitForItemExists(1000);
				repo.Application.Edit.DoubleClick();
				Reports.ReportLog("ClickonEdit", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonEdit : " + ex.Message);
			}
			
		}
		
		public static void VerifyEditOptions()
		{
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				List<string> fileNames = new List<string>(){ "Cut", "Copy", "Paste", "Paste...", "Undo", "Redo", "Select All", "Find", "Find Next",
					"Find Previous", "Replace", "Find word at caret", "Go to Line…", "Toggle Bookmark", "Previous  Bookmark",
					"Next Bookmark", "To Lower Case", "To Upper Case", "Folding", "Next Highlighted Error", "Previous Highlighted Error", "Next Change", "Previous Change" };
				
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyEditOptions : " + ex.Message);
			}
			
		}
		
		public static void ClickonServer()
		{
			try
			{
				repo.Application.ServerInfo.WaitForItemExists(1000);
				repo.Application.Server.DoubleClick();
				Reports.ReportLog("ClickonServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonServer : " + ex.Message);
			}
			
		}
		
		public static void VerifyServerOptions()
		{
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				
				List<string> fileNames = new List<string>(){ "New server Group", "Delete server Group", "Register server clone", "Register server", "Register SSH server", "Unregister server",
					"Server properties", "Connect", "Disconnect", "Reconnect", "Query Analyzer", "Query Analyzer clone", "Query Analyzer clone with content",
					"Query Analyzer Window", "Query Builder", "Fluidshell", "Execute" };
				
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyServerOptions : " + ex.Message);
			}
			
		}
		
		public static void ClickonQuery()
		{
			try
			{
				repo.Application.QueryInfo.WaitForItemExists(1000);
				repo.Application.Query.DoubleClick();
				Reports.ReportLog("ClickonQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonQuery : " + ex.Message);
			}
			
		}
		
		public static void VerifyQueryOptions()
		{
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				List<string> fileNames =  new List<string>(){ "Parse", "Execute", "Execute current", "Execute edit", "Execute Explain", "Stop", "Describe", "Auto commit", "Commit", "Rollback", "Reconnect",
					"Disconnect", "Change server", "Reconnect All windows", "Disconnect All windows", "Auto complete", "Auto on all Schemas", "Refresh Auto Schema", "SQL History",
					"Show text", "Show text History", "Show DBMS_OUTPUT", "Show Grid", "Show Pivot Grid", "Show Form", "Show Execution plan", "Show Client Statistics" };
				
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyQueryOptions : " + ex.Message);
			}
			
		}
		
		public static void ClickonAutomate()
		{
			try
			{
				repo.Application.AutomateInfo.WaitForItemExists(2000);
				repo.Application.Automate.DoubleClick();
				Reports.ReportLog("ClickonAutomate", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonAutomate : " + ex.Message);
			}
			
		}
		
		public static void VerifyAutomateOptions()
		{
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				List<string> fileNames =  new List<string>(){ "Introduce INSERT statement", "Introduce UPDATE statement", "Introduce DELETE statement", "Introduce SELECT statement", "Introduce Coloumns",
					"Introduce Qualified Coloumns", "Introduce Value Stubs", "Toggle Statement Comment", "Toggle // Line Comment", "Toggle -- Line Comment",
					"Toggle /*  Block Comment", "Morph to Upper case", "Morph to Lower case", "Morph to Delimited List", "Format current statement", "Format script" };
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyAutomateOptions : " + ex.Message);
			}
			
		}
		
		public static void ClickonQueryBuilder()
		{
			try
			{
				repo.Application.QueryBuilderInfo.WaitForItemExists(1000);
				repo.Application.QueryBuilder.DoubleClick();
				Reports.ReportLog("ClickonQueryBuilder", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonQueryBuilder : " + ex.Message);
			}
			
		}
		
		public static void VerifyQueryBuilderOptions()
		{
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				List<string> fileNames = new List<string>(){ "New", "Open", "Open Recent" };
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyQueryBuilderOptions : " + ex.Message);
			}
			
		}
		
		public static void ClickonVisualAnalytics()
		{
			try
			{
				repo.Application.VisualAnalyticsInfo.WaitForItemExists(1000);
				repo.Application.VisualAnalytics.DoubleClick();
				Reports.ReportLog("ClickonVisualAnalytics", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonVisualAnalytics : " + ex.Message);
			}
			
		}
		
		public static void VerifyVisualAnalyticsOptions()
		{
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				List<string> fileNames = new List<string>() { "New", "Open", "Open Recent" };
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyVisualAnalyticsOptions : " + ex.Message);
			}
			
		}
		
		public static void ClickonERModeler()
		{
			try
			{
				repo.Application.ERModelerInfo.WaitForItemExists(1000);
				repo.Application.ERModeler.DoubleClick();
				Reports.ReportLog("ClickonERModeler", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonERModeler : " + ex.Message);
			}
			
		}
		
		public static void VerifyERModelerOptions()
		{
			
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				List<string> fileNames = new List<string>() { "New", "Open", "Open Recent", "Generate"};
				
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyERModelerOptions : " + ex.Message);
			}
			
		}
		
		public static void ClickonTools()
		{
			try
			{
				repo.Application.ToolsInfo.WaitForItemExists(1000);
				repo.Application.Tools.DoubleClick();
				Reports.ReportLog("ClickonTools", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonTools : " + ex.Message);
			}
			
		}
		
		public static void VerifyToolsOptions()
		{
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				List<string> fileNames = new List<string>() { "Import Data", "Export Data", "Schema Script generator", "Server Script generator",
					"Object search", "Compare Tools", "Compress Tool", "Key Generator", "Explain WhiteBoard", "Execution monitor", "Connection Monitor" };
				
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyToolsOptions : " + ex.Message);
			}
			
		}
		
		public static void ClickonDBATools()
		{
			try
			{
				repo.Application.DBAToolsInfo.WaitForItemExists(1000);
				repo.Application.DBATools.DoubleClick();
				Reports.ReportLog("ClickonDBATools", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonDBATools : " + ex.Message);
			}
			
		}
		
		public static void VerifyDBAToolsOptions()
		{
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				List<string> fileNames = new List<string>() { "Amazon Redshift", "DB2 -LUW", "Greenplum", "Informix", "MS SQL Server", "MySQL", "Netteza", "Oracle", "Paraccel", "PostgreSQL",
					"Sybase ASE", "Sybase Anywhere", "Sybase IQ", "Teredata aster Database", "Teredata Database", "Vertica" };
				
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyDBAToolsOptions : " + ex.Message);
			}
			
		}
		
		public static void ClickonWindow()
		{
			try
			{
				repo.Application.WindowInfo.WaitForItemExists(1000);
				repo.Application.Window.DoubleClick();
				Reports.ReportLog("ClickonWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonWindow : " + ex.Message);
			}
			
		}
		
		public static void VerifyWindowOptions()
		{
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				List<string> fileNames = new List<string>() { "MultiTab/Splitpane results", "Show/Hide Apllication Tool Bar", "Show/Hide Query Tool Bar", "Show/Hide Editor Window", "Show/Hide Query Results",
					"Restore/Hide All Panels", "Show/Hide Server Panel", "Show/Hide File Panel", "Show/Hide Project  Panel", "Show/Hide Detail Panel", "Restore Default Panel Layout",
					"Next Tab", "Previous tab", "Last Tab", "Next Inner Tab", "Rename current Tab", "Close current tab", "CloseAll but Current Tab", "Close All Tabs",
					"Focus/top Bottom Inside tab", "Focus Tree/Document" };
				
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyWindowOptions : " + ex.Message);
			}
			
		}
		
		public static void ClickonHelp()
		{
			try
			{
				repo.Application.HelpInfo.WaitForItemExists(1000);
				repo.Application.Help.DoubleClick();
				Reports.ReportLog("ClickonHelp", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonHelp : " + ex.Message);
			}
			
		}
		
		public static void VerifyHelpOptions()
		{
			try
			{
				repo.SunAwWindow.contextmenu.EnsureVisible();
				List<string> fileNames = new List<string>() { "Key Assistant", "Technical support", "Answers", "Online Documentation", "Community Discussions",
					"SQL log", "View Log", "Memory monitor", "License", "Support  Information", "Kerberos Information", "About Aqua Data Studio" };
				
				foreach (var item in repo.SunAwWindow.contextmenu.Items)
				{
					if(fileNames.Contains(item.Text))
						Reports.ReportLog("Option Displayed : "+ item.Text, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyHelpOptions : " + ex.Message);
			}
			
		}
		
	}
	
}


