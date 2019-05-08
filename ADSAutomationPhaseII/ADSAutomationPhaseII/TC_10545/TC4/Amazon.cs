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

namespace ADSAutomationPhaseII.TC_10545.TC4
{
    [TestModule("692451DB-0A90-42B3-A231-FDC807445E61", ModuleType.UserCode, 1)]
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
        		Steps.ClickOnExport();
        		Steps.SelectServer();
        		Steps.ScanForTables();
        		Steps.ScanForADSTable();
        		Steps.ClickOnExportNext();
        		Steps.SelectExportDestinationDropdown(0);
        		Steps.EnterExportFilePathToSave();
        		Steps.ClickOnExportNext();
        		Steps.CheckExportStatus();
        		Steps.ClickOnExportCloseButton();
        		Steps.ValidateExportFile();
        		
        		Steps.ClickOnTools();
        		Steps.ClickOnExport();
        		Steps.SelectServer();
        		Steps.ScanForTables();
        		Steps.ScanForADSTable();
        		Steps.ClickOnExportNext();
        		Steps.SelectExportDestinationDropdown(1);
        		Steps.ClickOnExportNext();
        		Steps.ClickOnExportCloseButton();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;        	
        }
    }
}
