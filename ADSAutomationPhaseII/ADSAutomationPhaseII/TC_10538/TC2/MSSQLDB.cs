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
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10538.TC2
{
    [TestModule("955F06C0-072A-4A45-8374-CFE5CA631079", ModuleType.UserCode, 1)]
    public class MSSQLDB : BaseClass, ITestModule
    {
        public MSSQLDB()
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
        		Steps.InsertQuery_SQLSERVER();
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
