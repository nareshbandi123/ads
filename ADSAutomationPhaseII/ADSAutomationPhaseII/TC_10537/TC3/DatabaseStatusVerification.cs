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

namespace ADSAutomationPhaseII.TC_10537.TC3
{
    [TestModule("C6814A28-F938-4F21-97DF-9F97104F6D5D", ModuleType.UserCode, 1)]
    public class DatabaseStatusVerification :Base.BaseClass, ITestModule
    {
        public DatabaseStatusVerification()
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
        		Steps.CloseDetailsTab();
        		Steps.SelectSQLServerDatabase();
        		Steps.ClickOnDetailsTab();
        		Steps.SelectRows();
        		Steps.ValidateStatus();
        		Steps.ValidateDate();
        		Steps.ValidateSorting();
        		Steps.CloseDetailsTab();
        		Steps.DisconnectSqlServer();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
