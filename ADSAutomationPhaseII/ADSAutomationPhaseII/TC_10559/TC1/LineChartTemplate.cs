﻿
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

namespace ADSAutomationPhaseII.TC_10559
{
   
    [TestModule("91F51820-D221-49AE-9D8D-8D31427E7AC8", ModuleType.UserCode, 1)]
    public class LineChartTemplate : BaseClass, ITestModule
    {
        
        public LineChartTemplate()
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
        		Steps.ChangeChartTypetoLine();
        		Steps.SelectEntireWindow();
        		Steps.ValidateLineChart();
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
