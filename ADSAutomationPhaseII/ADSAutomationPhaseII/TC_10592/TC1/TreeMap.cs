
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

namespace ADSAutomationPhaseII.TC_10592.TC1
{
    [TestModule("8BDE27B9-4090-4EA5-A73E-3BCB4EC37035", ModuleType.UserCode, 1)]
    public class TreeMap : BaseClass, ITestModule
    {
       
        public TreeMap()
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
        		Steps.ClickonWorkSheet();
        		Steps.ValidateTreeMapFile();
        		Steps.SelectNewWorkSheet();
        		TC_10593.Steps.SelectEntireWindow();
        		Steps.DragCoffeetoColumn();
        		Steps.ValidateAfterCoffeetoColumn();
        		Steps.DragGeographytoColumn();
        		Steps.ValidateAfterGeographytoColumn();
        		Steps.DragprofittoRow();
        		Steps.ValidateAfterDragprofittoRow();
        		Steps.ClickonVisualization();
        		Steps.ClickonTreeMap();
        		Steps.ValidateAfterClickonTreeMapIcon();
        		Steps.DeselectVisualization();
        		Steps.ClickonLabel();
        		Steps.SelectShowMeasureValues();
        		Steps.ValidateAfterClickonMeasuredValues();
        		Steps.ClickonOptions();
        		Steps.SelectAbsoluteValues();
        		Steps.ValidateAfterClickonAbsoluteValues();
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
