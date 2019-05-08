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
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;

namespace ADSAutomationPhaseII.TC_10540.TC1
{
    [TestModule("BAE5E1DC-6F82-48C8-B59B-9C530B2DCB25", ModuleType.UserCode, 1)]
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
//        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
//        		Preconditions.Steps.SelectedServerTreeItem = server;
//        		Preconditions.Steps.SelectedServerName = server.Text;
        		Preconditions.Steps.SelectedServerTreeItem.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		System.Threading.Thread.Sleep(2000);
        		if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
    			else
    				Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.DropTable();
        		Preconditions.Steps.CloseTab(Preconditions.Steps.SelectedServerName);
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        		Preconditions.Steps.CloseTab(Preconditions.Steps.SelectedServerName);
				Preconditions.Steps.isPreconditionDone = false;        		
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        		
        	return true;
        }

    }
}
