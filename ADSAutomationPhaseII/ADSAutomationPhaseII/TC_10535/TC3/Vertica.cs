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
    [TestModule("43CB4AC2-D4C2-4D06-99F8-E207BF9476A4", ModuleType.UserCode, 1)]
    public class Vertica :Base.BaseClass, ITestModule
    {
        public Vertica()
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
        		Steps.SelectVerticaServer();
        		Steps.ClickOkButton();
        		Steps.SelectSchema();
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
