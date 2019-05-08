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

namespace ADSAutomationPhaseII.TC_10535.TC3
{
    [TestModule("50F19267-023E-4984-B668-2724DDB86DFA", ModuleType.UserCode, 1)]
    public class Cleanup : BaseClass, ITestModule
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
        		Reports.ReportLog("Failed : Cleanup : " + ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
