using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10547.TC20
{
    [TestModule("5AAF28AB-8B89-4E9A-A5FF-9701C54092B8", ModuleType.UserCode, 1)]
    public class MariaDB :Base.BaseClass, ITestModule
    {
        public MariaDB()
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
        		Steps.ExecuteTC20();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}
