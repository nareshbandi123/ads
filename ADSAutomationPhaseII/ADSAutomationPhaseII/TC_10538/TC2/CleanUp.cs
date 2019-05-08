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

namespace ADSAutomationPhaseII.TC_10538.TC2
{
    [TestModule("0E1E1CE7-6D9B-463E-8C09-C3269D814056", ModuleType.UserCode, 1)]
    public class CleanUp : BaseClass, ITestModule
    {
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
        		//TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
        		//Preconditions.Steps.SelectedServerTreeItem = server;
        		//Preconditions.Steps.SelectedServerName = server.Text;
        		Preconditions.Steps.SelectedServerTreeItem.RightClick();
        		Preconditions.Steps.ConnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
    			else
    				Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.DropTable();
        		Preconditions.Steps.CloseTab(Preconditions.Steps.SelectedServerName);
        		Preconditions.Steps.DisconnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        		Preconditions.Steps.CloseTab(Preconditions.Steps.SelectedServerName);
				Preconditions.Steps.isPreconditionDone = false;
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        		
        	return true;
        }

    }
}
