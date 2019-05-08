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
using ADSAutomationPhaseII.TC_10556;

namespace ADSAutomationPhaseII.TC_10564
{
	
	[TestModule("A458CBEE-570F-4676-A16B-FB22330613EB", ModuleType.UserCode, 1)]
	public class ToolbarsandShortcutKeys : BaseClass, ITestModule
	{
		
		public ToolbarsandShortcutKeys()
		{
			
		}
		void ITestModule.Run()
		{
			StartProcess();
		}
		
		bool StartProcess()
		{
			try
			{
				Steps.ClickonFile();
				Steps.VerifyFileOptions();
				Steps.ClickonEdit();
				Steps.VerifyEditOptions();
				Steps.ClickonServer();
				Steps.VerifyServerOptions();
				Steps.ClickonQuery();
				Steps.VerifyQueryOptions();
				Steps.ClickonAutomate();
				Steps.VerifyAutomateOptions();
				Steps.ClickonQueryBuilder();
				Steps.VerifyQueryBuilderOptions();
				Steps.ClickonVisualAnalytics();
				Steps.VerifyVisualAnalyticsOptions();
				Steps.ClickonERModeler();
				Steps.VerifyERModelerOptions();
				Steps.ClickonTools();
				Steps.VerifyToolsOptions();
				Steps.ClickonDBATools();
				Steps.VerifyDBAToolsOptions();
				Steps.ClickonWindow();
				Steps.VerifyWindowOptions();
				Steps.ClickonHelp();
				Steps.VerifyHelpOptions();

				Steps.ConnectServer();
				Steps.ClickonOpenScript();
				Steps.CancelOpenWindow();
				Steps.ClickonSaveQuery();
				Steps.CancelSaveWindow();
				Steps.ClickonSaveQueryAs();
				Steps.CancelSaveWindow();
				Steps.Clickonsaveresult();
				Steps.ClickonPrint();
				Steps.CancelPrintWindow();
				Steps.ClickonSelectBlock();
				Steps.EntertheText();
				Steps.ClickonCut();
				Steps.ClickonCopy();
				Steps.ClickonPaste();
				Steps.ClickonUndo();
				Steps.ClickonRedo();
				Steps.ClickonFind();
				Steps.Find();
				Steps.CloseFindWindow();
				Steps.ClickOnReplace();
				Steps.Replace();
				Steps.CloseFindWindow();
				Steps.EntertheText();
				Steps.ClickonLowerCase();
				Steps.ClickonUpperCase();
				Steps.ClickonParse();
				Steps.ClickonExecute();
				Steps.ClickonExecuteCurrent();
				Steps.ClickonExecuteEdit();
				Steps.ClickOk();
				Steps.ClickonExecuteExplain();
				Steps.ClickStop();
				Steps.ClickonAutoCommit();
				Steps.ClickonCommit();
				Steps.ClickonRollback();
				Steps.Clickonreconnect();
				Steps.CloseReconnectWindow();
				Steps.CloseReconnection();
				Steps.ClickonDisconnect();
				Steps.CloseReconnectWindow();
				Steps.ClickNoButton();
				Steps.ClickonChangeserverconnection();
				Steps.CloseReconnectWindow();
				Steps.CloseServerWindow();
				Steps.ClickonAutocomplete();
				Steps.ClickonAutocompleteAll();
				Steps.ClickonRefreshSchema();
				Steps.ClickonParametesrized();
				TC_10556.Steps.ClickCloseTab();
				Preconditions.Steps.SelectedServerTreeItem.Select();
				Preconditions.Steps.DisconnectServer();
				Preconditions.Steps.isPreconditionDone = false;
			}
			catch (Exception ex)
			{
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
			}
			return true;
		}
	}
}
