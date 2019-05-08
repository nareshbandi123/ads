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

using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.TC_10593;
using ADSAutomationPhaseII.TC_10590;

namespace ADSAutomationPhaseII.TC_10591.TC2
{
   
    [TestModule("AD6615F9-2D52-4510-A012-30B9DCF1E44D", ModuleType.UserCode, 1)]
    public class SymboMapPieLatitudeLongitude : BaseClass, ITestModule
    {
       
        public SymboMapPieLatitudeLongitude()
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
        		TC_10593.Steps.ClickonFileMenu();
        		TC_10593.Steps.ClickonOpen();
        		Steps.SelectNewFile();
        		TC_10593.Steps.ClickonOpenButton();
        		TC_10593.Steps.SelectEntireWindow();        		
        		TC_10593.Steps.ClickonWorkSheet();
        		TC_10593.Steps.SelectNewWorkSheet();
        		TC_10593.Steps.SelectEntireWindow();
        		Steps.DragLongitudetoColumn();
        		Steps.DragLatitudetoColumn();
        		Steps.DragProfittoRow1();
        		Steps.ClickonAutomatic();
        		Steps.ChangeChartTypetoPie();
        		TC_10590.Steps.ClickonVisualization();
        		TC_10590.Steps.ClickonSymbolMapIcon();
        		TC_10590.Steps.DeselectVisualization();
        		TC_10590.Steps.ClickonShape();
        		TC_10590.Steps.ChangetoTriangleShape();
        		TC_10590.Steps.ChangetoCircleShape();
        		TC_10590.Steps.ClickonSize();
        		TC_10590.Steps.SizeDecrease();
        		TC_10590.Steps.SizeIncrease();
        		TC_10590.Steps.ClickonLongitude();
        		TC_10590.Steps.ShowFilter();
        		TC_10590.Steps.LongitudeSilderMoves();        		
        		TC_10590.Steps.ClickonLatitude();
        		TC_10590.Steps.ShowFilter();
        		TC_10590.Steps.LatitudeSilderMoves();
        		TC_10593.Steps.CloseVAWindow();
        		TC_10593.Steps.DiscardButton();
          		
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
