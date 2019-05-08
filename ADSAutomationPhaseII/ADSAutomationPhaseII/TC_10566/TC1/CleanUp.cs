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

namespace ADSAutomationPhaseII.TC_10566.TC1
{
	[TestModule("5BF6A58C-C71C-4A5E-960B-0ADEE8B160F0", ModuleType.UserCode, 1)]
	public class CleanUp : BaseClass, ITestModule
	{
		public CleanUp()
		{
			
		}
		
		void ITestModule.Run()
		{
			if(Preconditions.Steps.isPreconditionDone)
				StartProcess();
		}
		
		bool StartProcess()
		{
			try
			{
				TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
				Preconditions.Steps.SelectedServerTreeItem = server;
				Preconditions.Steps.SelectedServerName = server.Text;
				server.RightClick();
				Preconditions.Steps.ConnectServer();
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(server.Text))
					Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else
					Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.DropTable();
				Preconditions.Steps.CloseTab(server.Text);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.DropDatabase();
				Preconditions.Steps.CloseTab(server.Text);
				Preconditions.Steps.isPreconditionDone = false;
			}
			catch(Exception){}
			
			return true;
		}
	}
}
