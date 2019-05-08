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

namespace ADSAutomationPhaseII.TC_10556
{
    
    [TestModule("9F2AE20A-36CF-4F01-A231-4AEB37263051", ModuleType.UserCode, 1)]
    public class WorkbooksTemplate : BaseClass, ITestModule
    {
        public WorkbooksTemplate()
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
        		Steps.IsServerRegistered();
		  		Steps.ConnectServer();
        		Steps.ClickQARun();
        		Steps.ClickNewVA();
        		Steps.MoveToColumn();
        		Steps.MoveToRows();
        		Steps.RightClickData();
        		Steps.RenameData();
        		Steps.ClickOkButton();
        		Steps.SaveWorkBook();
        		Steps.EnterWorkbookName();
        		Steps.SaveButton();
        		Steps.OverrideYes();
        		Steps.ClickCloseVA();
        		Steps.ClickCloseTab();
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
    }
}
