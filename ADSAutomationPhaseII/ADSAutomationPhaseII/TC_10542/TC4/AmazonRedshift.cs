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

namespace ADSAutomationPhaseII.TC_10542.TC4
{
    [TestModule("C38B211C-2F1F-42DF-B222-AC59BF9E97EC", ModuleType.UserCode, 1)]
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
        		Steps.ClickOnShowTextButton();
        		Steps.ClickOnShowTextHistoryButton();
        		Steps.ClickOnShowGridButton();
        		Steps.ClickOnPivotGridButton();
        		Steps.ClickOnFormButton();
        		Steps.ClickOnExecutionPlanButton();
        		Steps.ClickOnClientStatisticsButton();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.SelectTable();
        		Steps.ClickOnTextTab();
        		Steps.ClickOnTextHistoryTab();
        		Steps.ClickOnShowGridTab();
        		Steps.ClickOnPivotGridTab();
        		Steps.ClickOnFormTab();
        		Steps.ClickOnExecutionPlanTab();
        		Steps.ClickOnClientStatisticsTab();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        	}
        	catch(Exception e)
        	{
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }   
}
