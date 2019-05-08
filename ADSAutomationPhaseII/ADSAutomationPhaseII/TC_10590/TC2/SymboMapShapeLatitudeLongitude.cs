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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10590.TC2
{
   
    [TestModule("67F48355-AC77-428F-BCCF-7117F7A9C9AF", ModuleType.UserCode, 1)]
    public class SymboMapShapeLatitudeLongitude : BaseClass, ITestModule
    {
        
        public SymboMapShapeLatitudeLongitude()
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
        		Steps.ClickonFileMenu();
        		Steps.ClickonOpen();
        		Steps.SelectNewFile();
        		Steps.ClickonOpenButton();
        		TC_10593.Steps.SelectEntireWindow();
        		Steps.ValidateSymboMapShape();
        		Steps.ClickonWorkSheet();        		
        		Steps.SelectNewWorkSheet();
        		TC_10593.Steps.SelectEntireWindow();
        		Steps.DragDimensionstoColumns1();
        		Steps.ValidateAfterDragDimensionstoColumns1();
        		Steps.DragMeasurestoRows1();
        		Steps.ValidateAfterDragMeasurestoRow1();
        		Steps.ClickonVisualization();
        		Steps.ClickonSymbolMapIcon();
        		Steps.DeselectVisualization();
        		Steps.ValidateAfterClickonSymbolMap();
        		Steps.ClickonShape();
        		Steps.ChangetoTriangleShape();
        		Steps.ValidateAfterChangetoTriangle1();
        		Steps.ClickonSize();
        		Steps.SizeDecrease();
        		Steps.ValidateAfterDecreaseSize();
        		Steps.SizeIncrease();
        		Steps.ValidateAfterDecreaseSize();
        		Steps.ClickonLongitude();
        		Steps.ShowFilter();
        		Steps.LongitudeSilderMoves();
        		Steps.ClickonLatitude();
        		Steps.ShowFilter();
        		Steps.LatitudeSilderMoves();        		
        		Steps.CloseVAWindow();
        		Steps.DiscardButton();
          		
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
