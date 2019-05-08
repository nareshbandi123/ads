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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.TC_10542.TC3
{
    [TestModule("983C2C6F-7461-4772-96CC-5EFAAB101643", ModuleType.UserCode, 1)]
    public class AmazonRedshift :Base.BaseClass, ITestModule
    {
        public AmazonRedshift()
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
        		Steps.ClickOnTools();
        		Steps.ClickOnSeverScriptGenerator();
        		Steps.ClickOnGeneralTab();
        		Steps.ScanForLeftTables();
        		Steps.ClickOnDeselectObject();
        		Steps.ScanForRightTables();
        		Steps.ClickOnNextButton();
        		Steps.BrowseFolderLocation();
        		Steps.ClickOnNextButton();
        		Steps.ClickOnCloseButton();
        		Steps.ClickOnFile();
        		Steps.ClickOnOpenMenuItem();
        		Steps.OpenSqlFile();
        		Steps.ClickOpen();
        		Steps.SelectServer();
        		Steps.ClickOpenQueryAnalyser();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        	}
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}
