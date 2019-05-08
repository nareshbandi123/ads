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

namespace ADSAutomationPhaseII.TC_10596
{
    [TestModule("86052F57-CBD9-42C5-AC6C-9E5D541EF96E", ModuleType.UserCode, 1)]
    public class VisualAnalytics_MekkoChart : BaseClass, ITestModule
    {
    	public static TC10589 TC10589Repo = TC10589.Instance;
        public VisualAnalytics_MekkoChart()
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
        		Steps.DragCoffeeAndGeographyToColumns();
        		Steps.DragProfitToRows();
        		Steps.SelectMekkoMapVisualization();
        		Steps.ValidateMekkoChart();
        		Steps.SelectShowColumnTotal();
        		Steps.ValidateMekkoShowColumn();
        		Steps.SelectShowColumnPercent();
        		Steps.ValidateMekkoShowPercent();
        		Steps.SelectMeasurePercent();
        		Steps.ValidateMeasurePercent();
        		Steps.SelectAbsoluteValues();
        		Steps.ValidateAbsoluteValueChart();
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
