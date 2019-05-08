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

namespace ADSAutomationPhaseII.TC_10567.TC7
{
    [TestModule("D8FC8CA2-7087-42F6-96C3-9529A9A519E4", ModuleType.UserCode, 1)]
    public class DB2 : Base.BaseClass,  ITestModule
    {
        public DB2()
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
        		Steps.SelectSchemaScriptGenerator_TC7();
        		Steps.ConfigureGeneralTab_TC7();
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
