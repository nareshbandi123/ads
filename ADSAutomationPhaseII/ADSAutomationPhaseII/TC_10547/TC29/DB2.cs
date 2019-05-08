using System;
using System.Threading;
using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10547.TC29
{
    [TestModule("DD7752AB-D59B-43B7-8297-60B351B7C6FA", ModuleType.UserCode, 1)]
     public class DB2 : Base.BaseClass, ITestModule
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
        		Steps.ExecuteTC29();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}
