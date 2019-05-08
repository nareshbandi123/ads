
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
 

namespace ADSAutomationPhaseII.TC_10591.TC1
{
   
    [TestModule("187B98C4-2421-4688-AAA2-11501D43787B", ModuleType.UserCode, 1)]
    public class SymbolMapPie : BaseClass, ITestModule
    {
       
        public SymbolMapPie()
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
        		Steps.DragStatetoColumn();
        		Steps.DragProductCategorytoColumn();
        		Steps.DragProfittoRow();
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
        		Steps.DragPCtoColorDeck();
        		Steps.ClickonAnyPCIteminChart();
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
