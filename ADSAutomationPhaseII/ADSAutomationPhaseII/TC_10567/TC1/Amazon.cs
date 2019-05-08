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

namespace ADSAutomationPhaseII.TC_10567.TC1
{
    [TestModule("FB07BF25-B5B2-49F8-8647-98CFE24F015C", ModuleType.UserCode, 1)]
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
        		Steps.SelectSchemaScriptGenerator();
        		Steps.ConfigureGeneralTab();
        		Steps.ConfigureOptionsTab_Preview();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;        	
        }
    }
}
