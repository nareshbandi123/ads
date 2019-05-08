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
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;

namespace ADSAutomationPhaseII.TC_10543.TC4
{
    [TestModule("F5BB4021-7D58-469B-8FF4-B92134313AA6", ModuleType.UserCode, 1)]
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
        		Steps.ClickOnFileMenu();
        		Steps.ClickOnOptions();
        		Steps.ClickOnAmazonRedshift();
        		Steps.ScanForMaxResultEmpty();
        		Steps.ClickOnOptionsOk();
        		Steps.ClickOnEditorOk();
        		
        		TreeItem server = Preconditions.Steps.SelectedServerTreeItem;
        		server.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		
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
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
         }
        
    }
}
