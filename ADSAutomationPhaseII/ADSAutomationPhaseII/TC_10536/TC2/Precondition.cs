using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Extensions;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10536.TC2
{
    [TestModule("627A0467-778E-446D-B1AB-4BCE1FECC59F", ModuleType.UserCode, 1)]
    public class Precondition : BaseClass, ITestModule
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
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase1();
				Preconditions.Steps.CloseTab(server.Text);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(server.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB1_CAPS);
    			else
    				Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB1);
				Preconditions.Steps.CreateTable2();
				Preconditions.Steps.CloseTab(server.Text);	
				Preconditions.Steps.isPreconditionDone = true;				
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
