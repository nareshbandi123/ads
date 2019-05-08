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

namespace ADSAutomationPhaseII.TC_10535.TC3
{
    [TestModule("EEA77885-8F35-4D6C-A0E5-95494AEA4DAF", ModuleType.UserCode, 1)]
    public class Postgre :Base.BaseClass, ITestModule
    {
        public Postgre()
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
