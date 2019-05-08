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
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10543.TC3
{
    [TestModule("C91D05D3-2968-4258-8B78-D035CD87E27A", ModuleType.UserCode, 1)]
    public class AmazonRedshift : BaseClass, ITestModule
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
        		Steps.ClickOnFileMenu();
        		Steps.ClickOnOptions();
        		Steps.ClickOnQueryAnalyser();
        		Steps.ClickOnAmazonRedshift();
        		Steps.ScanForTables();
        		Steps.ClickOnOptionsOk();
        		Steps.ClickOnEditorOk();
        		Preconditions.Steps.QueryAnalyser();
        		System.Threading.Thread.Sleep(2000);
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.SelectDatabaseQuery();
        		Steps.ClickOnExecute();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnDiscard();
        	}
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
        
    }
}
