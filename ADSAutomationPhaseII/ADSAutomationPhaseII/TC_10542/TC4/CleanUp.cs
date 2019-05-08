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

namespace ADSAutomationPhaseII.TC_10542.TC4
{
	[TestModule("D9957F98-DFAB-4258-8F92-61263BE14CA7", ModuleType.UserCode, 1)]
	public class CleanUp : BaseClass, ITestModule
	{
		public CleanUp()
		{
			
		}

		void ITestModule.Run()
		{
			if(Preconditions.Steps.isPreconditionDone)
				StarProcess();
		}

		bool StarProcess()
		{
			try
			{
				TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
				Preconditions.Steps.SelectedServerTreeItem = server;
				Preconditions.Steps.SelectedServerName = server.Text;
				Steps.ClickOnShowTextButton();
				Steps.ClickOnShowTextHistoryButton();
				Steps.ClickOnShowGridButton();
				Steps.ClickOnPivotGridButton();
				Steps.ClickOnFormButton();
				Steps.ClickOnExecutionPlanButton();
				Steps.ClickOnClientStatisticsButton();
				server.RightClick();
				Preconditions.Steps.DisconnectServer();
				Preconditions.Steps.CloseTab(server.Text);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(server.Text))
					Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else
					Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.DropTable();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(server.Text);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.DropDatabase();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(server.Text);
				Preconditions.Steps.isPreconditionDone=false;
			}
			catch (Exception e)
			{
				Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
			}
			return true;
		}
	}
}
