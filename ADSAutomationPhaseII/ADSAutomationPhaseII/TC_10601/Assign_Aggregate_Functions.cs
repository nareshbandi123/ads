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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10589;

namespace ADSAutomationPhaseII.TC_10601
{
    [TestModule("9DD3B080-7F3E-4BBC-80D8-7E0315A6B573", ModuleType.UserCode, 1)]
    public class Assign_Aggregate_Functions : ITestModule
    {
    	public static TC10589 TC10589Repo = TC10589.Instance;
        public Assign_Aggregate_Functions()
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
        		TC_10589.Steps.ClickOnFileMenu();
        		TC_10589.Steps.ClickOnOpenMenu();
        		Steps.EnterFilePath();
        		TC_10589.Steps.ClickOnOpenButton();
        		TC_10589.Steps.ClickOnMaximize();
        		TC_10589.Steps.CreateNewWorksheet();
        		Steps.ClickOnSymbolMap();
        		Steps.DragOrderDateToColumn();
        		Steps.ClickOnOrderDate();
        		Steps.DragProfitToRow();
        		Steps.DragFreightToRow();
        		Steps.DragProductCategoryToFilter();
        		Steps.VisualAnalyticsMenu();
        		TC_10589.Steps.ClickOnCloseViz();
        		TC_10589.Steps.ClickOnDiscard();
        	}
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
        
    }
}
