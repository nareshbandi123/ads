﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10536.TC3
{
    [TestModule("01504233-C494-421E-B31A-44867D4CEDE6", ModuleType.UserCode, 1)]
    public class Netezza : BaseClass, ITestModule
    {
        public Netezza()
        {
            
        }
        
        void ITestModule.Run()
        {
        	if(Preconditions.Steps.isPreconditionDone)
	        	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{  
        		Preconditions.Steps.QueryAnalyserTab();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.SelectTable_ShortcutKey();
        		
        		Preconditions.Steps.QueryAnalyserTab();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB1, true);
        		Preconditions.Steps.SelectSecondTable_ShortcutKey();
        		
        		Steps.ClickOnTools();
				Steps.SelectCompareTools();
				Steps.SelectResultCompare();
				
				Steps.ClickOnResultTab();
				Steps.ClickOnResultSet1();
				Steps.ClickOnResultSet2();
				Steps.ClickOnOkButton();
				Steps.CompareResult();
				Steps.ClickOnRefresh();
				Steps.ClickOnResultTab();
				Steps.ClickOnResultListSet1();
				Steps.ClickOnResultListSet2();
				Steps.ClickOnOkButton();
				Steps.CompareResult();
				Steps.Save();
				Steps.Browse();				
				Steps.EnterFileName();
				Steps.SaveHtml();
				Steps.ClickOnOk();
				Steps.Navigate();
				Steps.ClickOnSpreadSheet();
				Steps.ResultCompareFilters();			
        	}
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        
        	return true;
        }
    }
}
