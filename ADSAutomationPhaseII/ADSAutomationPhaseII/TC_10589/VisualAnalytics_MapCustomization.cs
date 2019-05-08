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

namespace ADSAutomationPhaseII.TC_10589
{
    [TestModule("E4D7D669-114F-499F-8FCA-38CD6B1549DE", ModuleType.UserCode, 1)]
    public class VisualAnalytics_MapCustomization : ITestModule
    {
        public VisualAnalytics_MapCustomization()
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
        		Steps.ClickOnShowStateBorder();
        		Steps.SelectFilledMapVisualization();
        		//Steps.ValidateCheckedShowStateBorders();
        		Steps.SelectCity();
        		Steps.ShowLabelOptions();
        		//Steps.ValidateUnCheckedShowStateBorders();
        		
        		Steps.ClickOnCustomizeFilledMap();
        		Steps.AnalysisMapOnEditingLocation();
        		Steps.ScanLocationsTable();
        		Steps.ClickOnClose();
        		
        		Steps.ClickOnAmbiguousMap();
        		Steps.SelectFilledMapVisualization();
        		Steps.AnalysisMapOnEditingLocation();
        		Steps.SelectLocation();
        		
        		Steps.ClickOnBuildFilledMap();
        		Steps.ClickOnLabelAndColor();
        		Steps.ClickOnCloseViz();
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
