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

namespace ADSAutomationPhaseII.TC_10563
{
    
    [TestModule("846027B6-01B5-40F9-9D4C-87D4F72953CF", ModuleType.UserCode, 1)]
    public class PieChartTemplate : BaseClass, ITestModule
    {
       
        public PieChartTemplate()
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
        		Steps.ChangeChartTypetoPie();
        		Steps.SelectEntireWindow();
        		Steps.ValidatePieChart();
        		Steps.ClickonLabel();
        		Steps.CheckMarkonShowData();
        		Steps.ValidateShowData();
        		Steps.RightClickonShipDate();
        		Steps.RemoveShipdate();
        		Steps.ValidateAfterRemoveShipdateChart();
        		Steps.RightClickonCardType();
        		Steps.RemoveCardType();
        		Steps.ValidateAfterRemoveCardTypeChart();
        		Steps.DragCardtypetoColor();
        		Steps.ValidateDragCardtypetoCOlorChart();
        		Steps.DragCurrencycodetoLabel();
        		Steps.ValidateDragCurrencycodetoLabelChart();
        		Steps.ClickonLabel();
        		Steps.SelectMeasuredValues();
        		Steps.ValidateSelectMeasuredValueChart();
        		Steps.ClickonOptionsButton();
        		Steps.ClickONButton();
        		Steps.ValidateONButtonChart();
        		Steps.DragProfittoColorDeck();
        		Steps.ValidateDragProfittoColorChart();
        		Steps.DragCardTypetoLabel();
        		Steps.ValidateDragCardTypetoLabelChart();
        		Steps.SetCenterHoleMax();
        		Steps.ValidateMaxHoleChart();
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
