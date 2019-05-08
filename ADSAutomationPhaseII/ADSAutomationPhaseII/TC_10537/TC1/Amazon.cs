using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Commons;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10537.TC1
{
    [TestModule("ABB32EFD-C841-477C-98C9-0594B6876064", ModuleType.UserCode, 1)]
    public class Amazon :Base.BaseClass, ITestModule
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
        		if (Steps.ConnectServer()) 
        		{
	        		Steps.OpenQueryAnalyzerTab();
	        		Steps.WriteQueryScript();
	        		Steps.SaveFile();
	        		Steps.CloseTab();
	        		Steps.ClickOpenFileMenu();
	        		Steps.OpenFile();
	        		Steps.SelectServer();
	        		Steps.CloseTab();
	        		Steps.Cleanup();
	        		Steps.DisconnectServer();
        		}
        	}
        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
