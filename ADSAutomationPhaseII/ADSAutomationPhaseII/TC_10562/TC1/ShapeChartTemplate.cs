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


namespace ADSAutomationPhaseII.TC_10562
{
    
    [TestModule("17DDA4D9-BCA3-40FB-8CAC-E15F2086682C", ModuleType.UserCode, 1)]
    public class ShapeChartTemplate : BaseClass, ITestModule
    {
       
        public ShapeChartTemplate()
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
        		Steps.ChangeChartTypetoShape();
        		Steps.SelectEntireWindow();
        		Steps.ValidateShapeChart();
        		Steps.ClickonLabel();
        		Steps.CheckMarkonShowData();
        		Steps.ValidateShowData();
        		Steps.RightClickonShipDate();
        		Steps.RemoveShipdate();
        		Steps.ValidateAfterRemoveShipdate();
        		Steps.RightClickonCardType();
        		Steps.RemoveCardType();
        		Steps.ValidateAfterRemoveCardType();
        		Steps.DragFreighttoColumn();
        		Steps.ValidateDragFreighttoColumnChart();
        		Steps.DragCurrencytoColor();
        		Steps.ValidateDragCurrencytoColorChart();
        		Steps.DragFreighttoSizeDeck();
        		Steps.ValidateDragFreighttoSizeChart();
        		Steps.DragProducttoShapeDeck();
        		Steps.ValidateDragProducttoShapeChart();
        		Steps.SlidermovetoMinimum();
        		Steps.ValidateSliderMinimumChart();
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
