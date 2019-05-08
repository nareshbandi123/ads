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

namespace ADSAutomationPhaseII.TC_10542.TC3
{
    [TestModule("215A0CE1-8EFE-4329-A348-2424A718FDD0", ModuleType.UserCode, 1)]
    public class CleanUp : BaseClass, ITestModule
    {
    	public static string TC2_10542_Path = System.Configuration.ConfigurationManager.AppSettings["TC2_10542_Path"].ToString();
        public CleanUp()
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
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
        		Preconditions.Steps.SelectedServerTreeItem = server;
        		Preconditions.Steps.SelectedServerName = server.Text;
        		Common.DeleteFile(TC2_10542_Path + Preconditions.Steps.SelectedServerName + ".sql");
        		server.RightClick();
        		Preconditions.Steps.ConnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        		Preconditions.Steps.CloseTab(server.Text); 
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
