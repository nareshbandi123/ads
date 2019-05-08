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

namespace ADSAutomationPhaseII.TC_10544.TC3
{
    [TestModule("30222319-E958-4F37-9A27-88BFC763CF89", ModuleType.UserCode, 1)]
    public class CleanUp : BaseClass, ITestModule
    {
    	public static string TC1_10544_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10544_Path"].ToString();
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
        		Common.DeleteFile(TC1_10544_Path + "ADS.qbw");
        		server.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.QueryAnalyser();
        		System.Threading.Thread.Sleep(2000);
        		if(Config.SchemaServers.Contains(server.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);	
        		else
        			Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		
        		Preconditions.Steps.DropTable();
        		Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        		Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.isPreconditionDone = false;        		
        	}
        		
      	catch (Exception ex) 
        	{
      			Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
         }
    }
}
