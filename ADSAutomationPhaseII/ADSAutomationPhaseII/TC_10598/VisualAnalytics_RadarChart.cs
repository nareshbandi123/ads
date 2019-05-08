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


namespace ADSAutomationPhaseII.TC_10598
{
    [TestModule("F5C8C5FB-4753-4012-8080-3C92BE198609", ModuleType.UserCode, 1)]
    public class VisualAnalytics_RadarChart : ITestModule
    {
        public VisualAnalytics_RadarChart()
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
				Steps.ClickOnFileMenu();
        		Steps.ClickOnOpenMenu();
        		Steps.EnterFilePath();
        		Steps.ClickOnOpenButton();
        		Steps.ClickOnMaximize();
        		Steps.CreateNewWorksheet();
        		Steps.DragAtheleteToColumnPane();
        		Steps.DragTotalMedalsToRowsPane();
        		Steps.SelectRadarMapVisualization();
        		Steps.ValidateRadarMapChart();
        		Steps.ClickOnLabel();
        		Steps.ClickOnOptions();
        		Steps.ChooseArea();
        		Steps.ValidateAreaChart();
        		Steps.DragAtheleteToColor();
        		Steps.ClickOnOptions();
        		Steps.ChooseCircular();
        		Steps.ClickOnLabel();
        		Steps.SelectShowMeasure();
        		Steps.RemoveAthleteFromColor();
        		Steps.DragGoldMedalsToRows();
        		Steps.ValidateSplitGraph();
        		Steps.SelectMergeGraphs();
        		Steps.ValidateMergedGraph();
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
