using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10567.TC3
{
    [TestModule("1F72E681-A8DF-4561-B0A7-0C9A7468347F", ModuleType.UserCode, 1)]
    public class Precondition :Base.BaseClass, ITestModule
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
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
        		Preconditions.Steps.CloseTab(server.Text);  
	      		Preconditions.Steps.SelectedServerTreeItem = server;
	      		Preconditions.Steps.SelectedServerName = server.Text;
	      		server.RightClickThis();
        		Preconditions.Steps.ConnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.CreateDatabase();
        		Preconditions.Steps.CloseTab(server.Text);        		
        		Preconditions.Steps.QueryAnalyser();
        		if(Config.SchemaServers.Contains(server.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
    			else
    				Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.CreateTable();
        		Preconditions.Steps.CreateProcedure();
        		Preconditions.Steps.CloseTab(server.Text);
        	}
        	catch(Exception ex)
        	{
        		Preconditions.Steps.isPreconditionDone = false;
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;        	
        }
    }
}
