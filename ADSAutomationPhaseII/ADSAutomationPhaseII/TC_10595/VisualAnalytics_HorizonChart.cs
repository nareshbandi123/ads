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
using ADSAutomationPhaseII.TC_10589;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10595
{
    [TestModule("46DFD782-A90D-49D0-AAC1-6187AE4C29E2", ModuleType.UserCode, 1)]
    public class VisualAnalytics_HorizonChart : ITestModule
    {
    	public static TC10589 repoRef = TC10589.Instance;
        public VisualAnalytics_HorizonChart()
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
        		Steps.DragStockDateToColumn();
        		Steps.DragStockSymbolToColumn();
        		Steps.SelectWeekNumber();
        		Steps.DragStockCloseToRows();
        		Steps.SelectHorizonMap();
        		Steps.SelectBand2();
        		Steps.SelectBand3();
        		Steps.EditColors();
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
