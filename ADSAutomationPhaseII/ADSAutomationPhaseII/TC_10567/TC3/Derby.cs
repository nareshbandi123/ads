using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10567.TC3
{
    [TestModule("5CF692D5-50EF-49CF-8653-AADA3CE54A51", ModuleType.UserCode, 1)]
    public class Derby :Base.BaseClass, ITestModule
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
        		Steps.ConfigureGeneralTab_TC3();
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
