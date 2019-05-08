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
    [TestModule("A1511EE1-EB96-465F-9B9F-BABE1F7BF583", ModuleType.UserCode, 1)]
    public class Cassandra : BaseClass, ITestModule
    {
        public Cassandra()
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
        		Steps.InsertQuery_Cassandra();
        		Steps.MorphToUpperCase();
        		Steps.Execute();
        		Preconditions.Steps.CloseTab();
        		Steps.Discard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.WaitForQATabExist();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnUpdate();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.EditCassandraUpdateQuery();
        		Steps.MorphToLowerCase();
        		Steps.Execute();
        		Preconditions.Steps.CloseTab();
        		Steps.Discard();
        		
        		Preconditions.Steps.QueryAnalyser();
        		Steps.WaitForQATabExist();
        		Steps.ClickOnAutomate();
        		Steps.ClickOnSelect();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.EditCassandraSelectQuery();
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
        		Steps.EditCassandraDeleteQuery();
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
