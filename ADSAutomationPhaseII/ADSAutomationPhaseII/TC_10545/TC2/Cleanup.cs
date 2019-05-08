using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.TC_10538;
using ADSAutomationPhaseII.TC_10547;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10545.TC2
{
    
    [TestModule("B1B9DBD5-8177-489E-BB05-701378E15369", ModuleType.UserCode, 1)]
    public class Cleanup : Base.BaseClass, ITestModule
    {
    	
    	public static string TC_10545_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10545"].ToString();
		public static string FILENAME_TO_SAVE = "TC_10545_SAVEFILE.sql";
        
        public Cleanup()
        {
            
        }

        void ITestModule.Run()
        {
            StartProcess();
        }
        
        bool StartProcess()
        {
        	try
        	{
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
        		Preconditions.Steps.SelectedServerTreeItem = server;
        		Preconditions.Steps.SelectedServerName = server.Text;
        		server.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		server.RightClick();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        		Preconditions.Steps.CloseTab(server.Text);
        		
        		string filePath = string.Format("{0}{1}", TC_10545_PATH, FILENAME_TO_SAVE);
        		Common.DeleteFile(filePath);
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;        	
        }
    }
}
