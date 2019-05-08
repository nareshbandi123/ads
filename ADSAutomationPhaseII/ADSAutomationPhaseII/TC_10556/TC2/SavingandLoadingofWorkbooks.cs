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

namespace ADSAutomationPhaseII.TC_10556.TC2
{
    
    [TestModule("ACFAC4F5-3326-4665-9951-0579A833B451", ModuleType.UserCode, 1)]
    public class SavingandLoadingofWorkbooks : BaseClass, ITestModule
    {
        
        public SavingandLoadingofWorkbooks()
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
        		Steps.SelecttheFile();
        		Steps.ClickonOpenButton();
        		Steps.RightClickonSalesData();
        		Steps.ClickonExtract();
        		Steps.EntertheFileName();
        		Steps.SaveExtractFile();
        		Steps.OverrideNo();
        		Steps.ClickonVAFileMenu();
        		Steps.SelectExportWorkBook();
        		Steps.ConfirmContinue();
        		Steps.ProvideFileName();
        		Steps.ClickOnSaveButton();
        		Steps.OverrideNo();
        		Steps.ClickCloseVA();
        		Steps.ClickonFileMenu();
        		Steps.ClickonOpen();
        		Steps.SelectNewFile();
        		Steps.ClickonOpenButton();
        		Steps.ClickCloseVA();
        		
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
    }
}
