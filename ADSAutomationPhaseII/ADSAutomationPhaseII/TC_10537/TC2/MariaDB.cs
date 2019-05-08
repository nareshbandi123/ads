
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

namespace ADSAutomationPhaseII.TC_10537.TC2
{
    
    [TestModule("B4E4BBBF-200A-4E6E-83CB-557CFC1B9ED4", ModuleType.UserCode, 1)]
    public class MariaDB : Base.BaseClass, ITestModule
    {
       
        public MariaDB()
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
        		Steps.ClickOnToolsMenu();
        		Steps.ClickOnImport();
        		Steps.SelectServerImport();
        		Steps.ClickOkButton();
        		Steps.SelectImportFile();
        		Steps.ClickOnNext();
        		Steps.SelectTable();
        		Steps.ClickOnNext();
        		Steps.ClickOnNext();
        		Steps.ClickOnNext();
        		Steps.CheckImportStatus();
        	} 
        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
