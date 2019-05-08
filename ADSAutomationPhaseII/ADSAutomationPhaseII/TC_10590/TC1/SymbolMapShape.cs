
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
using ADSAutomationPhaseII.TC_10593;

namespace ADSAutomationPhaseII.TC_10590.TC1
{
  
    [TestModule("B1BFCC62-B9BD-45DC-8E7D-CDDBD9165FF5", ModuleType.UserCode, 1)]
    public class SymbolMapShape : BaseClass, ITestModule
    {
       
        public SymbolMapShape()
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
        		Steps.DragDimensionstoColumns();
        		Steps.ValidateAfterDragStateandPCtoColumn();
        		Steps.DragMeasurestoRows();
        		Steps.ValidateAfterDragProfittoRow();
        		Steps.ClickonVisualization();
        		Steps.ClickonSymbolMapIcon();
        		Steps.DeselectVisualization();
        		Steps. ValidateAfterClickonSymbolMapIcon();
        		Steps.DragProducttoColorDeck();
        		Steps.ValidateAfterDragPCtoColor();
        		Steps.ClickonShape();
        		Steps.ChangetoTriangleShape();
        		Steps.ValidateAfterChangetoTriangeShape();
        		Steps.ChangetoCircleShape();
        		Steps.ClickonSize();
        		Steps.SizeDecrease();
        		Steps.ValidateAfterDecreaseSize();
        		Steps.SizeIncrease();
        		Steps.ValidateAfterIncreaseSize();
        		Steps.ClickonProductItem();
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
