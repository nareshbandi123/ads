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

using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;

namespace ADSAutomationPhaseII.TC_10537.TC2
{
    [TestModule("0CA21F2C-E8E2-4646-AD1B-30E1BDF83ABA", ModuleType.UserCode, 1)]
    public class Precondition : Base.BaseClass, ITestModule
    {
        public Precondition()
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
        		Reports.ReportLog("Preconditions-Started", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
        		Preconditions.Steps.SelectedServerTreeItem = server;
        		Preconditions.Steps.SelectedServerName = server.Text;
        		server.RightClickThis();
        		Preconditions.Steps.ConnectServer();
        		if(server.Items.Count > 1)
        		{
	        		Preconditions.Steps.QueryAnalyser();
	        		Preconditions.Steps.CreateDatabase();
	        		Preconditions.Steps.CloseTab(server.Text);
	        		Preconditions.Steps.QueryAnalyser();
	        		if(Config.SchemaServers.Contains(server.Text))
	        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB);	
	        		else
	        			Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
	        		Preconditions.Steps.CreateTable();
					Preconditions.Steps.CloseTab(server.Text); 
					Preconditions.Steps.isPreconditionDone = true;
					Reports.ReportLog("Preconditions-Completed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
        		}
        		else
        		{
        			// Log failed due to Server down
        			server.Collapse();
        			Preconditions.Steps.isPreconditionDone = false;
        		}
        	} 
        	catch (Exception ex) 
        	{
        		Preconditions.Steps.isPreconditionDone = false;
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
