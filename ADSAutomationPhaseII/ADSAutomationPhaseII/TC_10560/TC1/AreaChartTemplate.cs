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

namespace ADSAutomationPhaseII.TC_10560
{
    
    [TestModule("FEB13746-C451-4E06-8DA2-E5FA4F8FDE92", ModuleType.UserCode, 1)]
    public class AreaChartTemplate : BaseClass, ITestModule
    {
        
        public AreaChartTemplate()
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
        		Steps.ChangeChartTypetoArea();
        		Steps.SelectEntireWindow();
        		Steps.ValidateAreaChart();
        		Steps.ClickonLabel();
        		Steps.CheckMarkonShowData();
        		Steps.ValidateShowdata();
        		Steps.DragCurrencyCodetoColor();
        		Steps.ValidateCurrencycodeColorChart();
        		Steps.DragFreighttoRowDeck();
        		Steps.ValidateFreightdragtoRowChart();
        		Steps.ClickonAxes();
        		Steps.ClickonMergedAxes();
        		Steps.ValidateMergedSharedscaleChart();
        		Steps.ClickonAxes();
        		Steps.ClickonMergedSeparate();
        		Steps.ValidateMergedseparateOptionChart();
        		Steps.ClickonAxes();
        		Steps.ClickonDualAxes();
        		Steps.ValidateDualAxesOptionChart();
        		Steps.ClickonAxes();
        		Steps.ClickonUnstacked();
        		Steps.ValidateUnstackedOptionChart();
        		Steps.SwaptheRowandColumn();
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
