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

namespace ADSAutomationPhaseII.TC_10537.TC4
{
    
    [TestModule("B7D171FE-7991-4A37-B87F-CD7D33B68A86", ModuleType.UserCode, 1)]
    public class RegisterServerTabs : Base.BaseClass, ITestModule
    {
       public RegisterServerTabs()
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
        		Steps.ClickOnServer();
        		Steps.ClickOnRegisterServer();
        		Steps.ValidateRegisterServerWindowOpened();
        		Steps.ValidateTabs();
        		Steps.ClickOnClose();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
