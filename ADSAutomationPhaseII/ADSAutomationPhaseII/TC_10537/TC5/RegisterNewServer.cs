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

namespace ADSAutomationPhaseII.TC_10537.TC5
{
    [TestModule("D2B7D2C2-478F-4509-9246-CE1D614892FD", ModuleType.UserCode, 1)]
    public class RegisterNewServer :Base.BaseClass,  ITestModule
    {
        public RegisterNewServer()
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
        		Steps.SelectServerToRegister();
        		Steps.RegisterData();
        		Steps.ClickOnTestConnection();
        		
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
