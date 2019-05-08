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

namespace ADSAutomationPhaseII.TC_10547.TC22
{
    [TestModule("682A9F73-23B0-42AD-8CC8-1C1BF99C3B0D", ModuleType.UserCode, 1)]
    public class MySql :Base.BaseClass, ITestModule
    {
        public MySql()
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
        		Steps.ExecuteTC22();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}
