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

namespace ADSAutomationPhaseII.TC_10557
{
   
    [TestModule("418454E2-C86E-4110-859C-BB1CB7B3E1B9", ModuleType.UserCode, 1)]
    public class TableChartTemplate : BaseClass, ITestModule
    {
        
        public TableChartTemplate()
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
        		Steps.ValidateVAtestsdataWindow();
        		Steps.ChangeChartTypetoTable();
        		Steps.ValidateTableChart();
        		Steps.DragFreight();
        		Steps.ValidatetheModifiedResult();
        		Steps.SwapRowandColumn();
        		Steps.DragCardtypetoColor();
        		Steps.ValidateCardtypeColorchart();
        		Steps.DragSubtotaltoColor();
        		Steps.ValidateSubtotaleColorchart();
        		Steps.ClickOnSettingIcon();
        		Steps.ClickOnHighlight();
        		Steps.ValidateHighlightTable();
        		Steps.ClickCloseVA();
        	} 
        	catch (Exception ex)
        	{
        		Steps.ClickCloseVA();
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
    }
}
