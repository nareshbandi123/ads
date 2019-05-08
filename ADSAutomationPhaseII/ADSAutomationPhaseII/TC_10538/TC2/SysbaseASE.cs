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
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10538.TC2
{
    [TestModule("85B2D5A6-F25D-4859-AFB6-599BF79A2F85", ModuleType.UserCode, 1)]
    public class SysbaseASE : BaseClass, ITestModule
    {
        public SysbaseASE()
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
				Steps.WaitForQATabExist();        		        		
        		Steps.ClickOnAutomate();
        		Steps.ClickOnInsert();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.InsertQuery_SysbaseASE();
        		Steps.MorphToUpperCase();
        		Steps.Execute();
        		Preconditions.Steps.CloseTab();
        		Steps.Discard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.WaitForQATabExist();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.ClickOnAutomate();
        		Steps.ClickOnUpdate();
        		Steps.EditUpdateQuery();
        		Steps.MorphToLowerCase();
        		Steps.Execute();
        		Preconditions.Steps.CloseTab();
        		Steps.Discard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.WaitForQATabExist();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnSelect();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.EditSelectQuery();
        		Steps.MorphToDelimitedList();
        		Steps.FormatStatement();
        		Steps.Execute();
        		Preconditions.Steps.CloseTab();
        		Steps.Discard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.WaitForQATabExist();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnDelete();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.EditDeleteQuery();
        		Steps.Execute();
        		Preconditions.Steps.CloseTab();
        		Steps.Discard();    		
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
        
    }
}
