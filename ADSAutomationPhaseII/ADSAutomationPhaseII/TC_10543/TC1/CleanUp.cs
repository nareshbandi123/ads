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
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.TC_10543.TC1
{
    [TestModule("E99D826D-2AE1-4CD4-BCE5-7E90229C895B", ModuleType.UserCode, 1)]
    public class CleanUp : BaseClass, ITestModule
    {
        public CleanUp()
        {
           
        }

        void ITestModule.Run()
        {
			if(Preconditions.Steps.isPreconditionDone)           
        		StarProcess();
        }

 		bool StarProcess()
        {
        	try 
        	{
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
        		Preconditions.Steps.SelectedServerTreeItem = server;
        		Preconditions.Steps.SelectedServerName = server.Text;
        		server.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		Preconditions.Steps.isPreconditionDone=false;
        	}
        	catch (Exception e) 
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
 		}
    }
}
