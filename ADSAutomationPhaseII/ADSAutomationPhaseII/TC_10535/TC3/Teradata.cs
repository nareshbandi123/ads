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

namespace ADSAutomationPhaseII.TC_10535.TC3
{
    [TestModule("07742ED1-C936-48AA-9D94-97FD7186FAF4", ModuleType.UserCode, 1)]
    public class Teradata : Base.BaseClass, ITestModule
    {
        public Teradata()
        {
            
        }

        void ITestModule.Run()
        {
            if(Preconditions.Steps.isPreconditionDone)
				StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{
        		Steps.ClickOnToolMenu();
        		Steps.ClickOnExportMenu();
        		Steps.SelectServer();
        		Steps.ClickOkButton();
        		Steps.UnselectObjectTypes();
        		Steps.SelectTables();
        		Steps.UnselectObjectType();
        		Steps.SelectADSTable();
        		Steps.ClickNext();
        		Steps.SetFilePath();
        		Steps.ClickNext();
        		Steps.ClickClose();
        	} 
        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
