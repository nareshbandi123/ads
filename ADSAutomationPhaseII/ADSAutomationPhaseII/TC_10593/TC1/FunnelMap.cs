
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


namespace ADSAutomationPhaseII.TC_10593.TC1
{
   
    [TestModule("F1087D36-AB2E-4F7A-AEBB-F2790767A66E", ModuleType.UserCode, 1)]
    public class FunnelMap : BaseClass, ITestModule
    {
        
        public FunnelMap()
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
        		Steps.ValidateFunnelMapFile();
        		Steps.ClickonWorkSheet();
        		Steps.SelectNewWorkSheet();
        		Steps.SelectEntireWindow();
        		Steps.DragStagetoColumn();
        		Steps.ValidationAfterDragStagetoColumn();
        		Steps.DragAPACtoRow();
        		Steps.ValidationAfterDragAPACtoColumn();
        		Steps.ClickonVisualization();
        		Steps.ClickonFunnelIcon();
        		Steps.DeselectVisualization();
        		Steps.ValidationAfterClickonFunnelIcon();
        		Steps.ClickonLabel();
        		Steps.SelectShowMeasurePercentage();
        		Steps.ValidationAfterClickonMeasurePercentage();
        		Steps.ClickonOptions();
        		Steps.SelectPyramid();
        		Steps.ValidationAfterClickonPyramidOption();
        		Steps.SelectUniformHeight();
        		Steps.ValidationAfterClickonUniformHeight();
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
