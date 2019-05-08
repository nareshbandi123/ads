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

namespace ADSAutomationPhaseII.TC_10539.TC1
{
    [TestModule("41F0F76D-9680-4144-8704-3B9361C7495C", ModuleType.UserCode, 1)]
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
        		Preconditions.Steps.CloseTab();
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
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
				Preconditions.Steps.CloseTab(server.Text); 
				Preconditions.Steps.isPreconditionDone = true; 				
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
