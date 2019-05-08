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

namespace ADSAutomationPhaseII.TC_10549.TC1
{
    [TestModule("1005BBD8-F154-4E1A-A654-659F19EB047D", ModuleType.UserCode, 1)]
    public class Oracle : BaseClass, ITestModule
    {
        public Oracle()
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
        		Steps.SelectADSDB();
        		Steps.ClickOk();
        		Steps.UnSelectObject();
        		Steps.SelectObjectType();
        		Steps.SelectColumnName();
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
