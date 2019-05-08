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
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10537.TC2
{
    [TestModule("18755A38-6A86-4A8C-92D5-39FB44E7CF9A", ModuleType.UserCode, 1)]
    public class Cleanup : Base.BaseClass, ITestModule
    {
        public Cleanup()
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
        		Reports.ReportLog("Cleanup-Started", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
        		Preconditions.Steps.SelectedServerTreeItem.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB);	
        		else
        			Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.DropTable();
        		Preconditions.Steps.CloseTab(Preconditions.Steps.SelectedServerName);
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        		Preconditions.Steps.CloseTab(Preconditions.Steps.SelectedServerName);
        		Preconditions.Steps.isPreconditionDone = false;
        		Reports.ReportLog("Cleanup-Completed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
        	} 
        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
    }
}
