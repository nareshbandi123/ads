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
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.TC_10543.TC1
{
    [TestModule("F4C4F04C-4209-40E9-9242-7226EE7BCBB1", ModuleType.UserCode, 1)]
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
        		Steps.ClickOnQuery();
        		Steps.ClickOnDisconnect();
        		Steps.ClickOnDisconnectYesButton();
        		Steps.ClickOnQuery();
        		Steps.ClickOnReconnect();
        		Steps.ClickOnReconnectYesButton();
        		Steps.ClickOnQuery();
        		Steps.ClickOnChangeServer();
        		Steps.SelectCassandra();
        		Steps.ClickOnOk();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        	}
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }

    }
}
