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

namespace ADSAutomationPhaseII.TC_10543.TC2
{
    [TestModule("DC3D7A05-AEC7-4FC5-A1EE-95EF1FCAC1F7", ModuleType.UserCode, 1)]
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
        		Steps.ClickOnFileMenu();
        		Steps.ClickOnOptions();
        		Steps.ClickOnSQLEditor();
        		Steps.ClickOnAutoCompletion();
        		Steps.ValidateSQLEditorTable();
        		Steps.ClickOnOptionsOk();
        		Preconditions.Steps.QueryAnalyser();
        		Steps.ClickOnQuery();
        		Steps.ClickOnAutoComplete();
        		Steps.SelectTableQuery();
        		Steps.ClickOnQuery();
        		Steps.ClickOnAutoComplete();
        		Steps.EditQuery();
        		Steps.SelectTableQuery();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnDiscard();
        		Preconditions.Steps.QueryAnalyser();
        		Steps.ClickOnQuery();
        		Steps.ClickOnAutoCommit();
        		Steps.ClickOnQuery();
        		Steps.ClickOnAutoCommit(); 
				Preconditions.Steps.CloseTab(Config.TestCaseName); 
				Steps.ClickOnDiscard();
				Preconditions.Steps.isPreconditionDone = false;				
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
