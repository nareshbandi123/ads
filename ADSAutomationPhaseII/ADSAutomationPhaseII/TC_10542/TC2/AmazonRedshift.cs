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

namespace ADSAutomationPhaseII.TC_10542.TC2
{
    [TestModule("1D958C2F-B6E9-4CB0-A1BC-F35E30F608EC", ModuleType.UserCode, 1)]
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
        		Steps.CreateDatabaseQuery();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnToggleStatementComment();
        		System.Threading.Thread.Sleep(200);
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnDiscard();
        		        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.CreateDatabaseQuery();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnToggleDoubleLineComment();
        		System.Threading.Thread.Sleep(200);
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnDiscard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.CreateDatabaseQuery();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnToggleMinusComment();
        		System.Threading.Thread.Sleep(200);
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnDiscard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.CreateDatabaseQuery();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnToggleBlockComment();
        		System.Threading.Thread.Sleep(200);
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnDiscard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.CreateTableQuery();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnToggleStatementComment();
        		System.Threading.Thread.Sleep(200);
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnDiscard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.CreateTableQuery();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnToggleDoubleLineComment();
        		System.Threading.Thread.Sleep(200);
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnDiscard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.CreateTableQuery();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnToggleMinusComment();
        		System.Threading.Thread.Sleep(200);
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnDiscard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.CreateTableQuery();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnToggleBlockComment();
        		System.Threading.Thread.Sleep(200);
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnDiscard();
        		Preconditions.Steps.isPreconditionDone=false;
        	}
        	catch(Exception e)
        	{
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnDiscard();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
        
    }
}
