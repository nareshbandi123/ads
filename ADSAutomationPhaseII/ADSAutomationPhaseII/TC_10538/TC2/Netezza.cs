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
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10538.TC2
{
    [TestModule("102CA4ED-F5C5-4509-957B-2B761412D896", ModuleType.UserCode, 1)]
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
				Steps.WaitForQATabExist();        		        		
        		Steps.ClickOnAutomate();
        		Steps.ClickOnInsert();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.InsertQuery_Netezza();
        		Steps.MorphToUpperCase();
        		Steps.Execute();
        		Preconditions.Steps.CloseTab();
        		Steps.Discard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.WaitForQATabExist();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.ClickOnAutomate();
        		Steps.ClickOnUpdate();
        		Steps.EditNetezzaUpdateQuery();
        		Steps.MorphToLowerCase();
        		Steps.Execute();
        		Preconditions.Steps.CloseTab();
        		Steps.Discard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.WaitForQATabExist();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnSelect();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.EditNetezzaSelectQuery();
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
        		Steps.EditNetezzaDeleteQuery();
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
