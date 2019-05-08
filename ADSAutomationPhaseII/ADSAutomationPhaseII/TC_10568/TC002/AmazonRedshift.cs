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

namespace ADSAutomationPhaseII.TC_10568.TC002
{
    [TestModule("47E34978-4C39-4DDE-9ACA-0F76BB02C8C8", ModuleType.UserCode, 1)]
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
        		Steps.ExpandDatabases();
        		//Steps.EditTableData("ads_db", "public", "public.ads_table");
        		Steps.VerifyTabledataTab();
        		Steps.VerifyPrimaryKeyTab();
        		Steps.VerifySqlPreviewTab();
        		Steps.VerifyMessagesTab();
        		Steps.ClickOnClose();
        	}
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}
