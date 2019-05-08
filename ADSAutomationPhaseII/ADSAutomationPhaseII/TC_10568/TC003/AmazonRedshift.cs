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

namespace ADSAutomationPhaseII.TC_10568.TC003
{
    [TestModule("EDAD8AE0-6450-4198-9229-5AAC5E9242F5", ModuleType.UserCode, 1)]
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
        		Steps.ExpandDatabases_Select();
        		//Steps.SelectDatabase("ads_db", "public", "public.ads_table");
        		Steps.VerifyTabledataTab();
        		Steps.VerifyPrimaryKeyTab();
        		Steps.VerifySqlPreviewTab();
        		Steps.VerifyMessagesTab();
        		Steps.ClickOnClose();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        	}
        	
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        return true;
        }
    }
}
