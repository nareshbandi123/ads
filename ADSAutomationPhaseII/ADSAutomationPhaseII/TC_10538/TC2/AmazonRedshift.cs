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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.TC_10538.TC2
{
    [TestModule("65A345E9-ABC9-402C-94B5-B79520B92672", ModuleType.UserCode, 1)]
    public class AmazonRedshift : BaseClass, ITestModule
    {
        public AmazonRedshift()
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
        		Steps.InsertQuery();
        		Steps.MorphToUpperCase();
        		Steps.Execute();
        		System.Threading.Thread.Sleep(5000);
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
        		System.Threading.Thread.Sleep(5000);
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
        		System.Threading.Thread.Sleep(5000);
        		Preconditions.Steps.CloseTab();
        		Steps.Discard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.WaitForQATabExist();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnDelete();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.EditDeleteQuery();
        		Steps.Execute();
        		System.Threading.Thread.Sleep(5000);
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
