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
    [TestModule("683FBEF8-127B-42D5-9DE7-09598EB3894D", ModuleType.UserCode, 1)]
    public class Vertica : BaseClass, ITestModule
    {
        public Vertica()
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
        		Steps.SelectAquaFold();
        		Steps.ClickOk();
        		Steps.UnSelectObject();
        		Steps.SelectObjectType();
        		Steps.SelectColumnName();
        		Steps.SelectViewSource();//this is not there in cassandra
        		Steps.SearchText("vertica_key");
        		Steps.SearchButton();
        		Steps.ValidateTable(0);
        		Steps.SearchText("vendor_name");
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
