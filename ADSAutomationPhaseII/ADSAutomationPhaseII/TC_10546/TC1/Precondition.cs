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

namespace ADSAutomationPhaseII.TC_10546.TC1
{
    [TestModule("D8973F49-0582-4F84-8F01-5B3C09DF8B58", ModuleType.UserCode, 1)]
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
        		TreeItem server1 = Preconditions.Steps.GetServerTreeFromTCName("DB2_LUW_172.24.1.8_v11.1");
	      		Preconditions.Steps.SelectedServerTreeItem = server1;
	      		Preconditions.Steps.SelectedServerName = server1.Text;
	      		server1.RightClickThis();
        		Preconditions.Steps.ConnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.Sleep();
        		Preconditions.Steps.CreateDatabase();
        		Preconditions.Steps.CloseTab(server1.Text);
        		Preconditions.Steps.QueryAnalyser();
        		System.Threading.Thread.Sleep(1000);
        		if(Config.SchemaServers.Contains(server1.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);	
        		else
        			Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.CreateTable();
        		Preconditions.Steps.CloseTab(server1.Text);
        		
        		TreeItem server2 = Preconditions.Steps.GetServerTreeFromTCName("DB2_LUW_172.24.1.145_v10.5");
	      		Preconditions.Steps.SelectedServerTreeItem = server2;
	      		Preconditions.Steps.SelectedServerName = server2.Text;
	      		server2.RightClickThis();
        		Preconditions.Steps.ConnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.Sleep();
        		Preconditions.Steps.CreateDatabase();
        		Preconditions.Steps.CloseTab(server2.Text);
        		Preconditions.Steps.QueryAnalyser();
        		System.Threading.Thread.Sleep(1000);
        		if(Config.SchemaServers.Contains(server2.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);	
        		else
        			Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.CreateTable();
        		Preconditions.Steps.CloseTab(server2.Text);
        		Preconditions.Steps.isPreconditionDone=true;
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
