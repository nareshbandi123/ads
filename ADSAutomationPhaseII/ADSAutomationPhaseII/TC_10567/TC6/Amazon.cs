using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10567.TC6
{
    [TestModule("0C7CF85C-9D7F-43CA-84F5-C403DE6B679D", ModuleType.UserCode, 1)]
    public class Amazon : Base.BaseClass, ITestModule
    {
        public Amazon()
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
        		Steps.SelectSchemaScriptGenerator_TC6();
        		Steps.ConfigureGeneralTab_TC6();
        		Steps.ConfigureOptionsTab_Preview_TC6();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;        	
        }
    }
}
