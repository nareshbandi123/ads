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
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10547.TC1
{
    [TestModule("4977EE06-7DCF-4AE5-9FC0-3E3BD9E3B31D", ModuleType.UserCode, 1)]
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
        		Steps.ConnectServer();
        		Steps.CreateDatabaseQA();        		
        		
        		Steps.CreateDBFromMenu1();
        		Steps.DropDBFromMenu1();
        		
        		Steps.CreateDBFromMenu2();
        		Steps.DropDBFromMenu2();
        		
        		Steps.CreateDBFromMenu3();
        		Steps.DropDBFromMenu3();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}
