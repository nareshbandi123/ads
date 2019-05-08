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

namespace ADSAutomationPhaseII.TC_10545.TC1
{
    [TestModule("A7BF79AF-637F-4432-8047-C18404C3BA13", ModuleType.UserCode, 1)]
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
        		Steps.ClickOnTools();
        		Steps.ClickOnImport();
        		Steps.SelectServer();
        		Steps.SelectExcelFile();
        		Steps.ClickOnNext();
        		Steps.ClickOnNext();
        		Steps.SelectDestinationDropdown(0);
        		Steps.ClickOnNext();
        		Steps.ClickOnNext();
        		Steps.ClickOnNext();
        		Steps.CheckImportStatus();
        		Steps.ClickOnCloseButton();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;        	
        }
    }
}
