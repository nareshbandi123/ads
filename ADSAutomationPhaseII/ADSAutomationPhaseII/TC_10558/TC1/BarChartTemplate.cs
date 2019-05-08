using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10558
{
   
    [TestModule("27EB5D08-6452-4696-8CAA-FB3CEBB0926F", ModuleType.UserCode, 1)]
    public class BarChartTemplate : BaseClass, ITestModule
    {
        
        public BarChartTemplate()
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
        		Steps.ChangeChartTypetoBar();
        		Steps.SelectEntireWindow();
        		Steps.ValidateBarChart();
        		Steps.ClickonLabel();
        		Steps.CheckMarkonShowData();
        		Steps.ValidateShowdataChart();
        		Steps.DragCurrencyCodetoColor();
        		Steps.ValidateCurrencycodeColorChart();
        		Steps.ClickonAxes();
        		Steps.SelectClustered();
        		Steps.ValidateClusteredOptionChart();
        		Steps.DragFreighttoRowDeck();
        		Steps.ValidateFreightDataChart();
        		Steps.ClickonAxes();
        		Steps.ClickonMergedAxes();
        		Steps.ValidateMergedSharedOptionChart();
        		Steps.ClickonAxes();
        		Steps.ClickonStacked();
        		Steps.ValidateStackedOptionChart();
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
