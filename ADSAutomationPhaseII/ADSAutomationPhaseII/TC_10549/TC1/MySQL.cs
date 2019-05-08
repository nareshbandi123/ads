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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10549.TC1
{
    [TestModule("6E33B57B-6CBD-422A-94B0-3AE143BD01BE", ModuleType.UserCode, 1)]
    public class MySQL : BaseClass, ITestModule
    {
        
        public MySQL()
        {
            
        }

		void ITestModule.Run()
        {
        	if(Preconditions.Steps.isPreconditionDone){
				StartProcess();}
        }
        
        bool StartProcess()
        {
        	try 
        	{  
        		Steps.ClickOnTools();
        		Steps.ClickOnObjectSearch();
        		Steps.SelectADSDb();
        		Steps.ClickOk();
        		Steps.UnSelectObject();
        		Steps.SelectObjectType();
        		Steps.SelectColumnName();
        		Steps.SelectViewSource();//this is not there in cassandra
        		Steps.SearchText("id");
        		Steps.SearchButton();
        		Steps.ValidateTable(0);
        		Steps.SearchText("name");
        		Steps.AppendButton();
        		Steps.ValidateTable(2);
        		Steps.QuickFilter();
        		Steps.ValidateTable(1);
        	}
        	catch (Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        
        	return true;
        }
    }
}
