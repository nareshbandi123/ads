
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

namespace ADSAutomationPhaseII.TC_10541.TC1
{
   
    [TestModule("420DA4BE-9DE3-4F70-A31D-E3C2073D38A5", ModuleType.UserCode, 1)]
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
        		Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.QueryAnalyser();
        		if(Config.SchemaServers.Contains(server.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB);	
        		else
        			Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.DropTable();
        		Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.QueryAnalyser();
        		if(Config.SchemaServers.Contains(server.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB);	
        		else
        			Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        		Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.isPreconditionDone = false;
        	} 
        	catch (Exception) 
        	{
        		
        	}
        	return true;
         }
    }
}
