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
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10543.TC4
{
    [TestModule("E8F0CFED-D933-42BC-8284-22E9FAE3F2C2", ModuleType.UserCode, 1)]
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
        		Steps.ScanForMaxResultTables("2");
        		Steps.ClickOnOptionsOk();
        		Steps.ClickOnEditorOk();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.SelectTable();
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
