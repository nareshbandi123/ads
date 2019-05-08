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
    [TestModule("6D2961EB-680F-44E7-A7C5-D5C01A25A5E1", ModuleType.UserCode, 1)]
    public class CleanUp : BaseClass, ITestModule
    {
         public CleanUp()
        {
            
        }

         void ITestModule.Run()
        {
            StarProcess();
        }

 		bool StarProcess()
        {
        	try 
        	{
        		TreeItem server1 = Preconditions.Steps.GetServerTreeFromTCName("DB2_LUW_172.24.1.8_v11.1");
        		Preconditions.Steps.SelectedServerTreeItem = server1;
        		Preconditions.Steps.SelectedServerName = server1.Text;
        		server1.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		Preconditions.Steps.CloseTab(server1.Text);
        		System.Threading.Thread.Sleep(1000);
        		Preconditions.Steps.QueryAnalyser();
        		System.Threading.Thread.Sleep(1000);
        		if(Config.SchemaServers.Contains(server1.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);	
        		else
        			Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		
        		Preconditions.Steps.DropTable();
        		Preconditions.Steps.CloseTab(server1.Text);
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        		Preconditions.Steps.CloseTab(server1.Text);
        		
        		TreeItem server2 = Preconditions.Steps.GetServerTreeFromTCName("DB2_LUW_172.24.1.145_v10.5");
        		Preconditions.Steps.SelectedServerTreeItem = server2;
        		Preconditions.Steps.SelectedServerName = server2.Text;
        		server2.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		Preconditions.Steps.CloseTab(server2.Text);
        		Preconditions.Steps.QueryAnalyser();
        		System.Threading.Thread.Sleep(1000);
        		if(Config.SchemaServers.Contains(server2.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);	
        		else
        			Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		
        		Preconditions.Steps.DropTable();
        		Preconditions.Steps.CloseTab(server2.Text);
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        		Preconditions.Steps.CloseTab(server2.Text);
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
