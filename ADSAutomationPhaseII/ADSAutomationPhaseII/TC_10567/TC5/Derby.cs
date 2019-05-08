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

namespace ADSAutomationPhaseII.TC_10567.TC5
{
    [TestModule("8D9CAAB2-6608-465C-AED4-E2128EA40008", ModuleType.UserCode, 1)]
    public class Derby : ITestModule
    {
        public Derby()
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
        		Steps.SelectSchemaScriptGenerator_TC3();
        		Steps.ConfigureGeneralTab_TC5();
        		Steps.ConfigureOptionsTab_Preview_TC3();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;        	
        }
    }
}
