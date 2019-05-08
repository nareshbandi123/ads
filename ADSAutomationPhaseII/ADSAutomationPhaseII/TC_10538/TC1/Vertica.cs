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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10538.TC1
{
    [TestModule("5A293680-C286-484F-BB95-425A0D82A0C2", ModuleType.UserCode, 1)]
    public class Vertica : BaseClass, ITestModule
    {
        public Vertica()
        {
            
        }
        
        void ITestModule.Run()
        {
        	if(Preconditions.Steps.isPreconditionDone)
	        	StartProcess();
        }
        
        bool StartProcess()
        {
        	try{
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
