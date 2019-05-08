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
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.TC_10538.TC1
{
    [TestModule("0DF2EE3A-F813-4893-8996-6308712C9133", ModuleType.UserCode, 1)]
    public class AmazonRedshift : BaseClass, ITestModule
    {
        public AmazonRedshift()
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
				Preconditions.Steps.CloseTab();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}
