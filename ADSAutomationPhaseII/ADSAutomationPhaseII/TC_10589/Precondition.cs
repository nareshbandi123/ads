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
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10589
{
    [TestModule("D037A01C-42B1-48BE-B95D-973269E17B86", ModuleType.UserCode, 1)]
    public class Precondition : BaseClass, ITestModule
    {
    	public static string TC_10589_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10589_Path"].ToString();
        public Precondition()
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
        		Steps.ClickOnFileMenu();
        		Steps.ClickOnOpenMenu();
        		Steps.EnterFilePath();
        		Steps.ClickOnOpenButton();
        		Steps.ClickOnMaximize();
        	}

        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
