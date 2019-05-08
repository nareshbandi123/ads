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

namespace ADSAutomationPhaseII.TC_10538.TC1
{
    [TestModule("6A8A80A2-029E-4B09-85B6-FDD069860723", ModuleType.UserCode, 1)]
    public class Derby : BaseClass, ITestModule
    {
        public Derby()
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
	        	Steps.ClickOnServerProperties();
	        	Steps.ClickOnConnectionMonitorTab();
	        	Steps.SelectPingIdleConnection();
	        	Steps.ClickOnSave();
	        	Steps.ClickOnYes();
	        	Preconditions.Steps.QueryAnalyser();
	        	Steps.ClickOnTools();
	        	Steps.ClickOnConectionMonitor();
				Steps.ValidatePing();
				Steps.CloseConnectionMonitor();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        	
        }
    }
}
