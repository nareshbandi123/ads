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
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.Application
{
    [TestModule("98A3A20A-D05D-4B7C-9B0A-E54BA854B07C", ModuleType.UserCode, 1)]
    public class OpenADS : BaseClass, ITestModule
    {
    	AppRepo repo = AppRepo.Instance;
    	
        public OpenADS()
        {
        }

        void ITestModule.Run()
        {
            StartProcess();
        }
        
        void StartProcess()
        {
        	try 
        	{
        		Ranorex.Host.Local.OpenADSApp();
        		repo.Application.SelfInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
        		if(repo.Application.SelfInfo.Exists(Commons.Common.ApplicationOpenWaitTime))
        		{
        			repo.Application.Self.Activate();
        			Reports.ReportLog("ADS Application Open", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        		}
        		else
        		{
        			Reports.ReportLog("ADS Application failed to open in given time duration(3M)", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        			StartProcess();
        		}
        	} 
        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.Message.ToString(), Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        }
    }
}
